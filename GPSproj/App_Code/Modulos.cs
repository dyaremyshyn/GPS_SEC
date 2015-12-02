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
    double termoA, termoB, termoC;

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
        termoA = Convert.ToDouble(stringA);
        termoB = Convert.ToDouble(stringB);
        termoC = Convert.ToDouble(stringC);
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

    public bool ValidaEq()
    {
        double valor = termoB * termoB - 4 * termoA * termoC;
         if (valor <= 0)
         {
             return false;
         }
         else {
              return true;
              }
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

    public double metodoNewton()
    {
        return 3;
    }

    //gráfico
}

