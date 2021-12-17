using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace VidyaBase.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCamera_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var qr_scanner = DependencyService.Get<IQRScannerService>();
                //var result = await qr_scanner.SendAsync();

                //if (result != null)
                //{
                //    eEAN.Text = result;
                //}
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
