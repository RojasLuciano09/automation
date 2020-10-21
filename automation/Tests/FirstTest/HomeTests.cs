using automation02.Pages.Home;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Tests.FirstTest
{
    class HomeTests : Tests
    {

        [Test]
        public void login()
        {
            Login newLogin = new Login(driver);
            Home bp = newLogin.login("test", "Pa$$word001");

            bp.biopago();

        }







    }
}
