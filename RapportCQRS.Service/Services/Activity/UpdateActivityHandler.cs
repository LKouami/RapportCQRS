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
    public class UpdateActivityHandler : IRequestHandler<UpdateActivityCommand, ActivityDto>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityDxos _activityDxos;
        private readonly IMediator _mediator;

        public UpdateActivityHandler(IActivityRepository activityRepository,
            IMediator mediator,
            IActivityDxos activityDxos)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _activityDxos = activityDxos ?? throw new ArgumentNullException(nameof(activityDxos));
        }


        public async Task<ActivityDto> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activityModel = _activityDxos.MapUpdateRequesttoActivity(request);

            _activityRepository.Update(activityModel);

            if (await _activityRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Update in database failed");
            }

            await _mediator.Publish(new ActivityUpdatedEvent(activityModel.Id), cancellationToken);

            var activityDto = _activityDxos.MapActivityDto(activityModel);

            return activityDto;
        }
    }
}