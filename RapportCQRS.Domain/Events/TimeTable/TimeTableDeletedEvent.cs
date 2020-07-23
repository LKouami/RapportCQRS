using MediatR;

namespace RapportCQRS.Domain.Events.TimeTable
{
    public class TimeTableDeletedEvent : INotification
    {
        public short TimeTableId { get; }

        public TimeTableDeletedEvent(short timeTableId)
        {
            TimeTableId = timeTableId;
        }
    }
}