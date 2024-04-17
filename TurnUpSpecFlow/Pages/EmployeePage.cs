using OpenQA.Selenium;
using SpecFlowTurnUpPortal.Utilities;

namespace SpecFlowTurnUpPortal.Pages
{
    public class EmployeePage : CommonDriver
    {
        public void CreateEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Created");
        }

        public void EditNewlyCreatedEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Edited");
        }

        public void DeleteEmployeeRecord(IWebDriver webDriver)
        {
            Console.WriteLine("Employee Record Deleted");
        }
    }
}
