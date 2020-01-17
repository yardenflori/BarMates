using BarMates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                return "iLlegal";
            }

            else
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("user_name", userDetails["userName"].ToString()));

                var dataDB = DBController.ExecuteStoredProcedure_Select("sp_check_for_existing_user", parameters);
                if (dataDB.Count > 0)
                {
                    return "usernameAlreadyExists";
                }

                returnVal = "Homepage";
                HttpContext.Current.Session["userName"] = userName;
                HttpContext.Current.Session["needUpdate"] = "1";

                parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("user_name", userDetails["userName"].ToString()));
                parameters.Add(new SqlParameter("password", userDetails["password"].ToString()));
                parameters.Add(new SqlParameter("age", int.Parse(userDetails["age"].ToString())));
                DBController.ExecuteStoredProcedure_InsertOrUpdateOrDelete("sp_insert_new_user", parameters);
                User user = Engine.GetUserByUserName(userName);
                Engine.InsertNewUserToBadgeToDB(user);
                Engine.InsertNewUserToChallengeUserToDB(user);
            }
        }
        return returnVal;
    }
    public static string RegisterInDB(string user_name, string password, string age) 
    {
        string userName = null;

        if(user_name.Length<6 || password.Length<6)
        {
            return userName;
        }

        userName = user_name;

        return userName;
    }
}