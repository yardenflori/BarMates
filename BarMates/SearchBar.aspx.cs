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

public partial class SearchBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (DBController.GetUserName() == null)
        //{
        //    Response.Redirect("Default.aspx");
        //}
    }
  
    [WebMethod]
    public static string SearchBars(string choises)
    {
        List<Bar> barsList = new List<Bar>();
        bool isSucceeded = true;
        List<JObject> choisesJobject = null;
        List<KeyValuePair<string, int>> choisesList = new List<KeyValuePair<string, int>>();
        try
        {
            choisesJobject = JsonConvert.DeserializeObject<List<JObject>>(choises);
        }
        catch
        {
            isSucceeded = false;
        }
        if (isSucceeded)
        {
            for(int i=0;i< choisesJobject.Count; i++)
            {
                string key = choisesJobject[i]["Key"].ToString();
                int value = int.Parse(choisesJobject[i]["Value"].ToString());
                choisesList.Add(new KeyValuePair<string, int>(key,value));

            }
            barsList = SearchBarsInDb(choisesList);
        }
        return JsonConvert.SerializeObject(barsList);
    }
    public static List<Bar> SearchBarsInDb(List<KeyValuePair<string, int>> choisesList)
    {//הפונקציה מקבלת רשימה של 
     //KeyValuePair<int, int> 
     //id =beer, value-1 or 0
     //ומחזירה את רשימה של הברים מסוג בר
     // Yarden should implement this with SP

        List<Bar> barsList = new List<Bar>();
        ArrayList searchresults;
        List<SqlParameter> parameters = new List<SqlParameter>();

        for (int i = 0; i < choisesList.Count; i++)
        {
            parameters.Add(new SqlParameter(choisesList[i].Key, choisesList[i].Value));
        }

        searchresults = DBController.ExecuteStoredProcedure_Select("sp_get_bars_by_search_of_tags", parameters);

        if (searchresults.Count > 0)
        {
            foreach (DbDataRecord currentItem in searchresults)
            {
                Bar newBar = new Bar();
                Engine.UpdateBarFields(newBar, currentItem);

                barsList.Add(newBar);
            }
        }

        /*Bar bar = new Bar();
        bar.BarId = 1;
        bar.BarName = "סעידה בפארק";
        bar.Address = "שמואל הנגיד 5 ,חולון";
        bar.SmokingFree = true;
        bar.Age = Age.EighteenPlus;
        bar.Price = Price.PriceMed;
        bar.Service = Service.FullService;

        bar.Food = new Food<bool>();
        bar.Food.Burger = true;
        bar.Food.Pizza = false;
        bar.Food.Sushi = true;
        bar.Food.Snacks = false;
        bar.Food.Kosher = false;
        bar.Food.Vegan = false;

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

        bars.Add(bar);


        Bar bar1 = new Bar();
        bar1.BarId = 2;
        bar1.BarName = "ברוני";
        bar1.Address = "סוקולוב 50, חולון";
        bar1.SmokingFree = true;
        bar1.Age = Age.EighteenPlus;
        bar1.Price = Price.PriceMed;
        bar1.Service = Service.FullService;

        bar1.Food = new Food<bool>();
        bar1.Food.Burger = false;
        bar1.Food.Pizza = false;
        bar1.Food.Sushi = false;
        bar1.Food.Snacks = false;
        bar1.Food.Kosher = false;
        bar1.Food.Vegan = false;

        bar1.Drink = new Drinks<bool>();
        bar1.Drink.Beer = true;
        bar1.Drink.Wine = true;
        bar1.Drink.Whiskey = true;

        bar1.Atmosphere = new Atmosphere<bool>();
        bar1.Atmosphere.Chill = true;
        bar1.Atmosphere.Shisha = true;
        bar1.Atmosphere.Sport = true;

        bar1.Company = new Company<bool>();
        bar1.Company.Dating = true;
        bar1.Company.Friends = true;
        bar1.Company.Colleagues = true;

        bar1.Music = new Music<bool>();
        bar1.Music.Pop = true;
        bar1.Music.Jazz = true;
        bar1.Music.Mizrahit = true;

        bars.Add(bar1);

        Bar bar2 = new Bar();
        bar2.BarId = 3;
        bar2.BarName = "מזג";
        bar2.Address = "רוטשילד 50, תל אביב";

        bar2.SmokingFree = false;

        bar2.Age = Age.None;
        bar2.Price = Price.PriceHigh;
        bar2.Service = Service.SelfService;

        bar2.Food = new Food<bool>();
        bar2.Food.Burger = true;
        bar2.Food.Pizza = true;
        bar2.Food.Sushi = true;
        bar2.Food.Snacks = true;
        bar2.Food.Kosher = true;
        bar2.Food.Vegan = true;

        bar2.Drink = new Drinks<bool>();
        bar2.Drink.Beer = true;
        bar2.Drink.Wine = true;
        bar2.Drink.Whiskey = true;

        bar2.Atmosphere = new Atmosphere<bool>();
        bar2.Atmosphere.Chill = true;
        bar2.Atmosphere.Shisha = true;
        bar2.Atmosphere.Sport = true;

        bar2.Company = new Company<bool>();
        bar2.Company.Dating = true;
        bar2.Company.Friends = true;
        bar2.Company.Colleagues = true;

        bar2.Music = new Music<bool>();
        bar2.Music.Pop = true;
        bar2.Music.Jazz = true;
        bar2.Music.Mizrahit = true;

        bars.Add(bar2);

    */

        return barsList;
    }
}