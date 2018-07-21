using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class DetailedUser : System.Web.UI.Page
    {
        private string userID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.userID = Request.QueryString.Get("id");

            if (!IsPostBack)
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
                    Title = "twoGAMES: Edit User";

                    UserService.UserCRUDClient userService = new UserService.UserCRUDClient();
                    userService.Open();
                    Object[] userDetails = userService.getUserDetailsManagement(Convert.ToInt32(userID));
                    userService.Close();

                    txtFirstName.Value = (string)userDetails[3];
                    txtLastName.Value = (string)userDetails[4];

                    txtEmail.Value = (string)userDetails[5];
                    txtCellNumber.Value = (string)userDetails[6];

                    txtDoB.Value = (string)userDetails[7];
                    txtRegDate.Value = (string)userDetails[8];

                    txtUsername.Value = (string)userDetails[1];

                    if(Convert.ToBoolean(userDetails[9]))
                    {
                        radioMod.Checked = true;
                    }
                    else if(Convert.ToBoolean(userDetails[10]))
                    {
                        radioAdmin.Checked = true;
                    }
                    else if(Convert.ToBoolean(userDetails[11]))
                    {
                        radioPrem.Checked = true;
                    }
                    else
                    {
                        radioFree.Checked = true;
                    }

                    if(Convert.ToBoolean(userDetails[12]))
                    {
                        flaggedSwitch.Checked = true;
                    }
                }
            }
        }

        protected void btnUpdateUser_ServerClick(object sender, EventArgs e)
        {
            if (!txtUsername.Equals("") && !txtFirstName.Value.Equals("") && !txtLastName.Value.Equals("") && !txtEmail.Equals("") && !txtCellNumber.Equals("") && !txtDoB.Equals("") && !txtRegDate.Equals(""))
            {
                if ((DateTime.Today.Year - Convert.ToDateTime(txtDoB.Value).Year) >= 16)
                {
                    int premChecked = 0;
                    int modChecked = 0;
                    int adminChecked = 0;
                    int flaggedChecked = 0;
                    if (radioPrem.Checked)
                        premChecked = 1;
                    if (radioMod.Checked)
                        modChecked = 1;
                    if (radioAdmin.Checked)
                        adminChecked = 1;
                    if (flaggedSwitch.Checked)
                        flaggedChecked = 1;

                    UserService.UserCRUDClient userService = new UserService.UserCRUDClient();
                    userService.Open();
                    int updateResult = userService.updateUserDetailsManagement(Convert.ToInt32(this.userID), txtUsername.Value, txtFirstName.Value, txtLastName.Value, txtEmail.Value, txtCellNumber.Value, Convert.ToDateTime(txtDoB.Value), Convert.ToDateTime(txtRegDate.Value), modChecked, adminChecked, premChecked, flaggedChecked, 0);
                    userService.Close();

                    if (updateResult == 1)
                    {
                        userCard.InnerHtml = "<div class='col s12 m6 push-m3'>";
                        userCard.InnerHtml += "<div class='card white'>";
                        userCard.InnerHtml += "<div class='card-content Black-text'>";
                        userCard.InnerHtml += "<span class='card-title bold'>User Updated Successfully</span>";
                        userCard.InnerHtml += "<p>You have successfully updated the user with ID = " + this.userID + ".</p>";

                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "<div class='card-action'>";
                        userCard.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a> ";
                        userCard.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Done</a>";
                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "</div>";

                    }
                    else
                    {
                        userCard.InnerHtml = "<div class='col s12 m6 push-m3'>";
                        userCard.InnerHtml += "<div class='card white'>";
                        userCard.InnerHtml += "<div class='card-content Black-text'>";
                        userCard.InnerHtml += "<span class='card-title bold'>User Updated Unsuccessfully</span>";
                        userCard.InnerHtml += "<p>We where unable to update the user with ID = " + this.userID + ". Please try again and if the problem persists please contact us <a href='ContactUs.aspx'>here</a>.</p>";

                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "<div class='card-action'>";
                        userCard.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a>";
                        userCard.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Done</a>";
                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "</div>";
                        userCard.InnerHtml += "</div>";
                    } 
                }
                else
                {
                    invalidUserUpdate.InnerHtml = "*Invalid Date of Birth. Needs to be at least 16 years old.";
                }
            }
            else
            {
                invalidUserUpdate.InnerHtml = "*Please make sure all fields are filled in.";
            }
        }

        protected void btnDeleteUser_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            int result = service.deleteUser(this.userID);
            service.Close();
            if (result == 1)//if the result is one then the user is deleted
            {
                userCard.InnerHtml = "<div class='col s12 m6 push-m3'>";
                userCard.InnerHtml += "<div class='card white'>";
                userCard.InnerHtml += "<div class='card-content Black-text'>";
                userCard.InnerHtml += "<span class='card-title bold'>User Deleted Successfully</span>";
                userCard.InnerHtml += "<p>You have successfully deleted the user with ID = " + this.userID + ".</p>";

                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "<div class='card-action'>";
                userCard.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a>";
                userCard.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Done</a>";
                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "</div>";
            }
            else
            {
                userCard.InnerHtml = "<div class='col s12 m6 push-m3'>";
                userCard.InnerHtml += "<div class='card white'>";
                userCard.InnerHtml += "<div class='card-content Black-text'>";
                userCard.InnerHtml += "<span class='card-title bold'>User Deleted Unsuccessfully</span>";
                userCard.InnerHtml += "<p>We where unable to delete the user with ID = " + this.userID + ". Please try again and if the problem persists please contact us <a href='ContactUs.aspx'>here</a>.</p>";

                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "<div class='card-action'>";
                userCard.InnerHtml += "<a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a> ";
                userCard.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Done</a>";
                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "</div>";
                userCard.InnerHtml += "</div>";
            }
        }
    }
}