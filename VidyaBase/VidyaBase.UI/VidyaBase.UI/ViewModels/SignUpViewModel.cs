using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.Pages.Project.User;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class SignUpViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();

        public ICommand SignInCommand { protected set; get; }

        public SignUpViewModel()
        {
            SignInCommand = new Command(OnSignIn);
        }

        public async void OnSignIn()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }
    }
}
