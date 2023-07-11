using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTutorial
{
    public interface ISeleniumTests
    {
        List<string> ValidateTheMessageIsDisplayed();

    }
    public class SeleniumTests:ISeleniumTests
    {
        private IWebDriver driver;
        private readonly ILogger<SeleniumTests> _logger;
        public SeleniumTests(ILogger<SeleniumTests> logger)
        {
            _logger = logger;
        }
        
        //public string ValidateTheMessageIsDisplayed()
        //{
        //    driver = new ChromeDriver();
        //    _logger.LogInformation("--------Opening Chrome--------");
        //    driver.Navigate().GoToUrl("https://www.lambdatest.com/selenium-playground/simple-form-demo");
        //    _logger.LogInformation("--------Redirecting to Url---------");
        //    driver.FindElement(By.Id("user-message")).SendKeys("LambdaTest rules");
        //    driver.FindElement(By.Id("showInput")).Click();
        //    _logger.LogInformation("---------fetching Elements--------");
        //    var str = driver.FindElement(By.Id("message")).Text;
        //    _logger.LogInformation("-------Extracting Message------");
        //    driver.Quit();
        //    _logger.LogInformation("------Closing chromeDriver------");

        //    return str;
        //    //Assert.IsTrue(driver.FindElement(By.Id("message")).Text.Equals("LambdaTest rules"), "The expected message was not displayed.");
            
        //}
        public List<string> ValidateTheMessageIsDisplayed()
        {
            driver = new ChromeDriver();
            _logger.LogInformation("--------Opening Chrome--------");
            driver.Navigate().GoToUrl("https://www.nmc.org.np/searchPractitioner");
            _logger.LogInformation("--------Redirecting to Url---------");
            driver.FindElement(By.Id("template-medical-name")).SendKeys("Suman");
            driver.FindElement(By.Id("nmc")).SendKeys("575");
            driver.FindElement(By.Id("Degree")).SendKeys("MBBS");
            driver.FindElement(By.XPath("/html/body/section[2]/div[1]/div/div/form/div/div[4]/button")).Click();
            _logger.LogInformation("---------fetching Elements--------");
            var fullname = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[1]")).Text;
            var nmcNumber = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[2]")).Text;
            var degree = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[1]/div/div/div/div[1]/table/tbody/tr[5]")).Text;
            _logger.LogInformation("-------Extracting Message------");
            driver.Quit();
            _logger.LogInformation("------Closing chromeDriver------");
            var str = new List<string>();
            str.Add(fullname);
            str.Add(degree);
            str.Add(nmcNumber);
            return str;
            //Assert.IsTrue(driver.FindElement(By.Id("message")).Text.Equals("LambdaTest rules"), "The expected message was not displayed.");

        }

    }
}
