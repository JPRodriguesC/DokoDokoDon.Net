using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doko.Get.Common;

namespace Doko.Get.Model.MyAnimeList
{
    public class MALAuthContent
    {
        public string ResponseType { get; set; } = "code";
        public string ClientId { get; set; } = string.Empty;
        public string CodeChallenge { get; set; } = Pkce.CodeChallenge;
        public string State { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;

        public MALAuthContent()
        {
            ClientId = Environment.GetEnvironmentVariable("MAL_CLIENT_ID") ?? throw new ArgumentNullException("MAL_CLIENT_ID");
        }

        public StringContent ToContent()
        {
            return new StringContent(
                $"response_type={ResponseType}&client_id={ClientId}&code_challenge={CodeChallenge}&state={State}&redirect_uri={RedirectUri}",
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );
        }
    }
}
