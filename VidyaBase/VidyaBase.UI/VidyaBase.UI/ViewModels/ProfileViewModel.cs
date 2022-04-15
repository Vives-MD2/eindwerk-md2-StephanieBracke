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
using VidyaBase.UI.API;
using Newtonsoft.Json;
using VidyaBase.DOMAIN;

namespace VidyaBase.UI.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly PageService pageService = new PageService();
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

        public async void OnScan()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ScanPage());
        }

        public async void OnEdit()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new EditPage(CurrentUser));
        }

        public async void OnList()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ListPage());
        }
        public async Task ShowCurrentUser()
        {
            //using stuff met api, hier current user opvragen

            int currentUserId = Convert.ToInt32(await SecureStorage.GetAsync("idLoggedInUser"));

            using (APIService<IUserApi> service = new APIService<IUserApi>(GlobalVars.VidyaBaseApiLocal))
            {
                if (currentUserId > 0)
                {
                    var response = await service.myService.GetById(currentUserId);
                    var user = JsonConvert.DeserializeObject<ApiSingleResponse<UserHelper>>(response).Value;
                    CurrentUser = user;
                }
            }
        }
    }
}
