using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doko.Get.Model.MyAnimeList;

namespace Doko.Get.Interface
{
    public interface IApiToken
    {
        MALToken? TokenInfo { get; set; }
        bool HasToken();
    }
}