using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebCore.App_Code
{
    public class JwtConfig : IOptions<JwtConfig>
    {
        public JwtConfig()
        {
            this.SecretKey = "d0ecd23c-dfdb-4005-a2ea-0fea210c858a";
            this.Issuer = "zhaow";
            this.Audience = "zhaow";
            this.Expired = 60;
        }
        public JwtConfig Value => this;

        public string SecretKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Expired { get; set; }

        public DateTime NotBefore => DateTime.UtcNow;

        public DateTime IssuedAt => DateTime.UtcNow;

        public DateTime Expiration => IssuedAt.AddMinutes(Expired);

        private SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public SigningCredentials SigningCredentials =>
            new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256);
    }
}
