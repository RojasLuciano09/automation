using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.BioPago
{
    class BioPago_AdministracionDeEquipos : BasePage
    {
        public BioPago_AdministracionDeEquipos(IWebDriver driver) : base(driver) { }

        private String NumeroDeSerie_PlaceHolder = "input[placeholder='Número de Serie']";
        private String NumeroDeAfiliado_PlaceHolder = "input[placeholder='Número de Afiliado']";
        private String RazonSocial_PlaceHolder = "input[placeholder='Razón Social']";
        private String Disponible_Select = "isAvailable"; // ID
        private String Tipo_Select = "type"; // ID
        private String Propietario_Select = "owner"; //ID
        private String Buscar_Button = "button[class='btn btn-inverse btn-lg mt-2 ml-2']";
        private String Borrar_Button = "button[class='btn btn-secondary btn-lg mt-2 ml-2']";
        public void temp() 
        {
            seleccionarDelDesplegable(FindElementBy(By.Id(Disponible_Select)),"No");
            FindElementBy(By.CssSelector(Buscar_Button)).Click();





         //tablareader
        }





    }
}
