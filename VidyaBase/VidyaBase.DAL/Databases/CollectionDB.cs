using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class CollectionDB : ICollection
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<Collection> CreateAsync(Collection entity)
        {
            _vidyaContext.Collections.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Collection>> CreateRangeAsync(List<Collection> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Collection> DeleteAsync(Collection entity)
        {
            _vidyaContext.Collections.Remove(_vidyaContext.Collections.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Collection>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Collections.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Collection> GetByIdAsync(int id)
        {
            return await _vidyaContext.Collections.AsNoTracking()
            .Include(x => x.CollectionOwnedGames)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Collections.CountAsync();
        }

        public async Task<Collection> UpdateAsync(Collection entity)
        {
            _vidyaContext.Collections.Attach(entity);
            _vidyaContext.Entry<Collection>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
