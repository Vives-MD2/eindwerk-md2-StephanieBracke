using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaBase.UI.HelperModels
{
    public class OwnedGameHelper
    {
        public UserHelper User { get; set; }
        public GameHelper Game { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
    }

    public class GameHelper
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string EAN { get; set; }

        public string DisplayName => $"{Title} - {EAN}";
    }
}
