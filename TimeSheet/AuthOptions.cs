using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TimeSheet.API
{
    public class AuthOptions
    {
        public const string ISSUER = "TimeSheetApiLayer";
        public const string AUDIENCE = "TimeSheetApi";
        private const string KEY = "mysupersecret_secretkey!123";
        public readonly int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public AuthOptions(int keyLifetime)
        {
            LIFETIME = keyLifetime;
        }
    }
}
