using System;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Linq;



public class Bar
{
    public int BarId { get; set; }
    public string BarGoogleId { get; set; }
    public string BarName { get; set; }
    public string Address { get; set; }
    public string PhotoUrl { get; set; }
    public Age Age { get; set; }
    public Food<bool> Food { get; set; }
    public Drinks<bool> Drinks { get; set; }
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
        Drinks = new Drinks<bool>();
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
        _barCharacteristics[15] = Drinks.WideRangeOfBeverages ? 1 : 0;
        _barCharacteristics[16] = Drinks.Beer ? 1 : 0;
        _barCharacteristics[17] = Drinks.BeveragePackages ? 1 : 0;
        _barCharacteristics[18] = Drinks.Cocktail ? 1 : 0;
        _barCharacteristics[19] = Drinks.Jin ? 1 : 0;
        _barCharacteristics[20] = Drinks.Whiskey ? 1 : 0;
        _barCharacteristics[21] = Drinks.Wine ? 1 : 0;
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

    public void CalculateBarFeilds()
    {
        SmokingFree = (_barCharacteristics[0] == 1) ? true : false;
        if (_barCharacteristics[1] == 1)
        {
            Age = Age.EighteenPlus;
        }
        else if (_barCharacteristics[2] == 1)
        {
            Age = Age.TwentyOnePlus;
        }
        else if (_barCharacteristics[3] == 1)
        {
            Age = Age.TwentyFourPlus;
        }
        else
        {
            Age = Age.None;
        }

        if (_barCharacteristics[4] == 1)
        {
            Price = Price.PriceLow;
        }
        else if (_barCharacteristics[5] == 1)
        {
            Price = Price.PriceMed;
        }
        else if (_barCharacteristics[6] == 1)
        {
            Price = Price.PriceHigh;
        }
        else
        {
            Price = Price.None;
        }

        if (_barCharacteristics[7] == 1)
        {
            Service = Service.FullService;
        }
        else if (_barCharacteristics[8] == 1)
        {
            Service = Service.SelfService;
        }
        else
        {
            Service = Service.None;
        }
        Food.Burger = (_barCharacteristics[9] == 1) ? true : false;
        Food.Vegan = (_barCharacteristics[10] == 1) ? true : false;
        Food.Kosher = (_barCharacteristics[11] == 1) ? true : false;
        Food.Pizza = (_barCharacteristics[12] == 1) ? true : false;
        Food.Snacks = (_barCharacteristics[13] == 1) ? true : false;
        Food.Sushi = (_barCharacteristics[14] == 1) ? true : false;
        Drinks.WideRangeOfBeverages = (_barCharacteristics[15] == 1) ? true : false;
        Drinks.Beer = (_barCharacteristics[16] == 1) ? true : false;
        Drinks.BeveragePackages = (_barCharacteristics[17] == 1) ? true : false;
        Drinks.Cocktail = (_barCharacteristics[18] == 1) ? true : false;
        Drinks.Jin = (_barCharacteristics[19] == 1) ? true : false;
        Drinks.Whiskey = (_barCharacteristics[20] == 1) ? true : false;
        Drinks.Wine = (_barCharacteristics[21] == 1) ? true : false;
        Atmosphere.Irish = (_barCharacteristics[22] == 1) ? true : false;
        Atmosphere.Chill = (_barCharacteristics[23] == 1) ? true : false;
        Atmosphere.Dance = (_barCharacteristics[24] == 1) ? true : false;
        Food.Vegan = (_barCharacteristics[25] == 1) ? true : false;
        Atmosphere.Shisha = (_barCharacteristics[26] == 1) ? true : false;
        Atmosphere.Sport = (_barCharacteristics[27] == 1) ? true : false;
        Company.Colleagues = (_barCharacteristics[28] == 1) ? true : false;
        Company.Dating = (_barCharacteristics[29] == 1) ? true : false;
        Company.Friends = (_barCharacteristics[30] == 1) ? true : false;
        Company.KidsFriendly = (_barCharacteristics[31] == 1) ? true : false;
        Company.PetsFriendly = (_barCharacteristics[32] == 1) ? true : false;
        Music.Greek = (_barCharacteristics[33] == 1) ? true : false;
        Music.Israeli = (_barCharacteristics[34] == 1) ? true : false;
        Music.Jazz = (_barCharacteristics[35] == 1) ? true : false;
        Music.LiveMusic = (_barCharacteristics[36] == 1) ? true : false;
        Music.Mainstream = (_barCharacteristics[37] == 1) ? true : false;
        Music.Mizrahit = (_barCharacteristics[38] == 1) ? true : false;
        Music.OpenMic = (_barCharacteristics[39] == 1) ? true : false;
        Music.Pop = (_barCharacteristics[40] == 1) ? true : false;
        Music.Reggaeton = (_barCharacteristics[41] == 1) ? true : false;
        Music.StandUp = (_barCharacteristics[42] == 1) ? true : false;
        Music.Trance = (_barCharacteristics[43] == 1) ? true : false;
    }
    
    public void UpdateBarByRate()
    {
        List<Rate> rates = Engine.GetRatesByBar(this);
        int[] counters = new int[44];
        int cnt = 0;
        int temp = 0;
        int timeDiff;
        for (int i = 0; i < rates.Count; i++)
        {
            int[] vector = rates[i].RateVector();
            timeDiff = Helpers.TimeDifference(DateTime.Now, rates[i].date);
            if (timeDiff < 3)
            {
                temp = 4;
            }
            else if (timeDiff < 6)
            {
                temp = 3;
            }
            else if (timeDiff < 12)
            {
                temp = 2;
            }
            else
            {
                temp = 1;
            }
            cnt += temp;
            for (int j = 0; j < vector.Length; j++)
            {
                counters[j] += vector[j] * temp;
            }
        }
        for (int i = 0; i < _barCharacteristics.Length; i++)
        {
            _barCharacteristics[i] = (counters[i] > (0.2 * cnt)) ? 1 : 0;
        }
        CalculateBarFeilds();
    }

    public static void UpdateBarPhoto(Bar bar)
    {
        string urlRequest = "https://maps.googleapis.com/maps/api/place/details/xml?place_id=" + bar.BarGoogleId + "&fields=photo&key=AIzaSyAsbHXRTAYj2YJfZNxms2Sp15zAG_-6Dyc";
        WebRequest request = WebRequest.Create(urlRequest);
        WebResponse response = request.GetResponse();

        List<string> namesList = new List<string>();

        using (Stream dataStream = response.GetResponseStream())
        {
            try
            {
                XDocument xdoc = XDocument.Load(dataStream);

                var name1 = from item in xdoc.Descendants("result").Elements("photo")
                            select item.Element("photo_reference").Value;
                foreach (string name in name1)
                {
                    namesList.Add(name);
                    string photoUrl = Helpers.photoReferenceToPhotoUrl(namesList[0]);
                    bar.PhotoUrl = photoUrl;
                    Engine.InsertUpdateBarCharacteristicToDB(bar);
                    break;
                }

            }
            catch
            {

            }

        }
    }
}

