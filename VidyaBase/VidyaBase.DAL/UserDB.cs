using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL
{
    public class UserDB : IUser
    {
        public Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
