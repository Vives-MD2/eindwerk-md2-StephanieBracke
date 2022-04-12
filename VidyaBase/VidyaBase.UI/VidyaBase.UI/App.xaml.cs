using VidyaBase.UI.Pages.Project.User;
using VidyaBase.UI.Pages.Project.Vidya;
using Xamarin.Forms;

namespace VidyaBase.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ScanPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
