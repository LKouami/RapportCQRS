using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.Activity;
using RapportCQRS.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class GetActivityHandler : IRequestHandler<GetActivityQuery, ActivityDto>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityDxos _activityDxos;
        private readonly ILogger _logger;

        public GetActivityHandler(IActivityRepository activityRepository, IActivityDxos activityDxos, ILogger<GetActivityHandler> logger)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _activityDxos = activityDxos ?? throw new ArgumentNullException(nameof(activityDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ActivityDto> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetAsync(e =>
                e.Id == request.Id);

            if (activity != null)
            {
                _logger.LogInformation($"Got a request get activity Id: {activity.Id}");
                var activityDto = _activityDxos.MapActivityDto(activity);
                return activityDto;
            }

            return null;
        }
    }
}