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
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, PagedResults<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public GetUsersHandler(IUserRepository userRepository, IUserDxos userDxos,
            ILogger<GetUsersHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResults<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Search))
            {
                return await _userRepository.GetListPageAsync(request, null);
            }
            else
            {
                return await _userRepository.GetListPageAsync(request,
               u =>
                   u.Email.ToLower().StartsWith(request.Search));
            }

        }
    }
}