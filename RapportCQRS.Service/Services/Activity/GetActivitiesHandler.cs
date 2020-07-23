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
    public class GetActivitiesHandler : IRequestHandler<GetActivitiesQuery, PagedResults<ActivityDto>>
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ILogger _logger;

        public GetActivitiesHandler(IActivityRepository activityRepository, IActivityDxos activityDxos,
            ILogger<GetActivitiesHandler> logger)
        {
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<ActivityDto>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrWhiteSpace(request.Search))
            {
                return await _activityRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _activityRepository.GetListPageAsync(request,
               p =>
                   p.ContenuAct.ToLower().StartsWith(request.Search));
            }

        }
    }
}