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

    }

    protected string digitos() //arredondamento a 2 casas decimais
    {
        return "{0:0.00}";
    }


    protected void botaoCalcular_Click(object sender, EventArgs e)
    {
        Calculo novo = new Calculo();
        double a = Convert.ToDouble(TextBoxA.Text);
        double b = Convert.ToDouble(TextBoxB.Text);
        double c = Convert.ToDouble(TextBoxC.Text);

        //caso o parametro A seja 0 (reta)
        if (a == 0 && b == 0)
        {
            //reta horizontal não apresenta 0´s
            resultado.Text = "Reta horizontal";
        }
        else {
                  if (a == 0 && c == 0) 
                  { 
                  //reta obliqua que passa sempre em 0
                      resultado.Text = "x = 0 <br />";
                  }
                  else{
                      if(a==0){
                              //reta obliqua com 1 zero                          
                              resultado.Text = "x = " + string.Format(digitos(), novo.FR_b(b, c)) + "<br />";                            
                              }else{
                                    //equação tem de ser possivel
                                     if (novo.ValidaEq(a, b, c))
                                     {
                                     //Calculo x1 pela formula resolvente quando existem os 3 termos a, b e c
                                     resultado.Text = "x1 = " + string.Format(digitos(),novo.FR_a_x1(a, b, c)) + "<br />"
                                     + "x2 = " + string.Format(digitos(),novo.FR_a_x2(a, b, c));
                                     }else { 
                                            //escreve equação impossivel numa label 
                                            resultado.Text = "Equação impossivel";
                                           }

                                   }

                      }
                   
            }
       
    }

    protected void TextBoxA_TextChanged(object sender, EventArgs e)
    {
        string ch = e.ToString();

        //fazer o TryParse
    }
}