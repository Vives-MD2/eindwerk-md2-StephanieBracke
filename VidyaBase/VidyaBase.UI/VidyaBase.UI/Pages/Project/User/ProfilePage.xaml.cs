using VidyaBase.UI.HelperModels;
using VidyaBase.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            var viewModel = new ProfileViewModel();
            BindingContext = viewModel;
            (BindingContext as ProfileViewModel)?.ShowCurrentUserCommand.Execute(null);
            InitializeComponent();
        }

        //public ProfilePage(UserHelper test)
        //{
        //    var viewModel = new ProfileViewModel(test);
        //    BindingContext = viewModel;
        //    InitializeComponent();
        //}
    }
}