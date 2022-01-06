using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    public class ListPageFlyoutMenuItem
    {
        public ListPageFlyoutMenuItem()
        {
            TargetType = typeof(ListPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}