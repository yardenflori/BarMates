using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string Register(string userDetailsString)
    {
        string returnVal = "";
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
            string userName =RegisterInDB(userDetails["userName"].ToString(), userDetails["password"].ToString(),userDetails["age"].ToString());
            if (userName == null)
            {
                //אם שם המשתמש והסיסמה לא תקינים מבחינת תווים אז להחזיר iLlegal
                //אם שם המשתמש קיים כבר במערכת אז להחזירusernameAlreadyExists
                if(userDetails["userName"].ToString().Length>0)
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("user_name", userDetails["userName"].ToString()));

                    var dataDB = DBController.ExecuteStoredProcedure_Select("sp_check_for_existing_user", parameters);
                    if (dataDB.Count > 0)
                    {
                        return "usernameAlreadyExists";
                    }
                }
                else
                {
                    return "iLlegal";
                }
            }
            else
            {
                returnVal = "Homepage";
                HttpContext.Current.Session["userName"] = userName;

            }
        }
        return returnVal;
    }
    public static string RegisterInDB(string user_name, string password, string age) 
    {
        string userName = null;
        //לבדוק ששם המשתמש תקין מבחינת תווים
        // לבדוק שהסיסמה תקינה מבחינת תווים
        // לבדוק ששם המשתמש לא קיים כבר בDB

        if(user_name.Length<5 || password.Length<5)
        {
            return userName;
        }

        userName = user_name;

        return userName;
    }
}