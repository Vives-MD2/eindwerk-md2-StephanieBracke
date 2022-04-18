using System.Threading.Tasks;

namespace VidyaBase.DOMAIN.Contracts

{
    public interface ICollectionOwnedGame : IGeneric<CollectionOwnedGame>
    {
        Task<CollectionOwnedGame> GetByIdAsync(int collectionID, int ownedGameID);
    }
}
