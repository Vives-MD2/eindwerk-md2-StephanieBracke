using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class WishlistDB : IWishlist
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<Wishlist> CreateAsync(Wishlist entity)
        {
            _vidyaContext.Wishlists.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Wishlist>> CreateRangeAsync(List<Wishlist> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Wishlist> DeleteAsync(Wishlist entity)
        {
            _vidyaContext.Wishlists.Remove(_vidyaContext.Wishlists.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Wishlist>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Wishlists.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Wishlist> GetByIdAsync(int id)
        {
            return await _vidyaContext.Wishlists.AsNoTracking()
            .Include(x => x.WishlistGames)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Wishlists.CountAsync();
        }

        public async Task<Wishlist> UpdateAsync(Wishlist entity)
        {
            _vidyaContext.Wishlists.Attach(entity);
            _vidyaContext.Entry<Wishlist>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
