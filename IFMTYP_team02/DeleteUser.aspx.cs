using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        private string userID = "";
        private string userName = "";

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
                Title = "twoGAMES: Delete User";
                this.userID = Request.QueryString.Get("id");
                this.userName = Request.QueryString.Get("user");
                verifyHeading.InnerHtml = "Verify Deletion of User, " + this.userName;
            }
        }

        protected void btnVerifyDelete_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            UserData user = (UserData)Session["User"];
            Object[] ds = service.Authenticate(user.getUsername(), Security.HashPassword(txtPassword.Value));

            if (!(ds == null))
            {
                int deleteResult = service.deleteUser(this.userID);
                if (deleteResult == 1)
                {
                    //deleteUserView.InnerHtml += "<div class='col s12 m6 l4 push-l4 push-m3'>";
                    //deleteUserView.InnerHtml += "<div class='card white'>";
                    //deleteUserView.InnerHtml += "<div class='card-content black-text'>";
                    deleteUserView.InnerHtml = "<span class='card-title bold'>User Deleted Successfully</span>";
                    deleteUserView.InnerHtml += "<p>You have successfully deleted the user \""+this.userName+"\" with ID "+userID+".</p><br/>";
                    deleteUserView.InnerHtml += "<div class='card-action'>";
                    deleteUserView.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light'>Manage Users</a>";
                    deleteUserView.InnerHtml += "</div>";

                }
                else
                {
                    deleteUserView.InnerHtml = "<span class='card-title bold'>User Deleted Unsuccessfully</span>";
                    deleteUserView.InnerHtml += "<p>An error occured trying to delete user \"" + this.userName + "\" with ID " + userID+"</p><br/>";
                    deleteUserView.InnerHtml += "<div class='card-action'>";
                    deleteUserView.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light'>Manage Useres</a>";
                    deleteUserView.InnerHtml += "</div>";
                }
                service.Close();
            }
            else
            {
                invalidVerify.InnerHtml = "<p>Invalid password. Please try again.</p>";
            }
        }
    }
}