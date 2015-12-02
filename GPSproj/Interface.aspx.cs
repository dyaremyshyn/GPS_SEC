using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            botaoCalcular.Enabled = false;
        }
    }

    protected void botaoCalcular_Click(object sender, EventArgs e)
    {
        double erroComparacao=0.01;

        //testar se as 3 caixas de texto se encontram vazias (o que significa que são interpretadas como tendo o valor 0)
        //se estiverem vazias, não é possível efectuar qualquer cálculo
        if (TextBoxA.Text.Equals("") && TextBoxB.Text.Equals("") && TextBoxC.Text.Equals(""))
        {
            //#############################################MENSAGEM DE ERRO
            return;
        }

        //inicializar um objeto da classe cálculo.
        Calculo calculo = new Calculo(TextBoxA.Text, TextBoxB.Text, TextBoxC.Text);

        //verifica se (a=0 ou b=0) e c=0, mostrando o valor de x nesse caso.
        if ((calculo.getA() == 0 || calculo.getB() == 0) && calculo.getC() == 0)
        {
            mostraResultado(0);
            return;
        }

        //verifica se a=0 e b!=0 e c!=0
        if (calculo.getA() == 0 && calculo.getB() != 0 && calculo.getC() != 0)
        {
            mostraResultado(calculo.formulaSimplificada());
            return;
        }

        //--------------->testar se a equação tem 2 raízes, 1 raíz ou nenhum raíz usando o discriminante da fórmula resolvente (discriminante = b * b - 4*a*c)
        double discriminante = calculo.getB() * calculo.getB() - 4 * calculo.getA() * calculo.getC();

        //se discriminante<0 a equação não possui raízes
        if (discriminante < 0)
        {
            //#############################################MENSAGEM DE ERRO --> a equação não possui raízes
            return;
        }

        //se discriminante=0 a equação possui 1 raiz
        if (discriminante == 0)
        {
            //comparar o x obtido pela fórmula resolvente com o obtido pelo método de newton
            double a=calculo.formulaResolvente_x1(), b=calculo.metodoNewton();
            if((Math.Abs(a-b))>=erroComparacao)
            {
                //#############################################MENSAGEM DE ERRO --> discrepancia entre os valores calculados pelos 2 metodos
                return;
            }
            mostraResultado(a);
            return;
        }

        //se discriminante=0 a equação possui 2 raizes
        if (discriminante > 0)
        {
            //comparar x1 e x2 obtido pela fórmula resolvente com o obtido pelo método de newton
            double a = calculo.formulaResolvente_x1(), b = calculo.metodoNewton(), c=calculo.formulaResolvente_x2(), d=calculo.metodoNewton();
            if (((Math.Abs(a - b)) >= erroComparacao) || ((Math.Abs(a - b)) >= erroComparacao))
            {
                //#############################################MENSAGEM DE ERRO --> discrepancia entre os valores calculados pelos 2 metodos
                return;
            }
            mostraResultado(a, c);
            return;
        }

        //caso o parametro A seja 0 (reta)
    //    if (a == 0 && b == 0)
    //    {
    //        //reta horizontal não apresenta 0´s
    //        resultado.Text = "Reta horizontal";
    //    }
    //    else {
    //              if (a == 0 && c == 0) 
    //              { 
    //              //reta obliqua que passa sempre em 0
    //                  resultado.Text = "x = 0 <br />";
    //              }
    //              else{
    //                  if(a==0){
    //                          //reta obliqua com 1 zero                          
    //                          resultado.Text = "x = " + string.Format(digitos(), calculo.FR_b(b, c)) + "<br />";                            
    //                          }else{
    //                                //equação tem de ser possivel
    //                                 if (calculo.ValidaEq(a, b, c))
    //                                 {
    //                                 //Calculo x1 pela formula resolvente quando existem os 3 termos a, b e c
    //                                 resultado.Text = "x1 = " + string.Format(digitos(),calculo.FR_a_x1(a, b, c)) + "<br />"
    //                                 + "x2 = " + string.Format(digitos(),calculo.FR_a_x2(a, b, c));
    //                                 }else { 
    //                                        //escreve equação impossivel numa label 
    //                                        resultado.Text = "Equação impossivel";
    //                                       }

    //                               }

    //                  }
                   
    //        }
       
    }

    //********************************************** EVENTOS OnTextChanged ****************************************************

    //Estes eventos são chamados quando o texto de uma das 3 text chama uma função auxiliar que faz a validação do que está a ser escrito na TextBox correspondente
    //Se tiver recebido false (a operação de conversão correu mal) --> mostra-se uma caixa de erro com o texto a dizer que só se aceitam valores numericos
    //                                                             --> o atributo enable do botão de calcular passa a false
    //AS MENSAGENS DE ERRO SÃO AS QUE ESTÃO DEFINIDAS NOS REQUISITOS?
    protected void TextBoxA_TextChanged(object sender, EventArgs e)
    {
        botaoCalcular.Enabled = true;
        if (!validar("txtA"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);
            botaoCalcular.Enabled = false;
        }

    }
    protected void TextBoxB_TextChanged(object sender, EventArgs e)
    {
        botaoCalcular.Enabled = true;
        if (!validar("txtB"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);
            botaoCalcular.Enabled = false;
        }

    }
    protected void TextBoxC_TextChanged(object sender, EventArgs e)
    {
        botaoCalcular.Enabled = true;
        if (!validar("txtC"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);
            botaoCalcular.Enabled = false;
        }

    }

    //************************************************ FUNÇÃO validar() *************************************************

    //Função validar() recebe o nove da TextBox que está a ser "utilizada" e tenta fazer a conversão para um double.
    //Se conseguir converter, guarda o valor convertido para uma variável do tipo double e retorna true (a operação correu bem)
    //Se não conseguir converter, retorna false (a operação correu mal)

    //FALTA VALIDAR O TAMANHO DA STRING
    private bool validar(string txt)
    {
        double valor = 0;
        if (txt.Equals("txtA"))
        {
            if (double.TryParse(TextBoxA.Text, out valor))
                return true;
        }
        else if (txt.Equals("txtB"))
        {
            if (double.TryParse(TextBoxB.Text, out valor))
                return true;
        }
        else if (txt.Equals("txtC"))
        {
            if (double.TryParse(TextBoxC.Text, out valor))
                return true;
        }
        return false;

    }

    //************************************************ FUNÇÃO mostraResultado() *************************************************
    //recebe 1 ou 2 argumentos (variáveis double), constroi uma string com o resultado e mostra-a na respectiva caixa de texto.
    void mostraResultado(double x)
    {
        resultado.Text = "<br />x = " + x;
    }

    void mostraResultado(double x1, double x2)
    {
        resultado.Text = "<br />x1 = " + x1 + "<br />x2 = " + x2;
    }
}