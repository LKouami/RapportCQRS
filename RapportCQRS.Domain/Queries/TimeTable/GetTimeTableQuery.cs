using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Queries.TimeTable
{
    public class GetTimeTableQuery : GetOneQuery<long, TimeTableDto>
    {
        public GetTimeTableQuery(long Id) : base(Id)
        {

        }
    }
}