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
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
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

            /*for (int i = 0; i < barsList.Count; i++)
            {
                Bar.UpdateBarPhoto(barsList[i]);
            }*/
        }
        return JsonConvert.SerializeObject(barsList);
    }
    public static List<Bar> SearchBarsInDb(List<KeyValuePair<string, int>> choisesList)
    {
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

        

        return barsList;
    }
}