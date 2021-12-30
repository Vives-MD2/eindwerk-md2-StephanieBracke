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
    public class WishlistGameDB : IWishlistGame
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<WishlistGame> CreateAsync(WishlistGame entity)
        {
            _vidyaContext.WishlistGames.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<WishlistGame>> CreateRangeAsync(List<WishlistGame> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<WishlistGame> DeleteAsync(WishlistGame entity)
        {
            _vidyaContext.WishlistGames.Remove(_vidyaContext.WishlistGames.Single(x => x.WishlistID == entity.WishlistID && x.GameID== entity.GameID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<WishlistGame>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.WishlistGames.AsNoTracking().OrderBy(x => x.WishlistID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<WishlistGame> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<WishlistGame> GetByIdAsync(int wishlistID, int gameID)
        {
            return await _vidyaContext.WishlistGames.AsNoTracking().SingleOrDefaultAsync(x => x.GameID == gameID && x.WishlistID == wishlistID); 
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.WishlistGames.CountAsync();
        }

        public async Task<WishlistGame> UpdateAsync(WishlistGame entity)
        {
            _vidyaContext.WishlistGames.Attach(entity);
            _vidyaContext.Entry<WishlistGame>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
