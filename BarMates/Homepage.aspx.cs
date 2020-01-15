using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Services;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (DBController.GetUserName() == null)
        //{
        //    Response.Redirect("Default.aspx");
        //}

        _= new Engine();

    }
    [WebMethod]
    public static string GetUserBars()
    {
        string userName = DBController.GetUserName();
        User user = Engine.GetUserByUserName(userName);
        List<Bar> bars = user.GetBestBars(5, Engine.Bars);
        for(int i = 0; i <bars.Count; i++)
        {
            Bar.UpdateBarPhoto(bars[i]);
        }
        /*List<Bar> bars = new List<Bar>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        var barsDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_bars", parameters);
        if (barsDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in barsDB)
            {
                Bar newBar = new Bar();
                Engine.UpdateBarFields(newBar, currentItem);
                bars.Add(newBar);
            }
        }*/
        return JsonConvert.SerializeObject(bars);
    }
    [WebMethod]
    public static string GetUserStatus()
    {
        JObject userStatus = new JObject();
        userStatus["userName"] = DBController.GetUserName();
        userStatus["score"] = 567;
       List<string> challenges = new List<string>();
        challenges.Add("jerus");
        challenges.Add("tlv");
        userStatus["challenges"] = JsonConvert.SerializeObject(challenges);
        return JsonConvert.SerializeObject(userStatus);
    }
}