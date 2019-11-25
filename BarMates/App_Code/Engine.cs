using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;

public class Engine
{
    User User { set; get; }
    List<User> Users { set; get; }
    
    public Engine()
	{
        InitUser();
        if(User.UserName!=null)
        {
            InitUsers();

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

    public static void UpdateUserFields(User i_user, DbDataRecord i_data)
    {
        i_user.UserId = int.Parse(i_data["userId"].ToString());
        i_user.UserName = i_data["userName"].ToString();
        //should add here all the user fields that came back from DB
    }

    
}
