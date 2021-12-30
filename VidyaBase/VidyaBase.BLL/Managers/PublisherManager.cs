using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.DAL.Databases;
using VidyaBase.DOMAIN;
using VidyaBase.DOMAIN.Contracts;

namespace VidyaBase.BLL.Managers
{
    public class PublisherManager : IPublisher
    {
        private readonly PublisherDB _publisherDB = new PublisherDB();

        public async Task<Publisher> CreateAsync(Publisher entity)
        {
            return await _publisherDB.CreateAsync(entity);
        }

        public async Task<IEnumerable<Publisher>> CreateRangeAsync(List<Publisher> entities)
        {
            return await _publisherDB.CreateRangeAsync(entities);
        }

        public async Task<Publisher> DeleteAsync(Publisher entity)
        {
            return await _publisherDB.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Publisher>> GetAsync(int skip, int take)
        {
            return await _publisherDB.GetAsync(skip, take);
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await _publisherDB.GetByIdAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _publisherDB.GetTotalCountAsync();
        }

        public async Task<Publisher> UpdateAsync(Publisher entity)
        {
            return await _publisherDB.UpdateAsync(entity);
        }
    }
}
