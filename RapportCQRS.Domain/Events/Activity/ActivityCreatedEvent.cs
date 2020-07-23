using MediatR;
using System;

namespace RapportCQRS.Domain.Events.Activity
{
    public class ActivityCreatedEvent : INotification
    {
        public short ActivityId { get; }

        public ActivityCreatedEvent(short activityId)
        {
            ActivityId = activityId;
        }
    }
}