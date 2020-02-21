using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class CreationProjectTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            appManager.ManageMenu.OpenManagePage();
            appManager.ManageMenu.OpenManageProjectsPage();

            List<ProjectData> oldList = appManager.Project.GetProjectsList();
            var newProject = new ProjectData() { Name = "testProject"};

            appManager.Project.CreateProject(newProject);
            List<ProjectData> newList = appManager.Project.GetProjectsList();

            oldList.Add(newProject);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
