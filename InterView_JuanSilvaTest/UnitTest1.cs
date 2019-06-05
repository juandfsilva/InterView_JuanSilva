using NUnit.Framework;
using InterView_JuanSilva;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private readonly Piloto piloto;
        private readonly LinhaInput linhaInput;
        private readonly MenuItem menuItem;
        private readonly ResultadoCorrida resultadoCorrida;

        string arquivo = "resultadoCorrida.txt";

        public Tests()
        {
            piloto = new Piloto();
            linhaInput = new LinhaInput();
            menuItem = new MenuItem();
            resultadoCorrida = new ResultadoCorrida();
        }

        [Test]
        public void TestarGeraColecaoPiloto()
        {
            var colecaoPiloto = Piloto.GerarColecaoPiloto(arquivo);

            if (colecaoPiloto != null)
            {
                Assert.Pass();
            }
            else Assert.Fail();
        }

        [Test]
        public void TestarGeraLinhaInput()
        {
            Assert.IsTrue(LinhaInput.GerarLinhaInput(arquivo).OfType<LinhaInput>().Any());
        }

        [Test]
        public void TestarGetMenuItems()
        {
            Assert.IsTrue(MenuItem.GetMenuItems().OfType<MenuItem>().Any());
        }

        [Test]
        public void TesteResultadoCorrida()
        {
            Exception validacao = new Exception();

            try
            {
                var colecaoPiloto = Piloto.GerarColecaoPiloto(arquivo);
                resultadoCorrida.Executar(colecaoPiloto);
                validacao = null;
            }
            catch (Exception e)
            {
                validacao = e;
            }
            Assert.IsNull(validacao);
        }


    }
}