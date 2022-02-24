using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeSheet.API.DAL.Entity;
using TimeSheet.API.Mapping;
using TimeSheet.BusinessLogic;
using TimeSheet.DB.DAL.Interface.RepositoryInterface;

namespace TimeSheet.API
{
    internal sealed class UserService
    {
        private readonly UserAccessLogic _userAccessLogic;
        private readonly IUserAccessRepository _userAccessRepository;
        private readonly CancellationTokenSource token;

        public UserService(UserAccessLogic userAccessLogic, IUserAccessRepository userAccessRepository)
        {
            _userAccessLogic = userAccessLogic;
            _userAccessRepository = userAccessRepository;
            token.CancelAfter(10000);
        }

        private const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";

        public async Task<string> Authenticate(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            var userAccessData = new UserAccessData
            {
                UserLogin = user,
                UserPass = password
            };

            var blUserAccessData = UserAccessMapping.MappingFromAPIUserAccessModel(userAccessData);
            
            var result = await _userAccessLogic.FindUserAccessAsync(token.Token, blUserAccessData);

            if (result < 0)
            {
                return string.Empty;
            }

            return GenerateJwtToken(result);
        }

        private string GenerateJwtToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SecretCode);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        private string GenerateJwtToken(int id, int lifeTime)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SecretCode);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(lifeTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
