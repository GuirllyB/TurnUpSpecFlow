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

        
        [Given(@"user logs into TurnUp Portal")]
        public void GivenUserLogsIntoTurnUpPortal()
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();
            Thread.Sleep(1000);

            //Login page object initialisation and definition
            loginPageObj.LoginActions(webDriver, "hari", "123123");
        }

        [Given(@"user navigates to TM Page")]
        public void GivenUserNavigatesToTMPage()
        {
            homePageObj.NavigateToTimeMaterialPage(webDriver);
        }

        [When(@"user creates a new TM record")]
        public void WhenUserCreatesANewTMRecord()
        {
            tmPageObj.CreateTimeRecord(webDriver);
        }

        [Then(@"verify TM record is created")]
        public void ThenVerifyTMRecordIsCreated()
        {
            tmPageObj.VerifyRecordCreated(webDriver);
        }

        [When(@"user clicks on <<Edit>> button under TM Page")]
        public void WhenUserClicksOnEditButtonUnderTMPage()
        {
            tmPageObj.EditNewlyCreatedTMRecord(webDriver);
        }

        [Then(@"verify TM record is edited")]
        public void ThenVerifyTMRecordIsEdited()
        {
            tmPageObj.VerifyNewlyEditedTMRecord(webDriver);
        }

        [When(@"user clicks on <<Delete>> button under TM Page")]
        public void WhenUserClicksOnDeleteButtonUnderTMPage()
        {
            tmPageObj.DeleteTMRecord(webDriver);
        }

        [Then(@"verify TM record is deleted")]
        public void ThenVerifyTMRecordIsDeleted()
        {
            tmPageObj.VerifyDeletedTMRecord(webDriver);
        }

        //[TearDown]
        //public void CloseTestRun()
        //{
        //    webDriver.Quit();
        //}
    }
}
