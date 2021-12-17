using System.Threading.Tasks;
using VidyaBase.UI.AppServices;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(VidyaBase.UI.Services.BarcodeScannerService))]
namespace VidyaBase.UI.Services
{
    class BarcodeScannerService : IBarcodeScannerService
    {
        public async Task<string> SendAsync()
        {
            var optionsDefault = new MobileBarcodeScanningOptions();
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Loading...",
                BottomText = "Please hang on there!",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}
