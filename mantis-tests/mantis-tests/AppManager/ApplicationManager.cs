using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;


        private static ThreadLocal<ApplicationManager> appManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver(@"C:\Users\MI\Downloads");
            baseURL = "http://localhost/mantisbt-2.23.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Admin = new AdminHelper(this, baseURL);
            Login = new LoginHelper(this);
            ManageMenu = new ManagementMenuHelper(this);
            Project = new ProjectManagementHelper(this);
            API = new APIHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public RegistrationHelper Registration { get; set; }

        public FtpHelper Ftp { get; set; }

        public JamesHelper James { get; set; }

        public MailHelper Mail { get; set; }

        public APIHelper API { get; set; }

        public AdminHelper Admin { get; set; }

        public LoginHelper Login { get; set; }

        public ManagementMenuHelper ManageMenu { get; set; }

        public ProjectManagementHelper Project { get; set; }
        public static ApplicationManager GetInstance()
        {
            if ( ! appManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.23.0/login_page.php";
                appManager.Value = newInstance;   
            }
            return appManager.Value;
        }

        public IWebDriver Driver 
        { 
            get
            {
                return driver;
            }
        }
    }
}
