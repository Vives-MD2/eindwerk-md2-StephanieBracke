using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class GamePublisherDB : IGamePublisher
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();

        public async Task<GamePublisher> CreateAsync(GamePublisher entity)
        {
            _vidyaContext.GamePublishers.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<GamePublisher>> CreateRangeAsync(List<GamePublisher> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<GamePublisher> DeleteAsync(GamePublisher entity)
        {
            _vidyaContext.GamePublishers.Remove(_vidyaContext.GamePublishers.Single(x => x.PublisherID == entity.PublisherID && x.GameID == entity.GameID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<GamePublisher>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.GamePublishers.AsNoTracking().OrderBy(x => x.GameID).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<GamePublisher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GamePublisher> GetByIdAsync(int gameID, int publisherID)
        {
            return await _vidyaContext.GamePublishers.AsNoTracking().SingleOrDefaultAsync(x => x.GameID == gameID && x.PublisherID == publisherID);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.GamePublishers.CountAsync();
        }

        public async Task<GamePublisher> UpdateAsync(GamePublisher entity)
        {
            _vidyaContext.GamePublishers.Attach(entity);
            _vidyaContext.Entry<GamePublisher>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
