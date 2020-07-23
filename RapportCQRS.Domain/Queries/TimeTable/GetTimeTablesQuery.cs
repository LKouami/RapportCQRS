using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Queries.Activity
{
    public class GetTimeTablesQuery : QueryListBase<PagedResults<TimeTableDto>>
    {
        public GetTimeTablesQuery() : base()
        {

        }
        public GetTimeTablesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}