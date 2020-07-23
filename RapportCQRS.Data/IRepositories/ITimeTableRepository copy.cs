using RapportCQRS.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using RapportCQRS.Model.Models;

namespace RapportCQRS.Data.IRepositories
{
    public interface ITimeTableRepository : IRepository<STimeTable, TimeTableDto>
    {
        
    }
}