using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;


public partial class homepage : System.Web.UI.Page
{
    string  eq_valida_actual;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBoxA.Text = "1";
            TextBoxB.Text = "2";
            TextBoxC.Text = "-3";
            TextBoxA_TextChanged(null, EventArgs.Empty);
            TextBoxB_TextChanged(null, EventArgs.Empty);
            TextBoxC_TextChanged(null, EventArgs.Empty);
            botaoCalcular_Click(null, EventArgs.Empty);
        }
    }

    protected void botaoCalcular_Click(object sender, EventArgs e)
    {
        const double erroComparacao = 0.01;
        
        if ((TextBoxA.BorderColor == System.Drawing.ColorTranslator.FromHtml("#ff0000")) || (TextBoxB.BorderColor == System.Drawing.ColorTranslator.FromHtml("#ff0000")) || (TextBoxC.BorderColor == System.Drawing.ColorTranslator.FromHtml("#ff0000")))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitidos valores numéricos até 8 dígitos.');", true);
            return;
        }

        //testar se as 3 caixas de texto se encontram vazias (o que significa que são interpretadas como tendo o valor 0)
        //se estiverem vazias, não é possível efectuar qualquer cálculo
        if (TextBoxA.Text.Equals("") && TextBoxB.Text.Equals("") && TextBoxC.Text.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Não foram introduzidos quaisquer valores.');", true);
            return;
        }

        //inicializar um objeto da classe cálculo.
        Calculo calculo = new Calculo(TextBoxA.Text, TextBoxB.Text, TextBoxC.Text);

        //verifica se a=0 e b=0.
        if (calculo.getA() == 0 && calculo.getB() == 0 && calculo.getC() != 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Os valores introduzidos não constituem uma equação.');", true);
            return;
        }

        eq_valida_actual = calculo.geteq();

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
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('A equação indicada não possui raízes.');", true);
            resultado.Text="<br/>";
            return;
        }

        //se discriminante=0 a equação possui apenas 1 raiz
        if (discriminante == 0)
        {
            //comparar o x obtido pela fórmula resolvente com o obtido pelo método de newton
            double x1FR = calculo.formulaResolvente_x1(), x1MN = 0, aux = 0;
            calculo.metodoNewton(ref x1MN, ref aux);
            if((Math.Abs(x1FR - x1MN)) >= erroComparacao) // se a diferença entre os valores obtidos pelos 2 métodos for superior ao erroComparacao, surge mensagem de erro
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Erro de cálculo; resultado não fidedigno.');", true);
                return;
            }
            mostraResultado(x1FR);
            return;
        }

        //se discriminante=0 a equação possui 2 raizes
        if (discriminante > 0)
        {
            //comparar x1 e x2 obtido pela fórmula resolvente com o obtido pelo método de newton
            double x1FR = calculo.formulaResolvente_x1(), x1MN = 0, x2FR = calculo.formulaResolvente_x2(), x2MN = 0;
            calculo.metodoNewton(ref x1MN, ref x2MN);
            // se a diferença entre os valores obtidos pelos 2 métodos for superior ao erroComparacao, surge mensagem de erro
            if (((Math.Abs(x1FR - x1MN)) >= erroComparacao) || ((Math.Abs(x2FR - x2MN)) >= erroComparacao))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Erro de cálculo; resultado não fidedigno.');", true);
                return;
            }
            mostraResultado(x1FR, x2FR);
            return;
        }
        
        
          
        
    }

    //********************************************** EVENTOS OnTextChanged ****************************************************

    //Estes eventos são accionados quando o texto de uma das 3 textboxs é alterado e chamam uma função auxiliar que faz a validação do que está a ser escrito na TextBox correspondente
    //Se tiver recebido false (a operação de conversão correu mal) --> mostra-se uma caixa de erro com o texto a dizer que só se aceitam valores numericos
    protected void TextBoxA_TextChanged(object sender, EventArgs e)
    {
        string alterada;
        TextBoxA.BorderColor = System.Drawing.ColorTranslator.FromHtml("#A9A9A9");
        TextBoxA.BorderWidth = 1;
        resultado.Text = "<br/>";
        eq_valida_actual = "";
        alterada = TextBoxA.Text.Replace('.', ',');
        if (!validar(alterada))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitidos valores numéricos até 8 dígitos.');", true);
            TextBoxA.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
            
        }
        else 
        {
        escreve_parametro("TextBoxA");                       
        }
    }
    protected void TextBoxB_TextChanged(object sender, EventArgs e)
    {
        string alterada;
        TextBoxB.BorderColor = System.Drawing.ColorTranslator.FromHtml("#A9A9A9");
        TextBoxB.BorderWidth = 1;
        resultado.Text = "<br/>";
        eq_valida_actual = "";
        alterada = TextBoxB.Text.Replace('.', ',');
        if (!validar(alterada))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitidos valores numéricos até 8 dígitos.');", true);
            TextBoxB.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
        }
        else 
        {
        escreve_parametro("TextBoxB");    
        }
    }
    protected void TextBoxC_TextChanged(object sender, EventArgs e)
    {
        string alterada;
        TextBoxC.BorderColor = System.Drawing.ColorTranslator.FromHtml("#A9A9A9");
        TextBoxC.BorderWidth = 1;
        resultado.Text = "<br/>";
        eq_valida_actual = "";
        alterada = TextBoxC.Text.Replace(".", ",");
        if (!validar(alterada))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitidos valores numéricos até 8 dígitos.');", true);
            TextBoxC.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
        }
        else 
        {
        escreve_parametro("TextBoxC");                      
        }
    }


    //escreve parametros consuante o que for introduzido(valores numericos negativos ou positivos) 
    protected void escreve_parametro(string TEXT_ALVO)
    {
        string alterada;
        double valor=0;
        if (TEXT_ALVO == "TextBoxA")
        {
            alterada = TextBoxA.Text.Replace('.', ',');

            if (alterada == "") 
            { 
                labelA.Text = "0x<sup>2</sup>";
                labelA1.Text = "0x<sup>2</sup>";
                return;
            }
            //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
            if (alterada[0] == '-')
            {
                double.TryParse(alterada, out valor);
                labelA.Text = " - " + -1 * valor + "x<sup>2</sup>"; //nao afeta a textbox
                labelA1.Text = " - " + -1 * valor + "x<sup>2</sup>"; //nao afeta a textbox
            }
            else
            {
                //escreve na interface consuante o valor a introduzido
                labelA.Text = alterada + "x<sup>2</sup>";
                labelA1.Text = alterada + "x<sup>2</sup>";
            }
        }
        else
        {
            if (TEXT_ALVO == "TextBoxB")
            {
                alterada = TextBoxB.Text.Replace('.', ',');
                if (alterada == "")
                {
                    labelB.Text = " + " + "0x";
                    labelB1.Text = " + " + "0x";
                    return;
                }
                //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
                if (alterada[0] == '-')
                {
                    double.TryParse(alterada, out valor);
                    labelB.Text = " - " + -1 * valor + "x"; //nao afeta a textbox
                    labelB1.Text = " - " + -1 * valor + "x"; //nao afeta a textbox
                }
                else
                {
                    //escreve na interface consuante o valor b introduzido
                    labelB.Text = " + " + alterada + "x";
                    labelB1.Text = " + " + alterada + "x";
                }
            }
            else
            {
                if (TEXT_ALVO == "TextBoxC")
                {
                    alterada = TextBoxC.Text.Replace('.', ',');
                    if (alterada == "")
                    {
                        labelC.Text = " + 0 = 0";
                        labelC1.Text = " + 0";
                        return;
                    }
                    //caso seja negativo para aparecer com espaçamento teremos de analisar e colocar o - com espaçamento e depois apenas o numero 
                    if (alterada[0] == '-')
                    {
                        double.TryParse(alterada, out valor);
                        labelC.Text = " - " + -1 * valor + " = 0"; //nao afeta a textbox
                        labelC1.Text = " - " + -1 * valor ; //nao afeta a textbox
                    }
                    else
                    {
                        //escreve na interface consuante o valor c introduzido
                        labelC.Text = " + " + alterada + " = 0";
                        labelC1.Text = " + " + alterada;
                    }
                }
            }
        }
    }

    //************************************************ FUNÇÃO validar() *************************************************

    //Função validar() recebe o valor da TextBox utilizada e tenta fazer a conversão para um double.
    //Se conseguir converter, guarda o valor convertido para uma variável do tipo double e retorna true (a operação correu bem)
    //Se não conseguir converter, retorna false (a operação correu mal)
    //Se a string possuir um numero de chars superior ao permitido pela constante maxChars, retorna false.
    private bool validar(string txt)
    {
        int maxChars = 8;
        double valor = 0;
        if (txt == "")
            return true;
        if (txt[0].Equals('+') || txt[0].Equals('-'))
            maxChars = 9;
        if (!double.TryParse(txt, out valor) || txt.Length > maxChars)
           return false;
        return true;
    }

    //************************************************ FUNÇÃO mostraResultado() *************************************************
    //recebe 1 ou 2 argumentos (variáveis double), constroi uma string com o resultado e mostra-a na respectiva caixa de texto.
    void mostraResultado(double x)
    {
        resultado.Text = "x = " + Math.Round(x, 4);
    }

    void mostraResultado(double x1, double x2)
    {
        resultado.Text = "x1 = " + Math.Round(x1, 4) + "<br />x2 = " + Math.Round(x2, 4) ;
    }

    public string getq()
    {
        return eq_valida_actual;
    }
    
}