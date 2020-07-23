using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.Activity;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.Activity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class DeleteActivityHandler : IRequestHandler<DeleteActivityCommand, DeleteResult>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMediator _mediator;

        public DeleteActivityHandler(IActivityRepository activityRepository,
            IMediator mediator)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activityModel = await _activityRepository.GetAsync(e => e.Id == request.Id);

            _activityRepository.Remove(activityModel);

            if (await _activityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new ActivityDeletedEvent(activityModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}