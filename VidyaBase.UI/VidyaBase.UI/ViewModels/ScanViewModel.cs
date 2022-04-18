
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.AppService.ScanService;
using VidyaBase.UI.HelperModels;
using VidyaBase.UI.Pages.Project.Vidya;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class ScanViewModel : BaseViewModel
    {
        private readonly PageService pageService = new PageService();

        public ICommand ScanEanCodeCommand { protected set; get; }
        public ICommand CollectionGoCommand { protected set; get; }
        public ICommand WishlistGoCommand { protected set; get; }

        private string _test;

        public string Test
        {
            get
            {
                return _test;
            }
            set => SetValue(ref _test, value);
        }
        private string _eanCodeInput;
        public string EanCodeInput
        {
            get
            {
                return _eanCodeInput;
            }
            set => SetValue(ref _eanCodeInput, value);
        }

        private EanModel _scannedEan;
        public EanModel ScannedEan
        {
            get
            {
                return _scannedEan;
            }
            set => SetValue(ref _scannedEan, value);
        }
        public ScanViewModel()
        {
            ScanEanCodeCommand = new Command(async x => await ScanEanCode());
            WishlistGoCommand = new Command(OnWishlistGoCommand);
            CollectionGoCommand = new Command(OnCollectionGoCommand);
        }

        public async void OnWishlistGoCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new WishlistPage());
        }

        public async void OnCollectionGoCommand()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CollectionPage());
        }

        public async Task ScanEanCode()
        {
            try
            {
                IBarcodeScannerService qr_scanner = DependencyService.Get<IBarcodeScannerService>();
                string result = await qr_scanner.SendAsync();

                EanCodeInput = result;
                Debug.WriteLine(EanCodeInput);
                await UseEanApi(result);
            }
            catch (Exception ex)
            {
                await pageService.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task UseEanApi(string barcode)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api.ean-search.org/api?token=1938aa76f22a300d0743041a82f12a38c234bd68f1ccfbe4d0da94e094d72be3&op=barcode-lookup&ean={barcode}&format=json")
                };
                HttpResponseMessage response = await httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                string body = await response.Content.ReadAsStringAsync();

                List<EanModel> test = JsonConvert.DeserializeObject<List<EanModel>>(body);

                if (test.Count == 0)
                {
                    throw new Exception("Barcode not found");
                }

                ScannedEan = test[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
