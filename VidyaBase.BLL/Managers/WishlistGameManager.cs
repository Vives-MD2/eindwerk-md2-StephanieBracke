using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class WishlistGameManager : IWishlistGame
    {
        private readonly WishlistGameDB _wishlistGameDB = new WishlistGameDB();

        public async Task<WishlistGame> CreateAsync(WishlistGame entity)
        {
            return await _wishlistGameDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<WishlistGame>> CreateRangeAsync(List<WishlistGame> entities)
        {
            return await _wishlistGameDB.CreateRangeAsync(entities);
        }

        public async Task<WishlistGame> DeleteAsync(WishlistGame entity)
        {
            return await _wishlistGameDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<WishlistGame>> GetAsync(int skip, int take)
        {
            return await _wishlistGameDB.GetAsync(skip, take);
        }

        public async Task<WishlistGame> GetByIdAsync(int wishlistID, int gameID)
        {
            return await _wishlistGameDB.GetByIdAsync(wishlistID, gameID);
        }

        public Task<WishlistGame> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _wishlistGameDB.GetTotalCountAsync();
        }

        public async Task<WishlistGame> UpdateAsync(WishlistGame entity)
        {
            return await _wishlistGameDB .UpdateAsync(entity);
        }
    }
}
