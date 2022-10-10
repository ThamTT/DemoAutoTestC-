using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowBasic.Page;
using NUnit.Framework;

namespace SpecFlowBasic.StepDefinitions
{
    [Binding]
    public sealed class LoginStepsDefinittions
    {
        private IWebDriver webDriver = new ChromeDriver();
        private LoginPage loginPage;

        [Given(@"Open the application")]
        public void GivenOpenTheApplication()
        {
            webDriver.Navigate().GoToUrl("https://web-order.london-demo.lmax.com/auth/login?response_type=code&redirect_uri=https%3A%2F%2Fweb-order.london-demo.lmax.com%2Foauth&client_id=TRADING");
            loginPage = new LoginPage(webDriver);
        }

        [When(@"I Input value to field")]
        public void WhenIInputValueToField(Table table)
        {
            IDictionary<string, string> addressRow = new Dictionary<string, string>();
            foreach (TableRow row in table.Rows)
            {
                //addressRow.Add(row["Field"], row["Value"]);
                //if(row["Value"])
                loginPage.inputFields(row["Field"], row["Value"]);
            }
        }

        [When(@"I click login button")]
        public void WhenIClickLoginButton() => loginPage.clickLoginbtn();

        [Then(@"Check message error should be shown")]
        public void ThenCheckMessageErrorShouldBeShown()
        {
            loginPage.checkErrorMessage();
        }

        [Then(@"Verify (.*) error should be shown")]
        public void ThenCheckMessageErrorShouldBeShowns(String message)
        {
            loginPage.verifyMessage(message);
        }

    }
}