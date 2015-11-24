using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Classe com os métodos responsáveis pelas operações de cálculo de X de uma equação do tipo ax^2+bx+c=0 .
/// </summary>
public class Calculo
{
    //Calculo x1 pela formula resolvente quando existem os 3 termos a, b e c.
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x1(double a, double b, double c)
    {
        return (-b + Math.Sqrt(b - 4 * a * c)) / (a * c);
    }

    //Calculo x2 pela formula resolvente quando existem os 3 termos a, b e c
    //Recebe a, b, e c e retorna o resultado.
    public double FR_a_x2(double a, double b, double c)
    {
        return (-b - Math.Sqrt(b - 4 * a * c)) / (a * c);
    }

}

