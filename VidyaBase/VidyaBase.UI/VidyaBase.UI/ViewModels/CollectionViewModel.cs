using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VidyaBase.UI.API;
using VidyaBase.UI.API.Contracts;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.HelperModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{

    public class CollectionViewModel : BaseViewModel
    {
        private readonly PageService pageService = new PageService();
        public ICommand GetCommand { get; private set; }
        private ObservableCollection<GameHelper> _games;

        public ObservableCollection<GameHelper> Games
        {
            get => _games;
            set => SetValue(ref _games, value);
        }

        public CollectionViewModel()
        {
            Games = new ObservableCollection<GameHelper>();
            GetCommand = new Command(async () => await Get());
        }

        private async Task Get()
        {
            try
            {
                string userIdAsString = await SecureStorage.GetAsync("idLoggedInUser");
                int userId = Convert.ToInt32(userIdAsString);

                using (APIService<IOwnedGameApi> service = new APIService<IOwnedGameApi>(GlobalVars.VidyaBaseApiLocal))
                {
                    string response = await service.myService.GetByUserId(userId, 0, 500);
                    IEnumerable<OwnedGameHelper> games = JsonConvert.DeserializeObject<ApiMultiResponse<OwnedGameHelper>>(response).Value;
                    Games.Clear();
                    foreach (OwnedGameHelper model in games)
                    {
                        Games.Add(model.Game);
                    }
                }
            }
            catch (Exception ex)
            {
                await pageService.DisplayAlert("Something went wrong...", $"Response:{ex.Message}", "ok");
            }
        }
    }
}
