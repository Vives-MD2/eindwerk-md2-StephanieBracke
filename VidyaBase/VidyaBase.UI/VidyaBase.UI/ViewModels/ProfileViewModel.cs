using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.HelperModels;
using VidyaBase.UI.Pages.Project.User;
using VidyaBase.UI.Pages.Project.Vidya;
using Xamarin.Forms;
using Xamarin.Essentials;
using System;

namespace VidyaBase.UI.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        private UserHelper _currentUser = new UserHelper();

        public ICommand ScanCommand { protected set; get; }
        public ICommand EditCommand { protected set; get; }
        public ICommand ListCommand { protected set; get; }
        public ICommand ShowCurrentUserCommand { protected set; get; }

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

            ShowCurrentUserCommand = new Command(async x => await ShowCurrentUser());
        }

        public ProfileViewModel(UserHelper user)
        {
            
            var testTrut = new UserHelper
            {
                FirstName = "Test",
                LastName = "Trut",
                Email = "test@test"
            };

            CurrentUser = testTrut;

            ScanCommand = new Command(OnScan);
            EditCommand = new Command(OnEdit);
            ListCommand = new Command(OnList);

            ShowCurrentUserCommand = new Command(async x => await ShowCurrentUser());
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
        public async Task ShowCurrentUser()
        {
            //using stuff met api, hier current user opvragen

            //CurrentUser = await SecureStorage.GetAsync("CurrentUser");



            var test = new UserHelper
            {
                FirstName = await SecureStorage.GetAsync("UserFirstName"),
                LastName = await SecureStorage.GetAsync("UserLastName"),
                Email = await SecureStorage.GetAsync("UserEmail"),
                DateOfBirth = DateTime.Parse(await SecureStorage.GetAsync("DateOfBirth"))
                };
            CurrentUser = test;
        }
    }
}
