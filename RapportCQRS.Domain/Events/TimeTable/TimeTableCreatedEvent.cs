using MediatR;
using System;

namespace RapportCQRS.Domain.Events.TimeTable
{
    public class TimeTableCreatedEvent : INotification
    {
        public short TimeTableId { get; }

        public TimeTableCreatedEvent(short timeTableId)
        {
            TimeTableId = timeTableId;
        }
    }
}