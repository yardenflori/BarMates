using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

public partial class BarRating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    private static bool IsSpamRate(Rate rate)
    {
        int cnt = 0;
        var rateVector = rate.RateVector();
        for (int i = 0; i < rateVector.Length; i++)
        {
            if (rateVector[i] == 1)
            {
                cnt++;
                if (cnt >= 2)
                {
                    return false;
                }
            }
        }
        return true;
    }

    [WebMethod]
    public static string SaveRate(string rate)
    {
        bool saveSucceeded = true;
        JObject RateToReturn=new JObject();
        RateToReturn["insertSucceeded"] = saveSucceeded.ToString();
        RateToReturn["challengeWin"] = "";
        JObject jsonRate = null;
        try
        {
            jsonRate = JsonConvert.DeserializeObject<JObject>(rate);
        }
        catch
        {
            saveSucceeded = false;
            RateToReturn["insertSucceeded"] = saveSucceeded.ToString();
        }
        if (saveSucceeded)
        {
            Rate newRate = Rate.ParseObjectToRate(jsonRate);
            if(IsSpamRate(newRate))
            {
                RateToReturn["insertSucceeded"] = saveSucceeded.ToString();
            }
            else
            {
                RateToReturn = InsertNewRatingToDB(newRate);
            }
        }
        return JsonConvert.SerializeObject(RateToReturn);
    }
    
    public static JObject InsertNewRatingToDB(Rate rate)
    {
        JObject rateToReturn = new JObject();
        bool insertSucceeded=true, firstRate;
        ArrayList barByIds;
        List<SqlParameter> barIds = new List<SqlParameter>();
        List<SqlParameter> barParameters = new List<SqlParameter>();
        barIds.Add(new SqlParameter("@barId", rate.BarId));
        string challengeWin = "";

        barByIds = DBController.ExecuteStoredProcedure_Select("sp_get_bar_by_barId", barIds);
        
        if (barByIds.Count == 0)
        {
            barParameters.Add(new SqlParameter("@barId", rate.BarId));
            barParameters.Add(new SqlParameter("@barGoogleId", rate.BarGoogleId));
            barParameters.Add(new SqlParameter("@barName", rate.BarName));
            barParameters.Add(new SqlParameter("@photoUrl", rate.photoURL));
            barParameters.Add(new SqlParameter("@Address", rate.address));
            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_bar", barParameters); 
        }
        if (insertSucceeded == true)
        {
            ArrayList rating_of_user_and_bar;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("userName", rate.UserName));
            parameters.Add(new SqlParameter("barId", rate.BarId));
            parameters.Add(new SqlParameter("barGoogleId", rate.BarGoogleId));
            parameters.Add(new SqlParameter("@barName", rate.BarName));
            parameters.Add(new SqlParameter("date", rate.date));

            parameters.Add(new SqlParameter("age", (int)rate.Age));
            parameters.Add(new SqlParameter("service", (int)rate.Service));
            parameters.Add(new SqlParameter("price", (int)rate.Price));

            parameters.Add(new SqlParameter("burgers", rate.Food.Burger));
            parameters.Add(new SqlParameter("pizza", rate.Food.Pizza));
            parameters.Add(new SqlParameter("sushi", rate.Food.Sushi));
            parameters.Add(new SqlParameter("snacks", rate.Food.Snacks));
            parameters.Add(new SqlParameter("vegan", rate.Food.Vegan));
            parameters.Add(new SqlParameter("kosher", rate.Food.Kosher));

            parameters.Add(new SqlParameter("beer", rate.Drinks.Beer));
            parameters.Add(new SqlParameter("wine", rate.Drinks.Wine));
            parameters.Add(new SqlParameter("cocktail", rate.Drinks.Cocktail));
            parameters.Add(new SqlParameter("beveragePackages", rate.Drinks.BeveragePackages));
            parameters.Add(new SqlParameter("Jin", rate.Drinks.Jin));
            parameters.Add(new SqlParameter("whiskey", rate.Drinks.Whiskey));
            parameters.Add(new SqlParameter("wideRangeOfBeverages", rate.Drinks.WideRangeOfBeverages));

            parameters.Add(new SqlParameter("irish", rate.Atmosphere.Irish));
            parameters.Add(new SqlParameter("chill", rate.Atmosphere.Chill));
            parameters.Add(new SqlParameter("dance", rate.Atmosphere.Dance));
            parameters.Add(new SqlParameter("sport", rate.Atmosphere.Sport));
            parameters.Add(new SqlParameter("shisha", rate.Atmosphere.Shisha));
            parameters.Add(new SqlParameter("party", rate.Atmosphere.Party));

            parameters.Add(new SqlParameter("smokingFree", rate.SmokingFree));

            parameters.Add(new SqlParameter("dating", rate.Company.Dating));
            parameters.Add(new SqlParameter("friends", rate.Company.Friends));
            parameters.Add(new SqlParameter("kidsFriendly", rate.Company.KidsFriendly));
            parameters.Add(new SqlParameter("petsFriendly", rate.Company.PetsFriendly));
            parameters.Add(new SqlParameter("colleagues", rate.Company.Colleagues));

            parameters.Add(new SqlParameter("pop", rate.Music.Pop));
            parameters.Add(new SqlParameter("jazz", rate.Music.Jazz));
            parameters.Add(new SqlParameter("mizrahit", rate.Music.Mizrahit));
            parameters.Add(new SqlParameter("greek", rate.Music.Greek));
            parameters.Add(new SqlParameter("trance", rate.Music.Trance));
            parameters.Add(new SqlParameter("mainstream", rate.Music.Mainstream));
            parameters.Add(new SqlParameter("israeli", rate.Music.Israeli));
            parameters.Add(new SqlParameter("liveMusic", rate.Music.LiveMusic));
            parameters.Add(new SqlParameter("reggaeton", rate.Music.Reggaeton));
            parameters.Add(new SqlParameter("openMic", rate.Music.OpenMic));
            parameters.Add(new SqlParameter("standup", rate.Music.StandUp));


            List<SqlParameter> parameters1 = new List<SqlParameter>();
            parameters1.Add(new SqlParameter("userName", rate.UserName));
            parameters1.Add(new SqlParameter("barId", rate.BarId));
            rating_of_user_and_bar = DBController.ExecuteStoredProcedure_Select("sp_get_rating_of_user_and_bar", parameters1);
            if (rating_of_user_and_bar.Count == 0)
            {
                firstRate = true;
                insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_rating", parameters);
            }
            else
            {
                firstRate = false;
                insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_rating", parameters);
            }

            Bar bar = Engine.GetBarByBarID(rate.BarId);
            //Engine.updatePhotoUrlInDB();
            bar.UpdateBarByRate();
            Engine.InsertUpdateBarCharacteristicToDB(bar);
            User user = Engine.GetUserByUserName(rate.UserName);
            user.UpdateUserByRate(rate);
            if (firstRate)
            {
                Engine.GetChallengeUserByUserName(user);
                user.UpdateScoreAfterRating(bar);
                if (user.IsDeservedAJerusalemBadge(bar))
                {
                    challengeWin = "ירושלים";
                }
                if (user.IsDeservedATLVBadge(bar))
                {
                    challengeWin = "תל אביב";
                }
                if (user.IsDeservedAWorldBadge(bar))
                {
                    challengeWin = "עולמי";
                }
            }
            Engine.InsertUpdateUserCountersToDB(user);

            if (insertSucceeded)
            {
                HttpContext.Current.Session["needUpdate"] = "1";
            }

        }
        rateToReturn["insertSucceeded"] = insertSucceeded.ToString();
        rateToReturn["challengeWin"] = challengeWin;
        return rateToReturn;
    }

    [WebMethod]
    public static string GetBarDetails(String barGoogleId)
    {
        ArrayList bars;
        JObject barDetails = new JObject();
        bool saveSucceeded = true;
        JObject jsonId = new JObject();
        string barId="";
        try
        {
            jsonId = JsonConvert.DeserializeObject<JObject>(barGoogleId);
            barId = jsonId["barGoogleId"].ToString();
        }

        catch
        {
            saveSucceeded = false;
        }

        if (saveSucceeded)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            
            parameters.Add(new SqlParameter("barId", barId.GetHashCode()));

            bars = DBController.ExecuteStoredProcedure_Select("sp_get_bar_by_barId", parameters);

            if (bars.Count == 1)
            {
                foreach (DbDataRecord currentItem in bars)
                {
                    barDetails["barId"] = currentItem["barGoogleId"].ToString();
                    barDetails["barName"] = currentItem["barName"].ToString();
                    barDetails["barAddress"] = currentItem["Address"].ToString();
                    barDetails["barPhotoURL"] = currentItem["photoUrl"].ToString();
                }
            }

        }
        return JsonConvert.SerializeObject(barDetails);

    }


}