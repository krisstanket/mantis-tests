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
            AccountData account = new AccountData() { Name = "administrator", Password = "password"};

            List<ProjectData> oldList = appManager.API.GetProjectsList(account);
            var newProject = new ProjectData() { Name = "testNewProject"};

            appManager.Project.CreateProject(newProject);
            List<ProjectData> newList = appManager.API.GetProjectsList(account);

            oldList.Add(newProject);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
