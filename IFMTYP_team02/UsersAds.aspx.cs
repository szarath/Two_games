using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class UsersAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (((UserData)Session["User"]).isAdmin() == 0)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Title = "twoGAMES: Users Ads";

                //Populate with table of users ads
                AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
                adCRUDService.Open();
                Object[][] ads = adCRUDService.getUsersAdsManagement(Convert.ToInt32(Request.QueryString.Get("id")));
                adCRUDService.Close();

                usersAdsView.InnerHtml = createUsersAdsView(ads, "There are no ads for user \""+ Request.QueryString.Get("user") + "\".", "Viewing " + Request.QueryString.Get("user")+"'s Ads");
            }
        }

        private string createTableRow(string ID, string Title, string Platform, string CreateDate, string Price, /*string UserID, */int ReportCount, Boolean Flagged)
        {
            //aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged
            string row = "";

            row = "<tr>";
            row += "<td>" + ID + "</td>";
            row += "<td>" + Title + "</td>";
            row += "<td>" + Platform + "</td>";
            row += "<td>" + CreateDate + "</td>";
            row += "<td>R" + Price + "</td>";
            //row += "<td>" + UserID + "</td>";
            row += "<td>" + ReportCount.ToString() + "</td>";
            row += "<td>" + Flagged.ToString() + "</td>";
            row += "<td>" + "<a href='DetailedAd.aspx?ad=" + ID + "' class='btn waves-effect waves-light'>View</a>";
            row += " <a href='EditAdPage.aspx?ad=" + ID + "' class='btn waves-effect waves-light orange lighten-2'>Edit</a>";
            row += "</td></tr>";

            return row;
        }

        private string createUsersAdsView(Object[][] adsObject, string noAdsMessage, string titleAboveTable)
        {
            if (adsObject == null)
            {
                return "<span class='card-title'>" + noAdsMessage + "</span>";
            }
            else
            {
                //aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged
                string adsView = "<span class='card-title'>" + titleAboveTable + "</span><table class='highlight responsive-table'><thead><tr>";
                adsView += "<th data-field=\"id\">ID</th>";
                adsView += "<th data-field=\"title\">Title</th>";
                adsView += "<th data-field=\"platform\">Platform</th>";
                adsView += "<th data-field=\"createDate\">Created</th>";
                adsView += "<th data-field=\"price\">Price</th>";
                //adsView += "<th data-field=\"userID\">User ID</th>";
                adsView += "<th data-field=\"reportCount\">No. Reports</th>";
                adsView += "<th data-field=\"flagged\">Flagged</th>";
                adsView += "<th data-field=\"action\">Action</th>";
                adsView += "</tr></thead><tbody>";

                for (int k = 0; k < adsObject.Length; k++)
                {
                    adsView += createTableRow((string)adsObject[k][0], (string)adsObject[k][1], (string)adsObject[k][2], Convert.ToDateTime((string)adsObject[k][3]).ToShortDateString(), (string)adsObject[k][4], /*(string)adsObject[k][5], */Convert.ToInt32((string)adsObject[k][5]), Convert.ToBoolean((string)adsObject[k][6]));
                }

                adsView += "</tbody></table>";

                return adsView;
            }
        }
    }
}