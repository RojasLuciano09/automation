using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.FirstPage
{
    class firstPage : BasePage
    {
        /// Inicio Variables
        private String url = "http://demo.guru99.com/test/facebook.html";

        private String id = "email";
        private String pass = "pass";
        private String button_log = "u_0_b";


        ///Fin Variables.



        public firstPage(IWebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(url);
        }

        ///Inicio Metodos



        public void Login(String usuario, String contrasenia)
        {
            FindElementBy(By.Id(id)).SendKeys(usuario);
            FindElementBy(By.Id(pass)).SendKeys(contrasenia);
            FindElementBy(By.Id(button_log)).Click();

        }


        public String actualurl()
        {
            return driver.Url;
        }




        ///Fin Metodos







    }
}
