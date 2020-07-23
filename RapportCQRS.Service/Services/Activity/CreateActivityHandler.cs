using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.Activity;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.Activity;
using RapportCQRS.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class CreateActivityHandler : IRequestHandler<CreateActivityCommand, ActivityDto>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityDxos _activityDxos;
        private readonly IMediator _mediator;

        public CreateActivityHandler(IActivityRepository activityRepository,
            IMediator mediator,
            IActivityDxos activityDxos)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _activityDxos = activityDxos ?? throw new ArgumentNullException(nameof(activityDxos));
        }


        public async Task<ActivityDto> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activityModel = _activityDxos.MapCreateRequesttoActivity(request);

            _activityRepository.Add(activityModel);

            if (await _activityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new ActivityCreatedEvent(activityModel.Id), cancellationToken);

            var activityDto = _activityDxos.MapActivityDto(activityModel);

            return activityDto;
        }
    }
}