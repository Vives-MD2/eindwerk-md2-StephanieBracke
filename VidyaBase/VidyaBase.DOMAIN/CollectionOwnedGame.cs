using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class CollectionOwnedGame
    {
        public Game OwnedGame { get; set; }
        public Collection Collection { get; set; }
        public int CollectionID { get; set; }
        public int OwnedGamesID{ get; set; }
    }
}
