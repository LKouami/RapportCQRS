using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.TimeTable;
using RapportCQRS.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using RapportCQRS.Domain.Queries.Activity;

namespace RapportCQRS.Service.Services
{
    public class GetTimeTablesHandler : IRequestHandler<GetTimeTablesQuery, PagedResults<TimeTableDto>>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ILogger _logger;

        public GetTimeTablesHandler(ITimeTableRepository timeTableRepository, ITimeTableDxos timeTableDxos,
            ILogger<GetTimeTablesHandler> logger)
        {
            _timeTableRepository = timeTableRepository ?? throw new ArgumentNullException(nameof(timeTableRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<TimeTableDto>> Handle(GetTimeTablesQuery request, CancellationToken cancellationToken)
        {
            
                return await _timeTableRepository.GetListPageAsync(request, null);
            
            

        }
    }
}