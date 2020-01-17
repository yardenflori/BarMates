using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static bool Login(string userDetailsString)
    {
        bool isSucceeded = true;
        JObject userDetails = null;
        try
        {
            userDetails = JsonConvert.DeserializeObject<JObject>(userDetailsString);
        }
        catch
        {
            isSucceeded = false;
        }
        if (isSucceeded)
        {
            string userName = LoginInDB(userDetails["userName"].ToString(), userDetails["password"].ToString());
            if (userName == null)
            {
                isSucceeded = false;
            }
            else
            {
                HttpContext.Current.Session["userName"] = userName;
                HttpContext.Current.Session["needUpdate"] = "1";
            }
        }
        return isSucceeded;
    }
    public static string LoginInDB(string user_name, string password) //מחזירה מספר כדי שנוכל לשמור אותו בסשן
    {
        string userName = null;
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("user_name", user_name));
        parameters.Add(new SqlParameter("password", password));

        var dataDB = DBController.ExecuteStoredProcedure_Select("sp_Login", parameters);
        if (dataDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in dataDB)
            {
                userName = (currentItem["userName"].ToString());
            }
        }
        return userName;
    }
    [WebMethod]
    public static void Logout()
    {
        HttpContext.Current.Session["userName"] = null;

    }
}