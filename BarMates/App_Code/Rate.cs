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
        Rate newRate = new Rate();
        newRate.UserName = DBController.GetUserName();
        var a = jsonRate["BarId"].ToString();
        newRate.BarId = jsonRate["BarId"].ToString().GetHashCode();
        newRate.date = DateTime.Now;
        //Age
        newRate.Age = (Age)int.Parse(jsonRate["Age"].ToString());
        //Service
        newRate.Service = (Service)int.Parse(jsonRate["Service"].ToString());
        //Price
        newRate.Price = (Price)int.Parse(jsonRate["Price"].ToString());
        //Food
        newRate.Food = new Food<int>();
        newRate.Food.Burger = int.Parse(jsonRate["Food"]["Burger"].ToString());
        newRate.Food.Pizza = int.Parse(jsonRate["Food"]["Pizza"].ToString());
        newRate.Food.Sushi = int.Parse(jsonRate["Food"]["Sushi"].ToString());
        newRate.Food.Snacks = int.Parse(jsonRate["Food"]["Snacks"].ToString());
        newRate.Food.Vegan = int.Parse(jsonRate["Food"]["Vegan"].ToString());
        newRate.Food.Kosher = int.Parse(jsonRate["Food"]["Kosher"].ToString());
        //Drinks
        newRate.Drinks = new Drinks<int>();
        newRate.Drinks.Beer = int.Parse(jsonRate["Drinks"]["Beer"].ToString());
        newRate.Drinks.Wine = int.Parse(jsonRate["Drinks"]["Wine"].ToString());
        newRate.Drinks.Cocktail = int.Parse(jsonRate["Drinks"]["Cocktail"].ToString());
        newRate.Drinks.BeveragePackages = int.Parse(jsonRate["Drinks"]["BeveragePackages"].ToString());
        newRate.Drinks.Jin = int.Parse(jsonRate["Drinks"]["Jin"].ToString());
        newRate.Drinks.Whiskey = int.Parse(jsonRate["Drinks"]["Whiskey"].ToString());
        newRate.Drinks.WideRangeOfBeverages = int.Parse(jsonRate["Drinks"]["WideRangeOfBeverages"].ToString());
        //Atmosphere
        newRate.Atmosphere = new Atmosphere<int>();
        newRate.Atmosphere.Irish = int.Parse(jsonRate["Atmosphere"]["Irish"].ToString());
        newRate.Atmosphere.Chill = int.Parse(jsonRate["Atmosphere"]["Chill"].ToString());
        newRate.Atmosphere.Dance = int.Parse(jsonRate["Atmosphere"]["Dance"].ToString());
        newRate.Atmosphere.Sport = int.Parse(jsonRate["Atmosphere"]["Sport"].ToString());
        newRate.Atmosphere.Shisha = int.Parse(jsonRate["Atmosphere"]["Shisha"].ToString());
        newRate.Atmosphere.Party = int.Parse(jsonRate["Atmosphere"]["Party"].ToString());
        //SmokingFree
        newRate.SmokingFree = int.Parse(jsonRate["SmokingFree"].ToString());
        //Company
        newRate.Company = new Company<int>();
        newRate.Company.Dating = int.Parse(jsonRate["Company"]["Dating"].ToString());
        newRate.Company.Friends = int.Parse(jsonRate["Company"]["Friends"].ToString());
        newRate.Company.KidsFriendly = int.Parse(jsonRate["Company"]["KidsFriendly"].ToString());
        newRate.Company.PetsFriendly = int.Parse(jsonRate["Company"]["PetsFriendly"].ToString());
        newRate.Company.Colleagues = int.Parse(jsonRate["Company"]["Colleagues"].ToString());
        //Music 
        newRate.Music = new Music<int>();
        newRate.Music.Jazz = int.Parse(jsonRate["Music"]["Jazz"].ToString());
        newRate.Music.Mizrahit = int.Parse(jsonRate["Music"]["Mizrahit"].ToString());
        newRate.Music.Greek = int.Parse(jsonRate["Music"]["Greek"].ToString());
        newRate.Music.Trance = int.Parse(jsonRate["Music"]["Trance"].ToString());
        newRate.Music.Mainstream = int.Parse(jsonRate["Music"]["Mainstream"].ToString());
        newRate.Music.Israeli = int.Parse(jsonRate["Music"]["Israeli"].ToString());
        newRate.Music.LiveMusic = int.Parse(jsonRate["Music"]["LiveMusic"].ToString());
        newRate.Music.Reggaeton = int.Parse(jsonRate["Music"]["Reggaeton"].ToString());
        newRate.Music.OpenMic = int.Parse(jsonRate["Music"]["OpenMic"].ToString());
        newRate.Music.StandUp = int.Parse(jsonRate["Music"]["StandUp"].ToString());
        return newRate;
    }
}