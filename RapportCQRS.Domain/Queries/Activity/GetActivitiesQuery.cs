using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Queries.Activity
{
    public class GetActivitiesQuery : QueryListBase<PagedResults<ActivityDto>>
    {
        public GetActivitiesQuery() : base()
        {

        }
        public GetActivitiesQuery(string search, string sort, string direction, int pageIndex, int pageSize) :
            base(search, sort, direction, pageIndex, pageSize)
        {

        }
    }
}