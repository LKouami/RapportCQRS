using RapportCQRS.Model.Dtos;
using System;

namespace RapportCQRS.Domain.Queries.User
{
  
        public class GetLoginQuery : QueryBase<String>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetLoginQuery()
        {

        }
        public GetLoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}