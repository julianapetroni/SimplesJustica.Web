using NUnit.Framework;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class CPFTest
    {
        [Test]
        [TestCase("367.442.780-02")]
        [TestCase("790.524.830-51")]
        [TestCase("670.012.810-26")]
        public void Quando_CpfForValido_Retorna_Verdadeiro(string val)
        {
            //Arrange
            var cpf = new CPF(val);

            //Act
            var result = cpf.EhValido();

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("367.442.780-11")]
        [TestCase("790.111.XXX-51")]
        [TestCase("790.111.830-51")]
        [TestCase("111.111.111-11")]
        [TestCase("11111111111")]
        [TestCase("111111111111111")]
        [TestCase("111111111")]
        public void Quando_CpfForInvalido_Retorna_Falso(string val)
        {
            //Arrange
            var cpf = new CPF(val);

            //Act
            var result = cpf.EhValido();

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
