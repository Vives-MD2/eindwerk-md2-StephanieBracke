using System;
using System.Threading.Tasks;
using VidyaBase.UI.AppService.ScanService;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(BarcodeScannerService))]
namespace VidyaBase.UI.AppService.ScanService
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
