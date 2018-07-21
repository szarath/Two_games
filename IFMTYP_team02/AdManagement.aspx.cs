using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class AdManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if ((((UserData)Session["User"]).isMod() == 0) && (((UserData)Session["User"]).isAdmin() == 0))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Title = "twoGAMES: Ad Management";

                /*if (!Page.IsPostBack && Request.Form["__EVENTTARGET"] == "btnSearch")
                {
                    btnSearch_ServerClick(null, null);
                }
                else
                {*/
                reported_ServerClick(null, null);
                //}
            }
        }

        protected void flagged_ServerClick(object sender, EventArgs e)
        {
            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = adCRUDService.getFlaggedAdsManagement();
            adCRUDService.Close();

            AdManageView.InnerHtml = createAdManageView(ads, "There seems to be no flagged ads...", "Flagged Ads");
        }

        protected void viewAll_ServerClick(object sender, EventArgs e)
        {
            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = adCRUDService.getAllAdsManagement();
            adCRUDService.Close();

            AdManageView.InnerHtml = createAdManageView(ads, "There seems to be no ads...","All Ads");
        }

        private string createTableRow(string ID, string Title, string Platform, string CreateDate, string Price, string UserID, int ReportCount, Boolean Flagged)
        {
            //aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged
            string row = "";

            row = "<tr>";
            row += "<td>" + ID+"</td>";
            row += "<td>" + Title + "</td>";
            row += "<td>" + Platform + "</td>";
            row += "<td>" + CreateDate + "</td>";
            row += "<td>R" + Price + "</td>";
            row += "<td>" + UserID + "</td>";
            row += "<td>" + ReportCount.ToString() + "</td>";
            row += "<td>" + Flagged.ToString() + "</td>";
            row += "<td>"+ "<a href='DetailedAd.aspx?ad=" + ID + "' class='btn waves-effect waves-light'>View</a>";
            row += " <a href='EditAdPage.aspx?ad="+ID+"' class='btn waves-effect waves-light orange lighten-2'>Edit</a>";
            row += "</td></tr>";

            return row;
        }

        private string createAdManageView(Object[][] adsObject, string noAdsMessage, string titleAboveTable)
        {
            if (adsObject == null)
            {
                return noAdsMessage;
            }
            else
            {
                //aID, aTitle, aPlatform, aCreateDate, aPrice, aUserID, aReportCount, aFlagged
                string adsView = "<span class='card-title'>"+titleAboveTable+"</span><table class='highlight responsive-table'><thead><tr>";
                adsView += "<th data-field=\"id\">ID</th>";
                adsView += "<th data-field=\"title\">Title</th>";
                adsView += "<th data-field=\"platform\">Platform</th>";
                adsView += "<th data-field=\"createDate\">Created</th>";
                adsView += "<th data-field=\"price\">Price</th>";
                adsView += "<th data-field=\"userID\">User ID</th>";
                adsView += "<th data-field=\"reportCount\">No. Reports</th>";
                adsView += "<th data-field=\"flagged\">Flagged</th>";
                adsView += "<th data-field=\"action\">Action</th>";
                adsView += "</tr></thead><tbody>";

                for (int k = 0; k < adsObject.Length; k++)
                {
                    adsView += createTableRow((string)adsObject[k][0], (string)adsObject[k][1], (string)adsObject[k][2], Convert.ToDateTime((string)adsObject[k][3]).ToShortDateString(), (string)adsObject[k][4], (string)adsObject[k][5], Convert.ToInt32((string)adsObject[k][6]), Convert.ToBoolean((string)adsObject[k][7]));
                }

                adsView += "</tbody></table>";

                return adsView;
            }
        }

        /*protected void search_ServerClick(object sender, EventArgs e)
        {
            string searchView = "<div class='row'>";
            searchView += "<div class='input-field col s12 m9 l10'>";
            searchView += "<i class='material-icons prefix'>search</i>";
            searchView += "<input id='txtSearch' type='text' class='black-text' runat='server' autofocus/>";
            searchView += "<label for='txtSearch'>Click here to search</label>";
            searchView += "</div>";
            searchView += "<div class='input-field col m2 l2'>";
            searchView += "<button id='btnSearch' type='submit' class='btn waves-effect waves-light' runat=\"server\" onserverclick=\"btnSearch_ServerClick\">Search</button>";
            searchView += "</div>";
            searchView += "</div>";

            searchView = "<span class='card-title'>Feature coming soon...</span>";
            AdManageView.InnerHtml = searchView;
        }*/

        /*protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = adCRUDService.searchAdsManagement(txtSearch.Value,"");
            adCRUDService.Close();

            AdManageView.InnerHtml = createAdManageView(ads, "No ads match your search...", "Search Ads");
        }*/

        protected void stats_ServerClick(object sender, EventArgs e)
        {
            //AdManageView.InnerHtml = "<span class='card-title'>Feature coming soon...</span>";

            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            DateTime todayIs = DateTime.Today;
            int newUsersThisYear = adCRUDService.numNewAdsYearManagement(todayIs);
            int newUsersThisMonth = adCRUDService.numNewAdsMonthManagement(todayIs);
            int newUsersThisWeek = adCRUDService.numNewAdsWeekManagement(todayIs);
            int newUsersToday = adCRUDService.numNewAdsDayManagement(todayIs);
            int reportedusersTotal = adCRUDService.numReportedAdsManagement();
            int flaggedUsersTotal = adCRUDService.numFlaggedAdsManagement();
            int premUsersTotal = adCRUDService.numPremAdsManagement();
            adCRUDService.Close();

            string statsView = "<span class='card-title'>Stats</span>";
            statsView += "<div class='row'>";
            statsView += "<p>New Ads This <b>Year:</b> " + newUsersThisYear.ToString() + "</p>";
            statsView += "<p>New Ads This <b>Month:</b> " + newUsersThisMonth.ToString() + "</p>";
            statsView += "<p>New Ads This <b>Week:</b> " + newUsersThisWeek.ToString() + "</p>";
            statsView += "<p>New Ads <b>Today:</b> " + newUsersToday.ToString() + "</p>";
            statsView += "<br/>";
            statsView += "<p>Number of <b>Premium Ads:</b> " + premUsersTotal.ToString() + "</p>";
            statsView += "<p>Number of <b>Reported Ads:</b> " + reportedusersTotal.ToString() + "</p>";
            statsView += "<p>Number of <b>Flagged Ads:</b> " + flaggedUsersTotal.ToString() + "</p>";
            statsView += "</div>";

            AdManageView.InnerHtml = statsView;
        }

        protected void reported_ServerClick(object sender, EventArgs e)
        {
            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = adCRUDService.getReportedAdsManagement();
            adCRUDService.Close();

            AdManageView.InnerHtml = createAdManageView(ads, "There seems to be no ads...", "Reported Ads");
        }
    }
}