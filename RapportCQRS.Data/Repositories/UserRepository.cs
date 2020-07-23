using AutoMapper;
using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos;

namespace RapportCQRS.Data.Repositories
{
    public class UserRepository : Repository<AUser, UserDto, IUserDxos>, IUserRepository
    {
        public DbSet<AUser> Users;

        public UserRepository(RapportCQRSDbContext dbContext,
            ILogger<UserRepository> logger,
            IUserDxos dxos) : base(dbContext, logger, dxos)
        {
            Users = _dbContext.Set<AUser>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AUser, UserDto>()
                  .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email.ToLower().Equals(email.ToLower()));

        }

        public async Task<IEnumerable<AUser>> GetClaimsFromUser(int Id)
        {
            return await Users.AsNoTracking().ToListAsync();
        }

        public async Task<AUser> Login(string email, string password)
        {
            AUser user = await
                ModelDbSets.AsNoTracking()
                .SingleOrDefaultAsync
                (
                    e => e.Email.ToLower().Equals(email.ToLower())
                );
            if (user == null)
            {
                return null;
            }
            else
            {
                //If user exists check password
                // TODO : Send this to a service
                if (user.Password == password)
                {
                    return user;
                }
                else
                {
                    return null;
                };
            }

        }

        Task<IEnumerable<AClaim>> IUserRepository.GetClaimsFromUser(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}