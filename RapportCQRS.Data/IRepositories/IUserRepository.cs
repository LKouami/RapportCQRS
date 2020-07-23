using System.Collections.Generic;
using System.Threading.Tasks;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;

namespace RapportCQRS.Data.IRepositories
{
    public interface IUserRepository : IRepository<AUser, UserDto>
    {
        Task<AUser> Login(string email, string password);
        Task<bool> EmailExistAsync(string email);

        Task<IEnumerable<AClaim>> GetClaimsFromUser(int userId);

    }
}