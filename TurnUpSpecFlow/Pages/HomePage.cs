using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowTurnUpPortal.Utilities;

namespace SpecFlowTurnUpPortal.Pages
{
    public class HomePage : CommonDriver
    {
        public void NavigateToTimeMaterialPage(IWebDriver webDriver)
        {
            try
            {
                //Navigate to Time and Material module (Click Administration button -> Select Time & Materials Option)
                IWebElement administrationDropdown = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                administrationDropdown.Click();
                WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")));

                IWebElement tmOption = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
                tmOption.Click();
            }
            catch (Exception ex) 
            {
                Assert.Fail("TurnUp Portal page did not display" + ex.Message);
            }
        }

        public void NavigateToEmployeePage(IWebDriver webDriver)
        {
            try
            {
                //Navigate to Employee module (Click Administration button -> Select Time & Materials Option)
                IWebElement administrationDropdown = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                administrationDropdown.Click();
                WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
                webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a")));

                IWebElement employeeOption = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
                employeeOption.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp Portal page did not display" + ex.Message);
            }
        }

        public void VerifyLoggedInUser(IWebDriver webDriver)
        {
            try
            {
                //Check if user has logged in successfully
                IWebElement helloHariLink = webDriver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
                Assert.That(helloHariLink.Text == "Hello hari!", "User hasn't been logged in.");
            }
            catch(Exception ex) 
            {
                Assert.Fail("User hasn't logged in :(" + ex.Message);
            }
        }

    }
}
