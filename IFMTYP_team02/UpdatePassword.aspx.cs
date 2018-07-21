using IFMTYP_team02.Classes;
using System;

namespace IFMTYP_team02
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) //Logged in
            {
                Title = "twoGAMES: Update Password";
                lblUpdatePass.InnerHtml = "Ok "+((UserData)Session["User"]).getFirstName() + ", Let's Update Your Password";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUpdatePass_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            Object[] ds = service.Authenticate(txtEmailAddress.Value, Security.HashPassword(txtOldPass.Value));
            service.Close();

            if (!(ds == null))
            {
                if (txtNewPass.Value.Equals(txtNewPassConfirm.Value))
                {
                    UserService.UserCRUDClient UserCRUDService = new UserService.UserCRUDClient();
                    UserCRUDService.Open();
                    int result = 0;
                    result = UserCRUDService.updateUserPassword(((UserData)Session["User"]).getID(), txtEmailAddress.Value, Security.HashPassword(txtOldPass.Value), Security.HashPassword(txtNewPassConfirm.Value));
                    UserCRUDService.Close();
                    if (result == 1)
                    {
                        Session["User"] = null;
                        changeCard();
                    }
                    else
                    {
                        invalidPassUpdate.InnerHtml = "<p>An error occured<br/>Please make sure you enter your correct email address and current password</p>";
                    }
                }
                else
                {
                    invalidPassUpdate.InnerHtml = "<p>Please make sure you confirm your new password</p>";
                }
            }
            else
            {
                invalidPassUpdate.InnerHtml = "<p>Invalid account details<br/>Please make sure you enter your current email address and password</p>";
            }
        }

        //Changing the page to look like the successfull update card
        protected void changeCard()
        {
            updatePassCard.InnerHtml = "<span class='card-title bold'>Password Update Successful</span>";
            updatePassCard.InnerHtml += "<p>You have successfully updated your password<br/><br/>You can now log in with your new password</p>";
            updatePassCard.InnerHtml += "</div>";
            updatePassCard.InnerHtml += "<div class='card-action'>";
            updatePassCard.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
        }
    }
}