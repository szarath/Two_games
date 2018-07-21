using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null) //Logged in
                {
                    Title = "twoGAMES: My Profile";
                    UserData currentUser = (UserData)(Session["User"]);
                    txtFirstName.Value = currentUser.getFirstName();
                    txtLastName.Value = currentUser.getSurname();
                    txtCellNumber.Value = currentUser.getCellNumber();
                    txtDoB.Value = currentUser.getDoB().ToShortDateString();
                    if (currentUser.isPrem() == 1)
                    {
                        myProfileTitle.InnerHtml = "My Profile <i class='material-icons tooltipped' data-position='right' data-tooltip='Premium Member'>star</i>";
                        lblPremUserLink.InnerHtml = "<a class='grey-text disabled'>Account Type: Premium Member</a>";
                        accountType.InnerHtml = "Account Type: Premium Member";
                    }
                    else
                    {
                        accountType.InnerHtml = "Account Type: Free Member";
                    }
                    if (currentUser.isMod() == 1)
                    {
                        lblPremUserLink.InnerHtml = "<a class='grey-text disabled'>Account Type: Moderator</a>";
                        accountType.InnerHtml = "Account Type: Moderator";
                    }
                    else if (currentUser.isAdmin() == 1)
                    {
                        lblPremUserLink.InnerHtml = "<a class='grey-text disabled'>Account Type: Administrator</a>";
                        accountType.InnerHtml = "Account Type: Administrator";
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                } 
            }
        }

        protected void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            int result = service.deleteUser(((UserData)Session["User"]).getUsername());
            service.Close();
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;
                //Response.Write("<script>alert('User Account Deleted!');</script>");
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnUpdateAccount_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            int result = service.updateUserInfo(((UserData)Session["User"]).getID(), txtFirstName.Value, txtLastName.Value, txtCellNumber.Value, Convert.ToDateTime(txtDoB.Value));
            service.Close();
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;

                myProfileView.InnerHtml = "<div class='col s12 m6 push-m3'>";
                myProfileView.InnerHtml += "<div class='card white'>";
                myProfileView.InnerHtml += "<div class='card-content Black-text'>";
                myProfileView.InnerHtml += "<span class='card-title bold'>Account Updated Successfully</span>";
                myProfileView.InnerHtml += "<p>Your account has been updated successfully.<br/><br/>Please proceeed to log back into your account to view the changes.</p>";

                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "<div class='card-action'> ";
                myProfileView.InnerHtml += "<a href='Login.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                myProfileView.InnerHtml += "<a href='Index.aspx' class='btn waves-effect waves-light orange lighten-2'>Cancel</a> ";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";

                //Response.Redirect("Index.aspx");
            }
            else
            {
                Session["User"] = null;

                myProfileView.InnerHtml = "<div class='col s12 m6 push-m3'>";
                myProfileView.InnerHtml += "<div class='card white'>";
                myProfileView.InnerHtml += "<div class='card-content Black-text'>";
                myProfileView.InnerHtml += "<span class='card-title bold'>Oh No...An Error Occured</span>";
                myProfileView.InnerHtml += "<p>Unfortunately we were unable to update your account.<br/><br/>As a precaution, please log back into your account where you may try again.</p>";

                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "<div class='card-action'> ";
                myProfileView.InnerHtml += "<a href='Login.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                myProfileView.InnerHtml += "<a href='Index.aspx' class='btn waves-effect waves-light orange lighten-2'>Cancel</a> ";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
            }
        }
    }
}