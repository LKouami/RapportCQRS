using RapportCQRS.Model.Dtos;

namespace RapportCQRS.Domain.Queries.User
{
    public class GetUserQuery : GetOneQuery<long, UserDto>
    {
        public GetUserQuery(long Id) : base(Id)
        {

        }

        public GetUserQuery()
        {

        }
    }
}