using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Rate
{
    public Food<int> Food { get; set; }
    public Drinks<int> Drinks { get; set; }
    public Atmosphere<int> Atmosphere { get; set; }
    public Company<int> Company { get; set; }
    public Music<int> Music { get; set; }
    public int Smoking { get; set; }
    public int Age { get; set; }
    public int Service { get; set; }
    public int Price { get; set; }

    public Rate()
    {
        
    }
}