using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.UI.API.Contracts
{
    interface IWishlistGameApi
    {
        [Get("/ownedgame/getbyuserid?id={id}&skip={skip}&take={take}")]
        Task<string> GetByUserId(int id, int skip, int take);
    }
}
