using System.Math;

public static class Helpers
{
    /*the vectors are interest vectors, it have to be the same length*/
    public static double InterestsVectorDistance(double[] vector1, double[] vector2)
    {
        int sum = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            sum += Math.Pow((vector1[i] - vector2[i]), 2.0);
        }
        sum = Math.sqrt(sum);
        return sum;
    }
}