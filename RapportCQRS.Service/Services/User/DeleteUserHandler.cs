using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.User;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public DeleteUserHandler(IUserRepository userRepository,
            IMediator mediator)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<DeleteResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(e => e.Id == request.Id);

            _userRepository.Remove(user);

            if (await _userRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Deletion failed");
            }

            await _mediator.Publish(new UserDeletedEvent(user.Id), cancellationToken);

            return new DeleteResult(true);
        }
    }
}