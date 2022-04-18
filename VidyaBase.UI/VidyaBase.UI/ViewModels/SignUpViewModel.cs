using System.Threading.Tasks;
using System.Windows.Input;
using VidyaBase.UI.API;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.HelperModels;
using VidyaBase.UI.Pages.Project.User;
using Xamarin.Forms;

using System.Diagnostics;

namespace VidyaBase.UI.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        private UserHelper _newUser = new UserHelper();

        public UserHelper NewUser
        {
            get
            {
                return _newUser;
            }
            set => SetValue(ref _newUser, value);
        }

        public ICommand SignInCommand { protected set; get; }
        public ICommand SignUpCommand { protected set; get; }

        public SignUpViewModel()
        {
            SignInCommand = new Command(async x => await OnSignIn());
            SignUpCommand = new Command(async x => await OnSignUp());
        }

        private async Task OnSignIn()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }

        public async Task OnSignUp()
        {
            using (APIService<IUserApi> service = new APIService<IUserApi>(GlobalVars.VidyaBaseApiLocal))
            {
                var response = await service.myService.Create(NewUser);

                if (response != null)
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                }
            }
        }
    }
}
