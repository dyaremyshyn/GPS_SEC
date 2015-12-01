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

    protected void botaoCalcular_Click(object sender, EventArgs e)
    {
        Calculo calculo = new Calculo(TextBoxA.Text, TextBoxB.Text, TextBoxC.Text);

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

    protected void TextBoxA_TextChanged(object sender, EventArgs e)
    {
        if (!validar("txtA"))
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);

    }
    protected void TextBoxB_TextChanged(object sender, EventArgs e)
    {
        if (!validar("txtB"))
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);

    }
    protected void TextBoxC_TextChanged(object sender, EventArgs e)
    {
        if (!validar("txtC"))
            ScriptManager.RegisterStartupScript(this, GetType(), "Erro", "alert('Só são permitodos valores numericos.');", true);

    }
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
}