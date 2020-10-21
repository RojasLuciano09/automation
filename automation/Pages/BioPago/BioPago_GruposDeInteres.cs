using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.BioPago
{
    class BioPago_GruposDeInteres : BasePage
    {
        public BioPago_GruposDeInteres(IWebDriver driver) : base(driver){}

        private String Nombre_PlaceHolder = "input[placeholder='Nombre']";
        private String AgregarGrupoDeInteres_Button = "button[class='btn btn-secondary btn-lg']"; //class
        //CrearGrupoDeInteres
        private String Name_PlaceHolder = "name"; //id
        private String Guardar_Button = "button[class='btn btn-inverse btn-lg mx-3 ng-star-inserted']";
        private String Descripcion_PlaceHolder = "description"; //id
      


        public void temp() 
        {
            FindElementBy(By.CssSelector(Nombre_PlaceHolder)).SendKeys("PruebasAutomatizadas");
            FindElementBy(By.CssSelector(Nombre_PlaceHolder)).Click();
            FindElementBy(By.CssSelector(Buscar_Button)).Click();
            FindElementBy(By.CssSelector(AgregarGrupoDeInteres_Button)).Click();
            FindElementBy(By.Id(Name_PlaceHolder)).SendKeys("PruebasAutomatizadas");
            FindElementBy(By.Id(Descripcion_PlaceHolder)).SendKeys("PruebasAutomatizadasDescripcion");
            FindElementBy(By.CssSelector(Guardar_Button)).Click();

        }

    }
}
