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
                TopText = "Bip blop blap scanning initiated",
                BottomText = "Even geduld!",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}
