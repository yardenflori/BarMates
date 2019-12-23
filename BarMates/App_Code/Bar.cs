using System;

public class Bar
{
    public int BarId { get; set; }
    public string BarName { get; set; }
    public string Address { get; set; }
    public Age Age { get; set; }
    public Food<bool> Food { get; set; }
    public Drinks<bool> Drink { get; set; }
    public Atmosphere<bool> Atmosphere { get; set; }
    public bool SmokingFree { get; set; }
    public Company<bool> Company { get; set; }
    public Music<bool> Music { get; set; }

    public Price Price { get; set; }
    public Service Service { get; set; }
    
    public int[] BarCharacteristics
    {
        get
        {
            CalculateBarCharacteristics();
            return BarCharacteristics;
        }
        set
        {

        }
    }
    public Bar()
	{
        BarCharacteristics = new int[44];
	}

    private void CalculateBarCharacteristics()
    {
        BarCharacteristics[0] = Smoking ? 1 : 0;
        switch(Age)
        {
            case Age.EighteenPlus:
                BarCharacteristics[1] = 1;
                break;
            case Age.TwentyOnePlus:
                BarCharacteristics[2] = 1;
                break;
            case Age.TwentyFourPlus:
                BarCharacteristics[3] = 1;
                break;
        }
        switch (Price)
        {
            case Price.PriceLow:
                BarCharacteristics[4] = 1;
                break;
            case Price.PriceMed:
                BarCharacteristics[5] = 1;
                break;
            case Price.PriceHigh:
                BarCharacteristics[6] = 1;
                break;
        }
        switch (Service)
        {
            case Service.FullService:
                BarCharacteristics[7] = 1;
                break;
            case Service.SelfService:
                BarCharacteristics[8] = 1;
                break;
        }
        BarCharacteristics[9] = Food.Burger ? 1 : 0;
        BarCharacteristics[10] = Food.Irish ? 1 : 0;
        BarCharacteristics[11] = Food.Kosher ? 1 : 0;
        BarCharacteristics[12] = Food.Pizza ? 1 : 0;
        BarCharacteristics[13] = Food.Snacks ? 1 : 0;
        BarCharacteristics[14] = Food.Sushi ? 1 : 0;
        BarCharacteristics[15] = Food.Vegan ? 1 : 0;
        BarCharacteristics[16] = Drink.Beer ? 1 : 0;
        BarCharacteristics[17] = Drink.BeveragePackages ? 1 : 0;
        BarCharacteristics[18] = Drink.Cocktail ? 1 : 0;
        BarCharacteristics[19] = Drink.Jin ? 1 : 0;
        BarCharacteristics[20] = Drink.Whiskey ? 1 : 0;
        BarCharacteristics[21] = Drink.WideRangeOfBeverages ? 1 : 0;
        BarCharacteristics[22] = Drink.Wine ? 1 : 0;
        BarCharacteristics[23] = Atmosphere.Chill ? 1 : 0;
        BarCharacteristics[24] = Atmosphere.Dance ? 1 : 0;
        BarCharacteristics[25] = Atmosphere.Party ? 1 : 0;
        BarCharacteristics[26] = Atmosphere.Shisha ? 1 : 0;
        BarCharacteristics[27] = Atmosphere.Sport ? 1 : 0;
        BarCharacteristics[28] = Company.Colleagues ? 1 : 0;
        BarCharacteristics[29] = Company.Dating ? 1 : 0;
        BarCharacteristics[30] = Company.Friends ? 1 : 0;
        BarCharacteristics[31] = Company.KidsFriendly ? 1 : 0;
        BarCharacteristics[32] = Company.PetsFriendly ? 1 : 0;
        BarCharacteristics[33] = Music.Greek ? 1 : 0;
        BarCharacteristics[34] = Music.Israeli ? 1 : 0;
        BarCharacteristics[35] = Music.Jazz ? 1 : 0;
        BarCharacteristics[36] = Music.LiveMusic ? 1 : 0;
        BarCharacteristics[37] = Music.Mainstream ? 1 : 0;
        BarCharacteristics[38] = Music.Mizrahit ? 1 : 0;
        BarCharacteristics[39] = Music.OpenMic ? 1 : 0;
        BarCharacteristics[40] = Music.Pop ? 1 : 0;
        BarCharacteristics[41] = Music.Reggaeton ? 1 : 0;
        BarCharacteristics[42] = Music.StandUp ? 1 : 0;
        BarCharacteristics[43] = Music.Trance ? 1 : 0;
    }
}
