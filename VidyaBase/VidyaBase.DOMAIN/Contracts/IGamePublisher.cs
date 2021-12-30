
using System.Threading.Tasks;

namespace VidyaBase.DOMAIN.Contracts
{
    public interface IGamePublisher : IGeneric<GamePublisher>
    {
        Task<GamePublisher> GetByIdAsync(int gameID, int publisherID);
    }
}
