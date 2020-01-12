using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BarRating : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    [WebMethod]
    public static bool SaveRate(string rate)
    {
        bool saveSucceeded = true;
        JObject jsonRate = null;
        try
        {
            jsonRate = JsonConvert.DeserializeObject<JObject>(rate);           
        }
        catch
        {
            saveSucceeded = false;
        }
        if (saveSucceeded)
        {
            Rate newRate = Rate.ParseObjectToRate(jsonRate); 
            saveSucceeded = InsertNewRatingToDB(newRate);
        }
        return saveSucceeded;
    }
    
    public static bool InsertNewRatingToDB(Rate rate)
    {
        bool insertSucceeded;
        ArrayList barByIds;
        List<SqlParameter> barIds = new List<SqlParameter>();
        List<SqlParameter> barParameters = new List<SqlParameter>();
        barIds.Add(new SqlParameter("@barId", rate.BarId));

        barByIds = DBController.ExecuteStoredProcedure_Select("sp_get_bar_by_barId", barIds);
        
        if (barByIds.Count == 0)
        {
            barParameters.Add(new SqlParameter("@barId", rate.BarId));
            barParameters.Add(new SqlParameter("@barGoogleId", rate.BarGoogleId));
            barParameters.Add(new SqlParameter("@barName", rate.BarName));
            barParameters.Add(new SqlParameter("@photoUrl", rate.photoURL));
            barParameters.Add(new SqlParameter("@Address", rate.address));
            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_bar", barParameters);

            if (!insertSucceeded)
            {
                return insertSucceeded;
            }
        }

        ArrayList rating_of_user_and_bar;
        
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userName", rate.UserName));
        parameters.Add(new SqlParameter("barId", rate.BarId));
        parameters.Add(new SqlParameter("date", rate.date));

        parameters.Add(new SqlParameter("age", (int) rate.Age));
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
            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_rating", parameters); 
        }
        else
        {
            insertSucceeded = DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_update_rating", parameters);
        }

        Bar bar = Engine.GetBarByBarID(rate.BarId);
        //Engine.updatePhotoUrlInDB();
        bar.UpdateBarByRate();
        Engine.InsertUpdateBarCharacteristicToDB(bar);
        User user = Engine.GetUserByUserName(rate.UserName);
        user.UpdateUserByRate(rate);
        Engine.InsertUpdateUserCountersToDB(user);
        
        return insertSucceeded;
    }


}