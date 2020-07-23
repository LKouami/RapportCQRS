using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Commands.User;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Events.User;
using RapportCQRS.Domain.Dxos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDxos _userDxos;
        private readonly IMediator _mediator;

        public CreateUserHandler(IUserRepository userRepository,
            IMediator mediator,
            IUserDxos userDxos)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userDxos = userDxos ?? throw new ArgumentNullException(nameof(userDxos));
        }


        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.EmailExistAsync(request.Email))
            {
                throw new ArgumentException($"A user with the email {request.Email} already exist!", nameof(request.Email));
            }

            var user = _userDxos.MapCreateRequesttoUser(request);

            _userRepository.Add(user);

            if (await _userRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException("Insertion to database failed");
            }

            await _mediator.Publish(new UserCreatedEvent(user.Id), cancellationToken);

            var userDto = _userDxos.MapUserDto(user);

            return userDto;
        }
    }
}