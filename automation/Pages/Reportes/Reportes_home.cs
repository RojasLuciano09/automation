using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.Reportes
{
    class Reportes_home : BasePage
    {
        public Reportes_home(IWebDriver driver) : base(driver) { }

        public Reportes_Afiliados Afiliados()
        {
            FindElementBy(By.CssSelector(("a[route='/reportes/afiliados']"))).Click();
            return new Reportes_Afiliados(driver);
        }

        public Reportes_Equipos Equipos()
        {
            FindElementBy(By.CssSelector(("a[title='Equipos']"))).Click();
            return new Reportes_Equipos(driver);
        }

        public Reportes_HistorialDeEquipos HistorialDeEquipos()
        {
            FindElementBy(By.CssSelector(("a[title='Historial de Equipos']"))).Click();
            return new Reportes_HistorialDeEquipos(driver);
        }


        public Reportes_IPG_Transacciones Transacciones()
        {
            FindElementBy(By.CssSelector(("a[title='IPG - Transacciones']"))).Click();
            return new Reportes_IPG_Transacciones(driver);
        }

        public Reportes_ReporteDeInactividad ReporteDeInactividad()
        {
            FindElementBy(By.CssSelector(("a[title='Reporte de Inactividad']"))).Click();
            return new Reportes_ReporteDeInactividad(driver);
        }

        public Reportes_TransaccionesAnuladaHOY TransaccionesAnuladas()
        {
            FindElementBy(By.CssSelector(("a[route='/reportes/transacciones_anulacion_id']"))).Click();
            return new Reportes_TransaccionesAnuladaHOY(driver);
        }

        public Reportes_TransaccionesDeCompraHOY TransaccionesDeCompra()
        {
            FindElementBy(By.CssSelector(("a[route='/reportes/transacciones_compras_id']"))).Click();
            return new Reportes_TransaccionesDeCompraHOY(driver);
        }

        
    
    }
}
