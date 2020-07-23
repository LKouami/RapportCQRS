using RapportCQRS.Data.IRepositories;
using RapportCQRS.Domain.Queries.User;
using RapportCQRS.Domain.Dxos;
using RapportCQRS.Service.Services.Helpers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services
{
    public class LoginHandler : IRequestHandler<GetLoginQuery, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDxos _userDxos;
        private readonly ILogger _logger;
        private readonly ITokenHelper _tokenHelper;

        public LoginHandler(
            IUserRepository userRepository, 
            IUserDxos userDxos, 
            ILogger<GetUserHandler> logger,
            ITokenHelper tokenHelper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _userDxos = userDxos ?? throw new ArgumentNullException(nameof(userDxos));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tokenHelper = tokenHelper ?? throw new ArgumentNullException(nameof(tokenHelper));
        }

        public async Task<String> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Login(request.Email, request.Password);

            if (user != null)
            {
                string token = await _tokenHelper.CreateJWTAsync(user);

                return token;
            }
            else
            {
                return string.Empty; 
            }
            
        }

    }
}