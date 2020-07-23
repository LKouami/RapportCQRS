using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.TimeTable;
using RapportCQRS.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class GetTimeTableHandler : IRequestHandler<GetTimeTableQuery, TimeTableDto>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ITimeTableDxos _timeTableDxos;
        private readonly ILogger _logger;

        public GetTimeTableHandler(ITimeTableRepository timeTableRepository, ITimeTableDxos timeTableDxos, ILogger<GetTimeTableHandler> logger)
        {
            _timeTableRepository = timeTableRepository ?? throw new ArgumentNullException(nameof(timeTableRepository));
            _timeTableDxos = timeTableDxos ?? throw new ArgumentNullException(nameof(timeTableDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TimeTableDto> Handle(GetTimeTableQuery request, CancellationToken cancellationToken)
        {
            var timeTable = await _timeTableRepository.GetAsync(e =>
                e.Id == request.Id);

            if (timeTable != null)
            {
                _logger.LogInformation($"Got a request get timeTable Id: {timeTable.Id}");
                var timeTableDto = _timeTableDxos.MapTimeTableDto(timeTable);
                return timeTableDto;
            }

            return null;
        }
    }
}