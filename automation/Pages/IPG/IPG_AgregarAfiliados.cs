using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automation02.Pages.IPG
{
    class IPG_AgregarAfiliados : BasePage
    {
        public IPG_AgregarAfiliados(IWebDriver driver) : base(driver) { }


        private String RIF_PlaceHolder = "input[placeholder='RIF']";
        private String NroAfiliado_PlaceHolder = "input[placeholder='Número de Afiliado']";
        private String RazonSocial_PlaceHolder = "input[placeholder='Razón Social']";
        private String Clasificacion_Select = "category"; //ID


        public void Busqueda_Por_NroAfiliado(String nro_afiliado)
        {
            FindElementBy(By.CssSelector(NroAfiliado_PlaceHolder)).SendKeys(nro_afiliado); //  72414241
            FindElementBy(By.CssSelector(Buscar_Button)).Click();
            Assert.IsTrue(tabla_reader_temp(nro_afiliado));
        }
        public void Busqueda_Por_RIF(String RIF)
        {
            FindElementBy(By.CssSelector(RIF_PlaceHolder)).SendKeys(RIF);
            FindElementBy(By.CssSelector(Buscar_Button)).Click();
            Assert.IsTrue(tabla_reader_temp(RIF));
        }
        public void Busqueda_Por_RazonSocial(String RazonSocial)
        {
            FindElementBy(By.CssSelector(RazonSocial_PlaceHolder)).SendKeys(RazonSocial);
            FindElementBy(By.CssSelector(Buscar_Button)).Click();
            Assert.IsTrue(tabla_reader_temp(RazonSocial));          
        }

        public void boton_agregar() 
        {
            FindElementBy(By.CssSelector("a[title='agregar']")).Click();
            FindElementBy(By.Id("email")).SendKeys("sendAFruit@gmail.com");
            FindElementBy(By.XPath("//div[class='row']/div/button[1]")).Click();
            seleccionarDelDesplegable(FindElementBy(By.Id("authenticationType")),"Email");
        }



    }//clase
}   //namespace

