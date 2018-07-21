using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IFMTYP_team02
{
    public partial class newMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] != null) //Logged in
            {
                dropDownMenuLoggedIn.Visible = true;
                dropDownMenuLoggedOut.Visible = false;
                logInSideNav.Visible = false;
                registerSideNav.Visible = false;
                postNewAdTopNav.Visible = true;
                postNewAdSideNav.Visible = true;
                floatingPostAdButton.Visible = true;
                signOutSideNav.Visible = true;

                //----obtain number of users ads and set myads badge
                AdService.AdCRUDClient adServ = new AdService.AdCRUDClient();
                adServ.Open();
                int numUsersAds = adServ.getNumUserAds(((UserData)Session["User"]).getID());
                adServ.Close();
                myAdsBadgeDropDown.InnerHtml = numUsersAds.ToString();

                //----set appropriate admin and mod link visible
                if(((UserData)Session["User"]).isMod() == 1)
                {
                    managementDropDownTrigger.Visible = true;
                    dropDownManagementMenu.Visible = true;
                    manageAdsDrop.Visible = true;
                    manageUsersDrop.Visible = false;
                    //adminSideNav.Visible = true;
                    manageAdsSideNav.Visible = true;
                    manageUsersSideNav.Visible = false;
                    adminSideNavDivider.Visible = true;
                }
                else if (((UserData)Session["User"]).isAdmin() == 1)
                {
                    managementDropDownTrigger.Visible = true;
                    dropDownManagementMenu.Visible = true;
                    manageAdsDrop.Visible = true;
                    manageUsersDrop.Visible = true;
                    //adminSideNav.Visible = true;
                    manageAdsSideNav.Visible = true;
                    manageUsersSideNav.Visible = true;
                    adminSideNavDivider.Visible = true;
                }
            }
            else
            {
                postNewAdTopNav.Visible = false;
                postNewAdSideNav.Visible = false;
                dropDownMenuLoggedIn.Visible = false;
                dropDownMenuLoggedOut.Visible = true;
                logInSideNav.Visible = true;
                registerSideNav.Visible = true;
                myProfileSideNav.Visible = false;
                myAdsSideNav.Visible = false;
                signOutSideNav.Visible = false;
            }
        }

        protected void dropDownMenuSignOut_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("User");
            Session.Remove("pic1");
            Session.Remove("pic2");
            Session.Remove("pic3");
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}