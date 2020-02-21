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
            appManager.ManageMenu.OpenManagePage();
            appManager.ManageMenu.OpenManageProjectsPage();
            
            if (!appManager.Project.CheckProjects())
            {
                var project = new ProjectData() { Name = "newProject" };
                appManager.Project.CreateProject(project);
            }

            List<ProjectData> oldList = appManager.Project.GetProjectsList();
            var projectToRemove = oldList[0];
            appManager.Project.RemoveProject(0);
            List<ProjectData> newList = appManager.Project.GetProjectsList();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
