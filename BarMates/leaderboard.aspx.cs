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

public partial class leaderboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DBController.GetUserName() == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    [WebMethod]
    public static string GetBestScoredUsers()
    {
        List<KeyValuePair<string, int>> scores = GetBestScoredUsersFromDB(10);

        return JsonConvert.SerializeObject(scores);
    }
    public static List<KeyValuePair<string, int>> GetBestScoredUsersFromDB(int numOfBest)
    {
        List<KeyValuePair<string, int>> users = new List<KeyValuePair<string, int>>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_sorted_users_by_scores", parameters);
        if (usersDB.Count > 0)
        {

            foreach (DbDataRecord currentItem in usersDB)
            {
                if (numOfBest > 0)
                {
                    int score = int.Parse(currentItem["score"].ToString());
                    string userName = currentItem["userName"].ToString();
                    KeyValuePair<string, int> tup = new KeyValuePair<string, int>(userName, score);
                    users.Add(tup);
                    numOfBest--;
                }
                else
                {
                    break;
                }
            }
        }
        return users;
    }

}