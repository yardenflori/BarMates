using BarMates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
}