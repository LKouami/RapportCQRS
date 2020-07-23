using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.TimeTable;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.TimeTable;
using RapportCQRS.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class CreateTimeTableHandler : IRequestHandler<CreateTimeTableCommand, TimeTableDto>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ITimeTableDxos _timeTableDxos;
        private readonly IMediator _mediator;

        public CreateTimeTableHandler(ITimeTableRepository timeTableRepository,
            IMediator mediator,
            ITimeTableDxos timeTableDxos)
        {
            _timeTableRepository = timeTableRepository ?? throw new ArgumentNullException(nameof(timeTableRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _timeTableDxos = timeTableDxos ?? throw new ArgumentNullException(nameof(timeTableDxos));
        }


        public async Task<TimeTableDto> Handle(CreateTimeTableCommand request, CancellationToken cancellationToken)
        {
            var timeTableModel = _timeTableDxos.MapCreateRequesttoTimeTable(request);

            _timeTableRepository.Add(timeTableModel);

            if (await _timeTableRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new TimeTableCreatedEvent(timeTableModel.Id), cancellationToken);

            var timeTableDto = _timeTableDxos.MapTimeTableDto(timeTableModel);

            return timeTableDto;
        }
    }
}