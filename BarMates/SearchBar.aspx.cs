using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
  
    [WebMethod]
    public static string SearchBars(string rate)
    {
        List<KeyValuePair<int, string>> barsList = new List<KeyValuePair<int, string>>();
        bool isSucceeded = true;
        JObject jsonRate = null;
        try
        {
            jsonRate = JsonConvert.DeserializeObject<JObject>(rate);
        }
        catch
        {
            isSucceeded = false;
        }
        if (isSucceeded)
        {
            Rate newRate = Rate.ParseObjectToRate(jsonRate);
            barsList = SearchBarsInDb(newRate);
        }
        return JsonConvert.SerializeObject(barsList);
    }
    public static List<KeyValuePair<int, string>> SearchBarsInDb(Rate rate)
    {//הפונקציה מקבלת דירוג ומחזירה את הברים הרלוונטים
        //ת.ז ושם
        List<KeyValuePair<int, string>> barsList = new List<KeyValuePair<int, string>>();
        barsList.Add(new KeyValuePair<int, string>(1, "ברוני"));
        barsList.Add(new KeyValuePair<int, string>(2, "מזג"));
        barsList.Add(new KeyValuePair<int, string>(3, "סעידה בפארק"));
        return barsList;
    }
}