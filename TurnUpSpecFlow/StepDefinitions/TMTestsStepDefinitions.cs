using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTurnUpPortal.Pages;
using SpecFlowTurnUpPortal.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTurnUpPortal.StepDefinitions
{
    [Binding]
    public class TMTestsStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TimeMaterialPage tmPageObj = new TimeMaterialPage();

        [Before] public void Before() 
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();
            Thread.Sleep(1000);
        }
        
        [After] public void After()
        {
            webDriver.Quit();
        }

        [Given(@"user logs into TurnUp Portal")]
        public void GivenUserLogsIntoTurnUpPortal()
        {
    

            //Login page object initialisation and definition
            loginPageObj.LoginActions(webDriver, "hari", "123123");
        }

        [Given(@"user navigates to TM Page")]
        public void GivenUserNavigatesToTMPage()
        {
            homePageObj.NavigateToTimeMaterialPage(webDriver);
        }

      
        [When(@"user creates a new TM record '([^']*)' '([^']*)'")]
        public void WhenUserCreatesANewTMRecord(string code, string description)
        {
            tmPageObj.CreateTimeRecord(webDriver, code, description);
        }


        [Then(@"verify TM record is created")]
        public void ThenVerifyTMRecordIsCreated(string code, string description)
        {
            tmPageObj.VerifyRecordCreated(webDriver, code, description);
        }

        [When(@"user clicks on <<Edit>> button under TM Page")]
        public void WhenUserClicksOnEditButtonUnderTMPage(string code, string description)
        {
            tmPageObj.EditNewlyCreatedTMRecord(webDriver, code, description);
        }

        [Then(@"verify TM record is edited")]
        public void ThenVerifyTMRecordIsEdited(string code)
        {
            tmPageObj.VerifyNewlyEditedTMRecord(webDriver, code);
        }

        [When(@"user clicks on <<Delete>> button under TM Page")]
        public void WhenUserClicksOnDeleteButtonUnderTMPage()
        {
            tmPageObj.DeleteTMRecord(webDriver);
        }

        [Then(@"verify TM record is deleted")]
        public void ThenVerifyTMRecordIsDeleted(string code)
        {
            tmPageObj.VerifyDeletedTMRecord(webDriver, code);
        }

        //[TearDown]
        //public void CloseTestRun()
        //{
        //    webDriver.Quit();
        //}
    }
}
