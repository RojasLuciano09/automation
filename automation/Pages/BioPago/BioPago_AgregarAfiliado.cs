using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.BioPago
{
    class BioPago_AgregarAfiliado : BasePage
    {

        public BioPago_AgregarAfiliado(IWebDriver driver) : base(driver) { }

        private String RIF_PlaceHolder = "input[placeholder='RIF']";
        private String NroAfiliado_PlaceHolder = "input[placeholder='Número de Afiliado']";
        private String RazonSocial_PlaceHolder = "input[placeholder='Razón Social']";
        private String acciones_agregar = "a[title='agregar']";
        private String Afiliar_Button = "button[class='btn btn-inverse btn-lg mx-3 ng-star-inserted']";
        private String tipo_de_afiliacion = "connectionType";

        private String Clasificacion_Select = "category"; //ID  

        public Boolean busqueda_por_nro_afiliado(String nro_afiliado)
        {
            Boolean retorno = false;
            if (nro_afiliado != null)
            {
                FindElementBy(By.CssSelector(NroAfiliado_PlaceHolder)).SendKeys(nro_afiliado);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                if (tabla_reader_temp(nro_afiliado))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public Boolean busqueda_por_rif(String nro_RIF)
        {
            Boolean retorno = false;
            if (nro_RIF != null)
            {
                FindElementBy(By.CssSelector(RIF_PlaceHolder)).SendKeys(nro_RIF);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                if (tabla_reader_temp(nro_RIF))
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public Boolean busqueda_por_RazonSocial(String RazonSocial)
        {
            Boolean retorno = false;
            if (RazonSocial != null)
            {
                FindElementBy(By.CssSelector(RazonSocial_PlaceHolder)).SendKeys(RazonSocial);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                if (tabla_reader_temp(RazonSocial))
                {
                    retorno = true;
                }
            }
            return retorno;
        }







        public Boolean agregar_afiliado(String email, String cantidad_de_claves)
        {
            Boolean retorno = false;
            if (email != null && cantidad_de_claves != null)
            {
                FindElementBy(By.CssSelector(acciones_agregar)).Click();
                FindElementBy(By.Id("email")).Clear();
                FindElementBy(By.Id("email")).SendKeys(email);
                FindElementBy(By.Id("installationKeys")).Clear();
                FindElementBy(By.Id("installationKeys")).SendKeys(cantidad_de_claves);
                seleccionarDelDesplegable(FindElementBy(By.Id(tipo_de_afiliacion)), "Conexión Directa");
                FindElementBy(By.CssSelector(Afiliar_Button)).Click();
                retorno = true;
            }   
            return retorno;
        }





    }
}
