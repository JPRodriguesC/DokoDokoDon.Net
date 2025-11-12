using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doko.Get.Model.MyAnimeList
{
    public record MALToken(
        string access_token,
        string token_type,
        int expires_in,
        string scope,
        string refresh_token
    );
}