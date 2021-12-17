using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidyaBase.UI.AppServices;
using Xamarin.Forms;


namespace VidyaBase.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
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
