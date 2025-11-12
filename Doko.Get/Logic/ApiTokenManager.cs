using Doko.Get.Interface;
using Doko.Get.Model.MyAnimeList;

namespace Doko.Get.Logic
{
    public class ApiTokenManager : IApiToken
    {
        public MALToken? TokenInfo { get; set; }

        public ApiTokenManager()
        {
            TokenInfo = null;
        }

        public bool HasToken()
            => TokenInfo is not null;
    }
}