using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace SpecFlow.Basic
{
    [Binding]
    public class SolAlunoAtivoSteps
    {
        public IWebDriver driver;
        
        [Given(@"Acesso a pagina de login do Sol Aluno")]
        public void UsuarioAcessaSolAluno()
        {
            driver = new ChromeDriver();
            driver.Url = "https://homoaca-php.animaeducacao.com.br/branches/base2/SOL/aluno/index.php/index/seguranca/dev/instituicao/1";
        }

        [When(@"Entro com as credenciais(.*) e(.*)")]
        public void AlunoInsereUsuarioSenha(string username, string password)
        {
            driver.FindElement(By.Name("matricula")).Clear();
            driver.FindElement(By.Name("matricula")).SendKeys(username);
            driver.FindElement(By.Name("senha")).Clear();
            driver.FindElement(By.Name("senha")).SendKeys(password);
        }

        [When(@"Clico no botao Login")]
        public void AlunoClicaLogin()
        {
            Thread.Sleep(4000);
            driver.FindElement(By.Id("logar")).Click();
        }

        [Then(@"Deve entrar na pagina inicial do Sol Aluno")]
        public void ValidacaoAcessoAluno()
        {
            Thread.Sleep(10000);
            String URL = driver.Url;
            Assert.AreEqual(URL, "https://homoaca-php.animaeducacao.com.br/branches/base2/SOL/aluno/index.php/");

            driver.Quit();
        }

        [Then(@"Deve aparecer uma mensagem de alerta 'Login ou senha inválido'")]
        public void AlertaFalhaLogin()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button/span")).Click();
            driver.Quit();
        }
    }
}
