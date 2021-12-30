using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class UserAchievementManager : IUserAchievement
    {
        private readonly UserAchievementDB _userAchievementDB = new UserAchievementDB();

        public async Task<UserAchievement> CreateAsync(UserAchievement entity)
        {
            return await _userAchievementDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<UserAchievement>> CreateRangeAsync(List<UserAchievement> entities)
        {
            return await _userAchievementDB.CreateRangeAsync(entities);
        }

        public async Task<UserAchievement> DeleteAsync(UserAchievement entity)
        {
            return await _userAchievementDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<UserAchievement>> GetAsync(int skip, int take)
        {
            return await _userAchievementDB.GetAsync(skip, take);
        }

        public async Task<UserAchievement> GetByIdAsync(int userID, int achievementID)
        {
            return await _userAchievementDB.GetByIdAsync(userID, achievementID);
        }

        public Task<UserAchievement> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _userAchievementDB.GetTotalCountAsync();
        }

        public async Task<UserAchievement> UpdateAsync(UserAchievement entity)
        {
            return await _userAchievementDB.UpdateAsync(entity);
        }
    }
}
