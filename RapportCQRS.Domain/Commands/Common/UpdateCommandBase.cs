using MediatR;
using System;

namespace RapportCQRS.Domain.Commands
{
    public class UpdateCommandBase<T> : IRequest<T> where T : class
    {
        public UpdateCommandBase()
        {

        }
        public UpdateCommandBase(int modifiedBy, DateTime modifiedAt)
        {
            ModifiedBy = modifiedBy;
            ModifiedAt = modifiedAt;
        }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}