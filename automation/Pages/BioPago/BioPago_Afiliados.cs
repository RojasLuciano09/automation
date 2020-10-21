using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automation02.Pages.BioPago
{
    class BioPago_Afiliados : BasePage
    {
        public BioPago_Afiliados(IWebDriver driver) : base(driver) { }

        private String RIF_PlaceHolder = "input[placeholder='RIF']";
        private String NroAfiliado_PlaceHolder = "input[placeholder='Número de Afiliado']";
        private String RazonSocial_PlaceHolder = "input[placeholder='Razón Social']";
        private String Clasificacion_Select = "category"; //ID  
        private String Editar_Button = "a[title='editar']";
        private String Detalle_Button = "a[title='detalle']";
        private String Eliminar_Button = "a[title='eliminar']";
        private String ClavesDeInstalacion_Button = "//div[@class='ng-star-inserted']/ul/li[2]/a";


        private String ClavesDeInstalacionMasiva_Button = "//div[@class='col-md-12 text-right']/button[2]";

        private String UbicacionGeografica_Button = "//div[@class='ng-star-inserted']/ul/li[3]/a";
        private String AsociarEquiposBiometricos_Button = "//div[@class='ng-star-inserted']/ul/li/a";
        private String EnviarClaveDeInstalacion_Button = "//div[@class='col-md-12 text-right']/button[1]";
        private String GeneracionMasivaDeClaves_Button = "//div[@class='col-md-12 text-right']/button[2]";
        private String GenerarClave_Button = "//div[@class='col-md-12 text-right']/button[3]";


        /// <summary>
        /// Busqueda de afiliado utilizando su nro_afiliado.
        /// </summary>
        /// <param name="nro_afiliado"> Valor que se utilizara para realizar la busqueda</param>
        /// <param name="opcion">Valor 0 : Selecciona el boton EDITAR - Valor 1 : Selecciona el boton DETALLE - Valor 2 : Selecciona el boton ELIMINAR - Valor 3 - No realiza ninguna accion </param>
        public Boolean Busqueda_Por_NroAfiliado(String nro_afiliado, int opcion)
        {
            Boolean retorno = false;
            if (nro_afiliado != null && opcion != null)
            {
                FindElementBy(By.CssSelector(NroAfiliado_PlaceHolder)).SendKeys(nro_afiliado); //  72414241
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                Assert.IsTrue(tabla_reader_temp(nro_afiliado));
                Switch_entre_opciones(opcion);
                retorno = true;
            }

            return retorno;
        }

        public Boolean Busqueda_Por_RIF(String RIF, int opcion)
        {
            Boolean retorno = false;
            if (RIF != null && opcion != null)
            {
                FindElementBy(By.CssSelector(RIF_PlaceHolder)).SendKeys(RIF);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                Assert.IsTrue(tabla_reader_temp(RIF));
                Switch_entre_opciones(opcion);

                retorno = true;
            }

            return retorno;
        }


        public Boolean Busqueda_Por_RazonSocial(String RazonSocial, int opcion)
        {
            Boolean retorno = false;
            if (RazonSocial != null && opcion != null)
            {
                FindElementBy(By.CssSelector(RazonSocial_PlaceHolder)).SendKeys(RazonSocial);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                Assert.IsTrue(tabla_reader_temp(RazonSocial));
                Switch_entre_opciones(opcion);
                retorno = true;
            }
            return retorno;
        }

        /// Busqueda por Clasificacion. El parametro recibe el valor de clasificacion a buscar.
        /// No le agregue EDITAR-DETALLE-ELIMINAR por que deberia crear otro metodo similar a tabla_reader_temp         
        /// el nuevo deberia recorrer entre los tr, si la condicion se cumple, tomara el indice donde se encuentre el tr, y sobre ese utilizar las opciones.
        public Boolean Busqueda_Por_Clasificacion(String Clasificacion)
        {
            Boolean retorno = false;
            if (Clasificacion != null)
            {
                seleccionarDelDesplegable(FindElementBy(By.Id(Clasificacion_Select)), Clasificacion);
                FindElementBy(By.CssSelector(Buscar_Button)).Click();
                Assert.IsTrue(tabla_reader_temp(Clasificacion));
                retorno = true;
            }
            return retorno;
        }

        public void GenerarClaveDeInstalacion()
        {
                FindElementBy(By.XPath(ClavesDeInstalacion_Button)).Click();
                FindElementBy(By.XPath(GenerarClave_Button)).Click();
        }

        public void GenerarClaveDeInstalacionMasiva()
        {
            FindElementBy(By.XPath(ClavesDeInstalacion_Button)).Click();
            FindElementBy(By.XPath(ClavesDeInstalacionMasiva_Button)).Click();
            FindElementBy(By.XPath("//div[@class='modal-content']/div[2]/div/input")).SendKeys("1");
            FindElementBy(By.XPath("//div[@class='modal-content']/div[2]/div[2]/div/button[1]")).Click();
        }



        public Boolean confirmarEliminar()
        {
            FindElementBy(By.XPath(ClavesDeInstalacion_Button)).Click();
            FindElementBy(By.ClassName("mx-1")).Click();
            Thread.Sleep(2000);
            FindElementBy(By.ClassName("swal-button-container")).Click();

            return true;
        }
       public Boolean ClaveEliminada()
        {

            element_auxiliar = FindElementBy(By.ClassName("toast-title"));

            if (element_auxiliar.Text.Equals("Clave Eliminada"))
            {
                FindElementBy(By.ClassName("toast-close-button")).Click();
                return true;
            }
            return false;

        }
        public Boolean MensajeSuccess()
        {
            element_auxiliar = FindElementBy(By.ClassName("toast-title"));

            if (element_auxiliar.Text.Equals("Clave Generada"))
            {
                FindElementBy(By.ClassName("toast-close-button")).Click();
                return true;
            }
            return false;

        }

        public Boolean MensajeMaxError()
        {
            element_auxiliar = FindElementBy(By.ClassName("toast-title"));

            if (element_auxiliar.Text.Equals("Error"))
            {
                FindElementBy(By.ClassName("toast-close-button")).Click();
                return true;
            }
            return false;

        }

        public Boolean ModificarCorreoElectrnico(String email)
        {
            Boolean retorno = false;
            if (email!=null) 
            {
                FindElementBy(By.Id("email")).Clear();
                FindElementBy(By.Id("email")).SendKeys(email);
                if (FindElementBy(By.CssSelector("p[class='text-danger m-0 ng-star-inserted']")).Text.Equals("Correo no válido")) 
                {
                    retorno = true;
                }
                
            }
            return retorno;
        }










        /// <summary>
        /// Este metodo selecciona la opcion de cada Afiliado según el valor del parametro que ingrese.
        /// </summary>
        /// <param name="opcion"> Valor 0 : Selecciona el boton EDITAR - Valor 1 : Selecciona el boton DETALLE - Valor 2 : Selecciona el boton ELIMINAR - </param>
        private void Switch_entre_opciones(int opcion)
        {
            switch (opcion)
            {
                case 0:
                    FindElementBy(By.CssSelector(Editar_Button)).Click();
                    break;
                case 1:
                    FindElementBy(By.CssSelector(Detalle_Button)).Click();
                    break;
                case 2:
                    FindElementBy(By.CssSelector(Eliminar_Button)).Click();
                    break;
                default: //Por si no se desea realizar ninguna accion.
                    break;
            }
        }












    }
}