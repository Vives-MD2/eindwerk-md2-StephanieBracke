using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Game : GObject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string EAN { get; set; }

        public ICollection<CollectionOwnedGame> OwnedGamesCollection { get; set; }
        public ICollection<WishlistGame> WishlistGames { get; set; }
        public ICollection<GameCategory> GameCategories { get; set; }
        public ICollection<GamePublisher> GamePublishers { get; set; }
        public ICollection<OwnedGame> OwnedGames { get; set; }
    }
}
