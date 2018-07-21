using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class PremUserReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["User"] != null) && (((UserData)Session["User"]).isPrem() == 0)) //Logged in and not a premium member
            {
                Title = "twoGAMES: Premium Registration";
                lblPremUserReg.InnerHtml = ((UserData)Session["User"]).getFirstName() + ", Let's Become a Premium User";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnActivatePrem_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            Object[] ds = service.Authenticate(txtEmail.Value, Security.HashPassword(txtUserPass.Value));
            service.Close();
            service = null;

            if (!(ds == null))
            {
                //if (txtEmail.Value.Equals(txtConfirmEmail.Value))
                //{
                    UserService.UserCRUDClient UserCRUDService = new UserService.UserCRUDClient();
                    UserCRUDService.Open();
                    int result = 0;
                    result = UserCRUDService.updateUserPremAccess(((UserData)Session["User"]).getID(), Security.HashPassword(txtUserPass.Value), txtEmail.Value, ((UserData)Session["User"]).getCellNumber(), ((UserData)Session["User"]).getDoB(), 1);
                    UserCRUDService.Close();
                    if (result == 1)
                    {
                        Session["User"] = null;
                        changeCard();
                    }
                    else
                    {
                        invalidPremActivation.InnerHtml = "<p>An error occured<br/>Please make sure you enter the correct account information for verification purposes</p>";
                    }
                /*}
                else
                {
                    invalidPremActivation.InnerHtml = "<p>Please make sure you confirm your email address</p>";
                }*/
            }
            else
            {
                invalidPremActivation.InnerHtml = "<p>Invalid account details<br/>Please make sure you enter your current email address and password</p>";
            }
        }

        //Changing the page to look like the successfull update card
        protected void changeCard()
        {
            activatePremCard.InnerHtml = "<span class='card-title bold'>Premium Activation Successful</span>";
            activatePremCard.InnerHtml += "<p>You have successfully activated premium membership on your account<br/>Your ads will now be prioritised and your account is now trusted<br/><br/>Log in to your new Premium Account</p>";
            activatePremCard.InnerHtml += "</div>";
            activatePremCard.InnerHtml += "<div class='card-action'>";
            activatePremCard.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
        }
    }
}