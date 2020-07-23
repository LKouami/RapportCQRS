using RapportCQRS.Model.Models;
using System.Threading.Tasks;

namespace RapportCQRS.Service.Services.Helpers
{
    public interface ITokenHelper
    {
        Task<string> CreateJWTAsync(AUser user);

    }

}
