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
    public static string GetBars()
    {
        //צריך לשלוף את רשימת הברים מהDB
        string[] bars = { "סעידה בפארק", "מזג", "ברוני" };

        return JsonConvert.SerializeObject(bars);
    }
}