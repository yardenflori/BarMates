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
    public int[] _BarCharacteristics;
    public int[] BarCharacteristics
    {
        get
        {
            CalculateBarCharacteristics();
            return _BarCharacteristics;
        }
        set
        {
            _BarCharacteristics = value;
        }
    }
    public Bar()
	{
        Food = new Food<bool>();
        Drink = new Drinks<bool>();
        Atmosphere = new Atmosphere<bool>();
        Company = new Company<bool>();
        Music = new Music<bool>();
        _BarCharacteristics = new int[44];
    }

    public void CalculateBarCharacteristics()
    {

        _BarCharacteristics[0] = SmokingFree ? 1 : 0;
        switch (Age)
        {
            case Age.EighteenPlus:
                _BarCharacteristics[1] = 1;
                break;
            case Age.TwentyOnePlus:
                _BarCharacteristics[2] = 1;
                break;
            case Age.TwentyFourPlus:
                _BarCharacteristics[3] = 1;
                break;
        }
        switch (Price)
        {
            case Price.PriceLow:
                _BarCharacteristics[4] = 1;
                break;
            case Price.PriceMed:
                _BarCharacteristics[5] = 1;
                break;
            case Price.PriceHigh:
                _BarCharacteristics[6] = 1;
                break;
        }
        switch (Service)
        {
            case Service.FullService:
                _BarCharacteristics[7] = 1;
                break;
            case Service.SelfService:
                _BarCharacteristics[8] = 1;
                break;
        }
        _BarCharacteristics[9] = Food.Burger ? 1 : 0;
        _BarCharacteristics[10] = Food.Vegan ? 1 : 0;
        _BarCharacteristics[11] = Food.Kosher ? 1 : 0;
        _BarCharacteristics[12] = Food.Pizza ? 1 : 0;
        _BarCharacteristics[13] = Food.Snacks ? 1 : 0;
        _BarCharacteristics[14] = Food.Sushi ? 1 : 0;
        _BarCharacteristics[15] = Drink.WideRangeOfBeverages ? 1 : 0;
        _BarCharacteristics[16] = Drink.Beer ? 1 : 0;
        _BarCharacteristics[17] = Drink.BeveragePackages ? 1 : 0;
        _BarCharacteristics[18] = Drink.Cocktail ? 1 : 0;
        _BarCharacteristics[19] = Drink.Jin ? 1 : 0;
        _BarCharacteristics[20] = Drink.Whiskey ? 1 : 0;
        _BarCharacteristics[21] = Drink.Wine ? 1 : 0;
        _BarCharacteristics[22] = Atmosphere.Irish ? 1 : 0;
        _BarCharacteristics[23] = Atmosphere.Chill ? 1 : 0;
        _BarCharacteristics[24] = Atmosphere.Dance ? 1 : 0;
        _BarCharacteristics[25] = Atmosphere.Party ? 1 : 0;
        _BarCharacteristics[26] = Atmosphere.Shisha ? 1 : 0;
        _BarCharacteristics[27] = Atmosphere.Sport ? 1 : 0;
        _BarCharacteristics[28] = Company.Colleagues ? 1 : 0;
        _BarCharacteristics[29] = Company.Dating ? 1 : 0;
        _BarCharacteristics[30] = Company.Friends ? 1 : 0;
        _BarCharacteristics[31] = Company.KidsFriendly ? 1 : 0;
        _BarCharacteristics[32] = Company.PetsFriendly ? 1 : 0;
        _BarCharacteristics[33] = Music.Greek ? 1 : 0;
        _BarCharacteristics[34] = Music.Israeli ? 1 : 0;
        _BarCharacteristics[35] = Music.Jazz ? 1 : 0;
        _BarCharacteristics[36] = Music.LiveMusic ? 1 : 0;
        _BarCharacteristics[37] = Music.Mainstream ? 1 : 0;
        _BarCharacteristics[38] = Music.Mizrahit ? 1 : 0;
        _BarCharacteristics[39] = Music.OpenMic ? 1 : 0;
        _BarCharacteristics[40] = Music.Pop ? 1 : 0;
        _BarCharacteristics[41] = Music.Reggaeton ? 1 : 0;
        _BarCharacteristics[42] = Music.StandUp ? 1 : 0;
        _BarCharacteristics[43] = Music.Trance ? 1 : 0;
    }
}
