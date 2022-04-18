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
    public class GameCategoryDB : IGameCategory
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<GameCategory> CreateAsync(GameCategory entity)
        {
            _vidyaContext.GameCategories.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<GameCategory>> CreateRangeAsync(List<GameCategory> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<GameCategory> DeleteAsync(GameCategory entity)
        {
            _vidyaContext.GameCategories.Remove(_vidyaContext.GameCategories.Single(x => x.GameID == entity.GameID && x.CategoryID== entity.CategoryID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<GameCategory>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.GameCategories.AsNoTracking().OrderBy(x => x.CategoryID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<GameCategory> GetByIdAsync(int gameID, int categoryID)
        {
            return await _vidyaContext.GameCategories.AsNoTracking().SingleOrDefaultAsync(x => x.GameID == gameID && x.CategoryID == categoryID);
        }

        public Task<GameCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Categories.CountAsync();
        }

        public async Task<GameCategory> UpdateAsync(GameCategory entity)
        {
            _vidyaContext.GameCategories.Attach(entity);
            _vidyaContext.Entry<GameCategory>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
