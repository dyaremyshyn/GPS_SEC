using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Classe com os métodos responsáveis pelas operações de cálculo de X de uma equação do tipo ax^2+bx+c=0 .
/// </summary>
/// 

public class Calculo
{   //Valida equação _-não da para fazer calculo de raizes negativas- logo equação será impossivel
     public bool ValidaEq(double a, double b, double c)
    {  
         double valor = b*b - 4 * a * c;
         if (valor <= 0)
         {
             return false;
         }
         else {
              return true;
              }
    }
    

    //Calcula x1 pela formula resolvente quando existem os 3 termos a, b e c.
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x1(double a, double b, double c)
    {
        return (-b + Math.Sqrt(b*b - 4 * a * c)) / (2*a);
    }

    //Calcula x2 pela formula resolvente quando existem os 3 termos a, b e c
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x2(double a, double b, double c)
    {
        return (-b - Math.Sqrt(b*b - 4 * a * c)) / (2*a);
    }

    //Calcula X quando o termo a=0.
    //Recebe b e c e retorna o resultado.
    public double FR_b( double b, double c)
    {
        double zero = 0;
        zero = c / b;
        return zero;
    }

    //Calcula x1 quando o termo b=0.
    //Recebe a e c e retorna o resultado.
    public double FR_c_x1(double a, double b, double c)
    {
        return 2.3;
    }

    //Calcula x2 quando o termo b=0.
    //Recebe a e c e retorna o resultado.
    public double FR_c_x2(double a, double b, double c)
    {
        return 2.3;
    }

}

