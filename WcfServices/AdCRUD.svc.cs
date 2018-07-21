using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServices.Classes;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdCRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdCRUD.svc or AdCRUD.svc.cs at the Solution Explorer and start debugging.
    public class AdCRUD : IAdCRUD
    {
        object[] IAdCRUD.getPlatforms()
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT pPlatform FROM tblPlatform ORDER BY pPlatform ASC"));

            string[] result = null;

            if (!(ds.Tables.Count == 0) && !(ds.Tables[0].Rows.Count == 0))
            {
                string[] temp = new string[ds.Tables[0].Rows.Count];
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    temp[k] = ds.Tables[0].Rows[k][0].ToString();
                }
                result = temp;
            }
                
                
            return result;
        }

        int IAdCRUD.deleteAd(int AdID)
        {
            string sqlStatement = "DELETE FROM tblAd WHERE aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", AdID);

            return clsSQL.ExecuteNonQuery(command);
            //returns 1 if record deleted and 0 otherwise
            //return clsSQL.ExecuteNonQuery("DELETE FROM tblAd WHERE aID=" + AdID);
        }

        object[] IAdCRUD.getAdDetails(string AdID)
        {
            string sqlStatement = "SELECT tblAd.*, tblUser.uCellNum FROM tblAd INNER JOIN tblUser ON tblAd.aUserID=tblUser.uID WHERE tblAd.aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", AdID);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT tblAd.*, tblUser.uCellNum FROM tblAd INNER JOIN tblUser ON tblAd.aUserID=tblUser.uID WHERE tblAd.aID=" + AdID);// + " AND aFlagged=0");

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

        object[] IAdCRUD.getEditAdDetails(string AdID, int userID)
        {
            string sqlStatement = "SELECT tblAd.*, tblUser.uCellNum FROM tblAd INNER JOIN tblUser ON tblAd.aUserID=tblUser.uID WHERE tblAd.aID=@0 AND tblAd.aUserID=@1";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0",AdID);
            command.Parameters.AddWithValue("@1", userID);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT tblAd.*, tblUser.uCellNum FROM tblAd INNER JOIN tblUser ON tblAd.aUserID=tblUser.uID WHERE tblAd.aID=" + AdID);// + " AND aFlagged=0");

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

        int IAdCRUD.insertAd(string Title, string Platform, DateTime CreatedDate, string Description, string Location, double Price, int Negotiable, int ShowNumber, String Pic1Path, String Pic2Path, String Pic3Path, int PremiumAd, int UserID)
        {
            string sqlStatement = "INSERT INTO tblAd (aTitle, aPlatform, aCreateDate, aDescrip, aLocation, aPrice, aNegotiable, aShowNum, aPic1Path, aPic2Path, aPic3Path, aPremiumAd, aUserID) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", Title);
            command.Parameters.AddWithValue("@1", Platform);
            command.Parameters.AddWithValue("@2", CreatedDate);
            command.Parameters.AddWithValue("@3", Description);
            command.Parameters.AddWithValue("@4", Location);
            command.Parameters.AddWithValue("@5", Price);
            command.Parameters.AddWithValue("@6", Negotiable);
            command.Parameters.AddWithValue("@7", ShowNumber);
            command.Parameters.AddWithValue("@8", Pic1Path);
            command.Parameters.AddWithValue("@9", Pic2Path);
            command.Parameters.AddWithValue("@10", Pic3Path);
            command.Parameters.AddWithValue("@11", PremiumAd);
            command.Parameters.AddWithValue("@12", UserID);

            return clsSQL.ExecuteNonQuery(command);

            //return clsSQL.ExecuteNonQuery("INSERT INTO tblAd (aTitle, aPlatform, aCreateDate, aDescrip, aLocation, aPrice, aNegotiable, aShowNum, aPic1Path, aPic2Path, aPic3Path, aPremiumAd, aUserID) VALUES('" + Title + "','" + Platform + "', '" + CreatedDate + "', '" + Description + "', '"+Location+"', " + Price + ", " + Negotiable + ", " + ShowNumber + ", '" + Pic1Path + "', '" + Pic2Path + "', '" + Pic3Path + "',"+ PremiumAd + ","+ UserID + ")");
        }

        object[][] IAdCRUD.searchAds(string searchTerm, string extraSQLParams, string extraSQLOrderBys)
        {
            string sqlStatement = "SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE (aTitle LIKE @0) AND (aFlagged=0) AND (DATEDIFF(week,aCreateDate,'"+ DateTime.Today.ToString()+ "')<=2)" + extraSQLParams + "ORDER BY aPremiumAd DESC, " + extraSQLOrderBys + "aCreateDate DESC";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", "%" + searchTerm + "%");

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE (aTitle LIKE '%" + searchTerm+ "%') AND (aFlagged=0) " + extraSQLParams+"ORDER BY aPremiumAd DESC, "+extraSQLOrderBys+"aCreateDate DESC"); 

            return create2DAdsArray(ds);
        }

        int IAdCRUD.updateAd(int AdID, string Title, string Platform, string Description, string Location, double Price, int Negotiable, int ShowNumber, string Pic1Path, string Pic2Path, string Pic3Path, int PremiumAd)
        {
            string sqlStatement = "UPDATE tblAd SET aTitle=@0, aPlatform=@1, aCreateDate='"+DateTime.Today.ToString()+"', aDescrip=@2, aLocation=@3, aPrice=@4, aNegotiable=@5, aShowNum=@6, aPic1Path=@7, aPic2Path=@8, aPic3Path=@9, aPremiumAd=@10 WHERE aID=@11";

            SqlCommand command = new SqlCommand(sqlStatement);
            
            command.Parameters.AddWithValue("@0", Title);
            command.Parameters.AddWithValue("@1", Platform);
            command.Parameters.AddWithValue("@2", Description);
            command.Parameters.AddWithValue("@3", Location);
            command.Parameters.AddWithValue("@4", Price);
            command.Parameters.AddWithValue("@5", Negotiable);
            command.Parameters.AddWithValue("@6", ShowNumber);
            command.Parameters.AddWithValue("@7", Pic1Path);
            command.Parameters.AddWithValue("@8", Pic2Path);
            command.Parameters.AddWithValue("@9", Pic3Path);
            command.Parameters.AddWithValue("@10", PremiumAd);
            command.Parameters.AddWithValue("@11", AdID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblAd SET aTitle='" + Title + "', aPlatform='" + Platform + "', aDescrip='" + Description + "', aLocation='"+Location+"', aPrice=" + Price + ", aNegotiable=" + Negotiable + ", aShowNum="+ ShowNumber + ", aPic1Path='" + Pic1Path + "', aPic2Path='"+ Pic2Path + "', aPic3Path='" + Pic3Path+ "', aPremiumAd="+PremiumAd+" WHERE aID=" + AdID);
        }

        Object[][] IAdCRUD.getUserAds(int userID)
        {
            string sqlStatement = "SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aUserID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aUserID=" + userID);

            return create2DAdsArray(ds);
        }

        Object[][] IAdCRUD.getRecentlyAdded()
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT TOP 26 aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aFlagged=0 AND (DATEDIFF(week,aCreateDate,'" + DateTime.Today.ToString() + "')<=2) ORDER BY aCreateDate DESC"));

            return create2DAdsArray(ds);
        }

        int IAdCRUD.getNumUserAds(int userID)
        {
            string sqlStatement = "SELECT COUNT(aID) FROM tblAd WHERE aUserID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE aUserID=" + userID);

            int temp = 0;
            if (!(ds.Tables.Count == 0))
            {
                if (!(ds.Tables[0].Rows.Count == 0))
                {
                    temp = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }

            return temp;
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

        /*int IAdCRUD.sendPictures(byte[][] pics, int aID)
        {
            if (!(pics == null))
            {
                for(int i = 0; i < pics.GetLength(0); i++)
                {
                    string base64String = Convert.ToBase64String(pics[i]);

                    clsSQL.ExecuteNonQuery("INSERT INTO tblImg (Picture, aID) VALUES('"+base64String+"', " + aID + ")");
                }
            }
            else
                return 0;


            return 1;*
        }

        byte[][] IAdCRUD.getPictures(int aID)
        {
            DataSet ds = clsSQL.ExecuteQuery("SELECT Picture FROM tblImg WHERE aID = " + aID);
            byte[][] temp = null;
            if (!(ds.Tables.Count == 0) && !(ds.Tables[0].Rows.Count == 0))
            {
                temp = new byte[ds.Tables[0].Rows.Count][];
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    temp[i] = Convert.FromBase64String(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            
            return temp;
        }*/

        Object[][] IAdCRUD.getFlaggedAdsManagement()
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged FROM tblAd WHERE aFlagged = 1"));

            return create2DAdsArray(ds);
        }

        Object[][] IAdCRUD.getAllAdsManagement()
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged FROM tblAd"));

            return create2DAdsArray(ds);
        }

        object[][] IAdCRUD.searchAdsManagement(string searchTerm, string extraSQLParams)
        {
            string sqlStatement = "SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged FROM tblAd WHERE aTitle LIKE @0" + extraSQLParams;

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", "%" + searchTerm + "%");

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged FROM tblAd WHERE aTitle LIKE '%" + searchTerm + "%'" + extraSQLParams);

            return create2DAdsArray(ds);
        }

        //Method for getting a user's email address
        string[] IAdCRUD.getUserEmail(int aID)
        {
            string sqlStatement = "SELECT uEmail, uUsername from tblUser INNER JOIN tblAd ON tblUser.uID = tblAd.aUserID WHERE tblAd.aID = @0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", aID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT uEmail, uUsername from tblUser INNER JOIN tblAd ON tblUser.uID = tblAd.aUserID WHERE tblAd.aID = " + aID);
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    String[] temp = new String[2];
                    temp[0] = sqlDataSet.Tables[0].Rows[0][0].ToString();
                    temp[1] = sqlDataSet.Tables[0].Rows[0][1].ToString();
                    return temp;
                }
            }
            return null;
        }

        int IAdCRUD.unflagAd(int adID)
        {
            string sqlStatement = "UPDATE tblAd SET aFlagged=0 WHERE aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", adID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblAd SET aFlagged=0 WHERE aID="+adID);
        }

        int IAdCRUD.flagAd(int adID)
        {
            string sqlStatement = "UPDATE tblAd SET aFlagged=1 WHERE aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", adID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblAd SET aFlagged=1 WHERE aID=" + adID);
        }

        int IAdCRUD.reportAd(int adID)
        {
            string sqlStatement = "UPDATE tblAd SET aReportCount=aReportCount+1 WHERE aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", adID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblAd SET aReportCount=aReportCount+1 WHERE aID=" + adID);
        }

        int IAdCRUD.unreportAd(int adID)
        {
            string sqlStatement = "UPDATE tblAd SET aReportCount=0 WHERE aID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", adID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDAE tblAd SET aReportCount=0 WHERE aID=" + adID);
        }

        object[][] IAdCRUD.getReportedAdsManagement()
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged FROM tblAd WHERE aReportCount>0"));

            return create2DAdsArray(ds);
        }

        object[][] IAdCRUD.getUsersAdsManagement(int ID)
        {
            string sqlStatement = "SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aReportCount, aFlagged FROM tblAd WHERE aUserID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT aID, aTitle, aPlatform, aCreateDate, aPrice, aReportCount, aFlagged FROM tblAd WHERE aUserID="+ID);

            return create2DAdsArray(ds);
        }

        int IAdCRUD.numNewAdsYearManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(aID) FROM tblAd WHERE DATEPART(year,aCreateDate)=DATEPART(year,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE DATEPART(year,aCreateDate)=DATEPART(year,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numNewAdsMonthManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(aID) FROM tblAd WHERE DATEPART(month,aCreateDate)=DATEPART(month,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE DATEPART(month,aCreateDate)=DATEPART(month,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numNewAdsWeekManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(aID) FROM tblAd WHERE DATEPART(week,aCreateDate)=DATEPART(week,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE DATEPART(week,aCreateDate)=DATEPART(week,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numNewAdsDayManagement(DateTime date)
        {
            string sqlStatement = "SELECT COUNT(aID) FROM tblAd WHERE DATEPART(dayofyear,aCreateDate)=DATEPART(dayofyear,@0)";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", date.ToShortDateString());

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE DATEPART(dayofyear,aCreateDate)=DATEPART(dayofyear,'" + date.ToShortDateString() + "')");
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numReportedAdsManagement()
        {
            DataSet sqlDataSet = clsSQL.ExecuteQuery(new SqlCommand("SELECT COUNT(aID) FROM tblAd WHERE aReportCount>0"));
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numFlaggedAdsManagement()
        {
            DataSet sqlDataSet = clsSQL.ExecuteQuery(new SqlCommand("SELECT COUNT(aID) FROM tblAd WHERE aFlagged=1"));
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        int IAdCRUD.numPremAdsManagement()
        {
            DataSet sqlDataSet = clsSQL.ExecuteQuery(new SqlCommand("SELECT COUNT(aID) FROM tblAd WHERE aPremiumAd=1"));
            return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0].ToString());
        }

        
        int IAdCRUD.incViewCount(int aID)
        {
            string sqlStatement = "UPDATE tblAd SET aViewCount = aViewCount + 1 WHERE aID = @0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", aID);

            return clsSQL.ExecuteNonQuery(command);
            //return clsSQL.ExecuteNonQuery("UPDATE tblAd SET aViewCount = aViewCount + 1 WHERE aID =" + aID);
        }

        int IAdCRUD.getViewCount(int aID)
        {
            string sqlStatement = "SELECT aViewCount FROM tblAd WHERE aID = @0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", aID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT aViewCount FROM tblAd WHERE aID = " + aID);
            if (sqlDataSet.Tables.Count != 0)
            {
                if (sqlDataSet.Tables[0].Rows.Count != 0)
                {
                    return Convert.ToInt32(sqlDataSet.Tables[0].Rows[0][0]);
                }
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

    }
}
