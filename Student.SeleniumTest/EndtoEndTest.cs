using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Student.SeleniumTest
{
    [TestClass]
    public class EndtoEndTest
    {
        private IWebDriver chrome;
        private IWebDriver firefox;

        [TestInitialize]
        public void Init()
        {
            chrome = new ChromeDriver();
            firefox = new FirefoxDriver();
        }

        [TestMethod]
        public void ChromeTest()
        {
            firefox.Url = "http://www.google.com";
            chrome.Url = "http://www.google.com";
        }
      
    }
}
