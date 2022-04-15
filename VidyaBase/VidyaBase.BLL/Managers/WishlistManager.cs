using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class WishlistManager : IWishlist
    {
        private readonly WishlistDB _wishlistDB = new WishlistDB();

        public async Task<Wishlist> CreateAsync(Wishlist entity)
        {
            return await _wishlistDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Wishlist>> CreateRangeAsync(List<Wishlist> entities)
        {
            return await _wishlistDB.CreateRangeAsync(entities);
        }

        public async Task<Wishlist> DeleteAsync(Wishlist entity)
        {
            return await _wishlistDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Wishlist>> GetAsync(int skip, int take)
        {
            return await _wishlistDB.GetAsync(skip, take);
        }

        public async Task<Wishlist> GetByIdAsync(int id)
        {
            return await _wishlistDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _wishlistDB.GetTotalCountAsync();
        }

        public async Task<Wishlist> UpdateAsync(Wishlist entity)
        {
            return await _wishlistDB.UpdateAsync(entity);
        }
    }
}
