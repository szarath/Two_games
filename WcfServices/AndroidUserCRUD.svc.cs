using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WcfServices.Classes;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AndroidUserCRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AndroidUserCRUD.svc or AndroidUserCRUD.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AndroidUserCRUD : IAndroidUserCRUD
    {
        //Insert method for inserting a User record into the database
        int IAndroidUserCRUD.AndroidinsertUser(string Username, string Password, string firstName, string surname, string Email, string cellNumber, string DOB, string RegDate)//, string modAccess, string adminAccess, string premAccess
        {
         
              DateTime dob = DateTime.ParseExact(DOB, "d-M-yyyy",System.Globalization.CultureInfo.InvariantCulture);
            DateTime reg = DateTime.ParseExact(RegDate, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
           
            return clsAndroidSQL.ExecuteNonQuery("INSERT INTO tblUser (uUsername, uPass, uFirstName, uSurname, uEmail, uCellNum, uDoB, uRegDate) VALUES('" + Username
                + "','" + Password + "', '" + firstName + "', '" + surname + "', '" + Email + "', '" + cellNumber + "', '" + dob + "', '" + reg + "')");
            // "', '" + Convert.ToBoolean(modAccess) + "',' " + Convert.ToBoolean(adminAccess) + "', '" + Convert.ToBoolean(premAccess) +
            
        }
        int IAndroidUserCRUD.AndroidreportUser(string userID)
        {
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblUser SET uReportCount=uReportCount+1 WHERE uID=" + Convert.ToInt32(userID));
        }
        //Delete method for deleting a User record from the database
        int IAndroidUserCRUD.AndroiddeleteUser(string Username)
        {

            //returns 1 if record deleted and 0 otherwise
            return clsAndroidSQL.ExecuteNonQuery("DELETE FROM tblUser WHERE uUsername = '" + Username + "'");
        }

        //Update Method for users to update User record in database
        int IAndroidUserCRUD.AndroidupdateUserInfo(string ID, string firstName, string surname, string cellNumber, string DOB,string Email)
        {
            DateTime dob = DateTime.ParseExact(DOB, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblUser SET uFirstName='" + firstName + "', uSurname='" + surname + "', uCellNum='" + cellNumber + "', uDoB='" + dob + "', uEmail='" + Email + "' WHERE uID=" + Convert.ToInt32(ID));
            
        }

        //Method for Authenticating a user
        Object[] IAndroidUserCRUD.AndroidAuthenticate(string UserEmail, string Password)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT uID, uFirstName, uSurname, uEmail, uCellNum, uDoB, uMod, uAdmin, uPrem FROM tblUser WHERE (UPPER(uUsername)='" + UserEmail.ToUpper() + "' OR UPPER(uEmail) ='" + UserEmail.ToUpper() + "') AND uPass='" + Password + "'");

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
        int IAndroidUserCRUD.AndroidupdateUserPassword(string ID, string emailAddress, string oldPass, string newPass)
        {
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblUser SET uPass='" + newPass + "' WHERE uID=" + Convert.ToInt32(ID) + " AND uEmail='" + emailAddress + "' AND uPass='" + oldPass + "'");
        }


        //Method for updating a user's email address
        int IAndroidUserCRUD.AndroidupdateUserEmail(string ID, string userPass, string oldEmail, string newEmail)
        {
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblUser SET uEmail='" + newEmail + "' WHERE uID=" + Convert.ToInt32(ID) + " AND uEmail='" + oldEmail + "' AND uPass='" + userPass + "'");
        }


        //Method for getting a user's email address
        string IAndroidUserCRUD.AndroidgetUserEmail(string ID)
        {
            DataSet sqlDataSet = clsAndroidSQL.ExecuteQuery("SELECT uEmail from tblUser WHERE uID=" + Convert.ToInt32(ID));
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }

       

        string IAndroidUserCRUD.ouch()
        {
            return "ouch";
        }
    }
}
