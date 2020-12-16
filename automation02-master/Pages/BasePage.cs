using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

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



        /// <summary>
        /// Constructor de la clase, asignando al driver con que 'driver' comenzar.
        /// </summary>
        /// <param name="driver">Recibe un driver por parametro</param>
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, time);
        }


        /// <summary>
        /// Metodo que realiza una espera hasta que el objecto aparezca en el DOM, o si se llega al timeout lanzara una Exeption
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public IWebElement FindElementBy(By by)
        {
            if (readyState())
            {
                WaitUntilElementNotVisible(By.Id("gxModalWindowDiv"), 15);
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by))));
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            return element;
        }

        /// <summary>
        /// Metodo privado de Javascript para tener posibilidades de utilizar sus metodos.
        /// </summary>
        /// <returns></returns>
        private Boolean readyState()
        {
            js = (IJavaScriptExecutor)driver;
            if (js.ExecuteScript("return document.readyState").Equals("complete"))
            {
                return true;
            }
            return false;
        }

        protected void WaitUntilElementNotVisible(By searchElementBy, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                            .Until(drv => !IsElementVisible(searchElementBy));
        }

        private bool IsElementVisible(By searchElementBy)
        {
            try
            {
            //    Thread.Sleep(500);
                return driver.FindElement(searchElementBy).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
















    }//clase
}
