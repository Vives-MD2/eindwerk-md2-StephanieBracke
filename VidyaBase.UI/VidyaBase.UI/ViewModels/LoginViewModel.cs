using System;
using System.Windows.Input;
using VidyaBase.UI.API;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.Pages.Project.User;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;
using VidyaBase.UI.HelperModels;
using System.Threading.Tasks;
using System.Diagnostics;
using VidyaBase.DOMAIN;

namespace VidyaBase.UI.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        private JsonSerializer _serializer = new JsonSerializer();

        // Based on C-Sharpcorner
        public Action DisplayInvalidLoginPrompt;
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        private UserHelper _loggedInUser;
        public UserHelper LoggedInUser
        {
            get { return _loggedInUser; }
            //set => SetValue(ref _loggedInUser, value);
            set
            {
                _loggedInUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { protected set; get; }
        public ICommand SignUpCommand { protected set; get; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(async x => await OnSubmit());
            SignUpCommand = new Command(OnSignUp);
        }
        
        public async Task OnSubmit()
        {
            //To store the logged in user: https://gabsikarim.gitbook.io/xamarin/code/topics/secure-storage
            using (APIService<IUserApi> service = new APIService<IUserApi>(GlobalVars.VidyaBaseApiOnline))
            {
                if (email != string.Empty && password == "secret")
                {
                   var response = await service.myService.GetByEmail(email);
                   var user = JsonConvert.DeserializeObject<ApiSingleResponse<User>>(response).Value;

                    await SecureStorage.SetAsync("idLoggedInUser", user.ID.ToString());
                   //await SecureStorage.SetAsync("UserFirstName", user.FirstName);
                   //await SecureStorage.SetAsync("UserEmail", user.Email);
                   //await SecureStorage.SetAsync("DateOfBirth", user.DateOfBirth.ToString());
                   Debug.WriteLine(LoggedInUser);
                   await Application.Current.MainPage.Navigation.PushModalAsync(new ProfilePage());
                }
                else
                {
                    DisplayInvalidLoginPrompt();
                }
            }
        }

        public async void OnSignUp()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }
    }
}
