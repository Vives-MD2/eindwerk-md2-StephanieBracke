using System;
using VidyaBase.UI.AppService.ScanService;
using Xamarin.Forms;


namespace VidyaBase.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void btnCameraScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var qr_scanner = DependencyService.Get<IBarcodeScannerService>();
                var result = await qr_scanner.SendAsync();

                if (result != null)
                {
                    eEAN.Text = result; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
