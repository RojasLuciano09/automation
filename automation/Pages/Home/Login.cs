using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.Home
{
    class Login : BasePage
    {

        private String user = "userName";
        private String pass = "password";
        private String url = "https://192.168.0.99/Biopago2/WebAdmin/home"; //QA
        // private String url = "https://192.168.0.91/Biopago2/WebAdmin/home"; //DEV

         

        public Login(IWebDriver driver) : base(driver) { driver.Navigate().GoToUrl(url); }


        public Home login(String usuario, String contrasenia)
        {
            FindElementBy(By.Id(user)).SendKeys(usuario);
            FindElementBy(By.Id(pass)).SendKeys(contrasenia);
            FindElementBy(By.CssSelector("div[class='col-md-12 mb-3']")).Click();
            return new Home(driver);
        }





    }
}
