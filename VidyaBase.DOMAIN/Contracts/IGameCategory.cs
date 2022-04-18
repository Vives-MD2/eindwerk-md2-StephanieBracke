
using System.Threading.Tasks;

namespace VidyaBase.DOMAIN.Contracts
{
    public interface IGameCategory : IGeneric<GameCategory>
    {
        Task<GameCategory> GetByIdAsync(int gameID, int categoryID);
    }
}
