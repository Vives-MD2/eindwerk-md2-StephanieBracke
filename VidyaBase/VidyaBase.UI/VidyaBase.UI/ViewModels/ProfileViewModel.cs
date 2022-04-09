using System.Diagnostics;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.HelperModels;
using VidyaBase.UI.Pages.Project.User;
using VidyaBase.UI.Pages.Project.Vidya;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        private UserHelper _currentUser = new UserHelper();

        public ICommand ScanCommand { protected set; get; }
        public ICommand EditCommand { protected set; get; }
        public ICommand ListCommand { protected set; get; }

        public UserHelper CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set => SetValue(ref _currentUser, value);
        }

        public ProfileViewModel()
        {

            ScanCommand = new Command(OnScan);
            EditCommand = new Command(OnEdit);
            ListCommand = new Command(OnList);
        }

        public ProfileViewModel(UserHelper user)
        {
            _currentUser = user;

            ScanCommand = new Command(OnScan);
            EditCommand = new Command(OnEdit);
            ListCommand = new Command(OnList);
        }

        public async void OnScan()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ScanPage());
        }

        public async void OnEdit()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new EditPage());
        }

        public async void OnList()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ListPage());
        }
    }
}
