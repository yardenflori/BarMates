using BarMates;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Rate
{
    public string UserName { get; set; }
    public int BarId { get; set; }
    public string BarGoogleId { get; set; }
    public string BarName { get; set; }
    public string photoURL { get; set; }
    public string address { get; set; }
    public DateTime date { get; set; }
    public Age Age { get; set; }//-------------------
    public Food<int> Food { get; set; }
    public Drinks<int> Drinks { get; set; }
    public Atmosphere<int> Atmosphere { get; set; }
    public Music<int> Music { get; set; }
    public Company<int> Company { get; set; }
    public Price Price { get; set; }//----
    public int SmokingFree { get; set; }
    public Service Service { get; set; }//----

    public Rate()
    {
        date = new DateTime();
        Food = new Food<int>();
        Drinks = new Drinks<int>();
        Atmosphere = new Atmosphere<int>();
        Music = new Music<int>();
        Company = new Company<int>();
    }
    public static Rate ParseObjectToRate(JObject jsonRate)
    {
        Rate newRate = new Rate()
        {
            UserName = DBController.GetUserName(),
            BarName = jsonRate["BarName"].ToString(),
            address = jsonRate["address"].ToString(),
            BarId = jsonRate["BarId"].ToString().GetHashCode(),
            BarGoogleId = jsonRate["BarId"].ToString(),
            photoURL = jsonRate["photoUrl"].ToString(),
            date = DateTime.Now,
            //Age
            Age = (Age)int.Parse(jsonRate["Age"].ToString()),
            //Service
            Service = (Service)int.Parse(jsonRate["Service"].ToString()),
            //Price
            Price = (Price)int.Parse(jsonRate["Price"].ToString()),
            //Food
            Food = new Food<int>()
            {
                Burger = int.Parse(jsonRate["Food"]["Burger"].ToString()),
                Pizza = int.Parse(jsonRate["Food"]["Pizza"].ToString()),
                Sushi = int.Parse(jsonRate["Food"]["Sushi"].ToString()),
                Snacks = int.Parse(jsonRate["Food"]["Snacks"].ToString()),
                Vegan = int.Parse(jsonRate["Food"]["Vegan"].ToString()),
                Kosher = int.Parse(jsonRate["Food"]["Kosher"].ToString())
            },
            //Drinks
            Drinks = new Drinks<int>()
            {
                Beer = int.Parse(jsonRate["Drinks"]["Beer"].ToString()),
                Wine = int.Parse(jsonRate["Drinks"]["Wine"].ToString()),
                Cocktail = int.Parse(jsonRate["Drinks"]["Cocktail"].ToString()),
                BeveragePackages = int.Parse(jsonRate["Drinks"]["BeveragePackages"].ToString()),
                Jin = int.Parse(jsonRate["Drinks"]["Jin"].ToString()),
                Whiskey = int.Parse(jsonRate["Drinks"]["Whiskey"].ToString()),
                WideRangeOfBeverages = int.Parse(jsonRate["Drinks"]["WideRangeOfBeverages"].ToString())
            },
            //Atmosphere
            Atmosphere = new Atmosphere<int>()
            {
                Irish = int.Parse(jsonRate["Atmosphere"]["Irish"].ToString()),
                Chill = int.Parse(jsonRate["Atmosphere"]["Chill"].ToString()),
                Dance = int.Parse(jsonRate["Atmosphere"]["Dance"].ToString()),
                Sport = int.Parse(jsonRate["Atmosphere"]["Sport"].ToString()),
                Shisha = int.Parse(jsonRate["Atmosphere"]["Shisha"].ToString()),
                Party = int.Parse(jsonRate["Atmosphere"]["Party"].ToString())
            },
            //SmokingFree
            SmokingFree = int.Parse(jsonRate["SmokingFree"].ToString()),
            //Company
            Company = new Company<int>()
            {
                Dating = int.Parse(jsonRate["Company"]["Dating"].ToString()),
                Friends = int.Parse(jsonRate["Company"]["Friends"].ToString()),
                KidsFriendly = int.Parse(jsonRate["Company"]["KidsFriendly"].ToString()),
                PetsFriendly = int.Parse(jsonRate["Company"]["PetsFriendly"].ToString()),
                Colleagues = int.Parse(jsonRate["Company"]["Colleagues"].ToString())
            },
            //Music 
            Music = new Music<int>()
            {
                Pop = int.Parse(jsonRate["Music"]["Pop"].ToString()),
                Jazz = int.Parse(jsonRate["Music"]["Jazz"].ToString()),
                Mizrahit = int.Parse(jsonRate["Music"]["Mizrahit"].ToString()),
                Greek = int.Parse(jsonRate["Music"]["Greek"].ToString()),
                Trance = int.Parse(jsonRate["Music"]["Trance"].ToString()),
                Mainstream = int.Parse(jsonRate["Music"]["Mainstream"].ToString()),
                Israeli = int.Parse(jsonRate["Music"]["Israeli"].ToString()),
                LiveMusic = int.Parse(jsonRate["Music"]["LiveMusic"].ToString()),
                Reggaeton = int.Parse(jsonRate["Music"]["Reggaeton"].ToString()),
                OpenMic = int.Parse(jsonRate["Music"]["OpenMic"].ToString()),
                StandUp = int.Parse(jsonRate["Music"]["StandUp"].ToString())
            }
        };
        return newRate;
    }

    public int[] RateVector()
    {
        int[] vector = new int[44];
        vector[0] = (SmokingFree != 7) ? 1 : 0;
        switch(Age)
        {
            case Age.EighteenPlus:
                vector[1] = 1;
                break;
            case Age.TwentyOnePlus:
                vector[2] = 1;
                break;
            case Age.TwentyFourPlus:
                vector[3] = 1;
                break;
            default:
                break;
        }
        switch (Price)
        {
            case Price.PriceLow:
                vector[4] = 1;
                break;
            case Price.PriceMed:
                vector[5] = 1;
                break;
            case Price.PriceHigh:
                vector[6] = 1;
                break;
            default:
                break;
        }
        switch (Service)
        {
            case Service.FullService:
                vector[7] = 1;
                break;
            case Service.SelfService:
                vector[8] = 1;
                break;
            default:
                break;
        }
        vector[9] = (Food.Burger != 7) ? 1 : 0;
        vector[10] = (Food.Vegan != 7) ? 1 : 0;
        vector[11] = (Food.Kosher != 7) ? 1 : 0;
        vector[12] = (Food.Pizza != 7) ? 1 : 0;
        vector[13] = (Food.Snacks != 7) ? 1 : 0;
        vector[14] = (Food.Sushi != 7) ? 1 : 0;
        vector[15] = (Drinks.WideRangeOfBeverages != 7) ? 1 : 0;
        vector[16] = (Drinks.Beer != 7) ? 1 : 0;
        vector[17] = (Drinks.BeveragePackages != 7) ? 1 : 0;
        vector[18] = (Drinks.Cocktail != 7) ? 1 : 0;
        vector[19] = (Drinks.Jin != 7) ? 1 : 0;
        vector[20] = (Drinks.Whiskey != 7) ? 1 : 0;
        vector[21] = (Drinks.Wine != 7) ? 1 : 0;
        vector[22] = (Atmosphere.Irish != 7) ? 1 : 0;
        vector[23] = (Atmosphere.Chill != 7) ? 1 : 0;
        vector[24] = (Atmosphere.Dance != 7) ? 1 : 0;
        vector[25] = (Atmosphere.Party != 7) ? 1 : 0;
        vector[26] = (Atmosphere.Shisha != 7) ? 1 : 0;
        vector[27] = (Atmosphere.Sport != 7) ? 1 : 0;
        vector[28] = (Company.Colleagues != 7) ? 1 : 0;
        vector[29] = (Company.Dating != 7) ? 1 : 0;
        vector[30] = (Company.Friends != 7) ? 1 : 0;
        vector[31] = (Company.KidsFriendly != 7) ? 1 : 0;
        vector[32] = (Company.PetsFriendly != 7) ? 1 : 0;
        vector[33] = (Music.Greek != 7) ? 1 : 0;
        vector[34] = (Music.Israeli != 7) ? 1 : 0;
        vector[35] = (Music.Jazz != 7) ? 1 : 0;
        vector[36] = (Music.LiveMusic != 7) ? 1 : 0;
        vector[37] = (Music.Mainstream != 7) ? 1 : 0;
        vector[38] = (Music.Mizrahit != 7) ? 1 : 0;
        vector[39] = (Music.OpenMic != 7) ? 1 : 0;
        vector[40] = (Music.Pop != 7) ? 1 : 0;
        vector[41] = (Music.Reggaeton != 7) ? 1 : 0;
        vector[42] = (Music.StandUp != 7) ? 1 : 0;
        vector[43] = (Music.Trance != 7) ? 1 : 0;
        return vector;
    }
}