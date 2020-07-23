using MediatR;

namespace RapportCQRS.Domain.Events.TimeTable
{
    public class TimeTableUpdatedEvent : INotification
    {
        public short TimeTableId { get; }

        public TimeTableUpdatedEvent(short timeTableId)
        {
            TimeTableId = timeTableId;
        }
    }
}