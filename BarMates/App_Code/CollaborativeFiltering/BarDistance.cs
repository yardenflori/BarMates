using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BarDistance : IComparable<BarDistance>
{
    public int BarID { get; set; }
    public double Distance { get; set; }

    public BarDistance(int barID, double distance)
    {
        BarID = barID;
        Distance = distance;
    }

    public int CompareTo(BarDistance otherBar)
    {
        return Distance.CompareTo(otherBar.Distance);
    }

}