using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using BarMates;
using System.Collections;
using System.Data.Common;



public static class Helpers
{
    /*the vectors are interest vectors, it have to be the same length*/
    public static double VectorDistance(double[] vector1, double[] vector2)
    {
        double sum = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            sum += Math.Pow((vector1[i] - vector2[i]), 2.0);
        }
        sum = Math.Sqrt(sum);
        return sum;
    }

}