using MediatR;

namespace RapportCQRS.Domain.Events.User
{
    public class UserUpdatedEvent : INotification
    {
        public int UserId { get; }

        public UserUpdatedEvent(int userId)
        {
            UserId = userId;
        }
    }
}