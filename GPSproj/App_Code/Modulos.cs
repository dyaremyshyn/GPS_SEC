using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Modulo_II
/// </summary>
public class Calculo
{
    double a, b, c;

    double A
    {
        get { return a; }
        set { a = value; }
    }

    double B
    {
        get { return b; }
        set { b = value; }
    }

    double C
    {
        get { return c; }
        set { c = value; }
    }

    double calcularX1()
    {
        return a + b + c;
    }

}