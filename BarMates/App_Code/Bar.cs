using System;

public class Bar
{
    public int BarId { get; set; }
    public string BarName { get; set; }
    public string Address { get; set; }
    public bool Smoking { get; set; }
    public Age Age { get; set; }
    public Price Price { get; set; }
    public Service Service { get; set; }
    public Food<bool> Food { get; set; }
    public Drinks<bool> Drink { get; set; }
    public Atmosphere<bool> Atmosphere { get; set; }
    public Company<bool> Company { get; set; }
    public Music<bool> Music { get; set; }

    public Bar()
	{

	}
}
