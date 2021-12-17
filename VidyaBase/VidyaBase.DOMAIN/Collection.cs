using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Collection : GObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }

        public ICollection<CollectionOwnedGame> OwnedGames { get; set; }
    }
}
