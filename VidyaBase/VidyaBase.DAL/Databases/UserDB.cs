using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.DAL
{
    public class UserDB : IUser
    {
        private readonly VidyaContext _vidyaContext = new VidyaContext();
        public async Task<User> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> CreateRangeAsync(List<User> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<User> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
