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
        Calculo novo = new Calculo();
       
        //Calculo x1 pela formula resolvente quando existem os 3 termos a, b e c
        resultado.Text ="x1 = "+novo.FR_a_x1(Convert.ToDouble(TextBoxA.Text), Convert.ToDouble(TextBoxB.Text), Convert.ToDouble(TextBoxC.Text)).ToString()+"<br />"
            + "x2 = " + novo.FR_a_x2(Convert.ToDouble(TextBoxA.Text), Convert.ToDouble(TextBoxB.Text), Convert.ToDouble(TextBoxC.Text)).ToString();

    }
}