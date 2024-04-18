using OpenQA.Selenium;
using SpecFlowTurnUpPortal.Utilities;

namespace SpecFlowTurnUpPortal.Pages
{
    public class LoginPage : CommonDriver
    {
        private readonly By usernameTextboxLocator = By.Id("UserName");
        IWebElement usernameTextbox;
        private readonly By passwordTextboxLocator = By.Id("Password");
        IWebElement passwordTextbox;
        //private readonly By loginButtonLocator = By.XPath("//*[@id='loginForm']/form/div[3]/input[1]");
        private readonly By loginButtonLocator = By.XPath("//*[@value='Log in']");

        IWebElement loginButton;

        public void LoginActions(IWebDriver webDriver, string username, string password)
        {
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //Launch TurnUp Portal and navigate to login page
            string baseURL = "http://horse.industryconnect.io/Account/Login";
            webDriver.Navigate().GoToUrl(baseURL);

            //Identify username textbox and enter valid username
            usernameTextbox = webDriver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);

            //Identify password textbox and enter valid password
            passwordTextbox = webDriver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);

            //Identify login button and click on the button
            loginButton = webDriver.FindElement(loginButtonLocator);
            loginButton.Click();
        }
    }
}
