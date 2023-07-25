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
}
