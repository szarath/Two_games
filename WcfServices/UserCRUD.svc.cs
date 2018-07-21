using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Activation;
using WcfServices.Classes;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserCRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserCRUD.svc or UserCRUD.svc.cs at the Solution Explorer and start debugging.
    public class UserCRUD : IUserCRUD
    {
        //Insert method for inserting a User record into the database
        int IUserCRUD.insertUser(string Username, string Password, string firstName, string surname, string Email, string cellNumber, DateTime DoB, DateTime RegDate, int modAccess, int adminAccess, int premAccess)
        {
            string sqlStatement = "INSERT INTO tblUser (uUsername, uPass, uFirstName, uSurname, uEmail, uCellNum, uDoB, uRegDate, uMod, uAdmin, uPrem) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0",Username);
            command.Parameters.AddWithValue("@1",Password);
            command.Parameters.AddWithValue("@2",firstName);
            command.Parameters.AddWithValue("@3",surname);
            command.Parameters.AddWithValue("@4",Email);
            command.Parameters.AddWithValue("@5",cellNumber);
            command.Parameters.AddWithValue("@6",DoB);
            command.Parameters.AddWithValue("@7",RegDate);
            command.Parameters.AddWithValue("@8",modAccess);
            command.Parameters.AddWithValue("@9",adminAccess);
            command.Parameters.AddWithValue("@10",premAccess);

            return clsSQL.ExecuteNonQuery(command);
        }

        //Delete method for deleting a User record from the database
        int IUserCRUD.deleteUser(string ID)
        {
            string sqlStatement = "DELETE FROM tblAd WHERE aUserID=@0; DELETE FROM tblUser WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            return clsSQL.ExecuteNonQuery(command);

            //clsSQL.ExecuteNonQuery("DELETE FROM tblAd WHERE aUserID=" + ID);
            //returns 1 if record deleted and 0 otherwise
            //return clsSQL.ExecuteNonQuery("DELETE FROM tblAd WHERE aUserID=" + ID + "; DELETE FROM tblUser WHERE uID=" + ID+";");
        }

        //Update Method for users to update User record in database
        int IUserCRUD.updateUserInfo(int ID, string firstName, string surname, string cellNumber, DateTime DoB)
        {
            string sqlStatement = "UPDATE tblUser SET uFirstName=@0, uSurname=@1, uCellNum=@2, uDoB=@3 WHERE uID=@4;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", firstName);
            command.Parameters.AddWithValue("@1", surname);
            command.Parameters.AddWithValue("@2", cellNumber);
            command.Parameters.AddWithValue("@3", DoB);
            command.Parameters.AddWithValue("@4", ID);

            return clsSQL.ExecuteNonQuery(command);

            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uFirstName='" + firstName + "', uSurname='" + surname + "', uCellNum='" + cellNumber + "', uDoB='" + DOB + "' WHERE uID="+ID);
        }

        //Method for Authenticating a user
        Object[] IUserCRUD.Authenticate(string UserEmailOrUsername, string Password)
        {
            string sqlStatement = "SELECT uID, uFirstName, uSurname, uCellNum, uDoB, uMod, uAdmin, uPrem FROM tblUser WHERE (UPPER(uUsername)=@0 OR UPPER(uEmail)=@0) AND uPass=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);

           

            command.Parameters.AddWithValue("@0", UserEmailOrUsername.ToUpper());
            command.Parameters.AddWithValue("@1", Password);

            DataSet ds = clsSQL.ExecuteQuery(command);


            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uFirstName, uSurname, uCellNum, uDoB, uMod, uAdmin, uPrem FROM tblUser WHERE (UPPER(uUsername)='" + UserEmail.ToUpper() + "' OR UPPER(uEmail) ='" + UserEmail.ToUpper() + "') AND uPass='" + Password + "'");

            string[] temp = null;
            if (!(ds.Tables.Count == 0))
            {
                if (!(ds.Tables[0].Rows.Count == 0))
                {
                    temp = new string[ds.Tables[0].Columns.Count];
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = ds.Tables[0].Rows[0][k].ToString();
                    }
                }
            }
                

            return temp;
        }

        //Method for updating a user's password
        int IUserCRUD.updateUserPassword(int ID, string emailAddress, string oldPass, string newPass)
        {
            string sqlStatement = "UPDATE tblUser SET uPass=@3 WHERE uID=@0 AND UPPER(uEmail)=@1 AND uPass=@2";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);
            command.Parameters.AddWithValue("@1", emailAddress.ToUpper());
            command.Parameters.AddWithValue("@2", oldPass);
            command.Parameters.AddWithValue("@3", newPass);

            return clsSQL.ExecuteNonQuery(command);

            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uPass='"+newPass+"' WHERE uID="+ID+" AND uEmail='"+emailAddress+"' AND uPass='"+oldPass+"'");
        }

        //Method for getting a user's email address
        string IUserCRUD.getUserEmail(int ID)
        {
            string sqlStatement = "SELECT uEmail from tblUser WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);

            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT uEmail from tblUser WHERE uID="+ID);
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString(); 
                }
            }
            return null;
        }

        //Method for updating a user's email address
        int IUserCRUD.updateUserEmail(int ID, string userPass, string oldEmail, string newEmail)
        {
            string sqlStatement = "UPDATE tblUser SET uEmail=@3 WHERE uID=@0 AND UPPER(uEmail)=@1 AND uPass=@2";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);
            command.Parameters.AddWithValue("@1", oldEmail.ToUpper());
            command.Parameters.AddWithValue("@2", userPass);
            command.Parameters.AddWithValue("@3", newEmail);

            return clsSQL.ExecuteNonQuery(command);

            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uEmail='" + newEmail + "' WHERE uID=" + ID + " AND uEmail='" + oldEmail + "' AND uPass='" + userPass + "'");
        }

        //Method for updating a user's premium membership
        int IUserCRUD.updateUserPremAccess(int ID, string userPass, string userEmail, string cellNumber, DateTime DoB, int premAccess)
        {
            string sqlStatement = "UPDATE tblUser SET uPrem=@5 WHERE uID=@0 AND UPPER(uEmail)=@2 AND uPass=@1 AND uCellNum=@3 AND uDoB=@4";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);
            command.Parameters.AddWithValue("@1", userPass);
            command.Parameters.AddWithValue("@2", userEmail.ToUpper());
            command.Parameters.AddWithValue("@3", cellNumber);
            command.Parameters.AddWithValue("@4", DoB);
            command.Parameters.AddWithValue("@5", premAccess);

            int result = clsSQL.ExecuteNonQuery(command);

            //int result = clsSQL.ExecuteNonQuery("UPDATE tblUser SET uPrem='" + premAccess + "' WHERE uID=" + ID + " AND uEmail='" + userEmail + "' AND uPass='" + userPass + "' AND uCellNum='"+cellNumber+"' AND uDoB='"+DoB+"'");
            if (result == 1)
            {
                command = null;

                sqlStatement = "UPDATE tblAd SET aPremiumAd=1 WHERE aUserID=@0";

                command = new SqlCommand(sqlStatement);

                command.Parameters.AddWithValue("@0",ID);

                clsSQL.ExecuteNonQuery(command);
                //clsSQL.ExecuteNonQuery("UPDATE tblAd SET aPremiumAd=1 WHERE aUserID=" + ID);
                return result;
            }
            else return result;
        }

        Object[][] IUserCRUD.getFlaggedUsersManagement()
        {
            string sqlStatement = "SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser WHERE uFlagged=1");

            return create2DAdsArray(ds);
        }

        Object[][] IUserCRUD.getAllUsersManagement()
        {
            string sqlStatement = "SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);
        }

        protected Object[][] create2DAdsArray(DataSet sqlDataSet)
        {
            string[][] result = null;

            if (!(sqlDataSet.Tables.Count == 0) && !(sqlDataSet.Tables[0].Rows.Count == 0))
            {
                string[][] temp = new string[sqlDataSet.Tables[0].Rows.Count][];
                for (int k = 0; k < sqlDataSet.Tables[0].Rows.Count; k++)
                {
                    temp[k] = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int j = 0; j < sqlDataSet.Tables[0].Columns.Count; j++)
                    {
                        temp[k][j] = sqlDataSet.Tables[0].Rows[k][j].ToString();
                    }
                    result = temp;
                }
            }

            return result;
        }

        int IUserCRUD.unflagUser(int userID)
        {
            string sqlStatement = "UPDATE tblUser SET uFlagged=0 WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uFlagged=0 WHERE uID=" + userID);
        }

        int IUserCRUD.flagUser(int userID)
        {
            string sqlStatement = "UPDATE tblUser SET uFlagged=1 WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uFlagged=1 WHERE uID=" + userID);
        }

        int IUserCRUD.reportUser(int userID)
        {
            string sqlStatement = "UPDATE tblUser SET uReportCount=uReportCount+1 WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uReportCount=uReportCount+1 WHERE uID=" + userID);
        }

        int IUserCRUD.unreportUser(int userID)
        {
            string sqlStatement = "UPDATE tblUser SET uReportCount=0 WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDAE tblUser SET uReportCount=0 WHERE uID=" + userID);
        }

        object[][] IUserCRUD.getReportedUsersManagement()
        {
            string sqlStatement = "SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser WHERE uReportCount>0";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser WHERE uReportCount>0");

            return create2DAdsArray(ds);
        }

        string IUserCRUD.getUsername(int userID)
        {
            string sqlStatement = "SELECT uUsername FROM tblUser WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT uUsername FROM tblUser WHERE uID=" + userID);

            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }

        string IUserCRUD.isUserPrem(int userID)
        {
            string sqlStatement = "SELECT uPrem FROM tblUser WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT uPrem FROM tblUser WHERE uID=" + userID);

            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }

        Object[] IUserCRUD.getUserDetailsManagement(int userID)
        {
            string sqlStatement = "SELECT * FROM tblUser WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT * FROM tblUser WHERE uID=" + userID);

            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;
        }

        int IUserCRUD.updateUserDetailsManagement(int userID, string username, string firstName, string surname, string Email, string cellNumber, DateTime DoB, DateTime regDate, int modAccess, int adminAccess, int premAccess, int flagged, int reportCount)
        {
            string sqlStatement = "UPDATE tblUser SET uUsername=@1, uFirstName=@2, uSurname=@3, uEmail=@4, uCellNum=@5, uDoB=@6, uRegDate=@7, uMod=@8, uAdmin=@9, uPrem=@10, uFlagged=@11, uReportCount=@12 WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);
            command.Parameters.AddWithValue("@1", username);
            command.Parameters.AddWithValue("@2", firstName);
            command.Parameters.AddWithValue("@3", surname);
            command.Parameters.AddWithValue("@4", Email);
            command.Parameters.AddWithValue("@5", cellNumber);
            command.Parameters.AddWithValue("@6", DoB);
            command.Parameters.AddWithValue("@7", regDate);
            command.Parameters.AddWithValue("@8", modAccess);
            command.Parameters.AddWithValue("@9", adminAccess);
            command.Parameters.AddWithValue("@10", premAccess);
            command.Parameters.AddWithValue("@11", flagged);
            command.Parameters.AddWithValue("@12", reportCount);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblUser SET uUsername='"+username+"', uFirstName='" + firstName + "', uSurname='" + surname + "', uEmail='"+Email+"', uCellNum='" + cellNumber + "', uDoB='" + DoB + "', uRegDate='" + regDate + "', uMod="+modAccess+", uAdmin="+adminAccess+", uPrem="+premAccess+", uFlagged="+flagged+", uReportCount="+reportCount+" WHERE uID=" + userID);
        }

        int IUserCRUD.numNewUsersYearManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE DATEPART(year,uRegDate)=DATEPART(year,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE DATEPART(year,uRegDate)=DATEPART(year,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numNewUsersMonthManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE DATEPART(month,uRegDate)=DATEPART(month,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE DATEPART(month,uRegDate)=DATEPART(month,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numNewUsersWeekManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE DATEPART(week,uRegDate)=DATEPART(week,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE DATEPART(week,uRegDate)=DATEPART(week,'" + date.ToShortDateString()+"')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numNewUsersDayManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE DATEPART(dayofyear,uRegDate)=DATEPART(dayofyear,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE DATEPART(dayofyear,uRegDate)=DATEPART(dayofyear,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numReportedUsersManagement()
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE uReportCount>0";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE uReportCount>0");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numFlaggedUsersManagement()
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE uFlagged=1";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE uFlagged=1");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IUserCRUD.numPremUsersManagement()
        {
            string sqlStatement = "SELECT COUNT(uID) FROM tblUser WHERE uPrem=1";

            SqlCommand command = new SqlCommand(sqlStatement);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(uID) FROM tblUser WHERE uPrem=1");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }
    }
}
