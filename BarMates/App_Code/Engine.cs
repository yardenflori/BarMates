using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;

public class Engine
{
    User User { set; get; }
    List<User> Users { set; get; }
    List<Bar> Bars { get; set; }
    public Engine()
	{
        InitUser();
        if(User.UserName!=null)
        {
            InitUsers();
            InitBars();
        }
    }

    public void InitUser()
    {
        string username = DBController.GetUserName();
        if (username!=null)
        {
            User = new User();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("user_name", username));
            //stored procedure sp_get_user_by_username should be built in DB
            var userDB = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_username", parameters);

            if (userDB.Count > 0)
            {
                foreach (DbDataRecord currentItem in userDB)
                {
                    UpdateUserFields(User, currentItem);
                }
            }
        }
    }

    public void InitUsers()
    {
        Users = new List<User>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("user_name", User.UserName));
        //stored procedure sp_get_all_other_users should be built in DB
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_other_users", parameters);

        if (usersDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in usersDB)
            {
                User new_user = new User();
                UpdateUserFields(new_user, currentItem);
                Users.Add(new_user);
            }
        }
    }

    public static void UpdateUserFields(User user, DbDataRecord data)
    {
        user.UserId = int.Parse(data["userId"].ToString());
        user.UserName = data["userName"].ToString();
        //should add here all the user fields that came back from DB
    }

    public void InitBars()
    {
        Bars = new List<Bar>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        //stored procedure sp_get_all_bars should be built in DB
        var barsDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_bars", parameters);
        if (barsDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in barsDB)
            {
                Bar newBar = new Bar();
                UpdateBarFields(newBar, currentItem);
                Bars.Add(newBar);
            }
        }
    }

    public void UpdateBarFields(Bar bar, DbDataRecord data)
    {
        bar.BarId = int.Parse(data["barId"].ToString());
        bar.BarName = data["barName"].ToString();
        //should add here all the user fields that came back from DB
    }



}
