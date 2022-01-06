using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    public class AchievementsPageFlyoutMenuItem
    {
        public AchievementsPageFlyoutMenuItem()
        {
            TargetType = typeof(AchievementsPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}