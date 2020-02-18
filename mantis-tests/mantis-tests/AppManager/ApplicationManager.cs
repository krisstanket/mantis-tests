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
            baseURL = "http://localhost/addressbook/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
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
