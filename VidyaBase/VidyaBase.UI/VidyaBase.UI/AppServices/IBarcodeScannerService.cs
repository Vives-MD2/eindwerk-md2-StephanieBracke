using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VidyaBase.UI.AppServices
{
    public interface IBarcodeScannerService
    {
        Task<string> SendAsync();
    }
}
