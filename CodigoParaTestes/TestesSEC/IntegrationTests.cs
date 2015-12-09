using CodigoParaTestes;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesSEC
{
    [TestClass]
    public class IntegrationTests
    {

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR eventos ontextchanged**********************************************
        //***************************************************************************************************************************************************
        [TestMethod]
        [TestCategory("ontextchanged()")]
        public void testeInicial1()
        {
            var calculo = new Calculo();
            calculo.setCaixas("5", "2", "1");
            calculo.TextBoxA_TextChanged(null, EventArgs.Empty);
            Assert.AreNotEqual("vermelho", calculo.getcaixaAcor());
            calculo.TextBoxB_TextChanged(null, EventArgs.Empty);
            Assert.AreNotEqual("vermelho", calculo.getcaixaBcor());
            calculo.TextBoxC_TextChanged(null, EventArgs.Empty);
            Assert.AreNotEqual("vermelho", calculo.getcaixaCcor());
        }

        [TestMethod]
        [TestCategory("ontextchanged()")]
        public void ontextchangedValidos()
        {
            var calculo = new Calculo();
            calculo.setCaixas("5", "", "1");
            calculo.TextBoxA_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("normal", calculo.getcaixaAcor());
            calculo.TextBoxB_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("normal", calculo.getcaixaBcor());
            calculo.TextBoxC_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("normal", calculo.getcaixaCcor());
        }

        [TestMethod]
        [TestCategory("ontextchanged()")]
        public void ontextchangedInvalidos1()
        {
            var calculo = new Calculo();
            calculo.setCaixas("a", "  ", "123456789");
            calculo.TextBoxA_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("vermelho", calculo.getcaixaAcor());
            calculo.TextBoxB_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("vermelho", calculo.getcaixaBcor());
            calculo.TextBoxC_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("vermelho", calculo.getcaixaCcor());
        }

        [TestMethod]
        [TestCategory("ontextchanged()")]
        public void ontextchangedOutros()
        {
            var calculo = new Calculo();
            calculo.setCaixas("#$%", "-0", "12345678");
            calculo.TextBoxA_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("vermelho", calculo.getcaixaAcor());
            calculo.TextBoxB_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("normal", calculo.getcaixaBcor());
            calculo.TextBoxC_TextChanged(null, EventArgs.Empty);
            Assert.AreEqual("normal", calculo.getcaixaCcor());
        }

        //***************************************************************************************************************************************************
        //************************************************************************ TESTAR eventos calcular()*************************************************
        //***************************************************************************************************************************************************
        [TestMethod]
        [TestCategory("calcular()")]
        public void testeInicial2()
        {
            var calculo = new Calculo();
            calculo.setCaixas("1", "1", "1");
            calculo.setCaixasCor("vermelho", "vermelho", "vermelho");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreNotEqual("teste", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void caixasVazias()
        {
            var calculo = new Calculo();
            calculo.setCaixas("", "", "");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("caixas vazias", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void caixaVermelho()
        {
            var calculo = new Calculo();
            calculo.setCaixas("1", "1", "1");
            calculo.setCaixasCor("vermelho", "vermelho", "vermelho");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("caixas vermelhas", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void caixaVermelho2()
        {
            var calculo = new Calculo();
            calculo.setCaixas("1", "1", "1");
            calculo.setCaixasCor("vermelho", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("caixas vermelhas", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void caixaVermelho3()
        {
            var calculo = new Calculo();
            calculo.setCaixas("1", "1", "1");
            calculo.setCaixasCor("normal", "vermelho", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("caixas vermelhas", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void caixaVermelho4()
        {
            var calculo = new Calculo();
            calculo.setCaixas("1", "1", "1");
            calculo.setCaixasCor("normal", "normal", "vermelho");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("caixas vermelhas", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void termos00dif()
        {
            var calculo = new Calculo("0", "0", "1");
            calculo.setCaixas("0", "0", "1");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("os valores introduzidos não constituem uma equação", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void termosDif00_1()
        {
            var calculo = new Calculo("2", "0", "0");
            calculo.setCaixas("2", "0", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x = " + Math.Round(0.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void termosDif00_2()
        {
            var calculo = new Calculo("0", "2", "0");
            calculo.setCaixas("0", "2", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x = " + Math.Round(0.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void termos0DifDif_1()
        {
            var calculo = new Calculo("0", "2", "-2");
            calculo.setCaixas("0", "2", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x = " + Math.Round(1.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void termos0DifDif_2()
        {
            var calculo = new Calculo("0", "2", "2");
            calculo.setCaixas("0", "2", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x = " + Math.Round(-1.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void discriminanteMenor0()
        {
            var calculo = new Calculo("1", "2", "10");
            calculo.setCaixas("1", "2", "10");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("A equação indicada não possui raízes", calculo.getAviso());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void discriminanteIgual0()
        {
            var calculo = new Calculo("1", "2", "1");
            calculo.setCaixas("1", "2", "1");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x = " + Math.Round(-1.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void discriminanteMaior0()
        {
            var calculo = new Calculo("1", "2", "-3");
            calculo.setCaixas("1", "2", "-3");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("<br />x1 = " + Math.Round(1.0000, 4) + "<br />x2 = " + Math.Round(-3.0000, 4), calculo.getResultado());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void eq_valida_actual()
        {
            var calculo = new Calculo("-5", "-2", "-1");
            calculo.setCaixas("-5", "-2", "-1");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("-5x*x+-2*x+-1", calculo.getEqValidaActual());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void eq_valida_actual2()
        {
            var calculo = new Calculo("0", "-2", "0");
            calculo.setCaixas("0", "-2", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("0x*x+-2*x+0", calculo.getEqValidaActual());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void eq_valida_actual3()
        {
            var calculo = new Calculo("3", "0", "0");
            calculo.setCaixas("3", "0", "0");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("3x*x+0*x+0", calculo.getEqValidaActual());
        }

        [TestMethod]
        [TestCategory("calcular()")]
        public void eq_valida_actual4()
        {
            var calculo = new Calculo("0", "0", "3");
            calculo.setCaixas("0", "0", "3");
            calculo.setCaixasCor("normal", "normal", "normal");
            calculo.botaoCalcular_Click(null, EventArgs.Empty);
            Assert.AreEqual("vazio", calculo.getEqValidaActual());
        }
    }
}
