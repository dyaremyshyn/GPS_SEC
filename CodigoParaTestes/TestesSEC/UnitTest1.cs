using CodigoParaTestes;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodigoParaTestes.Tests
{
    [TestClass()]
    public class UnitTest1
    {

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR CONSTRUTOR ********************************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("Construtor()")]
        public void testeInicial1()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.getA(), 3);
            Assert.AreNotEqual(calculo.getB(), 3);
            Assert.AreNotEqual(calculo.getC(), 3);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        public void positivos()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreEqual(calculo.getA(), 5);
            Assert.AreEqual(calculo.getB(), 2);
            Assert.AreEqual(calculo.getC(), 1);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        public void negativos()
        {
            var calculo = new Calculo("-5", "-2", "-1");
            Assert.AreEqual(calculo.getA(), -5);
            Assert.AreEqual(calculo.getB(), -2);
            Assert.AreEqual(calculo.getC(), -1);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        public void positivosDecimal()
        {
            var calculo = new Calculo("5987654,3", "2,47689", "1,689065");
            Assert.AreEqual(calculo.getA(), 5987654, 3);
            Assert.AreEqual(calculo.getB(), 2, 47689);
            Assert.AreEqual(calculo.getC(), 1, 689065);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        public void negativosDecimal()
        {
            var calculo = new Calculo("-5987654,3", "-2,47689", "-1,689065");
            Assert.AreEqual(calculo.getA(), -5987654, 3);
            Assert.AreEqual(calculo.getB(), -2, 47689);
            Assert.AreEqual(calculo.getC(), -1, 689065);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        public void caixasVazias()
        {
            var calculo = new Calculo("", "", "");
            Assert.AreEqual(calculo.getA(), 0);
            Assert.AreEqual(calculo.getB(), 0);
            Assert.AreEqual(calculo.getC(), 0);
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        [ExpectedException(typeof(FormatException))]
        public void naoValidosA()
        {
            var calculo = new Calculo("a", "2", "3");
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        [ExpectedException(typeof(FormatException))]
        public void naoValidosB()
        {
            var calculo = new Calculo("2", "$%&", "3");
        }

        [TestMethod()]
        [TestCategory("Construtor()")]
        [ExpectedException(typeof(FormatException))]
        public void naoValidosC()
        {
            var calculo = new Calculo("2", "2", "2..4");
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR geteq *************************************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("geteq()")]
        public void testeInicial2()
        {
            var calculo = new Calculo("5", "2", "1");
            string esperado = "5x*x+2*x+12";
            string resultado = calculo.geteq();
            Assert.AreNotEqual(esperado, resultado);
        }

        [TestMethod()]
        [TestCategory("geteq()")]
        public void sringPositivos()
        {
            var calculo = new Calculo("5", "2", "1");
            string esperado = "5x*x+2*x+1";
            string resultado = calculo.geteq();
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        [TestCategory("geteq()")]
        public void stringNegativos()
        {
            var calculo = new Calculo("-5", "-2", "-1");
            string esperado = "-5x*x+-2*x+-1";
            string resultado = calculo.geteq();
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        [TestCategory("geteq()")]
        public void stringDecimais()
        {
            var calculo = new Calculo("5,0987", "-2,765", "876541,87");
            string esperado = "5.0987x*x+-2.765*x+876541.87";
            string resultado = calculo.geteq();
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod()]
        [TestCategory("geteq()")]
        public void stringCaixasVazias()
        {
            var calculo = new Calculo("", "", "");
            string esperado = "0x*x+0*x+0";
            string resultado = calculo.geteq();
            Assert.AreEqual(esperado, resultado);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR formulaResolvente_x1 **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("formulaResolvente_x1()")]
        public void testeInicial3()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.formulaResolvente_x1(), 2);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x1()")]
        public void testeFR1()
        {
            var calculo = new Calculo("1", "2", "-3");
            Assert.AreEqual(calculo.formulaResolvente_x1(), 1);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x1()")]
        public void FR1raizNegativa()
        {
            var calculo = new Calculo("2", "2", "50");
            Assert.AreEqual(calculo.formulaResolvente_x1(), double.NaN);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x1()")]
        public void fr1DivideZero()
        {
            var calculo = new Calculo("0", "2", "50");
            Assert.AreEqual(calculo.formulaResolvente_x1(), double.NaN);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR formulaResolvente_x2 **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("formulaResolvente_x2()")]
        public void testeInicial4()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.formulaResolvente_x2(), 2);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x2()")]
        public void testeFR2()
        {
            var calculo = new Calculo("1", "2", "-3");
            Assert.AreEqual(calculo.formulaResolvente_x2(), -3);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x2()")]
        public void FR2raizNegativa()
        {
            var calculo = new Calculo("2", "2", "50");
            Assert.AreEqual(calculo.formulaResolvente_x2(), double.NaN);
        }

        [TestMethod()]
        [TestCategory("formulaResolvente_x2()")]
        public void fr2DivideZero()
        {
            var calculo = new Calculo("0", "2", "50");
            Assert.AreEqual(calculo.formulaResolvente_x2(), double.NegativeInfinity);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR formulaSimplificada() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("formulaSimplificada()")]
        public void testeInicial5()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.formulaSimplificada(), 2);
        }

        [TestMethod()]
        [TestCategory("formulaSimplificada()")]
        public void frValido()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.formulaSimplificada(), 0.5);
        }

        [TestMethod()]
        [TestCategory("formulaSimplificada()")]
        public void frInvalido()
        {
            var calculo = new Calculo("5", "0", "1");
            Assert.AreNotEqual(calculo.formulaSimplificada(), double.NaN);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR metodoNewton() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("metodoNewton()")]
        public void testeInicial6()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.formulaSimplificada(), 2);
        }

        [TestMethod()]
        [TestCategory("metodoNewton()")]
        public void validoMN()
        {
            var calculo = new Calculo("1", "2", "-3");
            double r1 = 0, r2 = 0;
            calculo.metodoNewton(ref r1, ref r2);
            Assert.AreEqual(Math.Round(r1, 4), 1);
            Assert.AreEqual(Math.Round(r2, 4), -3);
        }

        [TestMethod()]
        [TestCategory("metodoNewton()")]
        public void MNdivideZero()
        {
            var calculo = new Calculo("2", "0", "3");
            double r1 = 0, r2 = 0;
            calculo.metodoNewton(ref r1, ref r2);
            Assert.AreEqual(r1, double.NaN);
            Assert.AreEqual(r2, double.NaN);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR validar() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("validar()")]
        public void testeInicial7()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreNotEqual(calculo.validar("5"), false);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarValido()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreEqual(calculo.validar("5"), true);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarInvalido1()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreEqual(calculo.validar("a"), false);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarInvalido2()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreEqual(calculo.validar("123456789"), false);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarZero1()
        {
            var calculo = new Calculo();
            Assert.AreEqual(calculo.validar("0"), true);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarZero2()
        {
            var calculo = new Calculo();
            Assert.AreEqual(calculo.validar("-0"), true);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarCaixavazia()
        {
            var calculo = new Calculo("5", "2", "1");
            Assert.AreEqual(calculo.validar(""), true);
        }

        [TestMethod()]
        [TestCategory("validar()")]
        public void validarGrandeNegativo()
        {
            var calculo = new Calculo();
            Assert.AreEqual(calculo.validar("-23456789"), true);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR mostraResultado() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("mostraResultado()")]
        public void testeInicial8()
        {
            var calculo = new Calculo("1", "2", "3");
            calculo.mostraResultado(5.678945);
            Assert.AreNotEqual(calculo.getResultado(), "dfr");
        }

        [TestMethod()]
        [TestCategory("mostraResultado()")]
        public void mostraResultadoValido()
        {
            var calculo = new Calculo("5", "2", "1");
            string str = "<br />x = " + Math.Round(5.678945, 4);
            calculo.mostraResultado(5.678945);
            Assert.AreEqual(calculo.getResultado(), str);
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR mostraResultado2() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("mostraResultado2()")]
        public void testeInicial9()
        {
            var calculo = new Calculo("5", "2", "1");
            calculo.mostraResultado(5.678945, 765.8);
            Assert.AreNotEqual(calculo.getResultado(), "dfr");
        }

        [TestMethod()]
        [TestCategory("mostraResultado2()")]
        public void mostraResultado2Valido()
        {
            var calculo = new Calculo("5", "2", "1");
            string str = "<br />x1 = " + Math.Round(5.678945, 4) + "<br />x2 = " + Math.Round(765.8, 4);
            calculo.mostraResultado(5.678945, 765.8);
            Assert.AreEqual(calculo.getResultado(), str);
        }


        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR escreve_parametro() **********************************************
        //***************************************************************************************************************************************************
        [TestMethod()]
        [TestCategory("escreve_parametro()")]
        public void testeInicial10()
        {
            var calculo = new Calculo("5", "2", "1");
            calculo.setCaixas("5", "2", "1");
            calculo.escreve_parametro("TextBoxA");
            Assert.AreNotEqual(calculo.getlabelA(), "dfr");
        }

        [TestMethod()]
        [TestCategory("escreve_parametro()")]
        public void escreve_parametroValido()
        {
            var calculo = new Calculo();
            calculo.setCaixas("5", "2", "1");
            calculo.escreve_parametro("TextBoxA");
            calculo.escreve_parametro("TextBoxB");
            calculo.escreve_parametro("TextBoxC");
            Assert.AreEqual(calculo.getlabelA(), "5" + "x<sup>2</sup>");
            Assert.AreEqual(calculo.getlabelB(), " + " + "2" + "x");
            Assert.AreEqual(calculo.getlabelC(), " + " + "1" + " = 0");
        }

        [TestMethod()]
        [TestCategory("escreve_parametro()")]
        public void escreve_parametroValidoNegativo()
        {
            var calculo = new Calculo();
            calculo.setCaixas("-5", "-2", "-1");
            calculo.escreve_parametro("TextBoxA");
            calculo.escreve_parametro("TextBoxB");
            calculo.escreve_parametro("TextBoxC");
            Assert.AreEqual(calculo.getlabelA(), " - 5" + "x<sup>2</sup>");
            Assert.AreEqual(calculo.getlabelB(), " - " + "2" + "x");
            Assert.AreEqual(calculo.getlabelC(), " - " + "1" + " = 0");
        }

        [TestMethod()]
        [TestCategory("escreve_parametro()")]
        public void escreve_parametroCaixasVazias()
        {
            var calculo = new Calculo();
            calculo.setCaixas("", "", "");
            calculo.escreve_parametro("TextBoxA");
            calculo.escreve_parametro("TextBoxB");
            calculo.escreve_parametro("TextBoxC");
            Assert.AreEqual(calculo.getlabelA(), " + 0x");
            Assert.AreEqual(calculo.getlabelB(), " + " + "0" + "x");
            Assert.AreEqual(calculo.getlabelC(), " + " + "0" + " = 0");
        }
    }
}
