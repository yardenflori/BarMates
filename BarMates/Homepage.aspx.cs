using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        List<Bar> bestBars = new List<Bar>();
        bool isSucceeded = true;
        Bar bar = new Bar();

        if (HttpContext.Current.Session["needUpdate"].ToString() == "1")
        {
            bestBars = user.GetBestBars(5, Engine.Bars);
            HttpContext.Current.Session["bestBar1"] = JsonConvert.SerializeObject(bestBars[0]);
            HttpContext.Current.Session["bestBar2"] = JsonConvert.SerializeObject(bestBars[1]);
            HttpContext.Current.Session["bestBar3"] = JsonConvert.SerializeObject(bestBars[2]);
            HttpContext.Current.Session["bestBar4"] = JsonConvert.SerializeObject(bestBars[3]);
            HttpContext.Current.Session["bestBar5"] = JsonConvert.SerializeObject(bestBars[4]);

            

            HttpContext.Current.Session["needUpdate"] = "0";
        }

        else
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    bar = JsonConvert.DeserializeObject<Bar>(HttpContext.Current.Session["bestBar" + (i+1).ToString()].ToString());
                }
                catch
                {
                    isSucceeded = false;
                }
                if (isSucceeded)
                {
                    bestBars.Add(bar);
                }
            }
            for (int i = 0; i < bestBars.Count; i++)
            {
                Bar.UpdateBarPhoto(bestBars[i]);
            }
        }
        
        
        return JsonConvert.SerializeObject(bestBars);
    }
    [WebMethod]
    public static string GetUserStatus()
    {
        List<string> challenges = Engine.GetAllUserBadges();
        JObject userStatus = new JObject
        {
            ["userName"] = DBController.GetUserName(),
            ["score"] = Engine.User.Score,
            ["challenges"] = JsonConvert.SerializeObject(challenges)
        };
        return JsonConvert.SerializeObject(userStatus);
    }
}