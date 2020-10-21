using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.Reportes
{
    class Reportes_Afiliados : BasePage
    {
        public Reportes_Afiliados(IWebDriver driver) : base(driver){}

        private String RIF_PlaceHolder = "input[placeholder='RIF']";
        private String NroAfiliado_PlaceHolder = "input[placeholder='Nro Afiliado']";
        private String RazonSocial_PlaceHolder = "input[placeholder='Razón Social']";
        private String Clasificacion_Select = "category"; //ID
        private String Ubicacion_Select = "stateLocation"; //ID                  ///Anzoategui
        private String AreaGeografica_Select = "geographicArea"; //ID          San Martin, Los Molinos
        private String exportar_button = "button[class='btn btn-inverse m-2']";


   
    
        public Boolean Filtro_busquedaPorRIF(String rif) 
        {
            Boolean retorno = false;
            if (rif!=null) 
            {
                FindElementBy(By.CssSelector(RIF_PlaceHolder)).SendKeys(rif);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                if (tabla_reader_temp(rif))
                {
                    FindElementBy(By.CssSelector(exportar_button)).Click();
                    retorno = true;
                }
            }
            return retorno;
        }

        public Boolean Filtro_busquedaPorNroAfiliado(String nroAfiliado)
        {
            Boolean retorno = false;
            if (nroAfiliado != null)
            {
                FindElementBy(By.CssSelector(NroAfiliado_PlaceHolder)).SendKeys(nroAfiliado);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();

                if (tabla_reader_temp(nroAfiliado))
                {
                    FindElementBy(By.CssSelector(exportar_button)).Click();
                    retorno = true;
                }
              
            }
            return retorno;
        }

        public Boolean Filtro_busquedaPorRazonSocial(String razonsocial)
        {
            Boolean retorno = false;
            if (razonsocial != null)
            {
                FindElementBy(By.CssSelector(RazonSocial_PlaceHolder)).SendKeys(razonsocial);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                if (tabla_reader_temp(razonsocial))
                {
                    FindElementBy(By.CssSelector(exportar_button)).Click();
                    retorno = true;
                }
            }
            return retorno;
        }









    }
}
