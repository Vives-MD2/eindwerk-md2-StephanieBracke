using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class GamePublisherManager : IGamePublisher
    {
        private readonly GamePublisherDB _gamePublisherDB = new GamePublisherDB();

        public async Task<GamePublisher> CreateAsync(GamePublisher entity)
        {
            return await _gamePublisherDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<GamePublisher>> CreateRangeAsync(List<GamePublisher> entities)
        {
            return await _gamePublisherDB.CreateRangeAsync(entities);
        }

        public async Task<GamePublisher> DeleteAsync(GamePublisher entity)
        {
            return await _gamePublisherDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<GamePublisher>> GetAsync(int skip, int take)
        {
            return await _gamePublisherDB.GetAsync(skip, take);
        }

        public async Task<GamePublisher> GetByIdAsync(int gameID, int publisherID)
        {
            return await _gamePublisherDB.GetByIdAsync(id);
        }

        public Task<GamePublisher> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _gamePublisherDB.GetTotalCountAsync();
        }

        public async Task<GamePublisher> UpdateAsync(GamePublisher entity)
        {
            return await _gamePublisherDB.UpdateAsync(entity);
        }
    }
}
