using System;

public class Bar
{
    public string BarId { get; set; }
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
    private int[] _barCharacteristics { get; set; }
    public int[] BarCharacteristics
    {
        get
        {
            CalculateBarCharacteristics();
            return _barCharacteristics;
        }
        set
        {
            _barCharacteristics = value;
        }
    }
    public Bar()
	{
        Food = new Food<bool>();
        Drink = new Drinks<bool>();
        Atmosphere = new Atmosphere<bool>();
        Company = new Company<bool>();
        Music = new Music<bool>();
        _barCharacteristics = new int[44];
    }

    public void CalculateBarCharacteristics()
    {

        _barCharacteristics[0] = SmokingFree ? 1 : 0;
        switch (Age)
        {
            case Age.EighteenPlus:
                _barCharacteristics[1] = 1;
                break;
            case Age.TwentyOnePlus:
                _barCharacteristics[2] = 1;
                break;
            case Age.TwentyFourPlus:
                _barCharacteristics[3] = 1;
                break;
        }
        switch (Price)
        {
            case Price.PriceLow:
                _barCharacteristics[4] = 1;
                break;
            case Price.PriceMed:
                _barCharacteristics[5] = 1;
                break;
            case Price.PriceHigh:
                _barCharacteristics[6] = 1;
                break;
        }
        switch (Service)
        {
            case Service.FullService:
                _barCharacteristics[7] = 1;
                break;
            case Service.SelfService:
                _barCharacteristics[8] = 1;
                break;
        }
        _barCharacteristics[9] = Food.Burger ? 1 : 0;
        _barCharacteristics[10] = Food.Vegan ? 1 : 0;
        _barCharacteristics[11] = Food.Kosher ? 1 : 0;
        _barCharacteristics[12] = Food.Pizza ? 1 : 0;
        _barCharacteristics[13] = Food.Snacks ? 1 : 0;
        _barCharacteristics[14] = Food.Sushi ? 1 : 0;
        _barCharacteristics[15] = Drink.WideRangeOfBeverages ? 1 : 0;
        _barCharacteristics[16] = Drink.Beer ? 1 : 0;
        _barCharacteristics[17] = Drink.BeveragePackages ? 1 : 0;
        _barCharacteristics[18] = Drink.Cocktail ? 1 : 0;
        _barCharacteristics[19] = Drink.Jin ? 1 : 0;
        _barCharacteristics[20] = Drink.Whiskey ? 1 : 0;
        _barCharacteristics[21] = Drink.Wine ? 1 : 0;
        _barCharacteristics[22] = Atmosphere.Irish ? 1 : 0;
        _barCharacteristics[23] = Atmosphere.Chill ? 1 : 0;
        _barCharacteristics[24] = Atmosphere.Dance ? 1 : 0;
        _barCharacteristics[25] = Atmosphere.Party ? 1 : 0;
        _barCharacteristics[26] = Atmosphere.Shisha ? 1 : 0;
        _barCharacteristics[27] = Atmosphere.Sport ? 1 : 0;
        _barCharacteristics[28] = Company.Colleagues ? 1 : 0;
        _barCharacteristics[29] = Company.Dating ? 1 : 0;
        _barCharacteristics[30] = Company.Friends ? 1 : 0;
        _barCharacteristics[31] = Company.KidsFriendly ? 1 : 0;
        _barCharacteristics[32] = Company.PetsFriendly ? 1 : 0;
        _barCharacteristics[33] = Music.Greek ? 1 : 0;
        _barCharacteristics[34] = Music.Israeli ? 1 : 0;
        _barCharacteristics[35] = Music.Jazz ? 1 : 0;
        _barCharacteristics[36] = Music.LiveMusic ? 1 : 0;
        _barCharacteristics[37] = Music.Mainstream ? 1 : 0;
        _barCharacteristics[38] = Music.Mizrahit ? 1 : 0;
        _barCharacteristics[39] = Music.OpenMic ? 1 : 0;
        _barCharacteristics[40] = Music.Pop ? 1 : 0;
        _barCharacteristics[41] = Music.Reggaeton ? 1 : 0;
        _barCharacteristics[42] = Music.StandUp ? 1 : 0;
        _barCharacteristics[43] = Music.Trance ? 1 : 0;
    }
}
