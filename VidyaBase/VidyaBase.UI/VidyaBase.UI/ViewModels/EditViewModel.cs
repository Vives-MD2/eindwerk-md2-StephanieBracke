using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.HelperModels;
using VidyaBase.UI.Pages.Project.User;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class EditViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        private UserHelper _editUser = new UserHelper();

        public UserHelper EditUser
        {
            get
            {
                return _editUser;
            }
            set => SetValue(ref _editUser, value);
        }

        public ICommand EditCommand {protected set; get;}
        public EditViewModel()
        {
            EditCommand = new Command(async x => await OnEdit());
        }
        public EditViewModel(UserHelper user)
        {
            EditCommand = new Command(async x => await OnEdit());
        }

        private async Task OnEdit()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProfilePage());
        }

    }
}



