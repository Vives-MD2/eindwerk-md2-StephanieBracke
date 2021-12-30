using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL.Databases
{
    public class UserAchievementDB : IUserAchievement
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<UserAchievement> CreateAsync(UserAchievement entity)
        {
            _vidyaContext.UserAchievements.Add(entity);
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<UserAchievement>> CreateRangeAsync(List<UserAchievement> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i] = await CreateAsync(entities[i]);
            }
            return entities;
        }

        public async Task<UserAchievement> DeleteAsync(UserAchievement entity)
        {
            _vidyaContext.UserAchievements.Remove(_vidyaContext.UserAchievements.Single(x => x.UserID == entity.UserID&& x.AchievementID == entity.AchievementID));
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<UserAchievement>> GetAsync(int skip, int take)
        {
            return await _vidyaContext.UserAchievements.AsNoTracking().OrderBy(x => x.UserID).Skip(skip).Take(take).ToListAsync();
        }

        public Task<UserAchievement> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAchievement> GetByIdAsync(int userID, int achievementID)
        {
            return await _vidyaContext.UserAchievements.AsNoTracking().SingleOrDefaultAsync(x => x.UserID == userID && x.AchievementID == achievementID);

        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _vidyaContext.UserAchievements.CountAsync();
        }

        public async Task<UserAchievement> UpdateAsync(UserAchievement entity)
        {
            _vidyaContext.UserAchievements.Attach(entity);
            _vidyaContext.Entry<UserAchievement>(entity).State = EntityState.Modified;
            await _vidyaContext.SaveChangesAsync();
            return entity;
        }
    }
}
