using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class Achievement : GObject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<UserAchievement> UserAchievements { get; set; }
    }
}
