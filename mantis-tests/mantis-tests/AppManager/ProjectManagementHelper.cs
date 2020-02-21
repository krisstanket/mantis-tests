using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            ClickNewProjectButton();
            FillInputForm(project.Name, project.Description);
            SubmitProjectCreation();
            WaitLoadPage();
        }

        public void RemoveProject(int index)
        {
            SelectProject(index);
            InitRemovingProject();
            SubmitRemovingProject();
        }

        public void ClickNewProjectButton()
        {
            driver.FindElement(By.CssSelector("button[type=\"submit\"]")).Click();
        }

        public void FillInputForm(string name, string description)
        {
            Type(By.Name("name"), name);
            Type(By.Name("description"), description);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            projectsCache = null;
        }

        public void WaitLoadPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("button[type=\"submit\"]")).Count > 0);
        }

        private List<ProjectData> projectsCache = null;
        public List<ProjectData> GetProjectsList()
        {
            if (projectsCache == null)
            {
                projectsCache = new List<ProjectData>();
                manager.ManageMenu.OpenManageProjectsPage();
                var table = driver.FindElement(By.CssSelector("tbody:first-of-type"));
                ICollection<IWebElement> rows = table.FindElements(By.TagName("tr"));

                foreach (IWebElement element in rows)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    projectsCache.Add(new ProjectData()
                    {
                        Name = cells[0].Text,
                        Description = cells[4].Text
                    }); ;
                }
            }

            return new List<ProjectData>(projectsCache);
        }

        public bool CheckProjects()
        {
            return IsElementPresent(By.CssSelector("a[href*=\"manage_proj_edit_page.php\"]"));
        }

        public void SelectProject(int index)
        {
            driver.FindElements(By.CssSelector("a[href*=\"manage_proj_edit_page.php\"]"))[index].Click();
        }

        public void InitRemovingProject()
        {
            driver.FindElement(By.Id("project-delete-form")).Click();
        }

        public void SubmitRemovingProject()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            projectsCache = null;
        }
    }
}
