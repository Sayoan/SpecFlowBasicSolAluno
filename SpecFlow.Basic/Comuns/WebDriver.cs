using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Basic.Comuns
{
    class WebDriver
    {
        [SetUp]
        public void Setup()
        {
            DriverFactory.CreateInstance();
            DriverFactory.INSTANCE.Navigate().GoToUrl("https://homoaca-php.animaeducacao.com.br/branches/base2/SOL/aluno/index.php/index/seguranca/dev/instituicao/1");
        }


        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitInstace();
        }
    }
}
