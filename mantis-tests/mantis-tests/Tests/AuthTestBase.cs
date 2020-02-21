﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            appManager.Login.Login(new AccountData() 
            { 
                Name = "administrator",
                Password = "password"
            });
        }
    }
}
