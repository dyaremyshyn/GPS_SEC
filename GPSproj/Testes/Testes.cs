using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopiasParaTestes;

namespace Testes
{
    [TestClass]
    public class Testes
    {
        [TestMethod]
        public void TestaSoma()
        {
            Copias teste = new Copias();
            int sum = teste.testaSoma(1, 2);
            Assert.AreEqual(3, sum);
        }
    }
}
