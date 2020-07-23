using MediatR;

namespace RapportCQRS.Domain.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
}

