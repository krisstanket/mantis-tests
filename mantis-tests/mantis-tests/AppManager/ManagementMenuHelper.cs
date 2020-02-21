using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void OpenManagePage()
        {
            OpenMyViewPage();
            driver.FindElement(By.CssSelector("a[href=\"/mantisbt-2.23.0/manage_overview_page.php\"]")).Click();
        }

        public void OpenMyViewPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.23.0/my_view_page.php";
        }

        public void OpenManageProjectsPage()
        {
            driver.FindElement(By.CssSelector("a[href=\"/mantisbt-2.23.0/manage_proj_page.php\"]")).Click();
        }
    }
}
