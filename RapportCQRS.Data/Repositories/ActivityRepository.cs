using AutoMapper;
using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos;

namespace RapportCQRS.Data.Repositories
{
    public class ActivityRepository : Repository<SActivity, ActivityDto, IActivityDxos>, IActivityRepository
    {
        public ActivityRepository(RapportCQRSDbContext dbContext,
           ILogger<ActivityRepository> logger,
           IActivityDxos activityDxos) : base(dbContext, logger, activityDxos)
        {
            //Code removed here
        }

        public async Task<bool> UserIdExistAsync(string userId)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.UserId.Equals(userId));
        }
    }
}
