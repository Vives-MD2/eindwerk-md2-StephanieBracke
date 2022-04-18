using System.Collections.Generic;

namespace VidyaBase.UI.API
{
    public class ApiMultiResponse<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
