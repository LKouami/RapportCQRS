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
    public class TimeTableRepository : Repository<STimeTable, TimeTableDto, ITimeTableDxos>, ITimeTableRepository
    {
        public TimeTableRepository(RapportCQRSDbContext dbContext,
           ILogger<TimeTableRepository> logger,
           ITimeTableDxos bankDxos) : base(dbContext, logger, bankDxos)
        {
            //Code removed here
        }

        
    }
}
