using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class UpdateEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) //Logged in
            {
                Title = "twoGAMES: Update Email";
                lblUpdatePass.InnerHtml = "Ok " + ((UserData)Session["User"]).getFirstName() + ", Let's Update Your Email Address";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnUpdateEmail_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            Object[] ds = service.Authenticate(txtOldEmail.Value, Security.HashPassword(txtUserPass.Value));
            service.Close();
            service = null;

            if (!(ds == null))
            {
                if (txtNewEmail.Value.Equals(txtNewEmailConfirm.Value))
                {
                    UserService.UserCRUDClient UserCRUDService = new UserService.UserCRUDClient();
                    UserCRUDService.Open();
                    int result = 0;
                    result = UserCRUDService.updateUserEmail(((UserData)Session["User"]).getID(), Security.HashPassword(txtUserPass.Value), txtOldEmail.Value, txtNewEmailConfirm.Value);
                    UserCRUDService.Close();
                    if (result == 1)
                    {
                        Session["User"] = null;
                        changeCard();
                    }
                    else
                    {
                        invalidEmailUpdate.InnerHtml = "<p>An error occured<br/>Please make sure you enter your correct current email address and password</p>";
                    }
                }
                else
                {
                    invalidEmailUpdate.InnerHtml = "<p>Please make sure you confirm your new email address</p>";
                }
            }
            else
            {
                invalidEmailUpdate.InnerHtml = "<p>Invalid account details<br/>Please make sure you enter your current email address and password</p>";
            }
        }

        //Changing the page to look like the successfull update card
        protected void changeCard()
        {
            updateEmailCard.InnerHtml = "<span class='card-title bold'>Email Address Update Successful</span>";
            updateEmailCard.InnerHtml += "<p>You have successfully updated your email address<br/><br/>You can now log in with your username or your new email address</p>";
            updateEmailCard.InnerHtml += "</div>";
            updateEmailCard.InnerHtml += "<div class='card-action'>";
            updateEmailCard.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
        }
    }
}