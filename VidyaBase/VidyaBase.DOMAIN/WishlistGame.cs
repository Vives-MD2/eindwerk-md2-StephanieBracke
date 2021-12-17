using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class WishlistGame
    {
        public Game Game { get; set; }
        public Wishlist Wishlist { get; set; }
        public int WishlistID { get; set; }
        public int GameID { get; set; }
    }
}
