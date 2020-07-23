using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Queries.Activity
{
    public class GetActivityQuery : GetOneQuery<long, ActivityDto>
    {
        public GetActivityQuery(long Id) : base(Id)
        {

        }
    }
}