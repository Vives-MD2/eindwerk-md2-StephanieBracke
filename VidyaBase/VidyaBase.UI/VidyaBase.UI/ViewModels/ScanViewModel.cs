
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utf8Json;
using VidyaBase.UI.AppService.PageService;
using VidyaBase.UI.AppService.ScanService;
using VidyaBase.UI.HelperModels;
using Xamarin.Forms;

namespace VidyaBase.UI.ViewModels
{
    class ScanViewModel: BaseViewModel
    {
        private PageService pageService = new PageService();
        public ICommand ScanEanCodeCommand { protected set; get; }

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
        }

        public async Task ScanEanCode()
        {
            try
            {
                var qr_scanner = DependencyService.Get<IBarcodeScannerService>();
                var result = await qr_scanner.SendAsync();

                if (result == string.Empty)
                {
                    //await DisplayAlert("Error", "No EAN was scanned", "OK");
                    Debug.WriteLine("EMPTY STRIIIIING!!");
                }
                else
                {
                    EanCodeInput = result;
                    Debug.WriteLine(EanCodeInput);
                    await UseEanApi(result);
                }
            }
            catch (Exception)
            {
                //await DisplayAlert("Error", "No EAN was scanned", "OK");
            }
        }

        private async Task UseEanApi(string barcode)
        {
            //var httpClient = new HttpClient()
            //Uri uri = new Uri($"https://api.ean-search.org/api?token=1938aa76f22a300d0743041a82f12a38c234bd68f1ccfbe4d0da94e094d72be3&op=barcode-lookup&ean={barcode}&format=json");
            //HttpResponseMessage response = await httpClient.GetAsync(uri);
            //if (response.IsSuccessStatusCode)
            //{
            //    var body = await response.Content.ReadAsStringAsync();

            //    //deserializen adhv EanModel
            //    var test2 = JsonConvert.DeserializeObject<EanModel>(body);
            //    var test = "hi";
            //    Debug.WriteLine("LOOK AT ME" + ScannedEan.name);
            //}
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("Something went wrong...", $"Response:{response.StatusCode}", "ok");
            //}

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.ean-search.org/api?token=1938aa76f22a300d0743041a82f12a38c234bd68f1ccfbe4d0da94e094d72be3&op=barcode-lookup&ean={barcode}&format=json")
            };
            using(var response = await httpClient.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    //var editedBody = body.Substring(0, (body.Length - 2));
                    //var optimizedBody = editedBody.Replace(@"\", "");
                    //line.Replace(@"\", string.Empty);
                    //ScannedEan = await Utf8Json.JsonSerializer.DeserializeAsync<EanModel>(body);
                    //var test = Utf8Json.JsonSerializer.Deserialize<EanModel>(body);
                    var test = JsonConvert.DeserializeObject<EanModel>(body);
                }
                catch (JsonParsingException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }

            }
        }
    }
}
