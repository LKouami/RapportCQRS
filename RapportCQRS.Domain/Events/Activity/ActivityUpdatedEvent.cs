using MediatR;

namespace RapportCQRS.Domain.Events.Activity
{
    public class ActivityUpdatedEvent : INotification
    {
        public short ActivityId { get; }

        public ActivityUpdatedEvent(short activityId)
        {
            ActivityId = activityId;
        }
    }
}