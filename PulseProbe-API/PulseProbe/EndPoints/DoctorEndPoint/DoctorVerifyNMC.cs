using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PulseProbe.EndPoints.DoctorEndPoint
{
    public interface INMCDoctor
    {
        bool ValidateDoctor(string Name, string NMCnumber, string Degree);

    }
    public class NMCDoctor : INMCDoctor
    {
        private IWebDriver driver;
        private readonly ILogger<NMCDoctor> _logger;
        public NMCDoctor(ILogger<NMCDoctor> logger)
        {
            _logger = logger;
        }
        public bool ValidateDoctor(string Name , string NMCnumber , string Degree)
        {

            driver = new ChromeDriver();
            _logger.LogInformation("--------Opening Chrome--------");
            driver.Navigate().GoToUrl("https://www.nmc.org.np/searchPractitioner");
            _logger.LogInformation("--------Redirecting to Url---------");
            driver.FindElement(By.Id("template-medical-name")).SendKeys(Name);//suman
            driver.FindElement(By.Id("nmc")).SendKeys(NMCnumber); //5641
            driver.FindElement(By.Id("Degree")).SendKeys(Degree); //MBBS
            driver.FindElement(By.XPath("/html/body/section[2]/div[1]/div/div/form/div/div[4]/button")).Click();
            _logger.LogInformation("---------fetching Elements--------");
            if(driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr")).Text == "Sorry Practitioner you searched for not found.")
            {
                driver.Quit();
                _logger.LogInformation("-----Doctor Information invalid----");
                _logger.LogInformation("------Closing chromeDriver------");
                return false;
            }
            var fullname = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[1]")).Text;
            var nmcNumber = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[2]")).Text;
            var degree = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[5]")).Text;
            _logger.LogInformation("-------Extracting Message------");
            if(fullname.IsNullOrEmpty()==false && nmcNumber.IsNullOrEmpty() == false && degree.IsNullOrEmpty() == false)
            {
                driver.Quit();
                _logger.LogInformation("-----Doctor Information Verified----");
                _logger.LogInformation("------Closing chromeDriver------");
                return true;
            }
            driver.Quit();
            _logger.LogInformation("------Closing chromeDriver------");
            return false;

        }

    }
}
