using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Publisher
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<GamePublisher> GamePublishers { get; set; }
    }
}
