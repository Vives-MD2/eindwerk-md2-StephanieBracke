using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class GamePublisher
    {
        public Game Game { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherID { get; set; }
        public int GameID { get; set; }
    }
}
