using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using StudentCommon.Logic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.SeleniumTest
{
    [TestClass]
    public class FireFoxTest
    {
       
        private IWebDriver firefox;

        [TestInitialize]
        public void Init()
        {
            
            firefox = new FirefoxDriver();
        }

        [TestMethod]
        public void FireFoxNavegatorTest()
        {
            var url = "http://localhost:60421/api/Alumno";
            
            firefox.Navigate().GoToUrl(url);
            firefox.FindElement(By.Id("tab-1")).Click();
            var responseElement = firefox.FindElement(By.TagName("pre"));
            var resultJson = responseElement.Text;

            Assert.IsTrue(resultJson.Contains("guid"));
            Assert.IsTrue(resultJson.Contains("id"));
            Assert.IsTrue(resultJson.Contains("dni"));
            Assert.IsTrue(resultJson.Contains("nombre"));
            Assert.IsTrue(resultJson.Contains("apellidos"));
            Assert.IsTrue(resultJson.Contains("edad"));
            Assert.IsTrue(resultJson.Contains("nacimiento"));
            Assert.IsTrue(resultJson.Contains("registro"));

            var Alumnos = JsonConvert.DeserializeObject<List<Alumno>>(resultJson);
            Assert.IsTrue(Alumnos.Count>1);
        }

        [TestCleanup]
        public void Exit()
        {
            //firefox.Quit();
        }
    }
}
