using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;

namespace BarMates
{
    public static class DBController
    {
        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder();
            sqlString.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(sqlString.ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                connection.Close();
            }
            return connection;
        }
        public static ArrayList getValues_FromDB(string sqlQuery)
        {
            ArrayList foundDBValues = new ArrayList();
            SqlDataReader dataReader = null;
            SqlConnection connection = GetConnection();
            SqlCommand command;           

            try
            {
                
                command = new SqlCommand(sqlQuery, connection); dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    foreach (DbDataRecord r in dataReader)
                    {
                        foundDBValues.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                connection.Close();
            }

            return foundDBValues;
        }
        public static bool ExecuteStoredProcedure_InsertOrUpdateOrDelete(string procedureName, List<SqlParameter> parameters)
        {
            //init
            SqlConnection connection = GetConnection();
            bool isSucceeded = false;
            SqlCommand sqlCmd = new SqlCommand(procedureName, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //get parameters
            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }
            //exec sp
            try
            {
                int affectedRows = sqlCmd.ExecuteNonQuery();
                if (affectedRows <= 0)
                {
                    isSucceeded = false;
                }
                else
                {
                    isSucceeded = true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                isSucceeded = false;
            }
            finally
            {
                connection.Close();
            }
            return isSucceeded;
        }
        public static ArrayList ExecuteStoredProcedure_Select(string procedureName, List<SqlParameter> parameters)
        {
            //init
            SqlConnection connection = GetConnection();
            ArrayList foundDBValues = new ArrayList();
            SqlCommand sqlCmd = new SqlCommand(procedureName, connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            //get parameters
            foreach (SqlParameter param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }
            try
            {
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord r in reader)
                    {
                        foundDBValues.Add(r);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return foundDBValues;
        }
        public static string GetUserName()
        {
            string userName = null;
            try
            {
                userName = HttpContext.Current.Session["userName"].ToString();
            }
            catch
            {
                userName = null;
            }
            return userName;
        }

    }

}

