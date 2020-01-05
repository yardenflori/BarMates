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
        //if (DBController.GetUserName() == null)
        //{
        //    Response.Redirect("Default.aspx");
        //}

    }
    [WebMethod]
    public static string GetUserBars()
    {
        string userName = DBController.GetUserName();
        User user = Engine.GetUserByUserName(userName);
        List<Bar> bars = user.GetBestBars(5, Engine.Bars);
        return JsonConvert.SerializeObject(bars);
    }
}