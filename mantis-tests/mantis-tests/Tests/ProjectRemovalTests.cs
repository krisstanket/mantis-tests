using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "password" };
            appManager.ManageMenu.OpenManagePage();
            appManager.ManageMenu.OpenManageProjectsPage();
            
            if (!appManager.Project.CheckProjects())
            {
                var project = new ProjectData() { Name = "newTestProject" };
                appManager.API.CreateNewProject(account, project);
                appManager.ManageMenu.OpenManageProjectsPage();
            }

            List<ProjectData> oldList = appManager.API.GetProjectsList(account);
            var projectToRemove = oldList[0];
            appManager.Project.RemoveProject(0);
            List<ProjectData> newList = appManager.API.GetProjectsList(account);
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
