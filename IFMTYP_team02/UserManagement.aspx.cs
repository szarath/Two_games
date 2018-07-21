using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class UserMangement : System.Web.UI.Page
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
                Title = "twoGAMES: User Management";
                reported_ServerClick(null, e);
            }
        }

        protected void reported_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient userCRUDService = new UserService.UserCRUDClient();
            userCRUDService.Open();
            Object[][] users = userCRUDService.getReportedUsersManagement();
            userCRUDService.Close();

            UserManageView.InnerHtml = createUserManageView(users, "There are no reported users.", "Reported Users");
        }

        protected void viewAll_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient userCRUDService = new UserService.UserCRUDClient();
            userCRUDService.Open();
            Object[][] users = userCRUDService.getAllUsersManagement();
            userCRUDService.Close();

            UserManageView.InnerHtml = createUserManageView(users,"There are no users.","All Users");
        }

        private string createTableRow(string ID, string Username, string Email, string RegDate, int ReportedCount, Boolean Flagged)
        {
            string row = "";

            row = "<tr>";
            row += "<td>" + ID + "</td>";
            row += "<td>" + Username + "</td>";
            row += "<td>" + Email + "</td>";
            row += "<td>" + RegDate + "</td>";
            row += "<td>" + ReportedCount.ToString() + "</td>";
            row += "<td>" + Flagged.ToString() + "</td>";
            row += "<td>" + "<a class='btn waves-effect waves-light' href='UsersAds.aspx?id=" + ID + "&user="+Username+"'>Ads</a> ";
            row += "<a class='btn waves-effect waves-light orange lighten-2' href='EditUser.aspx?id=" + ID + "'>Edit</a>";
            //row += "<a class='btn waves-effect waves-light red' href='DeleteUser.aspx?id=" + ID + "&user=" + Username + "'>Delete</a>";
            row += "</td></tr>";

            return row;
        }

        private string createUserManageView(Object[][] adsObject, string noUsersMessage, string titleAboveTable)
        {
            if (adsObject == null)
            {
                return noUsersMessage;
            }
            else
            {
                //uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged
                string usersView = "<span class='card-title'>" + titleAboveTable + "</span><div class='row'><table class='highlight responsive-table'><thead><tr>";
                usersView += "<th data-field=\"id\">ID</th>";
                usersView += "<th data-field=\"title\">Username</th>";
                usersView += "<th data-field=\"platform\">Email</th>";
                usersView += "<th data-field=\"createDate\">Registered</th>";
                usersView += "<th data-field=\"reportCount\">No. Reports</th>";
                usersView += "<th data-field=\"flagged\">Flagged</th>";
                usersView += "<th data-field=\"action\">Action</th>";
                usersView += "</tr></thead><tbody>";

                for (int k = 0; k < adsObject.Length; k++)
                {
                    usersView += createTableRow((string)adsObject[k][0], (string)adsObject[k][1], (string)adsObject[k][2], Convert.ToDateTime((string)adsObject[k][3]).ToShortDateString(), Convert.ToInt32((string)adsObject[k][4]), Convert.ToBoolean((string)adsObject[k][5]));
                }

                usersView += "</tbody></table></div>";

                return usersView;
            }
        }

        protected void flagged_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient userCRUDService = new UserService.UserCRUDClient();
            userCRUDService.Open();
            Object[][] users = userCRUDService.getFlaggedUsersManagement();
            userCRUDService.Close();

            UserManageView.InnerHtml = createUserManageView(users, "There are no flagged users.", "Flagged Users");
        }

        protected void stats_ServerClick(object sender, EventArgs e)
        {
            //UserManageView.InnerHtml = "<span class='card-title'>Feature coming soon...</span>";
            //UserManageView.InnerHtml = "<img src=\"MakeUserRegChart.cshtml\" />";

            //UserManageView.InnerHtml = "<asp:Chart ID=\"chtNBAChampionships\" runat=\"server\">";
            //UserManageView.InnerHtml += "<Series>";
            //UserManageView.InnerHtml += "<asp:Series Name=\"Championships\" YValueType=\"Int32\" ChartType=\"Column\" ChartArea=\"MainChartArea\">";
            //UserManageView.InnerHtml += "<Points>";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Celtics\" YValues=\"17\"/>";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Lakers\" YValues=\"15\" />";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Bulls\" YValues=\"6\" />";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Spurs\" YValues=\"4\" />";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"76ers\" YValues=\"3\" />";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Pistons\" YValues=\"3\" />";
            //UserManageView.InnerHtml += "<asp:DataPoint AxisLabel=\"Warriors\" YValues=\"3\" />";
            //UserManageView.InnerHtml += "</Points>";
            //UserManageView.InnerHtml += "</asp:Series>";
            //UserManageView.InnerHtml += "</Series>";
            //UserManageView.InnerHtml += "<ChartAreas>";
            //UserManageView.InnerHtml += "<asp:ChartArea Name=\"MainChartArea\">";
            //UserManageView.InnerHtml += "</asp:ChartArea>";
            //UserManageView.InnerHtml += "</ChartAreas>";
            //UserManageView.InnerHtml += "</asp:Chart>";

            UserService.UserCRUDClient userCRUDService = new UserService.UserCRUDClient();
            userCRUDService.Open();
            DateTime todayIs = DateTime.Today;
            int newUsersThisYear = userCRUDService.numNewUsersYearManagement(todayIs);
            int newUsersThisMonth = userCRUDService.numNewUsersMonthManagement(todayIs);
            int newUsersThisWeek = userCRUDService.numNewUsersWeekManagement(todayIs);
            int newUsersToday = userCRUDService.numNewUsersDayManagement(todayIs);
            int reportedusersTotal = userCRUDService.numReportedUsersManagement();
            int flaggedUsersTotal = userCRUDService.numFlaggedUsersManagement();
            int premUsersTotal = userCRUDService.numPremUsersManagement();
            userCRUDService.Close();

            string statsView = "<span class='card-title'>Stats</span>";
            statsView += "<div class='row'>";
            statsView += "<p>New Users This <b>Year:</b> "+newUsersThisYear.ToString()+"</p>";
            statsView += "<p>New Users This <b>Month:</b> " + newUsersThisMonth.ToString() + "</p>";
            statsView += "<p>New Users This <b>Week:</b> " + newUsersThisWeek.ToString() + "</p>";
            statsView += "<p>New Users <b>Today:</b> " + newUsersToday.ToString() + "</p>";
            statsView += "<br/>";
            statsView += "<p>Number of <b>Premium Users:</b> " + premUsersTotal.ToString() + "</p>";
            statsView += "<p>Number of <b>Reported Users:</b> " + reportedusersTotal.ToString() + "</p>";
            statsView += "<p>Number of <b>Flagged Users:</b> " + flaggedUsersTotal.ToString() + "</p>";
            statsView += "</div>";

            UserManageView.InnerHtml = statsView;
        }
    }
}