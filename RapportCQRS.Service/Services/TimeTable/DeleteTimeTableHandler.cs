using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.TimeTable;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.TimeTable;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class DeleteTimeTableHandler : IRequestHandler<DeleteTimeTableCommand, DeleteResult>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly IMediator _mediator;

        public DeleteTimeTableHandler(ITimeTableRepository timeTableRepository,
            IMediator mediator)
        {
            _timeTableRepository = timeTableRepository ?? throw new ArgumentNullException(nameof(timeTableRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteTimeTableCommand request, CancellationToken cancellationToken)
        {
            var timeTableModel = await _timeTableRepository.GetAsync(e => e.Id == request.Id);

            _timeTableRepository.Remove(timeTableModel);

            if (await _timeTableRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new TimeTableDeletedEvent(timeTableModel.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}