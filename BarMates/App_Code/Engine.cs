using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Linq;

public class Engine
{
    public static User User { set; get; }
    public static List<User> Users { set; get; }
    public static List<Bar> Bars { get; set; }
    public static Challenges Challenges { get; set; }
    public Engine()
    {
        InitUser();
        if (User.UserName != null)
        {
            InitUsers();
            InitBars();
        }
        Challenges = new Challenges();
    }

    public void InitUser()
    {
        string username = DBController.GetUserName();
        if (username != null)
        {
            User = new User();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("user_name", username));
            var users = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_username", parameters);
            List<SqlParameter> parameters2 = new List<SqlParameter>();
            parameters2.Add(new SqlParameter("user_name", username));
            var challenges = DBController.ExecuteStoredProcedure_Select("sp_get_challegeUser_by_userName", parameters2);
            if (users.Count > 0)
            {
                foreach (DbDataRecord currentItem in users)
                {
                    UpdateUserFields(User, currentItem);
                    foreach (DbDataRecord currentChallenge in challenges)
                    {
                        UpdateChallengeUserFields(User, currentChallenge);
                    }
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
        List<SqlParameter> parameters2 = new List<SqlParameter>();
        parameters2.Add(new SqlParameter("user_name", User.UserName));
        var challenges = DBController.ExecuteStoredProcedure_Select("sp_get_challegeUser_by_userName", parameters2);
        if (usersDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in usersDB)
            {
                User user = new User();
                UpdateUserFields(user, currentItem);
                foreach (DbDataRecord currentChallenge in challenges)
                {
                    UpdateChallengeUserFields(user, currentChallenge);
                }
                Users.Add(user);
            }
        }
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

    public static void UpdateUserFields(User user, DbDataRecord data)
    {
        String a = data["userId"].ToString();
        String b = data["userName"].ToString();

        user.UserId = int.Parse(data["userId"].ToString());
        user.UserName = data["userName"].ToString();
        user.Password = data["password"].ToString();
        user.Age = int.Parse(data["age"].ToString());
        user.Score = int.Parse(data["score"].ToString());
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
        user.Drinks.Beer.NegCounts = int.Parse(data["beerNeg"].ToString());
        user.Drinks.Beer.PosCounts = int.Parse(data["beerPos"].ToString());
        user.Drinks.Beer.DontCareCounts = int.Parse(data["beerDontCare"].ToString());
        user.Drinks.Wine.NegCounts = int.Parse(data["wineNeg"].ToString());
        user.Drinks.Wine.PosCounts = int.Parse(data["winePos"].ToString());
        user.Drinks.Wine.DontCareCounts = int.Parse(data["wineDontCare"].ToString());
        user.Drinks.Cocktail.NegCounts = int.Parse(data["cocktailNeg"].ToString());
        user.Drinks.Cocktail.PosCounts = int.Parse(data["cocktailPos"].ToString());
        user.Drinks.Cocktail.DontCareCounts = int.Parse(data["cocktailDontCare"].ToString());
        user.Drinks.BeveragePackages.NegCounts = int.Parse(data["beveragePackagesNeg"].ToString());
        user.Drinks.BeveragePackages.PosCounts = int.Parse(data["beveragePackagesPos"].ToString());
        user.Drinks.BeveragePackages.DontCareCounts = int.Parse(data["beveragePackagesDontCare"].ToString());
        user.Drinks.Jin.NegCounts = int.Parse(data["JinNeg"].ToString());
        user.Drinks.Jin.PosCounts = int.Parse(data["JinPos"].ToString());
        user.Drinks.Jin.DontCareCounts = int.Parse(data["JinDontCare"].ToString());
        user.Drinks.Whiskey.NegCounts = int.Parse(data["whiskeyNeg"].ToString());
        user.Drinks.Whiskey.PosCounts = int.Parse(data["whiskeyPos"].ToString());
        user.Drinks.Whiskey.DontCareCounts = int.Parse(data["whiskeyDontCare"].ToString());
        user.Drinks.WideRangeOfBeverages.NegCounts = int.Parse(data["wideRangeOfBeveragesNeg"].ToString());
        user.Drinks.WideRangeOfBeverages.PosCounts = int.Parse(data["wideRangeOfBeveragesPos"].ToString());
        user.Drinks.WideRangeOfBeverages.DontCareCounts = int.Parse(data["wideRangeOfBeveragesDontCare"].ToString());
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

    public static void UpdateBarFields(Bar bar, DbDataRecord data)
    {
        bar.BarId = int.Parse(data["barId"].ToString());
        bar.BarGoogleId = data["barGoogleId"].ToString();
        bar.BarName = data["barName"].ToString();
        bar.Address = data["Address"].ToString();
        bar.Age = Age.None;

        if (data["age18"].ToString() == "True")
        {
            bar.Age = Age.EighteenPlus;
        }
        else if (data["age21"].ToString() == "True")
        {
            bar.Age = Age.TwentyOnePlus;
        }
        else if (data["age24"].ToString() == "True")
        {
            bar.Age = Age.TwentyFourPlus;
        }

        bar.PhotoUrl = data["photoUrl"].ToString();

        bar.Food.Burger = data["burgers"].ToString() == "True";
        bar.Food.Pizza = data["pizza"].ToString() == "True";
        bar.Food.Sushi = data["sushi"].ToString() == "True";
        bar.Food.Snacks = data["snacks"].ToString() == "True";
        bar.Food.Vegan = data["vegan"].ToString() == "True";
        bar.Food.Kosher = data["kosher"].ToString() == "True";
        bar.Drinks.Beer = data["beer"].ToString() == "True";
        bar.Drinks.Wine = data["wine"].ToString() == "True";
        bar.Drinks.Cocktail = data["cocktail"].ToString() == "True";
        bar.Drinks.BeveragePackages = data["beveragePackages"].ToString() == "True";
        bar.Drinks.Jin = data["jin"].ToString() == "True";
        bar.Drinks.Whiskey = data["whiskey"].ToString() == "True";
        bar.Drinks.WideRangeOfBeverages = data["wideRangeOfBeverages"].ToString() == "True";
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

    public static User GetUserByUserID(int userID)
    {
        ArrayList users, challenges;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userId", userID));
        users = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_userId", parameters);
        if (users.Count > 0)
        {
            foreach (DbDataRecord currentItem in users)
            {
                User user = new User();
                UpdateUserFields(user, currentItem);
                List<SqlParameter> parameters2 = new List<SqlParameter>();
                parameters2.Add(new SqlParameter("userName", user.UserName));
                challenges = DBController.ExecuteStoredProcedure_Select("sp_get_challegeUser_by_userName", parameters2);
                foreach (DbDataRecord currentChallenge in challenges)
                {
                    UpdateChallengeUserFields(user, currentChallenge);
                }
                return user;
            }
        }
        return null;
    }

    public static User GetUserByUserName(string userName)
    {
        ArrayList users, challenges;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("user_name", userName));
        users = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_userName", parameters);
        List<SqlParameter> parameters2 = new List<SqlParameter>();
        parameters2.Add(new SqlParameter("userName", userName));
        challenges = DBController.ExecuteStoredProcedure_Select("sp_get_challengeUser_by_userName", parameters2);
        if (users.Count > 0)
        {
            foreach (DbDataRecord currentItem in users)
            {
                User user = new User();
                UpdateUserFields(user, currentItem);
                foreach (DbDataRecord currentChallenge in challenges)
                {
                    UpdateChallengeUserFields(user, currentChallenge);
                }
                return user;
            }
        }
        return null;
    }

    public static void UpdateChallengeUserFields(User user, DbDataRecord data)
    {
        switch (int.Parse(data["id"].ToString()))
        {
            case (1):
                user.ChallengeUser.Dizengoff[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.Dizengoff[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.Dizengoff[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.Dizengoff[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.Dizengoff[4] = bool.Parse(data["bar5"].ToString());
                user.ChallengeUser.Dizengoff[5] = bool.Parse(data["bar6"].ToString());
                user.ChallengeUser.Dizengoff[6] = bool.Parse(data["bar7"].ToString());
                break;
            case (2):
                user.ChallengeUser.Ibngabirol[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.Ibngabirol[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.Ibngabirol[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.Ibngabirol[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.Ibngabirol[4] = bool.Parse(data["bar5"].ToString());
                break;
            case (3):
                user.ChallengeUser.Rotchild[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.Rotchild[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.Rotchild[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.Rotchild[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.Rotchild[4] = bool.Parse(data["bar5"].ToString());
                break;
            case (4):
                user.ChallengeUser.MahneYehuda[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.MahneYehuda[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.MahneYehuda[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.MahneYehuda[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.MahneYehuda[4] = bool.Parse(data["bar5"].ToString());
                break;
            case (5):
                user.ChallengeUser.JerusalemCity[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.JerusalemCity[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.JerusalemCity[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.JerusalemCity[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.JerusalemCity[4] = bool.Parse(data["bar5"].ToString());
                break;
            case (6):
                user.ChallengeUser.Italy[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.Italy[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.Italy[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.Italy[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.Italy[4] = bool.Parse(data["bar5"].ToString());
                break;
            case (7):
                user.ChallengeUser.Irland[0] = bool.Parse(data["bar1"].ToString());
                user.ChallengeUser.Irland[1] = bool.Parse(data["bar2"].ToString());
                user.ChallengeUser.Irland[2] = bool.Parse(data["bar3"].ToString());
                user.ChallengeUser.Irland[3] = bool.Parse(data["bar4"].ToString());
                user.ChallengeUser.Irland[4] = bool.Parse(data["bar5"].ToString());
                user.ChallengeUser.Irland[5] = bool.Parse(data["bar6"].ToString());
                user.ChallengeUser.Irland[6] = bool.Parse(data["bar7"].ToString());
                break;
        }
    }
    public static void UpdateRateFields(Rate rate, DbDataRecord data)
    {
        rate.UserName = data["userName"].ToString();
        rate.BarId = int.Parse(data["barId"].ToString());
        rate.date = DateTime.Parse(data["date"].ToString());
        int age = int.Parse(data["age"].ToString());
        switch (age)
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
        switch (service)
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
        switch (price)
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

    public static List<Rate> GetRatesByBar(Bar bar)
    {
        ArrayList rates;
        var barRates = new List<Rate>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("barId", bar.BarId));
        rates = DBController.ExecuteStoredProcedure_Select("sp_get_all_ratings_of_bar_by_barId", parameters);
        if (rates.Count > 0)
        {
            foreach (DbDataRecord currentItem in rates)
            {
                Rate newRate = new Rate();
                UpdateRateFields(newRate, currentItem);
                barRates.Add(newRate);
            }
        }
        return barRates;
    }

    public static Bar GetBarByBarID(int barID)
    {
        ArrayList bars;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("barId", barID));
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

    public static bool InsertUpdateBarCharacteristicToDB(Bar bar)
    {

        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("barId", bar.BarId));




        parameters.Add(new SqlParameter("age18", int.Parse("0")));
        parameters.Add(new SqlParameter("age21", int.Parse("0")));
        parameters.Add(new SqlParameter("age24", int.Parse("0")));

        switch (bar.Age)
        {
            case Age.EighteenPlus:
                parameters[1].Value = 1;
                break;
            case Age.TwentyOnePlus:
                parameters[2].Value = 1;
                break;
            case Age.TwentyFourPlus:
                parameters[3].Value = 1;
                break;

            default:
                break;
        }
        parameters.Add(new SqlParameter("selfService", int.Parse("0")));
        parameters.Add(new SqlParameter("fullService", int.Parse("0")));

        switch (bar.Service)
        {
            case Service.SelfService:
                parameters[4].Value = 1;
                break;
            case Service.FullService:
                parameters[5].Value = 1;
                break;
            default:
                break;
        }

        parameters.Add(new SqlParameter("priceLow", int.Parse("0")));
        parameters.Add(new SqlParameter("priceMed", int.Parse("0")));
        parameters.Add(new SqlParameter("priceHigh", int.Parse("0")));

        switch (bar.Price)
        {
            case Price.PriceLow:
                parameters[6].Value = 1;
                break;
            case Price.PriceMed:
                parameters[7].Value = 1;
                break;
            case Price.PriceHigh:
                parameters[8].Value = 1;
                break;

            default:
                break;
        }

        parameters.Add(new SqlParameter("burgers", bar.Food.Burger));
        parameters.Add(new SqlParameter("pizza", bar.Food.Pizza));
        parameters.Add(new SqlParameter("sushi", bar.Food.Sushi));
        parameters.Add(new SqlParameter("snacks", bar.Food.Snacks));
        parameters.Add(new SqlParameter("vegan", bar.Food.Vegan));
        parameters.Add(new SqlParameter("kosher", bar.Food.Kosher));

        parameters.Add(new SqlParameter("beer", bar.Drinks.Beer));
        parameters.Add(new SqlParameter("wine", bar.Drinks.Wine));
        parameters.Add(new SqlParameter("cocktail", bar.Drinks.Cocktail));
        parameters.Add(new SqlParameter("beveragePackages", bar.Drinks.BeveragePackages));
        parameters.Add(new SqlParameter("Jin", bar.Drinks.Jin));
        parameters.Add(new SqlParameter("whiskey", bar.Drinks.Whiskey));
        parameters.Add(new SqlParameter("wideRangeOfBeverages", bar.Drinks.WideRangeOfBeverages));

        parameters.Add(new SqlParameter("irish", bar.Atmosphere.Irish));
        parameters.Add(new SqlParameter("chill", bar.Atmosphere.Chill));
        parameters.Add(new SqlParameter("dance", bar.Atmosphere.Dance));
        parameters.Add(new SqlParameter("sport", bar.Atmosphere.Sport));
        parameters.Add(new SqlParameter("shisha", bar.Atmosphere.Shisha));
        parameters.Add(new SqlParameter("party", bar.Atmosphere.Party));

        parameters.Add(new SqlParameter("smokingFree", bar.SmokingFree));

        parameters.Add(new SqlParameter("dating", bar.Company.Dating));
        parameters.Add(new SqlParameter("friends", bar.Company.Friends));
        parameters.Add(new SqlParameter("kidsFriendly", bar.Company.KidsFriendly));
        parameters.Add(new SqlParameter("petsFriendly", bar.Company.PetsFriendly));
        parameters.Add(new SqlParameter("colleagues", bar.Company.Colleagues));

        parameters.Add(new SqlParameter("pop", bar.Music.Pop));
        parameters.Add(new SqlParameter("jazz", bar.Music.Jazz));
        parameters.Add(new SqlParameter("mizrahit", bar.Music.Mizrahit));
        parameters.Add(new SqlParameter("greek", bar.Music.Greek));
        parameters.Add(new SqlParameter("trance", bar.Music.Trance));
        parameters.Add(new SqlParameter("mainstream", bar.Music.Mainstream));
        parameters.Add(new SqlParameter("israeli", bar.Music.Israeli));
        parameters.Add(new SqlParameter("liveMusic", bar.Music.LiveMusic));
        parameters.Add(new SqlParameter("reggaeton", bar.Music.Reggaeton));
        parameters.Add(new SqlParameter("openMic", bar.Music.OpenMic));
        parameters.Add(new SqlParameter("standup", bar.Music.StandUp));
        parameters.Add(new SqlParameter("photoUrl", bar.PhotoUrl));



        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_bar", parameters);

        return insertSucceeded;
    }

    public static bool InsertUpdateUserCountersToDB(User user)
    {

        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("password", user.Password));
        parameters.Add(new SqlParameter("age", user.Age));

        parameters.Add(new SqlParameter("burgersPos", user.Food.Burger.PosCounts));
        parameters.Add(new SqlParameter("burgersNeg", user.Food.Burger.NegCounts));
        parameters.Add(new SqlParameter("burgersDontCare", user.Food.Burger.DontCareCounts));
        parameters.Add(new SqlParameter("pizzaPos", user.Food.Pizza.PosCounts));
        parameters.Add(new SqlParameter("pizzaNeg", user.Food.Pizza.NegCounts));
        parameters.Add(new SqlParameter("pizzaDontCare", user.Food.Pizza.DontCareCounts));
        parameters.Add(new SqlParameter("sushiPos", user.Food.Sushi.PosCounts));
        parameters.Add(new SqlParameter("sushiNeg", user.Food.Sushi.NegCounts));
        parameters.Add(new SqlParameter("sushiDontCare", user.Food.Sushi.DontCareCounts));
        parameters.Add(new SqlParameter("snacksPos", user.Food.Snacks.PosCounts));
        parameters.Add(new SqlParameter("snacksNeg", user.Food.Snacks.NegCounts));
        parameters.Add(new SqlParameter("snacksDontCare", user.Food.Snacks.DontCareCounts));
        parameters.Add(new SqlParameter("veganPos", user.Food.Vegan.PosCounts));
        parameters.Add(new SqlParameter("veganNeg", user.Food.Vegan.NegCounts));
        parameters.Add(new SqlParameter("veganDontCare", user.Food.Vegan.DontCareCounts));
        parameters.Add(new SqlParameter("kosherPos", user.Food.Kosher.PosCounts));
        parameters.Add(new SqlParameter("kosherNeg", user.Food.Kosher.NegCounts));
        parameters.Add(new SqlParameter("kosherDontCare", user.Food.Kosher.DontCareCounts));

        parameters.Add(new SqlParameter("beerPos", user.Drinks.Beer.PosCounts));
        parameters.Add(new SqlParameter("beerNeg", user.Drinks.Beer.NegCounts));
        parameters.Add(new SqlParameter("beerDontCare", user.Drinks.Beer.DontCareCounts));
        parameters.Add(new SqlParameter("winePos", user.Drinks.Wine.PosCounts));
        parameters.Add(new SqlParameter("wineNeg", user.Drinks.Wine.NegCounts));
        parameters.Add(new SqlParameter("wineDontCare", user.Drinks.Wine.DontCareCounts));
        parameters.Add(new SqlParameter("cocktailPos", user.Drinks.Cocktail.PosCounts));
        parameters.Add(new SqlParameter("cocktailNeg", user.Drinks.Cocktail.NegCounts));
        parameters.Add(new SqlParameter("cocktailDontCare", user.Drinks.Cocktail.DontCareCounts));
        parameters.Add(new SqlParameter("beveragePackagesPos", user.Drinks.BeveragePackages.PosCounts));
        parameters.Add(new SqlParameter("beveragePackagesNeg", user.Drinks.BeveragePackages.NegCounts));
        parameters.Add(new SqlParameter("beveragePackagesDontCare", user.Drinks.BeveragePackages.DontCareCounts));
        parameters.Add(new SqlParameter("JinPos", user.Drinks.Jin.PosCounts));
        parameters.Add(new SqlParameter("JinNeg", user.Drinks.Jin.NegCounts));
        parameters.Add(new SqlParameter("JinDontCare", user.Drinks.Jin.DontCareCounts));
        parameters.Add(new SqlParameter("whiskeyPos", user.Drinks.Whiskey.PosCounts));
        parameters.Add(new SqlParameter("whiskeyNeg", user.Drinks.Whiskey.NegCounts));
        parameters.Add(new SqlParameter("whiskeyDontCare", user.Drinks.Whiskey.DontCareCounts));
        parameters.Add(new SqlParameter("wideRangeOfBeveragesPos", user.Drinks.WideRangeOfBeverages.PosCounts));
        parameters.Add(new SqlParameter("wideRangeOfBeveragesNeg", user.Drinks.WideRangeOfBeverages.NegCounts));
        parameters.Add(new SqlParameter("wideRangeOfBeveragesDontCare", user.Drinks.WideRangeOfBeverages.DontCareCounts));

        parameters.Add(new SqlParameter("irishPos", user.Atmosphere.Irish.PosCounts));
        parameters.Add(new SqlParameter("irishNeg", user.Atmosphere.Irish.NegCounts));
        parameters.Add(new SqlParameter("irishDontCare", user.Atmosphere.Irish.DontCareCounts));
        parameters.Add(new SqlParameter("chillPos", user.Atmosphere.Chill.PosCounts));
        parameters.Add(new SqlParameter("chillNeg", user.Atmosphere.Chill.NegCounts));
        parameters.Add(new SqlParameter("chillDontCare", user.Atmosphere.Chill.DontCareCounts));
        parameters.Add(new SqlParameter("dancePos", user.Atmosphere.Dance.PosCounts));
        parameters.Add(new SqlParameter("danceNeg", user.Atmosphere.Dance.NegCounts));
        parameters.Add(new SqlParameter("danceDontCare", user.Atmosphere.Dance.DontCareCounts));
        parameters.Add(new SqlParameter("sportPos", user.Atmosphere.Sport.PosCounts));
        parameters.Add(new SqlParameter("sportNeg", user.Atmosphere.Sport.NegCounts));
        parameters.Add(new SqlParameter("sportDontCare", user.Atmosphere.Sport.DontCareCounts));
        parameters.Add(new SqlParameter("shishaPos", user.Atmosphere.Shisha.PosCounts));
        parameters.Add(new SqlParameter("shishaNeg", user.Atmosphere.Shisha.NegCounts));
        parameters.Add(new SqlParameter("shishaDontCare", user.Atmosphere.Shisha.DontCareCounts));
        parameters.Add(new SqlParameter("partyPos", user.Atmosphere.Party.PosCounts));
        parameters.Add(new SqlParameter("partyNeg", user.Atmosphere.Party.NegCounts));
        parameters.Add(new SqlParameter("partyDontCare", user.Atmosphere.Party.DontCareCounts));

        parameters.Add(new SqlParameter("smokingFreePos", user.SmokingFree.PosCounts));
        parameters.Add(new SqlParameter("smokingFreeNeg", user.SmokingFree.NegCounts));
        parameters.Add(new SqlParameter("smokingFreeDontCare", user.SmokingFree.DontCareCounts));

        parameters.Add(new SqlParameter("datingPos", user.Company.Dating.PosCounts));
        parameters.Add(new SqlParameter("datingNeg", user.Company.Dating.NegCounts));
        parameters.Add(new SqlParameter("datingDontCare", user.Company.Dating.DontCareCounts));
        parameters.Add(new SqlParameter("friendsPos", user.Company.Friends.PosCounts));
        parameters.Add(new SqlParameter("friendsNeg", user.Company.Friends.NegCounts));
        parameters.Add(new SqlParameter("friendsDontCare", user.Company.Friends.DontCareCounts));
        parameters.Add(new SqlParameter("kidsFriendlyPos", user.Company.KidsFriendly.PosCounts));
        parameters.Add(new SqlParameter("kidsFriendlyNeg", user.Company.KidsFriendly.NegCounts));
        parameters.Add(new SqlParameter("kidsFriendlyDontCare", user.Company.KidsFriendly.DontCareCounts));
        parameters.Add(new SqlParameter("petsFriendlyPos", user.Company.PetsFriendly.PosCounts));
        parameters.Add(new SqlParameter("petsFriendlyNeg", user.Company.PetsFriendly.NegCounts));
        parameters.Add(new SqlParameter("petsFriendlyDontCare", user.Company.PetsFriendly.DontCareCounts));
        parameters.Add(new SqlParameter("colleaguesPos", user.Company.Colleagues.PosCounts));
        parameters.Add(new SqlParameter("colleaguesNeg", user.Company.Colleagues.NegCounts));
        parameters.Add(new SqlParameter("colleaguesDontCare", user.Company.Colleagues.DontCareCounts));

        parameters.Add(new SqlParameter("popPos", user.Music.Pop.PosCounts));
        parameters.Add(new SqlParameter("popNeg", user.Music.Pop.NegCounts));
        parameters.Add(new SqlParameter("popDontCare", user.Music.Pop.DontCareCounts));
        parameters.Add(new SqlParameter("jazzPos", user.Music.Jazz.PosCounts));
        parameters.Add(new SqlParameter("jazzNeg", user.Music.Jazz.NegCounts));
        parameters.Add(new SqlParameter("jazzDontCare", user.Music.Jazz.DontCareCounts));
        parameters.Add(new SqlParameter("mizrahitPos", user.Music.Mizrahit.PosCounts));
        parameters.Add(new SqlParameter("mizrahitNeg", user.Music.Mizrahit.NegCounts));
        parameters.Add(new SqlParameter("mizrahitDontCare", user.Music.Mizrahit.DontCareCounts));
        parameters.Add(new SqlParameter("greekPos", user.Music.Greek.PosCounts));
        parameters.Add(new SqlParameter("greekNeg", user.Music.Greek.NegCounts));
        parameters.Add(new SqlParameter("greekDontCare", user.Music.Greek.DontCareCounts));
        parameters.Add(new SqlParameter("trancePos", user.Music.Trance.PosCounts));
        parameters.Add(new SqlParameter("tranceNeg", user.Music.Trance.NegCounts));
        parameters.Add(new SqlParameter("tranceDontCare", user.Music.Trance.DontCareCounts));
        parameters.Add(new SqlParameter("mainstreamPos", user.Music.Mainstream.PosCounts));
        parameters.Add(new SqlParameter("mainstreamNeg", user.Music.Mainstream.NegCounts));
        parameters.Add(new SqlParameter("mainstreamDontCare", user.Music.Mainstream.DontCareCounts));
        parameters.Add(new SqlParameter("israeliPos", user.Music.Israeli.PosCounts));
        parameters.Add(new SqlParameter("israeliNeg", user.Music.Israeli.NegCounts));
        parameters.Add(new SqlParameter("israeliDontCare", user.Music.Israeli.DontCareCounts));
        parameters.Add(new SqlParameter("liveMusicPos", user.Music.LiveMusic.PosCounts));
        parameters.Add(new SqlParameter("liveMusicNeg", user.Music.LiveMusic.NegCounts));
        parameters.Add(new SqlParameter("liveMusicDontCare", user.Music.LiveMusic.DontCareCounts));
        parameters.Add(new SqlParameter("reggaetonPos", user.Music.Reggaeton.PosCounts));
        parameters.Add(new SqlParameter("reggaetonNeg", user.Music.Reggaeton.NegCounts));
        parameters.Add(new SqlParameter("reggaetonDontCare", user.Music.Reggaeton.DontCareCounts));
        parameters.Add(new SqlParameter("openMicPos", user.Music.OpenMic.PosCounts));
        parameters.Add(new SqlParameter("openMicNeg", user.Music.OpenMic.NegCounts));
        parameters.Add(new SqlParameter("openMicDontCare", user.Music.OpenMic.DontCareCounts));
        parameters.Add(new SqlParameter("standupPos", user.Music.StandUp.PosCounts));
        parameters.Add(new SqlParameter("standupNeg", user.Music.StandUp.NegCounts));
        parameters.Add(new SqlParameter("standupDontCare", user.Music.StandUp.DontCareCounts));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_user_interest_vector", parameters);

        return insertSucceeded;
    }

    public static void GetChallengeUserByUserName(User user)
    {
        ArrayList challengeUser;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userId", user.UserId));
        challengeUser = DBController.ExecuteStoredProcedure_Select("sp_get_challengeUser_by_userName", parameters);
        if (challengeUser.Count > 0)
        {
            foreach (DbDataRecord currentItem in challengeUser)
            {
                switch (int.Parse(currentItem["id"].ToString()))
                {
                    case 1:
                        user.ChallengeUser.Dizengoff[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.Dizengoff[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.Dizengoff[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.Dizengoff[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Dizengoff[4] = bool.Parse(currentItem["bar5"].ToString());
                        user.ChallengeUser.Dizengoff[5] = bool.Parse(currentItem["bar6"].ToString());
                        user.ChallengeUser.Dizengoff[6] = bool.Parse(currentItem["bar7"].ToString());
                        break;
                    case 2:
                        user.ChallengeUser.Ibngabirol[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.Ibngabirol[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.Ibngabirol[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.Ibngabirol[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Ibngabirol[4] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    case 3:
                        user.ChallengeUser.Rotchild[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.Rotchild[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.Rotchild[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.Rotchild[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Rotchild[4] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    case 4:
                        user.ChallengeUser.MahneYehuda[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.MahneYehuda[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.MahneYehuda[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.MahneYehuda[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.MahneYehuda[4] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    case 5:
                        user.ChallengeUser.JerusalemCity[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.JerusalemCity[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.JerusalemCity[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.JerusalemCity[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.JerusalemCity[4] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    case 6:
                        user.ChallengeUser.Italy[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.Italy[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.Italy[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.Italy[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Italy[4] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    case 7:
                        user.ChallengeUser.Irland[0] = bool.Parse(currentItem["bar1"].ToString());
                        user.ChallengeUser.Irland[1] = bool.Parse(currentItem["bar2"].ToString());
                        user.ChallengeUser.Irland[2] = bool.Parse(currentItem["bar3"].ToString());
                        user.ChallengeUser.Irland[3] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Irland[4] = bool.Parse(currentItem["bar5"].ToString());
                        user.ChallengeUser.Irland[5] = bool.Parse(currentItem["bar4"].ToString());
                        user.ChallengeUser.Irland[6] = bool.Parse(currentItem["bar5"].ToString());
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public static bool InsertUpdateDizengoffChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 1));
        parameters.Add(new SqlParameter("name", "Dizengoff"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.Dizengoff[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.Dizengoff[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.Dizengoff[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.Dizengoff[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.Dizengoff[4]));
        parameters.Add(new SqlParameter("bar6", user.ChallengeUser.Dizengoff[5]));
        parameters.Add(new SqlParameter("bar7", user.ChallengeUser.Dizengoff[6]));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateRotchildChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 3));
        parameters.Add(new SqlParameter("name", "Rotchild"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.Rotchild[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.Rotchild[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.Rotchild[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.Rotchild[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.Rotchild[4]));
        parameters.Add(new SqlParameter("bar6", null));
        parameters.Add(new SqlParameter("bar7", null));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateIbnGabirolChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 2));
        parameters.Add(new SqlParameter("name", "IbnGabirol"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.Ibngabirol[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.Ibngabirol[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.Ibngabirol[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.Ibngabirol[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.Ibngabirol[4]));
        parameters.Add(new SqlParameter("bar6", null));
        parameters.Add(new SqlParameter("bar7", null));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateJerusalemCityChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 5));
        parameters.Add(new SqlParameter("name", "JerusalemCity"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.JerusalemCity[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.JerusalemCity[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.JerusalemCity[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.JerusalemCity[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.JerusalemCity[4]));
        parameters.Add(new SqlParameter("bar6", null));
        parameters.Add(new SqlParameter("bar7", null));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateMahneYehudaChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 4));
        parameters.Add(new SqlParameter("name", "MahneYehuda"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.MahneYehuda[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.MahneYehuda[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.MahneYehuda[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.MahneYehuda[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.MahneYehuda[4]));
        parameters.Add(new SqlParameter("bar6", null));
        parameters.Add(new SqlParameter("bar7", null));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateItalyChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 6));
        parameters.Add(new SqlParameter("name", "Irland"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.Italy[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.Italy[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.Italy[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.Italy[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.Italy[4]));
        parameters.Add(new SqlParameter("bar6", null));
        parameters.Add(new SqlParameter("bar7", null));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }
    public static bool InsertUpdateIrlandChallengeUserToDB(User user)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("id", 7));
        parameters.Add(new SqlParameter("name", "Irland"));
        parameters.Add(new SqlParameter("bar1", user.ChallengeUser.Irland[0]));
        parameters.Add(new SqlParameter("bar2", user.ChallengeUser.Irland[1]));
        parameters.Add(new SqlParameter("bar3", user.ChallengeUser.Irland[2]));
        parameters.Add(new SqlParameter("bar4", user.ChallengeUser.Irland[3]));
        parameters.Add(new SqlParameter("bar5", user.ChallengeUser.Irland[4]));
        parameters.Add(new SqlParameter("bar6", user.ChallengeUser.Irland[5]));
        parameters.Add(new SqlParameter("bar7", user.ChallengeUser.Irland[6]));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_challengeUser_by_userName_and_challengeId", parameters);

        return insertSucceeded;
    }

    public static bool InsertUpdateBadgeToDB(User user, string badgeName, bool isDeserved)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("badgeName", badgeName));
        parameters.Add(new SqlParameter("isdeserved", isDeserved));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_badge_by_userName_badgeName", parameters);

        return insertSucceeded;
    }

    public static bool InsertUpdateScoreByUserName(User user, int score)
    {
        bool insertSucceeded;
        List<SqlParameter> parameters = new List<SqlParameter>();

        parameters.Add(new SqlParameter("userName", user.UserName));
        parameters.Add(new SqlParameter("score", score));

        insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_user_score", parameters);

        return insertSucceeded;
    }

    public static bool InsertNewUserToChallengeUserToDB(User user)
    {
        bool insertSucceeded = false;
        List<string> names = new List<string> { "Dizengoff", "IbnGabirol", "Rotchild", "MahneYehuda", "JerusalemCity", "Italy", "Irland" };
        for (int i = 0; i < 7; i++)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("id", i + 1));
            parameters.Add(new SqlParameter("name", names[i]));
            parameters.Add(new SqlParameter("userName", user.UserName));

            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_user_to_challengeUser", parameters);
        }

        return insertSucceeded;
    }

    public static bool InsertNewUserToBadgeToDB(User user)
    {
        bool insertSucceeded = false;
        List<string> names = new List<string> { "TLV", "Jerusalem", "World" };
        for (int i = 0; i < 3; i++)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("userName", user.UserName));
            parameters.Add(new SqlParameter("badgeName", names[i]));

            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_user_to_badge", parameters);
        }

        return insertSucceeded;
    }

    public static void InitAll()
    {
        foreach (User user in Users)
        {
            InsertNewUserToChallengeUserToDB(user);
        }
        InsertNewUserToChallengeUserToDB(User);
    }

    public static List<Tuple<string, int>> GetBestScoredUsers(int numOfBest)
    {
        List<Tuple<string, int>> users = new List<Tuple<string, int>>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_sorted_users_by_scores", parameters);
        if (usersDB.Count > 0)
        {

            foreach (DbDataRecord currentItem in usersDB)
            {
                if (numOfBest > 0)
                {
                    int score = int.Parse(currentItem["score"].ToString());
                    string userName = currentItem["userName"].ToString();
                    Tuple<string, int> tup = new Tuple<string, int>(userName, score);
                    users.Add(tup);
                    numOfBest--;
                }
                else
                {
                    break;
                }
            }
        }
        return users;
    }

    public static List<string> GetAllUserBadges()
    {
        ArrayList badges;
        List<string> res = new List<string>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userName", User.UserName));
        badges = DBController.ExecuteStoredProcedure_Select("sp_get_badges_by_userName", parameters);
        if (badges.Count > 0)
        {
            foreach (DbDataRecord currentItem in badges)
            {
                var s = currentItem["badgeName"].ToString();
                switch (s)
                {
                    case "World":
                        if (bool.Parse(currentItem["isdeserved"].ToString()))
                            res.Add("world");
                        break;
                    case "TLV":
                        if (bool.Parse(currentItem["isdeserved"].ToString()))
                            res.Add("tlv");
                        break;
                    case "Jerusalem":
                        if (bool.Parse(currentItem["isdeserved"].ToString()))
                            res.Add("jerus");
                        break;
                }
            }
            return res;
        }
        return null;
    }
}


