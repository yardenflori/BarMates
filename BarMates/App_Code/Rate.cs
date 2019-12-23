﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Rate
{
    public Food<int> Food { get; set; }
    public Drinks<int> Drinks { get; set; }
    public Atmosphere<int> Atmosphere { get; set; }
    public Music<int> Music { get; set; }
    public Company<int> Company { get; set; }
    public Age Age { get; set; }
    public Price Price { get; set; }
    public int SmokingFree { get; set; }
    public int FullService { get; set; }
    public int SelfService { get; set; }

    public Rate()
    {
        
    }
}