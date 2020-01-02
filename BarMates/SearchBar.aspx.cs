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
    public static string SearchBars(string choises)
    {
        List<KeyValuePair<int, string>> barsList = new List<KeyValuePair<int, string>>();
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
    public static List<KeyValuePair<int, string>> SearchBarsInDb(List<KeyValuePair<string, int>> choisesList)
    {//הפונקציה מקבלת רשימה של 
     //KeyValuePair<int, int> 
     //id =beer, value-1 or 0
     //ומחזירה את הברים הרלוונטים בפורמט שמופיע למטה
     // Yarden should implement this with SP
     
              List<KeyValuePair<int, string>> barsList = new List<KeyValuePair<int, string>>();
        barsList.Add(new KeyValuePair<int, string>(1, "ברוני"));
        barsList.Add(new KeyValuePair<int, string>(2, "מזג"));
        barsList.Add(new KeyValuePair<int, string>(3, "סעידה בפארק"));
        return barsList;
    }
}