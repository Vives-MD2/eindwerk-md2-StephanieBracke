using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<GameCategory> GameCategories { get; set; }
    }
}
