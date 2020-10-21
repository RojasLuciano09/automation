using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.BioPago
{/// <summary>
/// Esta clase deriva hacia los sub menus de BIOPADO sean : ADMINISTRACION DE EQUIPOS - AREGAR EQUIPO - CARGA MASIVA DE EQUIPOS - AFILIADOS - AGREGAR AFILIADO - GRUPO DE INTERES
/// 
/// </summary>
    class BioPago_home : BasePage
    {
        public BioPago_home(IWebDriver driver) : base(driver) { }

        public BioPago_AdministracionDeEquipos administracionDeEquipos()
        {
            FindElementBy(By.CssSelector(("a[title='Administración de Equipos']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_AdministracionDeEquipos(driver);
        }
        public BioPago_Afiliados afiliados()
        {
            FindElementBy(By.CssSelector(("a[title='Afiliados']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_Afiliados(driver);
        }
        public BioPago_AgregarAfiliado agregarAfiliados()
        {
            FindElementBy(By.CssSelector(("a[title='Agregar Afiliado']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_AgregarAfiliado(driver);
        }
        public BioPago_AgregarEquipo agregarEquipo()
        {
            FindElementBy(By.CssSelector(("a[title='Agregar Equipo']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_AgregarEquipo(driver);
        }
        public BioPago_CargaMasivaDeEquipos CargaMasivaDeEquipos()
        {
            FindElementBy(By.CssSelector(("a[title='Carga Masiva de Equipos']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_CargaMasivaDeEquipos(driver);
        }
        public BioPago_GruposDeInteres GruposDeInteres()
        {
            FindElementBy(By.CssSelector(("a[title='Grupos de Interés']"))).Click(); //Revisar si se encuentra dentro de la etiqueta. 
            return new BioPago_GruposDeInteres(driver);
        }

    }
}
