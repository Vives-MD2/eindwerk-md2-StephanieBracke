using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.UI.AppService.ScanService
{
    public interface IBarcodeScannerService
    {
        Task<string> SendAsync();
    }
}
