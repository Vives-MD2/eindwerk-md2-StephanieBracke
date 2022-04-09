using System;
using System.Collections.Generic;
using System.Linq;
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
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No EAN was scanned", "OK");
            }
        }
    }
}