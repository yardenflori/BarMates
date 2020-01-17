using BarMates;
using Newtonsoft.Json;
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

public partial class challenges : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    [WebMethod]
    public static string RatedBars()
    {
        ArrayList rates;
        List<string> userRates = new List<string>();
        string userName = DBController.GetUserName();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("userName", userName));
        rates = DBController.ExecuteStoredProcedure_Select("sp_get_all_rating_by_userName", parameters);
        if (rates.Count > 0)
        {
            foreach (DbDataRecord currentItem in rates)
            {
                userRates.Add(currentItem["barGoogleId"].ToString());
            }
        }
        return JsonConvert.SerializeObject(userRates);
    }
}