using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class GameCategory
    {
        public Game GameCat { get; set; }
        public Category Category { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }
    }
}
