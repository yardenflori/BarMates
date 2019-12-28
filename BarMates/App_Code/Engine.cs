using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;
using System.Collections;

public class Engine
{
    User User { set; get; }
    List<User> Users { set; get; }
    List<Bar> Bars { get; set; }
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
            User = new User();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("user_name", username));
            //stored procedure sp_get_user_by_username should be built in DB
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
        //stored procedure sp_get_all_other_users should be built in DB
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_other_users", parameters);

        if (usersDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in usersDB)
            {
                User new_user = new User();
                UpdateUserFields(new_user, currentItem);
                Users.Add(new_user);
            }
        }
    }

    public static void UpdateUserFields(User user, DbDataRecord data)
    {
        user.UserId = int.Parse(data["userId"].ToString());
        user.UserName = data["userName"].ToString();
        //should add here all the user fields that came back from DB
    }

    public void InitBars()
    {
        Bars = new List<Bar>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        //stored procedure sp_get_all_bars should be built in DB
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

    public void UpdateBarFields(Bar bar, DbDataRecord data)
    {
        bar.BarId = int.Parse(data["barId"].ToString());
        bar.BarName = data["barName"].ToString();
        //should add here all the user fields that came back from DB
    }

    public static User GetUserByUserID(int userID)
    {
        ArrayList users;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userId", userID));
        users = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_userId", parameters);
        if (users.Count > 0)
        {
            foreach (DbDataRecord currentItem in users)
            {
                User user = new User();
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
}
