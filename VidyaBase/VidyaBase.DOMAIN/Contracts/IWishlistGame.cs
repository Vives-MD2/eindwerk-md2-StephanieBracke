
using System.Threading.Tasks;

namespace VidyaBase.DOMAIN.Contracts
{
    public interface IWishlistGame : IGeneric<WishlistGame>
    {
        Task<WishlistGame> GetByIdAsync(int wishlistID, int gameID);
    }
}
