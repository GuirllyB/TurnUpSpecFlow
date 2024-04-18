using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowTurnUpPortal.Utilities;

namespace SpecFlowTurnUpPortal.Pages
{
    public class TimeMaterialPage : CommonDriver
    {
        public void CreateTimeRecord(IWebDriver webDriver, string code, string description)
        {
            //Create a new Time/Material record
            Thread.Sleep(2000);
            //Click on the Create New Button
            IWebElement createNewButton = webDriver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]", 5);

            //Select Time from dropdown
            IWebElement typeCodeDropdown = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
            typeCodeDropdown.Click();
            IWebElement timetypeCode = webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
            timetypeCode.Click();

            //Enter Code
            IWebElement codeTextbox = webDriver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys(code);

            //Enter Description
            IWebElement descriptionTextbox = webDriver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys(description);

            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 5);

            //Enter Price per unit
            IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("2206.85");

            //Click on Select file button and select a file

            //Click on Save button
            WaitUtils.WaitToBeClickable(webDriver, "Id", "SaveButton", 3);
            IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(2000);

            //Check if new Time/Material record has been created successfully
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            VerifyRecordCreated(webDriver);
        }

        public void VerifyRecordCreated(IWebDriver webDriver)
           {
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement newCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            /*if (newCode.Text == "GBTime")
            {
                Assert.Pass("New Time record has been created successfully");
            }
            else
            {
                Assert.Fail("New Time record hasn't been created.");
            }*/

            Assert.That(newCode.Text == "GBTime", "New Time record hasn't been created.");
            }

        public void EditNewlyCreatedTMRecord(IWebDriver webDriver)
        {
            Thread.Sleep(2000);

            //Check if new Time/Material record has been created successfully
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(2000);

            //Click on Edit button
            IWebElement editButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit Code to add "New"
            IWebElement codeTextboxEdit = webDriver.FindElement(By.Id("Code"));
            codeTextboxEdit.Clear();
            codeTextboxEdit.SendKeys("GBTimeNew");

            //Edit Description to add "New"
            IWebElement descriptionTextboxEdit = webDriver.FindElement(By.Id("Description"));
            descriptionTextboxEdit.Clear();
            descriptionTextboxEdit.SendKeys("GBTimeNew Description");

            //Edit Price per unit
            IWebElement priceTextboxEdit = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextboxEdit.Click();
            Actions actions = new Actions(webDriver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("5785.32").Build().Perform();

            //Click on Save button
            IWebElement saveButtonEdit = webDriver.FindElement(By.Id("SaveButton"));
            saveButtonEdit.Click();

            Thread.Sleep(2000);
        }

        public void VerifyNewlyEditedTMRecord(IWebDriver webDriver)
        {
            Thread.Sleep(2000);

            //Go to Last Page to Check if new Time/Material record has been edited successfully
            IWebElement goToLastPageButtonEdit = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();

            Thread.Sleep(2000);
            //Check if new Time/Material record has been edited successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement editedCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            Assert.That(editedCode.Text == "GBTimeNew", "Time record hasn't been edited.");
            Thread.Sleep(2000);
        }

        public void DeleteTMRecord(IWebDriver webDriver)
        {
            //Check if new Time/Material record has been created successfully
            WaitUtils.WaitToBeClickable(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            Thread.Sleep(2000);

            //Click on Delete button
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 3);
            IWebElement deleteButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(2000);

            ////Click on Ok on pop - up window to delete item
            //IAlert alert = webDriver.SwitchTo().Alert();
            //alert.Accept();

            //Click on Cancel on pop-up window to delete item
            IAlert alert = webDriver.SwitchTo().Alert();
            alert.Dismiss();

            Thread.Sleep(2000);
        }

        public void VerifyDeletedTMRecord(IWebDriver webDriver)
        {
            Thread.Sleep(2000);

            //Verify if new Time/Material record has been deleted/cancelled deletion
            IWebElement goToLastPageButtonDelete = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonDelete.Click();

            Thread.Sleep(2000);
            //Check if new Time/Material record has been edited successfully
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);
            IWebElement deletedCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


            Assert.That(deletedCode.Text == "GBTimeNew", "Time record hasn't been deleted.");
        }


    }

}
