using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow.Basic.Steps
{
    [Binding]
    public class SolFeatureSteps
    {
        public IWebDriver driver;
        public ExtentReports report { get; set; }
        private static KlovReporter klov;

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

            /*********************/
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\sayoan.oliveira\Documents\SpecFlowBasicSolAluno\SpecFlow.Basic\Logs\extendReport.html");

            report = new ExtentReports();

            klov = new KlovReporter();
            klov.InitMongoDbConnection("ABHNTBNSI2964", 27017);
            klov.ProjectName = "SpecFlow Test";

            klov.KlovUrl = "http://abhntbnsi2964:899";
            klov.ReportName = "Base2 SpecFlow" + DateTime.Now.ToString();

            report.AttachReporter(htmlReporter, klov);


            var feature = report.CreateTest<Feature>("Sol Aluno - Login");
            var scenario = feature.CreateNode<Scenario>("Aluno Ativo acessa Sol Aluno");
            scenario.CreateNode<Given>("Acesso a pagina de login do Sol Aluno").Pass("pass");
            scenario.CreateNode<And>("Entro com as credenciais username e password").Pass("pass");
            scenario.CreateNode<When>("Clico no botao Login").Pass("pass");
            scenario.CreateNode<Then>("Deve entrar na pagina inicial do Sol Aluno").Pass("pass");
            
            report.Flush();
            /*********************/
            driver.Quit();
        }

        [Then(@"Deve aparecer uma mensagem de alerta 'Login ou senha inválido'")]
        public void AlertaFalhaLogin()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//button/span")).Click();

            /*********************/
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\sayoan.oliveira\Documents\SpecFlowBasicSolAluno\SpecFlow.Basic\Logs\extendReport.html");

            report = new ExtentReports();

            klov = new KlovReporter();
            klov.InitMongoDbConnection("ABHNTBNSI2964", 27017);
            klov.ProjectName = "SpecFlow Test";

            klov.KlovUrl = "http://abhntbnsi2964:899";
            klov.ReportName = "Base2 SpecFlow" + DateTime.Now.ToString();

            report.AttachReporter(htmlReporter, klov);


            var feature = report.CreateTest<Feature>("Sol Aluno - Login");
            var scenario = feature.CreateNode<Scenario>("Aluno Ativo acessa Sol Aluno");
            scenario.CreateNode<Given>("Acesso a pagina de login do Sol Aluno").Pass("pass");
            scenario.CreateNode<And>("Entro com as credenciais username e password").Pass("pass");
            scenario.CreateNode<When>("Clico no botao Login").Pass("pass");
            scenario.CreateNode<Then>("Deve aparecer uma mensagem de alerta 'Login ou senha inválido'").Pass("pass");

            
            report.Flush();
            /*********************/

            driver.Quit();
        }
    }
}
