using Microsoft.VisualStudio.TestTools.UnitTesting;
using loginCheckerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginCheckerClass.Tests
{
    [TestClass()]
    public class LoginTest
    {
        [TestMethod()]
        public void Check_login_with_spec_symb_false()
        {
            string testLogin = "adm<>";

            bool expected = false;

            bool actual = LoginCheckMethod.loginCheker(testLogin);

            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void Check_login_without_spec_symb_true()
        {
            string testLogin = "adm";

            bool expected = true;

            bool actual = LoginCheckMethod.loginCheker(testLogin);

            Assert.AreEqual(expected, actual);
        }
    }
}