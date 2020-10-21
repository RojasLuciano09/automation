using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace automation02.Pages
{
    /// <summary>
    /// Todas las clases deben heredar esta.
    /// Esas clases deben tener un 
    /// public constructor(IWebDriver driver) : base(driver) { }
    /// </summary>

    class BasePage


    {
        /// <summary>
        /// time : Representa el tiempo maximo antes de que podamos obtener un TIMEOUT
        /// </summary>
        private TimeSpan time = TimeSpan.FromSeconds(10);
        public IWebDriver driver;
        protected WebDriverWait wait;
        private IJavaScriptExecutor js;
        protected IWebElement element = null;
        public IWebElement element_auxiliar;
        public int count_auxiliar;


        /// <summary>
        /// Constructor de la clase, asignando al driver con que 'driver' comenzar.
        /// </summary>
        /// <param name="driver">Recibe un driver por parametro</param>
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, time);
        }

        /*
        private static Queue<DateTime> eventQueue = new Queue<DateTime>();
        private static int timeWindowSeconds = 60;
        private static int threshold = 3;

        private static void TestEvent(object src, EventArgs mea)
        {
            DateTime now = DateTime.UtcNow;
            DateTime tooOld = now.AddSeconds(-timeWindowSeconds);

            // remove old entries
            while ((eventQueue.Count > 0) && (eventQueue.Peek() < tooOld))
            {
                eventQueue.Dequeue();
            }

            // add new entry
            eventQueue.Enqueue(now);

            // test for condition
            if (eventQueue.Count >= threshold)
            {
                eventQueue.Clear();
                DoSomething();
            }
        }
        */  // ADAPTAR 













        /// <summary>
        /// Metodo que realiza una espera hasta que el objecto aparezca en el DOM, o si se llega al timeout lanzara una Exeption
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public IWebElement FindElementBy(By by)
        {
            if (readyState())
            {

                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by))));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                moverHasta(element);
            }
            return element;
        }

        /// <summary>
        /// Metodo privado de Javascript para tener posibilidades de utilizar sus metodos.
        /// </summary>
        /// <returns></returns>
        private Boolean readyState()
        {
            Thread.Sleep(500);
            js = (IJavaScriptExecutor)driver;
            if (js.ExecuteScript("return document.readyState").Equals("complete"))
            {
                if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader-inner"))))
                {
                    return true;
                }
            }
            return false;
        }


        private void moverHasta(IWebElement anotherElement)
        {
            var firstAction = new Actions(driver);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(anotherElement));
            firstAction.MoveToElement(anotherElement).Perform();
        }





        public String Buscar_Button = "button[class='btn btn-inverse btn-lg mt-2 ml-2']";
        public String Borrar_Button = "button[class='btn btn-secondary btn-lg mt-2 ml-2']";
        public void seleccionarDelDesplegable(IWebElement element, String opcion)
        {
            element.Click();
            SelectElement new_select = new SelectElement(element);
            IList<IWebElement> options = element.FindElements(By.TagName("option"));
            foreach (IWebElement runOverOptions in options)
            {
                if (runOverOptions.Text.Contains(opcion))
                {
                    driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", element);
                    new_select.SelectByText(runOverOptions.Text);
                }
            }
        }

        /// <summary>
        /// Para futuro. Si la tabla trae mas de un resultado utilizar xpath   "//*[@class='table']/tbody/tr/td[7]/a[2]" a[1] editar , a[2] detalle , a[3] eliminar
        /// Nota: 1 resultado  tr    // 1> tr[] y inicia en 1 
        /// </summary>
        protected Boolean tabla_reader_temp(String texto_A_Validar)
        {
            element_auxiliar = FindElementBy(By.ClassName("table"));
            IList<IWebElement> tr = element_auxiliar.FindElements(By.TagName("tr"));
            foreach (IWebElement runOverTr in tr)
            {
                IList<IWebElement> td = element_auxiliar.FindElements(By.TagName("td"));
                foreach (IWebElement runOverTd in td)
                {
                    if (runOverTd.Text.Contains(texto_A_Validar))
                    {
                        return true;
                    }
                }
            }
            return false;
        }




    }//clase
}
