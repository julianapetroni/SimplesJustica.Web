using NUnit.Framework;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class CNPJTest
    {
        [Test]
        [TestCase("75.277.760/0001-40")]
        [TestCase("17.512.474/0001-15")]
        [TestCase("67115242000100")]
        [TestCase("33451112000118")]
        public void Quando_CnpjForValido_Retorna_Verdadeiro(string val)
        {
            //arrange
            var cnpj = new CNPJ(val);

            //act
            var result = cnpj.EhValido();

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("75.277.760/0001-11")]
        [TestCase("17.512.474/XXX1-15")]
        [TestCase("11111111111111")]
        [TestCase("334511120")]
        [TestCase("3345111201111111111")]
        public void Quando_CnpjForInvalido_Retorna_Falso(string val)
        {
            //arrange
            var cnpj = new CNPJ(val);

            //act
            var result = cnpj.EhValido();

            //assert
            Assert.That(result, Is.False);
        }

        [Test]
        [TestCase("89.986.237/0001-05")]
        [TestCase("89028651000101")]
        [TestCase("31123752000173")]
        public void Quando_ObterCnpj_Retorna_CnpjFormatado(string val)
        {
            //arrange
            var cnpj = new CNPJ(val);

            //act
            var result = cnpj.StringValue;

            //assert
            Assert.AreEqual('.', result[2]);
            Assert.AreEqual('.', result[6]);
            Assert.AreEqual('/', result[10]);
            Assert.AreEqual('-', result[15]);
        }
    }
}
