using MediatR;

namespace RapportCQRS.Domain.Events.Activity
{
    public class ActivityDeletedEvent : INotification
    {
        public short ActivityId { get; }

        public ActivityDeletedEvent(short activityId)
        {
            ActivityId = activityId;
        }
    }
}