using NUnit.Framework;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Tests.ValueObjects
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        [TestCase("fulano@gmail.com")]
        [TestCase("fulano.da-silva@bol.com.br")]
        [TestCase("fulano11@hotmail.com")]
        [TestCase("fulano_da_silva58@empresa.com.br")]
        public void Quando_EmailForValido_Retorna_Verdadeiro(string val)
        {
            //arrange
            var email = new Email(val);

            //act
            var result = email.EhValido();

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("fulanogmail.com")]
        [TestCase("fulano11@hotmail.com.br.a.b")]
        [TestCase("@empresa.com.br")]
        [TestCase("fulano11@")]
        [TestCase("fulano.da-silva@.br")]
        public void Quando_EmailForValido_Retorna_Falso(string val)
        {
            //arrange
            var email = new Email(val);

            //act
            var result = email.EhValido();

            //assert
            Assert.That(result, Is.False);
        }
    }
}
