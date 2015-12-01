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
        public void TestPressCalcular()
        {
        Copias teste = new Copias();
        //calculator.Enter(2m);
        //calculator.PressPlus();
        //calculator.Enter(2m);
        //calculator.PressEquals();
        //Assert.AreEqual(4m, calculator.Display);
        }
    }
}
