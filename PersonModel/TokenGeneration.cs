
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using TimeSheet.BusinessLogic.DAL.Entity;
using TimeSheet.DB.DAL.Entity;

namespace TimeSheet.BusinessLogic
{
    internal static class TokenGeneration
    {
        private const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";

        public static TokenModel Authenticate(DB.DAL.Entity.UserAccessData userData)
        {
            var newTokenModel = new TokenModel
            {
                AccessToken = GenerateJwtToken(userData.Id),
                RefreshToken = GenerateJwtToken(userData.Id, 15)
            };

            return newTokenModel;
        }

        private static string GenerateJwtToken(int id, int lifetime = 1)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(SecretCode);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(lifetime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        internal static string RefreshToken(string token)
        {

            return null;
        }
    }
}
