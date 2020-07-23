using MediatR;
using System;

namespace RapportCQRS.Domain.Events.User
{
    public class UserCreatedEvent : INotification
    {
        public Int64 UserId { get; }

        public UserCreatedEvent(Int64 employeeId)
        {
            UserId = employeeId;
        }
    }
}