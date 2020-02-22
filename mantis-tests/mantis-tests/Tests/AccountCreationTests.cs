using System;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            appManager.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(
                "C:/Users/MI/source/repos/krisstanket/mantis-tests/mantis-tests/mantis-tests/config_inc.php", 
                FileMode.Open))
            {
                appManager.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            appManager.Ftp.RestoreBackupFile("/config_inc.php");
        }

        [Test]
        public void AccountRegistrationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            appManager.James.Delete(account);
            appManager.James.Add(account);
            appManager.Registration.Register(account);

        }
    }
}
