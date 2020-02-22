using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            var projectsArray = client.mc_projects_get_user_accessible(account.Name, account.Password);
            projectsArray.ToList();
            List<ProjectData> projects = new List<ProjectData>();
            foreach (Mantis.ProjectData project in projectsArray)
            {
                projects.Add(new ProjectData() 
                { 
                    Name = project.name
                });
            }
            return projects;
        }

        public void CreateNewProject(AccountData account, ProjectData projectTest)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();
            project.name = projectTest.Name;
            client.mc_project_add(account.Name, account.Password, project);
        }
    }
}
