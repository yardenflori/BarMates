using BarMates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }

    }
    [WebMethod]
    public static string GetUserBars() //Shaked and Yuval should implement this
    {
        //צריך להחזיר את רשימת הברים המומלצים של היוזר )
        //ת.ז ושם
        // if stored procedures needed, contact Yarden
        String userName = DBController.GetUserName();
        List<KeyValuePair<int, string>> barsList = new List<KeyValuePair<int, string>>();
        barsList.Add(new KeyValuePair<int, string>(1, "ברוני"));
        barsList.Add(new KeyValuePair<int, string>(2, "מזג"));
        barsList.Add(new KeyValuePair<int, string>(3, "סעידה בפארק"));
        return JsonConvert.SerializeObject(barsList);
    }

}