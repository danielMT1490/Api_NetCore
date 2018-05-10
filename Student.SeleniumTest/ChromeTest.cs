using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.SeleniumTest
{
    [TestClass]
    public class ChromeTest
    {
        private IWebDriver chrome;

        [TestInitialize]
        public void Init()
        {
            chrome = new ChromeDriver();
        }

        [TestMethod]
        public void ChromeNavegatorTest()
        {

            var url = "http://localhost:60421/api/Alumno";
            chrome.Navigate().GoToUrl(url);
            var responseElement = chrome.FindElement(By.TagName("pre"));
            var resultJson = responseElement.Text;

            Assert.IsTrue(resultJson.Contains("guid"));
            Assert.IsTrue(resultJson.Contains("id"));
            Assert.IsTrue(resultJson.Contains("dni"));
            Assert.IsTrue(resultJson.Contains("nombre"));
            Assert.IsTrue(resultJson.Contains("apellidos"));
            Assert.IsTrue(resultJson.Contains("edad"));
            Assert.IsTrue(resultJson.Contains("nacimiento"));
            Assert.IsTrue(resultJson.Contains("registro"));

            
            Assert.IsTrue(resultJson.Split('{').Length > 2);

        }

        [TestCleanup]
        public void Exit()
        {
            chrome.Quit();
        }
    }
}
