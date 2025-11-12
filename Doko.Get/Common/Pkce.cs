using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Doko.Get.Model.Static;
using Microsoft.IdentityModel.Tokens;

namespace Doko.Get.Common
{
    public static class Pkce
    {
        public static string CodeChallenge { 
            get {
                return GetCodeChallenge(GetCodeVerifier());
            } 
        }

        public static string GetCodeVerifier(uint size = 128)
        {
            Random random = new();
            
            var pool = CommonStaticData.PkceBoundCaracters.Length;
            var entropy = new char[size];
            while (size-- > 0)
            {
                entropy[size] = CommonStaticData.PkceBoundCaracters[random.Next(pool)];
            }

            return new string(entropy);
        }

        public static string GetCodeChallenge(string codeVerifier)
        {
            var challengeBytes = SHA256.HashData(Encoding.UTF8.GetBytes(codeVerifier));
            return Base64UrlEncoder.Encode(challengeBytes);
        }
    }
}