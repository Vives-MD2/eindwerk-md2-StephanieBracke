using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class CategoryDB : ICategory
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<Category> CreateAsync(Category entity)
        {
            _vidyaContext.Categories.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Category>> CreateRangeAsync(List<Category> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            _vidyaContext.Categories.Remove(_vidyaContext.Categories.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Category>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Categories.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _vidyaContext.Categories.AsNoTracking()
            .Include(x => x.GameCategories)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Categories.CountAsync();
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _vidyaContext.Categories.Attach(entity);
            _vidyaContext.Entry<Category>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
