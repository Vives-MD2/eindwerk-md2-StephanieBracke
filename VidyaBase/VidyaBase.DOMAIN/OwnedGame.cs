using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class OwnedGame
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
    }
}
