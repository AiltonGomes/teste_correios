using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestBuscaCep.Steps
{
    [TestClass]
    public class BuscaCep
    {
        WebDriver driver;
        WebDriverWait esperar;

        [SetUp]
        public void Inicializa()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        }

        [Test]
        public void BuscaCorreios()
        {

            driver.FindElement(By.Id("endereco")).SendKeys("80700000");

            driver.FindElement(By.Id("btn_pesquisar")).Click();

            string titulo = driver.Title;

            Assert.AreEqual(titulo, "Busca CEP");

            driver.FindElement(By.XPath("//a[@class='hamburger'][contains(.,'.')]")).Click();

            driver.FindElement(By.XPath("//a[contains(.,'Por Endereço ou CEP')]")).Click();            

            driver.FindElement(By.Id("endereco")).SendKeys("01013001");

            driver.FindElement(By.Id("btn_pesquisar")).Click();

        }
        
        [TearDown]
        public void Cleanup()
        {
            driver.Close();
        }
    }
}
