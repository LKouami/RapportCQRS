using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;

namespace RapportCQRS.Data.IRepositories
{
    public interface IRoleRepository : IRepository<ARole, RoleDto>
    {
        Task<IEnumerable<ARole>> GetRolesFromUser(int userId);
        Task<IEnumerable<AClaim>> GetRolesClaimsFromUser(int userId);
    }
}