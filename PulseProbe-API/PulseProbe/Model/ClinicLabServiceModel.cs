using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium.DevTools.V112.Runtime;

namespace PulseProbe.Model
{
    [PrimaryKey("ServiceId")]
    public class ClinicLabServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }

    [PrimaryKey("PriceId")]
    public class ClinicLabServicesPriceModel
    {
        public int PriceId { get; set; }
        public int ClinicId { get; set; }
        public int ServiceId { get; set; }
        public int price { get; set; }
    }
    
}
