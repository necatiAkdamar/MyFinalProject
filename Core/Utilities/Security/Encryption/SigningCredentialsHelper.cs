using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper//Jason Web Token jwt için giriş bilgilerini tanımlıyoruz
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);//webapi tarafı için hangi anahtar ve hangi algoritmayı kullanacağını belirtiyoruz.
        }
    }
}
