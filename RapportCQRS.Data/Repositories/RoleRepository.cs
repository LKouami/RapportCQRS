using AutoMapper;
using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using RapportCQRS.Domain.Dxos;

namespace RapportCQRS.Data.Repositories
{
    public class RoleRepository : Repository<ARole, RoleDto, IRoleDxos>, IRoleRepository
    {
        public DbSet<AClaim> Claims;

        public RoleRepository(RapportCQRSDbContext dbContext,
            ILogger<RoleRepository> logger,
            IRoleDxos dxos) : base(dbContext, logger, dxos)
        {
            Claims = _dbContext.Set<AClaim>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ARole, RoleDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            });

            _mapper = config.CreateMapper();
        }

        public async Task<IEnumerable<AClaim>> GetRolesClaimsFromUser(int userId)
        {
            return await Claims.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ARole>> GetRolesFromUser(int userId)
        {
            return await ModelDbSets.AsNoTracking().ToListAsync();
        }
    }
}