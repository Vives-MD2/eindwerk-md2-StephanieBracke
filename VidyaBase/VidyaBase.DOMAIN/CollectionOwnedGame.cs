using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class CollectionOwnedGame : GObject
    {
        public int CollectionID { get; set; }
        public Collection Collection { get; set; }

        public int OwnedGamesID { get; set; }
        public OwnedGame OwnedGame { get; set; }

    }
}
