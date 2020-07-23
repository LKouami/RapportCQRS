using MediatR;

namespace RapportCQRS.Domain.Events.User
{
    public class UserDeletedEvent : INotification
    {
        public int UserId { get; }

        public UserDeletedEvent(int userId)
        {
            UserId = userId;
        }
    }
}