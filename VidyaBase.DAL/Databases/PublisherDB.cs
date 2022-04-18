using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class PublisherDB : IPublisher
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<Publisher> CreateAsync(Publisher entity)
        {
            _vidyaContext.Publishers.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Publisher>> CreateRangeAsync(List<Publisher> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<Publisher> DeleteAsync(Publisher entity)
        {
            _vidyaContext.Publishers.Remove(_vidyaContext.Publishers.Single(x => x.ID == entity.ID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Publisher>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.Publishers.AsNoTracking().OrderBy(x => x.ID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _vidyaContext.Publishers.AsNoTracking()
            .Include(x => x.GamePublishers)
            .SingleOrDefaultAsync(x => x.ID == id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.Publishers.CountAsync();
        }

        public async Task<Publisher> UpdateAsync(Publisher entity)
        {
            _vidyaContext.Publishers.Attach(entity);
            _vidyaContext.Entry<Publisher>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
