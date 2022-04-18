namespace VidyaBase.UI.HelperModels
{
    public class GameHelper
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string EAN { get; set; }

        public string DisplayName => $"{Title} - {EAN}";
    }
}
