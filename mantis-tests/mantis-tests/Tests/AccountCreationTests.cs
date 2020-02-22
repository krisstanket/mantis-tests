using System;
using System.Collections.Generic;
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
            List<AccountData> accounts = appManager.Admin.GetAllAccounts();
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                appManager.Admin.DeleteAccount(existingAccount);
            }
            
            appManager.James.Delete(account);
            appManager.James.Add(account);
            appManager.Registration.Register(account);

        }
    }
}
