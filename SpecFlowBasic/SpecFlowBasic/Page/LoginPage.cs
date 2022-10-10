using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBasic.Page
{
    internal class LoginPage
    {
        public IWebDriver driver { get; }

        //Elements
        private IWebElement btnLogin => driver.FindElement(By.Id("login-button"));
        private IWebElement message => driver.FindElement(By.XPath("//div[@class = 'error-message']"));
        

        public IWebElement getField(String text)
        {
            IWebElement inputText = driver.FindElement(By.XPath("//label[text() = '" + text + "']/../input"));
            return inputText;
        }

        //methods

        public LoginPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void inputFields(String field, String value) => getField(field).SendKeys(value);

        public void clickLoginbtn() => btnLogin.Click();

        public void checkErrorMessage()
        {
            Assert.That(message.Displayed, Is.True);
        }

        public void verifyMessage(String mess)
        {
            Assert.AreEqual(message.Text, mess);
        }
    }
}
