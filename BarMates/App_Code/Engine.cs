using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;
using System.Collections;

public class Engine
{
    public User User { set; get; }
    public List<User> Users { set; get; }
    public List<Bar> Bars { get; set; }
    public Engine()
	{
        InitUser();
        if(User.UserName!=null)
        {
            InitUsers();
            InitBars();
        }
    }

    public void InitUser()
    {
        string username = DBController.GetUserName();
        if (username!=null)
        {
            User = new User(this);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("user_name", username));
            var userDB = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_username", parameters);

            if (userDB.Count > 0)
            {
                foreach (DbDataRecord currentItem in userDB)
                {
                    UpdateUserFields(User, currentItem);
                }
            }
        }
    }

    public void InitUsers()
    {
        Users = new List<User>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("user_name", User.UserName));
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_other_users", parameters);

        if (usersDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in usersDB)
            {
                User new_user = new User(this);
                UpdateUserFields(new_user, currentItem);
                Users.Add(new_user);
            }
        }
    }

    public static void UpdateUserFields(User user, DbDataRecord data)
    {
        user.UserId = int.Parse(data["userId"].ToString());
        user.UserName = data["userName"].ToString();
        user.Password = data["password"].ToString();
        user.Age = int.Parse(data["age"].ToString());
        user.SmokingFree.NegCounts = int.Parse(data["smokingFreeNeg"].ToString());
        user.SmokingFree.PosCounts = int.Parse(data["smokingFreePos"].ToString());
        user.SmokingFree.DontCareCounts = int.Parse(data["smokingFreeDontCare"].ToString());
        user.Food.Burger.NegCounts = int.Parse(data["burgersNeg"].ToString());
        user.Food.Burger.PosCounts = int.Parse(data["burgersPos"].ToString());
        user.Food.Burger.DontCareCounts = int.Parse(data["burgersDontCare"].ToString());
        user.Food.Pizza.NegCounts = int.Parse(data["pizzaNeg"].ToString());
        user.Food.Pizza.PosCounts = int.Parse(data["pizzaPos"].ToString());
        user.Food.Pizza.DontCareCounts = int.Parse(data["pizzaDontCare"].ToString());
        user.Food.Sushi.NegCounts = int.Parse(data["sushiNeg"].ToString());
        user.Food.Sushi.PosCounts = int.Parse(data["sushiPos"].ToString());
        user.Food.Sushi.DontCareCounts = int.Parse(data["sushiDontCare"].ToString());
        user.Food.Snacks.NegCounts = int.Parse(data["snackNeg"].ToString());
        user.Food.Snacks.PosCounts = int.Parse(data["snacksPos"].ToString());
        user.Food.Snacks.DontCareCounts = int.Parse(data["snacksDontCare"].ToString());
        user.Food.Vegan.NegCounts = int.Parse(data["veganNeg"].ToString());
        user.Food.Vegan.PosCounts = int.Parse(data["veganPos"].ToString());
        user.Food.Vegan.DontCareCounts = int.Parse(data["veganDontCare"].ToString());
        user.Food.Kosher.NegCounts = int.Parse(data["kosherNeg"].ToString());
        user.Food.Kosher.PosCounts = int.Parse(data["kosherPos"].ToString());
        user.Food.Kosher.DontCareCounts = int.Parse(data["kosherDontCare"].ToString());
        user.Drink.Beer.NegCounts = int.Parse(data["beerNeg"].ToString());
        user.Drink.Beer.PosCounts = int.Parse(data["beerPos"].ToString());
        user.Drink.Beer.DontCareCounts = int.Parse(data["beerDontCare"].ToString());
        user.Drink.Wine.NegCounts = int.Parse(data["wineNeg"].ToString());
        user.Drink.Wine.PosCounts = int.Parse(data["winePos"].ToString());
        user.Drink.Wine.DontCareCounts = int.Parse(data["wineDontCare"].ToString());
        user.Drink.Cocktail.NegCounts = int.Parse(data["cocktailNeg"].ToString());
        user.Drink.Cocktail.PosCounts = int.Parse(data["cocktailPos"].ToString());
        user.Drink.Cocktail.DontCareCounts = int.Parse(data["cocktailDontCare"].ToString());
        user.Drink.BeveragePackages.NegCounts = int.Parse(data["beveragePackagesNeg"].ToString());
        user.Drink.BeveragePackages.PosCounts = int.Parse(data["beveragePackagesPos"].ToString());
        user.Drink.BeveragePackages.DontCareCounts = int.Parse(data["beveragePackagesDontCare"].ToString());
        user.Drink.Jin.NegCounts = int.Parse(data["JinNeg"].ToString());
        user.Drink.Jin.PosCounts = int.Parse(data["JinPos"].ToString());
        user.Drink.Jin.DontCareCounts = int.Parse(data["JinDontCare"].ToString());
        user.Drink.Whiskey.NegCounts = int.Parse(data["whiskeyNeg"].ToString());
        user.Drink.Whiskey.PosCounts = int.Parse(data["whiskeyPos"].ToString());
        user.Drink.Whiskey.DontCareCounts = int.Parse(data["whiskeyDontCare"].ToString());
        user.Drink.WideRangeOfBeverages.NegCounts = int.Parse(data["wideRangeOfBeveragesNeg"].ToString());
        user.Drink.WideRangeOfBeverages.PosCounts = int.Parse(data["wideRangeOfBeveragesPos"].ToString());
        user.Drink.WideRangeOfBeverages.DontCareCounts = int.Parse(data["wideRangeOfBeveragesDontCare"].ToString());
        user.Atmosphere.Irish.NegCounts = int.Parse(data["irishNeg"].ToString());
        user.Atmosphere.Irish.PosCounts = int.Parse(data["irishPos"].ToString());
        user.Atmosphere.Irish.DontCareCounts = int.Parse(data["irishDontCare"].ToString());
        user.Atmosphere.Chill.NegCounts = int.Parse(data["chillNeg"].ToString());
        user.Atmosphere.Chill.PosCounts = int.Parse(data["chillPos"].ToString());
        user.Atmosphere.Chill.DontCareCounts = int.Parse(data["chillDontCare"].ToString());
        user.Atmosphere.Dance.NegCounts = int.Parse(data["danceNeg"].ToString());
        user.Atmosphere.Dance.PosCounts = int.Parse(data["dancePos"].ToString());
        user.Atmosphere.Dance.DontCareCounts = int.Parse(data["danceDontCare"].ToString());
        user.Atmosphere.Sport.NegCounts = int.Parse(data["sportNeg"].ToString());
        user.Atmosphere.Sport.PosCounts = int.Parse(data["sportPos"].ToString());
        user.Atmosphere.Sport.DontCareCounts = int.Parse(data["sportDontCare"].ToString());
        user.Atmosphere.Shisha.NegCounts = int.Parse(data["shishaNeg"].ToString());
        user.Atmosphere.Shisha.PosCounts = int.Parse(data["shishaPos"].ToString());
        user.Atmosphere.Shisha.DontCareCounts = int.Parse(data["shishaDontCare"].ToString());
        user.Atmosphere.Party.NegCounts = int.Parse(data["partyNeg"].ToString());
        user.Atmosphere.Party.PosCounts = int.Parse(data["partyPos"].ToString());
        user.Atmosphere.Party.DontCareCounts = int.Parse(data["partyDontCare"].ToString());
        user.Company.Dating.NegCounts = int.Parse(data["datingNeg"].ToString());
        user.Company.Dating.PosCounts = int.Parse(data["datingPos"].ToString());
        user.Company.Dating.DontCareCounts = int.Parse(data["datingDontCare"].ToString());
        user.Company.Friends.NegCounts = int.Parse(data["friendsNeg"].ToString());
        user.Company.Friends.PosCounts = int.Parse(data["friendsPos"].ToString());
        user.Company.Friends.DontCareCounts = int.Parse(data["friendsDontCare"].ToString());
        user.Company.KidsFriendly.NegCounts = int.Parse(data["kidsFriendlyNeg"].ToString());
        user.Company.KidsFriendly.PosCounts = int.Parse(data["kidsFriendlyPos"].ToString());
        user.Company.KidsFriendly.DontCareCounts = int.Parse(data["kidsFriendlyDontCare"].ToString());
        user.Company.PetsFriendly.NegCounts = int.Parse(data["petsFriendlyNeg"].ToString());
        user.Company.PetsFriendly.PosCounts = int.Parse(data["petsFriendlyPos"].ToString());
        user.Company.PetsFriendly.DontCareCounts = int.Parse(data["petsFriendlyDontCare"].ToString());
        user.Company.Colleagues.NegCounts = int.Parse(data["colleaguesNeg"].ToString());
        user.Company.Colleagues.PosCounts = int.Parse(data["colleaguesPos"].ToString());
        user.Company.Colleagues.DontCareCounts = int.Parse(data["colleaguesDontCare"].ToString());
        user.Music.Pop.NegCounts = int.Parse(data["popNeg"].ToString());
        user.Music.Pop.PosCounts = int.Parse(data["popPos"].ToString());
        user.Music.Pop.DontCareCounts = int.Parse(data["popDontCare"].ToString());
        user.Music.Jazz.NegCounts = int.Parse(data["jazzNeg"].ToString());
        user.Music.Jazz.PosCounts = int.Parse(data["jazzPos"].ToString());
        user.Music.Jazz.DontCareCounts = int.Parse(data["jazzDontCare"].ToString());
        user.Music.Mizrahit.NegCounts = int.Parse(data["mizrahitNeg"].ToString());
        user.Music.Mizrahit.PosCounts = int.Parse(data["mizrahitPos"].ToString());
        user.Music.Mizrahit.DontCareCounts = int.Parse(data["mizrahitDontCare"].ToString());
        user.Music.Greek.NegCounts = int.Parse(data["greekNeg"].ToString());
        user.Music.Greek.PosCounts = int.Parse(data["greekPos"].ToString());
        user.Music.Greek.DontCareCounts = int.Parse(data["greekDontCare"].ToString());
        user.Music.Trance.NegCounts = int.Parse(data["tranceNeg"].ToString());
        user.Music.Trance.PosCounts = int.Parse(data["trancePos"].ToString());
        user.Music.Trance.DontCareCounts = int.Parse(data["tranceDontCare"].ToString());
        user.Music.Mainstream.NegCounts = int.Parse(data["mainstreamNeg"].ToString());
        user.Music.Mainstream.PosCounts = int.Parse(data["mainstreamPos"].ToString());
        user.Music.Mainstream.DontCareCounts = int.Parse(data["mainstreamDontCare"].ToString());
        user.Music.Israeli.NegCounts = int.Parse(data["israeliNeg"].ToString());
        user.Music.Israeli.PosCounts = int.Parse(data["israeliPos"].ToString());
        user.Music.Israeli.DontCareCounts = int.Parse(data["israeliDontCare"].ToString());
        user.Music.LiveMusic.NegCounts = int.Parse(data["liveMusicNeg"].ToString());
        user.Music.LiveMusic.PosCounts = int.Parse(data["liveMusicPos"].ToString());
        user.Music.LiveMusic.DontCareCounts = int.Parse(data["liveMusicDontCare"].ToString());
        user.Music.Reggaeton.NegCounts = int.Parse(data["reggaetonNeg"].ToString());
        user.Music.Reggaeton.PosCounts = int.Parse(data["reggaetonPos"].ToString());
        user.Music.Reggaeton.DontCareCounts = int.Parse(data["reggaetonDontCare"].ToString());
        user.Music.OpenMic.NegCounts = int.Parse(data["openMicNeg"].ToString());
        user.Music.OpenMic.PosCounts = int.Parse(data["openMicPos"].ToString());
        user.Music.OpenMic.DontCareCounts = int.Parse(data["openMicDontCare"].ToString());
        user.Music.StandUp.NegCounts = int.Parse(data["standupNeg"].ToString());
        user.Music.StandUp.PosCounts = int.Parse(data["standupPos"].ToString());
        user.Music.StandUp.DontCareCounts = int.Parse(data["standupDontCare"].ToString());
    }

    public void InitBars()
    {
        Bars = new List<Bar>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        var barsDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_bars", parameters);
        if (barsDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in barsDB)
            {
                Bar newBar = new Bar();
                UpdateBarFields(newBar, currentItem);
                Bars.Add(newBar);
            }
        }
    }

    public static void UpdateBarFields(Bar bar, DbDataRecord data)
    {
        bar.BarId = int.Parse(data["barId"].ToString());
        bar.BarName = data["barName"].ToString();
        bar.Address = data["Address"].ToString();
        bar.Age = Age.None;

        if (data["age18"].ToString() == "True")
        {
            bar.Age = Age.EighteenPlus;
        }
        else if(data["age21"].ToString() == "True")
        {
            bar.Age = Age.TwentyOnePlus;
        }
        else if (data["age24"].ToString() == "True")
        {
            bar.Age = Age.TwentyFourPlus;
        }


        bar.Food.Burger = data["burgers"].ToString() == "True";
        bar.Food.Pizza = data["pizza"].ToString() == "True";
        bar.Food.Sushi = data["sushi"].ToString() == "True";
        bar.Food.Snacks = data["snacks"].ToString() == "True";
        bar.Food.Vegan = data["vegan"].ToString() == "True";
        bar.Food.Kosher = data["kosher"].ToString() == "True";
        bar.Drink.Beer = data["beer"].ToString() == "True";
        bar.Drink.Wine = data["wine"].ToString() == "True";
        bar.Drink.Cocktail = data["cocktail"].ToString() == "True";
        bar.Drink.BeveragePackages = data["beveragePackages"].ToString() == "True";
        
        bar.Drink.Jin = data["jin"].ToString() == "True";
        bar.Drink.Whiskey = data["whiskey"].ToString() == "True";
        bar.Drink.WideRangeOfBeverages = data["wideRangeOfBeverages"].ToString() == "True";
        
        bar.Atmosphere.Irish = data["irish"].ToString() == "True";
        bar.Atmosphere.Chill = data["chill"].ToString() == "True";
        bar.Atmosphere.Dance = data["dance"].ToString() == "True";
        bar.Atmosphere.Sport = data["sport"].ToString() == "True";
        bar.Atmosphere.Shisha = data["shisha"].ToString() == "True";
        bar.Atmosphere.Party = data["party"].ToString() == "True";
        bar.SmokingFree = data["smokingFree"].ToString() == "True";
        bar.Company.Dating = data["dating"].ToString() == "True";
        bar.Company.Friends = data["friends"].ToString() == "True";
        bar.Company.KidsFriendly = data["kidsFriendly"].ToString() == "True";
        bar.Company.PetsFriendly = data["petsFriendly"].ToString() == "True";
        bar.Company.Colleagues = data["colleagues"].ToString() == "True";
        bar.Music.Pop = data["pop"].ToString() == "True";
        bar.Music.Jazz = data["jazz"].ToString() == "True";
        bar.Music.Mizrahit = data["mizrahit"].ToString() == "True";
        bar.Music.Greek = data["greek"].ToString() == "True";
        bar.Music.Trance = data["trance"].ToString() == "True";
        bar.Music.Mainstream = data["mainstream"].ToString() == "True";
        bar.Music.Israeli = data["israeli"].ToString() == "True";
        bar.Music.LiveMusic = data["liveMusic"].ToString() == "True";
        bar.Music.Reggaeton = data["reggaeton"].ToString() == "True";
        
        bar.Music.OpenMic = data["openMic"].ToString() == "True";
        bar.Music.StandUp = data["standup"].ToString() == "True";

        bar.Price = Price.None;
        if (data["priceLow"].ToString() == "True")
        {
            bar.Price = Price.PriceLow;
        }
        else if (data["priceMed"].ToString() == "True")
        {
            bar.Price = Price.PriceMed;
        }
        else if (data["priceHigh"].ToString() == "True")
        {
            bar.Price = Price.PriceHigh;
        }

        bar.Service = Service.None;
        if (data["fullService"].ToString() == "True")
        {
            bar.Service = Service.FullService;
        }
        else if (data["selfService"].ToString() == "True")
        {
            bar.Service = Service.SelfService;
        }
        
    }

    public User GetUserByUserID(int userID)
    {
        ArrayList users;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userId", userID));
        users = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_userId", parameters);
        if (users.Count > 0)
        {
            foreach (DbDataRecord currentItem in users)
            {
                User user = new User(this);
                UpdateUserFields(user, currentItem);
                return user;
            }
        }
        return null;
    }
   
    public static void UpdateRateFields(Rate rate, DbDataRecord data)
    {
        rate.UserName = data["userName"].ToString();
        rate.BarId = int.Parse(data["userName"].ToString());
        rate.date = DateTime.Parse(data["date"].ToString());
        int age = int.Parse(data["age"].ToString());
        switch(age)
        {
            case 0:
                rate.Age = Age.EighteenPlus;
                break;
            case 1:
                rate.Age = Age.TwentyOnePlus;
                break;
            case 2:
                rate.Age = Age.TwentyFourPlus;
                break;
            case 7:
                rate.Age = Age.None;
                break;
        }
        int service = int.Parse(data["service"].ToString());
        switch(service)
        {
            case 0:
                rate.Service = Service.SelfService;
                break;
            case 1:
                rate.Service = Service.FullService;
                break;
            case 7:
                rate.Service = Service.None;
                break;

        }
        int price = int.Parse(data["price"].ToString());
        switch(price)
        {
            case 0:
                rate.Price = Price.PriceLow;
                break;
            case 1:
                rate.Price = Price.PriceMed;
                break;
            case 2:
                rate.Price = Price.PriceHigh;
                break;
            case 7:
                rate.Price = Price.None;
                break;

        }
        rate.Food.Burger = int.Parse(data["burgers"].ToString());
        rate.Food.Pizza = int.Parse(data["pizza"].ToString());
        rate.Food.Sushi = int.Parse(data["sushi"].ToString());
        rate.Food.Snacks = int.Parse(data["snacks"].ToString());
        rate.Food.Vegan = int.Parse(data["vegan"].ToString());
        rate.Food.Kosher = int.Parse(data["kosher"].ToString());
        rate.Drinks.Beer = int.Parse(data["beer"].ToString());
        rate.Drinks.Wine = int.Parse(data["wine"].ToString());
        rate.Drinks.Cocktail = int.Parse(data["cocktail"].ToString());
        rate.Drinks.BeveragePackages = int.Parse(data["beveragePackages"].ToString());
        rate.Drinks.Jin = int.Parse(data["jin"].ToString());
        rate.Drinks.Whiskey = int.Parse(data["whiskey"].ToString());
        rate.Drinks.WideRangeOfBeverages = int.Parse(data["wideRangeOfBeverages"].ToString());
        rate.Atmosphere.Irish = int.Parse(data["irish"].ToString());
        rate.Atmosphere.Chill = int.Parse(data["chill"].ToString());
        rate.Atmosphere.Dance = int.Parse(data["dance"].ToString());
        rate.Atmosphere.Sport = int.Parse(data["sport"].ToString());
        rate.Atmosphere.Shisha = int.Parse(data["shisha"].ToString());
        rate.Atmosphere.Party = int.Parse(data["party"].ToString());
        rate.SmokingFree = int.Parse(data["smokingFree"].ToString());
        rate.Company.Dating = int.Parse(data["dating"].ToString());
        rate.Company.Friends = int.Parse(data["friends"].ToString());
        rate.Company.KidsFriendly = int.Parse(data["kidsFriendly"].ToString());
        rate.Company.PetsFriendly = int.Parse(data["petsFriendly"].ToString());
        rate.Company.Colleagues = int.Parse(data["colleagues"].ToString());
        rate.Music.Pop = int.Parse(data["pop"].ToString());
        rate.Music.Jazz = int.Parse(data["jazz"].ToString());
        rate.Music.Mizrahit = int.Parse(data["mizrahit"].ToString());
        rate.Music.Greek = int.Parse(data["greek"].ToString());
        rate.Music.Trance = int.Parse(data["trance"].ToString());
        rate.Music.Mainstream = int.Parse(data["mainstream"].ToString());
        rate.Music.Israeli = int.Parse(data["israeli"].ToString());
        rate.Music.LiveMusic = int.Parse(data["liveMusic"].ToString());
        rate.Music.Reggaeton = int.Parse(data["reggaeton"].ToString());
        rate.Music.OpenMic = int.Parse(data["openMic"].ToString());
        rate.Music.StandUp = int.Parse(data["standUp"].ToString());
    }

    public static List<Rate> GetRatesByUser(User user)
    {
        ArrayList rates;
        var userRates = new List<Rate>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userName", user.UserName));
        rates = DBController.ExecuteStoredProcedure_Select("sp_get_all_rating_by_userName", parameters);
        if (rates.Count > 0)
        {
            foreach (DbDataRecord currentItem in rates)
            {
                Rate newRate = new Rate();
                UpdateRateFields(newRate, currentItem);
                userRates.Add(newRate);
            }
        }
        return userRates;
    }

    public Bar GetBarByBarID(int barID)
    {
        ArrayList bars;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userId", barID));
        //Need to add sp_get_bar_by_barId
        bars = DBController.ExecuteStoredProcedure_Select("sp_get_bar_by_barId", parameters);
        if (bars.Count > 0)
        {
            foreach (DbDataRecord currentItem in bars)
            {
                Bar bar = new Bar();
                UpdateBarFields(bar, currentItem);
                return bar;
            }
        }
        return null;
    }
}   

