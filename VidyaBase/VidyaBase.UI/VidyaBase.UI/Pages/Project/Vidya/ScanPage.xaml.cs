using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.UI.AppService.ScanService;
using VidyaBase.UI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VidyaBase.UI.Pages.Project.Vidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            var viewModel = new ScanViewModel();
            BindingContext = viewModel;
            InitializeComponent();
        }
        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            try
            {
                var qr_scanner = DependencyService.Get<IBarcodeScannerService>();
                var result = await qr_scanner.SendAsync();

                if(result == string.Empty)
                {
                    await DisplayAlert("Error", "No EAN was scanned", "OK");
                }
                else
                {
                    eEAN.Text = result;
                    await UseEanApi(result);
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No EAN was scanned", "OK");
            }
        }
        private async Task UseEanApi(string barcode)
        {
            var httpClient = new HttpClient();

            Uri uri = new Uri($"https://api.ean-search.org/api?token=1938aa76f22a300d0743041a82f12a38c234bd68f1ccfbe4d0da94e094d72be3&op=barcode-lookup&ean={barcode}&format=json");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(body);
                //deserializen adhv EanModel
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Something went wrong...", $"Response:{response.StatusCode}", "ok");
            }
        }
    }
}