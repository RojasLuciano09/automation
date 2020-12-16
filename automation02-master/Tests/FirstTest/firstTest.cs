using automation02.Pages.FirstPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace automation02.Tests.FirstTest
{                   //BaseTest

    class firstTest : Tests
    {
        String aux;


        [Test]
        public void loginOK()
        {
            firstPage instancia_first_page = new firstPage(driver);
            instancia_first_page.Login("admin", "12345");
            Assert.IsTrue(true);
        }

        [Test]
        public void LoginFAIL()
        {
            firstPage instancia_first_page = new firstPage(driver);
            instancia_first_page.Login("admin", "-----");
            Assert.IsFalse(true);
        }






    }
}

