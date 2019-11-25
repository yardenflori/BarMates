using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using BarMates;

public class Engine
{
    User user { set; get; }
    List<User> users { set; get; }
    List<KeyValuePair<User, List<KeyValuePair<string, bool>>>> interests_and_user_matrix { set; get; }

    public Engine()
	{
        InitUser();
        if(user.userName!=null)
        {
            InitUsers();

        }
    }

    public void InitUser()
    {
        string username = DBController.GetUserName();
        if (username!=null)
        {
            user = new User();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("user_name", username));
            //stored procedure sp_get_user_by_username should be built in DB
            var userDB = DBController.ExecuteStoredProcedure_Select("sp_get_user_by_username", parameters);

            if (userDB.Count > 0)
            {
                foreach (DbDataRecord currentItem in userDB)
                {
                    UpdateUserFields(user, currentItem);
                }
            }
        }
    }

    public void InitUsers()
    {
        users = new List<User>();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("user_name", user.userName));
        //stored procedure sp_get_all_other_users should be built in DB
        var usersDB = DBController.ExecuteStoredProcedure_Select("sp_get_all_other_users", parameters);

        if (usersDB.Count > 0)
        {
            foreach (DbDataRecord currentItem in usersDB)
            {
                User new_user = new User();
                UpdateUserFields(new_user, currentItem);
                users.Add(new_user);
            }
        }
    }

    public static void UpdateUserFields(User i_user, DbDataRecord i_data)
    {
        i_user.userId = int.Parse(i_data["userId"].ToString());
        i_user.userName = i_data["userName"].ToString();
        //should add here all the user fields that came back from DB
    }

    public void Init_interests_and_user_matrix()
    {
        interests_and_user_matrix = new List<KeyValuePair<User, List<KeyValuePair<string, bool>>>>();
        
    }
}
