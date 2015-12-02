using CodigoParaTestes;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodigoParaTestes.Tests
{
    [TestClass()]
    public class UnitTest1
    {

        [TestMethod()]
        public void ValidaEqTest()
        {
            //arrange
            
            var equacao = new Calculo("5", "2", "1");
            //act
            
        }

        [TestMethod()]
        public void FR_a_x1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FR_a_x2Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FR_bTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FR_c_x1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FR_c_x2Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void rRuffini_x1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void rRuffini_x2Test()
        {
            Assert.Fail();
        }
    }
}
