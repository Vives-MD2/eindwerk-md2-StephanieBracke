using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.Pages.Project.User;
using VidyaBase.UI.Pages.Project.Vidya;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();

        public ICommand ScanCommand { protected set; get; }
        public ICommand EditCommand { protected set; get; }
        public ICommand ListCommand { protected set; get; }
        public ProfileViewModel()
        {
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
            //Listpage
            //await Application.Current.MainPage.Navigation.PushModalAsync(new ListPage());
        }
    }
}
