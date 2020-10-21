using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.IPG
{
    class IPG_home : BasePage
    {
        public IPG_home(IWebDriver driver) : base(driver) { }

        public IPG_Afiliados Afiliados()
        {
            FindElementBy(By.CssSelector(("a[title='Afiliados']"))).Click();
            return new IPG_Afiliados(driver);
        }

        public IPG_AgregarAfiliados AgregarAfiliados()
        {
            FindElementBy(By.CssSelector(("a[route='/ipg/afiliados/agregar']"))).Click();
        //    FindElementBy(By.CssSelector(("a[title='Agregar Afiliado']"))).Click();
            return new IPG_AgregarAfiliados(driver);
        }




    }
}
