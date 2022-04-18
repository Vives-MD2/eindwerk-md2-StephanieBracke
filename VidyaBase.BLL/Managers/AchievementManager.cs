using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class AchievementManager : IAchievement
    {
        private readonly AchievementDB _achievementDB = new AchievementDB();

        public async Task<Achievement> CreateAsync(Achievement entity)
        {
            return await _achievementDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Achievement>> CreateRangeAsync(List<Achievement> entities)
        {
            return await _achievementDB.CreateRangeAsync(entities);
        }

        public async Task<Achievement> DeleteAsync(Achievement entity)
        {
            return await _achievementDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Achievement>> GetAsync(int skip, int take)
        {
            return await _achievementDB.GetAsync(skip, take);
        }

        public async Task<Achievement> GetByIdAsync(int id)
        {
            return await _achievementDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _achievementDB.GetTotalCountAsync();
        }

        public async Task<Achievement> UpdateAsync(Achievement entity)
        {
            return await _achievementDB.UpdateAsync(entity);
        }
    }
}
