using System;
using System.Collections.Generic;
using System.Linq;


public class BarsTagsMatrix
{
    public BarsTagsMatrix()
    {
        
    }

    /*returns a matrix, in the i row we have the bar tags (0 if dont have the tag, else 1)*/
    public Matrix GetBarTagsMatrix(List<Bar> bars)
    {
        int n = bars.Count;
        Matrix barsMatrix = new Matrix();
        barsMatrix.IDS = new int[n];
        for (int i = 0; i < n; i++)
        {
            barsMatrix.IDS[i] = bars[i].BarId;
            barsMatrix.CharMatrix[i] = bars[i].BarCharacteristics.Select(x => (double)x).ToArray();
        }
        return barsMatrix;
    }
    public Matrix GetSimilarBars(int numSimilar, Bar bar, Matrix barTagsMatrix)
    {
        Matrix similarBars = new Matrix();
        int n = barTagsMatrix.IDS.Length;
        double[] barDistance = new double[n];
        double tempMax = 0;
        int tempInd = 0;
        for(int i = 0; i < n; i++)
        {
            barDistance[i] = Helpers.VectorDistance(bar.BarCharacteristics.Select(x => (double)x).ToArray(), barTagsMatrix.CharMatrix[i]);
        }
        for(int i = 0; i < numSimilar; i++)
        {
            tempMax = barDistance.Max();
            tempInd = barDistance.ToList().IndexOf(tempMax);
            similarBars.IDS[i] = barTagsMatrix.IDS[tempInd];
            similarBars.CharMatrix[i] = barTagsMatrix.CharMatrix[tempInd];
            barDistance[tempInd] = -1;
        }
        return similarBars;
    }
}