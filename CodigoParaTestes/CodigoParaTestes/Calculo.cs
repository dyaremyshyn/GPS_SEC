using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodigoParaTestes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Calculo
    {
        //são variaveis privadas
        double termoA, termoB, termoC;
        string caixaA, caixaB, caixaC, labelA, labelB, labelC, resultado, labelA1, labelB1, labelC1, caixaAcor, caixaBcor, caixaCcor, aviso, eq_valida_actual;

        public Calculo()
        {
            termoA = 0;
            termoB = 0;
            termoC = 0;
        }

        //construtor que recebe 3 strings correspondentes às caixas de texto com os termos e converte-as para números com formato double;
        //de seguida coloca-os nos respectivos campos da class (double a, b e c) correspondentes aos termos a, b e c da equação.
        public Calculo(string stringA, string stringB, string stringC)
        {
            // testar se alguma das caixas de texto está vazia, ou eja,  possui uma string vazia, substituindo-a por 0
            if (stringA.Equals(""))
            {
                stringA = "0";
            }
            if (stringB.Equals(""))
            {
                stringB = "0";
            }
            if (stringC.Equals(""))
            {
                stringC = "0";
            }

            //guarda os valores nos respetivos campos
            //estes valores(stringA,stringB,stringC) são valores verificados externamente.
            termoA = Convert.ToDouble(stringA);
            termoB = Convert.ToDouble(stringB);
            termoC = Convert.ToDouble(stringC);
        }

        public void setCaixas(string caixaA, string caixaB, string caixaC)
        {
            this.caixaA = caixaA;
            this.caixaB = caixaB;
            this.caixaC = caixaC;
        }

        public void setCaixasCor(string caixaAcor, string caixaBcor, string caixaCcor)
        {
            this.caixaAcor = caixaAcor;
            this.caixaBcor = caixaBcor;
            this.caixaCcor = caixaCcor;
        }

        public string getAviso()
        {
            return aviso;
        }

        public double getA()
        {
            return termoA;
        }

        public double getB()
        {
            return termoB;
        }

        public double getC()
        {
            return termoC;
        }

        public string getlabelA()
        {
            return labelA;
        }

        public string getlabelB()
        {
            return labelB;
        }

        public string getlabelC()
        {
            return labelC;
        }

        public string getcaixaA()
        {
            return caixaA;
        }

        public string getcaixaB()
        {
            return caixaB;
        }

        public string getcaixaC()
        {
            return caixaC;
        }

        public string getcaixaAcor()
        {
            return caixaAcor;
        }

        public string getcaixaBcor()
        {
            return caixaBcor;
        }

        public string getcaixaCcor()
        {
            return caixaCcor;
        }

        public string getEqValidaActual()
        {
            return eq_valida_actual;
        }

        public string geteq()
        {
            string equacaostring = (getA().ToString() + 'x' + '*' + 'x' + '+' + getB().ToString() + '*' + 'x' + '+' + getC().ToString());
            equacaostring = equacaostring.Replace(",", ".");
            return equacaostring;
        }

        //Calcula x1 pela formula resolvente quando: --> existem os 3 termos a, b e c são diferentes de zero,
        //                                           --> c=0 ou b=0
        //Retorna o resultado.
        public double formulaResolvente_x1()
        {
            return (-termoB + Math.Sqrt(termoB * termoB - 4 * termoA * termoC)) / (2 * termoA);
        }

        //Calcula x2 pela formula resolvente quando: --> existem os 3 termos a, b e c são diferentes de zero,
        //                                           --> c=0 ou b=0
        //Retorna o resultado.
        public double formulaResolvente_x2()
        {
            return (-termoB - Math.Sqrt(termoB * termoB - 4 * termoA * termoC)) / (2 * termoA);
        }

        //Calcula o valor de x quando a=0 e (b && c)!=0
        public double formulaSimplificada()
        {
            return -termoC / termoB;
        }

        //implementação do método numérico de Newton-Rhapson
        //Xn: valor de x considerado.
        //Xmin: mínimo da função
        //fXn: f(Xn)= valor da função no ponto Xn.
        //fdXn: f'(Xn)= valor da derivada da função no ponto Xn.
        //Xn_mais1: Xn+1= valor de Xn a ser usado na iteração seguinte
        //erroReal: erro real do cálculo de Xn entre duas iterações consecutivas
        //erroMax: erro máximo que serve como critério de paragem das iterações
        //x1,x2 são variaveis verificadas externamente para evitar conflitos nos calculos.
        public void metodoNewton(ref double x1, ref double x2)
        {
            const double erroMax = 0.001;
            const int numIt = 10000;
            double Xn, fXn, fdXn, Xn_mais1, erroReal = 1, Xmin;
            Xmin = -termoB / (2 * termoA);

            Xn = 0;
            for (int i = 1; erroReal > erroMax && i < numIt; i++)
            {
                fXn = termoA * (Xn * Xn) + termoB * Xn + termoC;
                fdXn = termoA * 2 * Xn + termoB;
                Xn_mais1 = Xn - (fXn / fdXn);
                erroReal = Math.Abs(Xn - Xn_mais1);
                Xn = Xn_mais1;
            }
            x1 = Xmin + Math.Abs((Xmin - Xn));
            x2 = Xmin - Math.Abs((Xmin - Xn));
        }

        static void Main()
        {

        }

        public bool validar(string txt)
        {
            const int maxChars = 8;
            double valor = 0;
            if (txt == "")
                return true;
            if (!double.TryParse(txt, out valor) || txt.Length > maxChars)
                return false;
            return true;
        }

        public string getResultado()
        {
            return resultado;
        }

        public void setResultado(string resultado)
        {
            this.resultado = resultado;
        }

        public void mostraResultado(double x)
        {
            resultado = "<br />x = " + Math.Round(x, 4);
        }

        public void mostraResultado(double x1, double x2)
        {
            resultado = "<br />x1 = " + Math.Round(x1, 4) + "<br />x2 = " + Math.Round(x2, 4);
        }

        //escreve parametros consuante o que for introduzido(valores numericos negativos ou positivos) 
        public void escreve_parametro(string TEXT_ALVO)
        {
            if (TEXT_ALVO == "TextBoxA")
            {
                if (caixaA.Equals(""))
                {
                    labelA = " + " + "0" + "x";
                    labelA1 = " + " + "0" + "x";
                    return;
                }
                //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
                if (caixaA[0] == '-')
                {
                    labelA = " - " + -1 * Int32.Parse(caixaA) + "x<sup>2</sup>"; //nao afeta a textbox
                    labelA1 = " - " + -1 * Int32.Parse(caixaA) + "x<sup>2</sup>"; //nao afeta a textbox
                }
                else
                {
                    //escreve na interface consuante o valor a introduzido
                    labelA = caixaA + "x<sup>2</sup>";
                    labelA1 = caixaA + "x<sup>2</sup>";
                }
            }
            else
            {
                if (TEXT_ALVO == "TextBoxB")
                {
                    if (caixaB.Equals(""))
                    {
                        labelB = " + " + "0" + "x";
                        labelB1 = " + " + "0" + "x";
                        return;
                    }
                    //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
                    if (caixaB[0] == '-')
                    {
                        labelB = " - " + -1 * Int32.Parse(caixaB) + "x"; //nao afeta a textbox
                        labelB1 = " - " + -1 * Int32.Parse(caixaB) + "x"; //nao afeta a textbox
                    }
                    else
                    {
                        //escreve na interface consuante o valor b introduzido
                        labelB = " + " + caixaB + "x";
                        labelB1 = " + " + caixaB + "x";
                    }
                }
                else
                {
                    if (TEXT_ALVO == "TextBoxC")
                    {
                        if (caixaC.Equals(""))
                        {
                            labelC = " + " + "0" + " = 0";
                            labelC1 = " + " + "0";
                            return;
                        }
                        //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
                        if (caixaC[0] == '-')
                        {
                            labelC = " - " + -1 * Int32.Parse(caixaC) + " = 0"; //nao afeta a textbox
                            labelC1 = " - " + -1 * Int32.Parse(caixaC); //nao afeta a textbox
                        }
                        else
                        {
                            //escreve na interface consuante o valor c introduzido
                            labelC = " + " + caixaC + " = 0";
                            labelC1 = " + " + caixaC;
                        }
                    }
                }
            }
        }

        public void TextBoxA_TextChanged(object sender, EventArgs e)
        {
            caixaAcor = "normal";
            if (!validar(caixaA))
            {
                caixaAcor = "vermelho";
            }
            else
            {
                escreve_parametro("TextBoxA");
            }
        }

        public void TextBoxB_TextChanged(object sender, EventArgs e)
        {
            caixaBcor = "normal";
            if (!validar(caixaB))
            {
                caixaBcor = "vermelho";
            }
            else
            {
                escreve_parametro("TextBoxB");
            }
        }

        public void TextBoxC_TextChanged(object sender, EventArgs e)
        {
            caixaCcor = "normal";
            if (!validar(caixaC))
            {
                caixaCcor = "vermelho";
            }
            else
            {
                escreve_parametro("TextBoxC");
            }
        }


        public void botaoCalcular_Click(object sender, EventArgs e)
        {
            const double erroComparacao = 0.01;

            if (caixaAcor.Equals("vermelho") || caixaBcor.Equals("vermelho") || caixaCcor.Equals("vermelho"))
            {
                aviso = "caixas vermelhas";
                return;
            }

            //testar se as 3 caixas de texto se encontram vazias (o que significa que são interpretadas como tendo o valor 0)
            //se estiverem vazias, não é possível efectuar qualquer cálculo
            if (caixaA.Equals("") && caixaB.Equals("") && caixaC.Equals(""))
            {
                aviso = "caixas vazias";
                return;
            }

            //inicializar um objeto da classe cálculo.
            //Calculo calculo = new Calculo(TextBoxA.Text, TextBoxB.Text, TextBoxC.Text);
            eq_valida_actual = "vazio";

            //verifica se a=0 e b=0, mostrando o valor de x nesse caso.
            if (getA() == 0 && getB() == 0 && getC() != 0)
            {
                aviso="os valores introduzidos não constituem uma equação";
                return;
            }

            eq_valida_actual = geteq();

            //verifica se (a=0 ou b=0) e c=0, mostrando o valor de x nesse caso.
            if ((getA() == 0 || getB() == 0) && getC() == 0)
            {
                mostraResultado(0);
                return;
            }

            //verifica se a=0 e b!=0 e c!=0
            if (getA() == 0 && getB() != 0 && getC() != 0)
            {
                mostraResultado(formulaSimplificada());
                return;
            }

            //--------------->testar se a equação tem 2 raízes, 1 raíz ou nenhum raíz usando o discriminante da fórmula resolvente (discriminante = b * b - 4*a*c)
            double discriminante = getB() * getB() - 4 * getA() * getC();

            //se discriminante<0 a equação não possui raízes
            if (discriminante < 0)
            {
                aviso="A equação indicada não possui raízes";
                return;
            }

            //se discriminante=0 a equação possui apenas 1 raiz
            if (discriminante == 0)
            {
                //comparar o x obtido pela fórmula resolvente com o obtido pelo método de newton
                double x1FR = formulaResolvente_x1(), x1MN = 0, aux = 0;
                metodoNewton(ref x1MN, ref aux);
                if ((Math.Abs(x1FR - x1MN)) >= erroComparacao) // se a diferença entre os valores obtidos pelos 2 métodos for superior ao erroComparacao, surge mensagem de erro
                {
                    aviso="Erro de cálculo; resultado não fidedigno";
                    return;
                }
                mostraResultado(x1FR);
                return;
            }

            //se discriminante=0 a equação possui 2 raizes
            if (discriminante > 0)
            {
                //comparar x1 e x2 obtido pela fórmula resolvente com o obtido pelo método de newton
                double x1FR = formulaResolvente_x1(), x1MN = 0, x2FR = formulaResolvente_x2(), x2MN = 0;
                metodoNewton(ref x1MN, ref x2MN);
                // se a diferença entre os valores obtidos pelos 2 métodos for superior ao erroComparacao, surge mensagem de erro
                if (((Math.Abs(x1FR - x1MN)) >= erroComparacao) || ((Math.Abs(x2FR - x2MN)) >= erroComparacao))
                {
                    aviso="Erro de cálculo; resultado não fidedigno";
                    return;
                }
                mostraResultado(x1FR, x2FR);
                return;
            }
        }

    }

}
