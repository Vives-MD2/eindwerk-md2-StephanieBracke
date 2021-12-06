using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Game : GObject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int EAN { get; set; }
    }
}
