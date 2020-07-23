using RapportCQRS.Data.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RapportCQRS.Model.Models;

namespace RapportCQRS.Service.Services.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly string issuer = "https://sipconsult.net";
        private readonly string authority = "https://sipconsult.net";

        //256-bit string generated on https://passwordsgenerator.net/
        private readonly string privateKey = "J6k2eVCTXDp5b97u6gNH5GaaqHDxCmzz2wv3PRPFRsuW2UavK8LGPRauC4VSeaetKTMtVmVzAC8fh8Psvp8PFybEvpYnULHfRpM8TA2an7GFehrLLvawVJdSRqh2unCnWehhh2SJMMg5bktRRapA8EGSgQUV8TCafqdSEHNWnGXTjjsMEjUpaxcADDNZLSYPMyPSfp6qe5LMcd5S9bXH97KeeMGyZTS2U8gp3LGk2kH4J4F3fsytfpe9H9qKwgjb";

        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        int daysValid = 7;

        public TokenHelper(IConfiguration configuration,
            IUserRepository userRepository
            , IRoleRepository roleRepository)
        {
            //this.configuration = configuration;

            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<string> CreateJWTAsync(AUser user
                                                       )
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = await CreateClaimsIdentitiesAsync(user);

            // Create JWToken
            var token = tokenHandler.CreateJwtSecurityToken(issuer: issuer,
                audience: authority,
                subject: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(daysValid),
                signingCredentials:
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.Default.GetBytes(privateKey)),
                        SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }


        private async Task<ClaimsIdentity> CreateClaimsIdentitiesAsync(AUser user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            // TODO : Add claim from Employee table

            //claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.FullName ?? $"{user.FirstName} {user.LastName}"));
            //claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userData)));


            // Add roles
            var roles = await roleRepository.GetRolesFromUser(user.Id);

            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            //Add claims linked to those roles
            var rolesClaims = await roleRepository.GetRolesClaimsFromUser(user.Id);

            foreach (var claim in rolesClaims)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, claim.Name));
            }

            //Add claims linked to the individual user
            var userClaims = await userRepository.GetClaimsFromUser(user.Id);

            foreach (var claim in userClaims)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, claim.Name));
            }

            return claimsIdentity;
        }
    }

}
