using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace mantis_tests
{
    public class JamesHelper : HelperBase
    {
        public JamesHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("adduser " + account.Name + " " + account.Password);
            telnet.Read();
        }

        public void Delete(AccountData account)
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("deluser " + account.Name);
            telnet.Read();
        }

        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LoginToJames();
            telnet.WriteLine("verify " + account.Name + " " + account.Password);
            string s = telnet.Read();
            return !s.Contains("does not exist");

        }
        private TelnetConnection LoginToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            telnet.Read();
            telnet.WriteLine("root");
            telnet.Read();
            telnet.WriteLine("root");
            telnet.Read();
            return telnet;
        }
    }
}
