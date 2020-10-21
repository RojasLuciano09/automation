using automation02.Pages.BioPago;
using automation02.Pages.Bitacoras;
using automation02.Pages.IPG;
using automation02.Pages.Reportes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automation02.Pages.Home
{/// <summary>
/// Esta clase deriva hacia las primera opciones generales de biopago. Sean : BIOPAGO - IPG - ADMINISTRACIÓN - BITACORAS - REPORTES
///
/// </summary>
    class Home : BasePage
    {
        public Home(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Opcion principal de BioPago.
        /// </summary>
        /// <returns></returns>
        public BioPago_home biopago()
        {
            FindElementBy(By.CssSelector(("a[title='BioPago']"))).Click();
            return new BioPago_home(driver);
        }

        public IPG_home ipg()
        {
            Thread.Sleep(500);
            FindElementBy(By.CssSelector(("a[title='IPG']"))).Click();
            return new IPG_home(driver);
        }

        public Reportes_home reportes()
        {
            FindElementBy(By.CssSelector(("a[title='Reportes']"))).Click();
            return new Reportes_home(driver);
        }


        public Bitacoras_ExTransaccionesPendientes bitacoras()
        {
            FindElementBy(By.CssSelector(("a[title='Bitacoras']"))).Click();    //Revisar la tilde 
            return new Bitacoras_ExTransaccionesPendientes(driver);
        }







    }
}
