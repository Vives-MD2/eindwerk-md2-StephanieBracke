using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.DOMAIN
{
    public class UserAchievement : GObject
    {
        public User User { get; set; }
        public Achievement Achievement { get; set; }
        public int UserID { get; set; }
        public int AchievementID { get; set; }
    }
}
