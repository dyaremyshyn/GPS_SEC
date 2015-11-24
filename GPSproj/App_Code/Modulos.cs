using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Classe com os métodos responsáveis pelas operações de cálculo de X de uma equação do tipo ax^2+bx+c=0 .
/// </summary>
/// 

public class Calculo
{
    //Calcula x1 pela formula resolvente quando existem os 3 termos a, b e c.
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x1(double a, double b, double c)
    {
        return (-b + Math.Sqrt(b - 4 * a * c)) / (a * c);
    }

    //Calcula x2 pela formula resolvente quando existem os 3 termos a, b e c
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x2(double a, double b, double c)
    {
        return (-b - Math.Sqrt(b - 4 * a * c)) / (a * c);
    }

    //Calcula X quando o termo a=0.
    //Recebe b e c e retorna o resultado.
    public double FR_b(double a, double b, double c)
    {
        return 2.3;
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

