using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WcfServices.Classes;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AndroidAdCRUD" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AndroidAdCRUD.svc or AndroidAdCRUD.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AndroidAdCRUD : IAndroidAdCRUD
    {
        public object Request { get; private set; }

        object[] IAndroidAdCRUD.AndroidgetPlatforms()
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT pPlatform FROM tblPlatform");

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


        string IAndroidAdCRUD.message(string productemail, string productusername, string producttitle, string buyeremail, string buyerusername, string description)
            {

          





                  NetworkCredential netCred = new NetworkCredential("twogamesza@gmail.com", "IFMTYP2016");
                  SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
                  smtpobj.EnableSsl = true;
                  smtpobj.Credentials = netCred;

                  MailMessage mailMessage = new MailMessage();
                 mailMessage.From = new MailAddress("twogamesza@gmail.com", "twoGames");
                 mailMessage.To.Add(new MailAddress(productemail));
                mailMessage.Subject = "You have a reply to your ad \"" + (string)producttitle + "\"";
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = "<h1>Hi " + productusername + ",</h1><br/>";
                mailMessage.Body += "<b>" + buyerusername + "</b> has replied to your advert <b>\"" + (string)producttitle + "\"</b>";
                mailMessage.Body += "<br/><br/>";
                mailMessage.Body += "Their message: <br/>";
                mailMessage.Body += "\"<i>" +description + "</i>\"";
                mailMessage.Body += "<br/><br/><a href='mailto:" + buyeremail + "?subject=[twoGames] \""+ (string)producttitle + "\" Advert'><button>Click here to reply</button></a>";
                mailMessage.Body += "<br/><br/>Kind Regards<br/>twoGames";



            return "Sent";

                
               }

        string IAndroidAdCRUD.issue(string useremail, string usernmae, string issueselect,string description)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("twogamesza@gmail.com", "IFMTYP2016"),
                EnableSsl = true
            };



            String mailBody = "";
          
            mailBody += "Name: " +usernmae + "\r\n";
            mailBody += "Email: " + useremail + "\r\n";
            mailBody += "Category: " + issueselect + "\r\n\r\n";
            mailBody += "Issue: \r\n";
            mailBody += description + "\r\n\r\n\r\n";


            return "Sent";


        }

        int IAndroidAdCRUD.AndroiddeleteAd(string AdID)
        {
            //returns 1 if record deleted and 0 otherwise
            return clsAndroidSQL.ExecuteNonQuery("DELETE FROM tblAd WHERE aID=" + Convert.ToInt32(AdID));
        }

        object[] IAndroidAdCRUD.AndroidgetAdDetails(string AdID)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT tblAd.*, tblUser.uCellNum FROM tblAd INNER JOIN tblUser ON tblAd.aUserID=tblUser.uID WHERE tblAd.aID=" + Convert.ToInt32(AdID));

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

        int IAndroidAdCRUD.AndroidinsertAd(insertAd ia)
        {
            // string Title, string Platform, string CreatedDate, string Description, string Location, string Price, string Negotiable, string ShowNumber, string Pic1Path, string Pic2Path, string Pic3Path, string PremiumAd, string UserID

           

           DateTime cd = DateTime.ParseExact(ia.CreatedDate, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
              return clsAndroidSQL.ExecuteNonQuery("INSERT INTO tblAd (aTitle, aPlatform, aCreateDate, aDescrip, aLocation, aPrice, aNegotiable, aShowNum, aPic1Path, aPic2Path, aPic3Path, aPremiumAd, aUserID) VALUES('" + ia.Title   + "','" + ia.Platform + "', '" + cd + "', '" + ia.Description + "', '" + ia.Location + "', " + Convert.ToDouble(ia.Price) + ", " + Convert.ToInt32(Convert.ToBoolean(ia.Negotiable)) + ", " + Convert.ToInt32(Convert.ToBoolean(ia.ShowNumber)) + ", '" + ia.Pic1Path + "', '" + ia.Pic2Path + "', '" + ia.Pic3Path + "'," + Convert.ToInt32(Convert.ToBoolean(ia.PremiumAd)) + "," + Convert.ToInt32(ia.UserID) + ")");
          //  DateTime cd = DateTime.ParseExact(CreatedDate, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //  return clsSQL.ExecuteNonQuery("INSERT INTO tblAd (aTitle, aPlatform, aCreateDate, aDescrip, aLocation, aPrice, aNegotiable, aShowNum, aPic1Path, aPic2Path, aPic3Path, aPremiumAd, aUserID) VALUES('" + Title   + "','" + Platform + "', '" + cd + "', '" + Description + "', '" + Location + "', " + Convert.ToDouble(Price) + ", " + Convert.ToInt32(Convert.ToBoolean(Negotiable)) + ", " + Convert.ToInt32(Convert.ToBoolean(ShowNumber)) + ", '" + Pic1Path + "', '" + Pic2Path + "', '" + Pic3Path + "'," + Convert.ToInt32(Convert.ToBoolean(PremiumAd)) + "," + Convert.ToInt32(UserID) + ")");
        }

        object[][] IAndroidAdCRUD.AndroidsearchAds(string searchTerm)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aTitle LIKE '%" + searchTerm + "%'");

            return create2DAdsArray(ds);
        }

        int IAndroidAdCRUD.AndroidupdateAd(editAd ea)
        {
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblAd SET aTitle='" + ea.Title + "', aPlatform='" + ea.Platform + "', aDescrip='" + ea.Description + "', aLocation='" + ea.Location + "', aPrice=" + Convert.ToDouble(ea.Price) + ", aNegotiable=" + Convert.ToInt32(Convert.ToBoolean(ea.Negotiable))
                + ", aShowNum=" +Convert.ToInt32( Convert.ToBoolean(ea.ShowNumber)) + ", aPic1Path='" + ea.Pic1Path + "', aPic2Path='" + ea.Pic2Path + "', aPic3Path='" + ea.Pic3Path + "', aPremiumAd=" + Convert.ToInt32(Convert.ToBoolean(ea.PremiumAd)) + " WHERE aID=" + Convert.ToInt32(ea.AdID));
        }

        Object[][] IAndroidAdCRUD.AndroidgetUserAds(string userID)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aUserID=" + Convert.ToInt32(userID));

            return create2DAdsArray(ds);
        }

        Object[][] IAndroidAdCRUD.AndroidgetRecentlyAdded()
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT TOP 26 aID, aPic1Path, aTitle, aPlatform, aLocation, aPrice, aPremiumAd FROM tblAd WHERE aFlagged=0 AND (DATEDIFF(week,aCreateDate,'" + DateTime.Today.ToString() + "')<=2) ORDER BY aCreateDate DESC");

            return create2DAdsArray(ds);
        }

        int IAndroidAdCRUD.AndroidgetNumUserAds(string userID)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT COUNT(aID) FROM tblAd WHERE aUserID=" + Convert.ToInt32(userID));

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

        string IAndroidAdCRUD.test(string hello, string what)
        {

            return hello + what;

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

        /*int IAndroidAdCRUD.AndroidsendPictures(byte[][] pics, string aID)
        {
            if (!(pics == null))
            {
                for (int i = 0; i < pics.GetLength(0); i++)
                {
                    string base64String = Convert.ToBase64String(pics[i]);

                    clsSQL.ExecuteNonQuery("INSERT INTO tblImg (Picture, aID) VALUES('" + base64String + "', " + Convert.ToInt32(aID) + ")");
                }
            }
            else
                return 0;


            return 1;
        }*/

        byte[][] IAndroidAdCRUD.AndroidgetPictures(string aID)
        {
            DataSet ds = clsAndroidSQL.ExecuteQuery("SELECT Picture FROM tblImg WHERE aID = " + Convert.ToInt32(aID));
            byte[][] temp = null;
            if (!(ds.Tables.Count == 0) && !(ds.Tables[0].Rows.Count == 0))
            {
                temp = new byte[ds.Tables[0].Rows.Count][];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    temp[i] = Convert.FromBase64String(ds.Tables[0].Rows[i][0].ToString());
                }
            }

            return temp;
        }

        string[] IAndroidAdCRUD.AndroidgetUserEmail(string aID)
        {
            DataSet sqlDataSet = clsAndroidSQL.ExecuteQuery("SELECT uEmail, uUsername from tblUser INNER JOIN tblAd ON tblUser.uID = tblAd.aUserID WHERE tblAd.aID = " + Convert.ToInt32(aID));
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

        int IAndroidAdCRUD.Androidreportad(string adID)
        {
            int ad = Convert.ToInt32(adID);
            return clsAndroidSQL.ExecuteNonQuery("UPDATE tblAd SET aReportCount=aReportCount+1 WHERE aID = " + ad);
        }
    }

}
