﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WcfServices.Classes
{
    public abstract class clsAndroidSQL
    {

        private static SqlDataReader reader;
        private static String ConnectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        private static DataSet tempset;
        private static SqlConnection connection = new SqlConnection(ConnectionString);

        //A function that executes a command and returns a SqlDataReader object
        //Only for SQL commands that return something. Not for update SQL commands
        public static DataSet ExecuteQuery(String sqlCommand)
        {
            try
            {

                //look at how to get connection stirng dynamically
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand, connection);
                tempset = new DataSet();
                adapter.Fill(tempset);

            }
            catch (Exception e)
            { }


            return tempset;
        }


        public static int ExecuteNonQuery(String sqlStr)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {

                return 0;

            }
            finally
            {
                if (!(connection == null))
                    connection.Close();
            }

            return 1;
        }

        //This function returns the connection string
        public static String getConnectionString()
        {
            return ConnectionString;
        }

        //This function is used to set the connection string
        public static void setConnectionString(String newString)
        {
            ConnectionString = newString;
        }

    }
}