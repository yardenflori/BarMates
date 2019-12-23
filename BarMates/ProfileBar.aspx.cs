using BarMates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    [WebMethod]
    public static string GetBar(string barName)
    {//יש להחזיר את הבר לפי שם הבר שהפונקציה מקבלת
        Bar bar = new Bar();
        bar.BarId = 1;
        bar.BarName = "סעידה בפארק";
        bar.Address = "שמואל הנגיד 5 ,חולון";
        bar.SmokingFree = true;
        bar.Age = Age.EighteenPlus;
        bar.Price = Price.PriceMed;
        bar.Service = Service.FullService;
        bar.Food = new Food<bool>();
        bar.Food.Burger = true;
        bar.Food.Pizza = true;
        bar.Food.Vegan = true;
        bar.Drink = new Drinks<bool>();
        bar.Drink.Beer = true;
        bar.Drink.Wine = true;
        bar.Drink.Whiskey = true;
        bar.Atmosphere = new Atmosphere<bool>();
        bar.Atmosphere.Chill = true;
        bar.Atmosphere.Shisha = true;
        bar.Atmosphere.Sport = true;
        bar.Company = new Company<bool>();
        bar.Company.Dating = true;
        bar.Company.Friends = true;
        bar.Company.Colleagues = true;
        bar.Music = new Music<bool>();
        bar.Music.Pop = true;
        bar.Music.Jazz = true;
        bar.Music.Mizrahit = true;
        return JsonConvert.SerializeObject(bar);
    }
}