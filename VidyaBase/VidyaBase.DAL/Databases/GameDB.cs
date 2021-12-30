using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL
{
    public class GameDB : IGame
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<Game> CreateAsync(Game entity)
        {
            _vidyaContext.Games.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Game>> CreateRangeAsync(List<Game> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Game> DeleteAsync(Game entity)
        {
            _vidyaContext.Games.Remove(_vidyaContext.Games.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Game>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Games.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _vidyaContext.Games.AsNoTracking()
            .Include(x => x.GameCategories)
            .Include(x => x.GamePublishers)
            .Include(x => x.WishlistGames)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Games.CountAsync();
        }

        public async Task<Game> UpdateAsync(Game entity)
        {
            _vidyaContext.Games.Attach(entity);
            _vidyaContext.Entry<Game>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
