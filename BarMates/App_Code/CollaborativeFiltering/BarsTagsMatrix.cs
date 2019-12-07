using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BarsTagsMatrix
{
    public int[][] GetBarTagsMatrix(List<Bar> bars)
    {
        int n = bars.Count;
        int[][] barsMatrix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            barsMatrix[i] = new int[bars[i].BarCharacteristics.Length + 1];
            barsMatrix[i][0] = bars[i].BarId;
            for (int j = 1; j < bars[i].BarCharacteristics.Length + 1; j++)
            {
                barsMatrix[i][j] = bars[i].BarCharacteristics[j];
            }
        }
        return barsMatrix;
    }
    public BarsTagsMatrix()
    {
        
    }
}