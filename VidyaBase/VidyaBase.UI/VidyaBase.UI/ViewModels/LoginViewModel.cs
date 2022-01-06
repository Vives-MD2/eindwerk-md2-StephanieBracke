using System;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.Pages.Project.User;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();

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

        public ICommand SubmitCommand { protected set; get; }
        public ICommand SignUpCommand { protected set; get; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            SignUpCommand = new Command(OnSignUp);
        }
        public async void OnSubmit()
        {
            if (email != "stephanie.bracke@student.vives.be" || password != "secret")
            {
                DisplayInvalidLoginPrompt();
            }
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProfilePage());
        }

        public async void OnSignUp()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }
    }
}
