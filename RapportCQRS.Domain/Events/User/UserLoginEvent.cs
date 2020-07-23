using MediatR;

namespace RapportCQRS.Domain.Events.User
{
    public class UserLoginEvent : INotification
    {
        public string Username { get; }
        public string Token { get; }

        public UserLoginEvent(string username, string token)
        {
            Username = username;
            Token = token;
        }
    }
}