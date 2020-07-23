using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries.User;
using RapportCQRS.Domain.Dxos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDxos _userDxos;
        private readonly ILogger _logger;

        public GetUserHandler(IUserRepository userRepository, IUserDxos userDxos, ILogger<GetUserHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userDxos = userDxos ?? throw new ArgumentNullException(nameof(userDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(e =>
                e.Id == request.Id);

            if (user != null)
            {
                _logger.LogInformation($"Got a request get user Id: {user.Id}");
                var userDto = _userDxos.MapUserDto(user);
                return userDto;
            }

            return null;
        }
    }
}