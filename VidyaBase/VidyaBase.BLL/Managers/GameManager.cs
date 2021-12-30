using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class GameManager : IGame
    {
        private readonly GameDB _gameDB = new GameDB();

        public async Task<Game> CreateAsync(Game entity)
        {
            return await _gameDB.CreateAsync(entity);
        }

        public async  Task<IEnumerable<Game>> CreateRangeAsync(List<Game> entities)
        {
            return await _gameDB.CreateRangeAsync(entities);
        }

        public async Task<Game> DeleteAsync(Game entity)
        {
            return await _gameDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Game>> GetAsync(int skip, int take)
        {
            return await _gameDB.GetAsync(skip, take);
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _gameDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _gameDB.GetTotalCountAsync();
        }

        public async Task<Game> UpdateAsync(Game entity)
        {
            return await _gameDB.UpdateAsync(entity);
        }
    }
}
