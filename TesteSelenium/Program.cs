using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TesteSelenium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o robo");

            ChromeDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            driver.Navigate().GoToUrl("http://localhost:8183");

            var title = driver.Title;

            var emailBox = driver.FindElement(By.Id("txtEmailUsuario"));
            var senhaBox = driver.FindElement(By.Id("txtSenhaUsuario"));
            var submitButton = driver.FindElement(By.Id("btnEntrar"));

            emailBox.SendKeys("teste@teste");
            senhaBox.SendKeys("123");

            submitButton.Click();

            driver.Navigate().GoToUrl("http://localhost:8183/TelaAdministrador_Adicionar.aspx");

            var nome = driver.FindElement(By.Id("MainContent_txtNome"));
            nome.SendKeys("misael");

            var email = driver.FindElement(By.Id("MainContent_txtEmail"));
            email.SendKeys("misael@teste.com");            

            driver.ExecuteScript("var script=document.createElement('script'); script.type = 'text/javascript'; script.text=`var el = document.getElementById('MainContent_txtSenha'); el.addEventListener('change', myScript); function myScript() { alert('mudou'); }`; document.body.appendChild(script);");

            Thread.Sleep(3000);
            
            Console.WriteLine("ok");

            driver.Quit();

            //testeWait();
        }

        public static void testeWait()
        {
            ChromeDriver driver = new ChromeDriver();

            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.FindElement(By.Id("reveal")).Click();

            wait.Until(d => 
            revealed.Displayed
            );

            revealed.SendKeys("Displayed");
            //Assert.AreEqual("Displayed", revealed.GetDomProperty("value"));

        }
    }
}
