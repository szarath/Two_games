using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
                Response.Redirect("Index.aspx");

            Title = "twoGAMES: Registration";
        }


        protected void RegisterUser_ServerClick(object sender, EventArgs e)
        {
            String innerHTML = "<p>";

            //invalidRegister.InnerHtml = "";//"<p class="black-text">Processing the information you provided...</p>";

            Boolean blnRegister = true;
            //DateTime dttToday = DateTime.Today;

            if ((txtFirstName.Value.Equals("")) || (txtLastName.Value.Equals("")) || (txtEmail.Value.Equals("")) || (txtConfirmEmail.Value.Equals("")) || (txtDoB.Value.Equals("")) || (txtCellNumber.Value.Equals("")) || (txtUsername.Value.Equals("")) || (txtPassword.Value.Equals("")) || (txtConfirmPassword.Value.Equals("")))
            {
                blnRegister = false;
                //Show fields empty error message
                innerHTML += "*Please make sure you have filled in all the fields<br/>";
            }
            else
            {
                if (!(txtEmail.Value.Contains("@")))
                {
                    blnRegister = false;
                    //Show email is not valid 
                    innerHTML += "*Your email is not valid<br/>";
                }

                if (!(txtConfirmEmail.Value.Equals(txtEmail.Value)))
                {
                    blnRegister = false;
                    //Show email not match error message
                    innerHTML += "*Your emails do not match<br/>";
                }
                if (!((DateTime.Today.Year - Convert.ToDateTime(txtDoB.Value).Year) >= 16))
                {
                    blnRegister = false;
                    //Show date of birth error message
                    innerHTML += "*You need to be at least 16 years old to use twoGames<br/>If you are too young then ask your parents for some help<br/>";
                }
                
                try
                {
                    int intNumTest = Convert.ToInt32(txtCellNumber.Value);
                }
                catch (Exception)
                {
                    blnRegister = false;
                    //Show cell number error message
                    innerHTML += "*Please provide a correct cell number<br/>";
                }
                if (!(txtPassword.Value.Length >= 8))
                {
                    blnRegister = false;
                    //Show Password is short 
                    innerHTML += "*Your Password is too short. <br/> It has to be more than 8 characters<br/>";
                }
                if (!(txtConfirmPassword.Value.Equals(txtPassword.Value)))
                {
                     blnRegister = false;
                     //Show password not match error 
                     innerHTML += "*Your passwords do not match<br/>";

                }
                
            }

            innerHTML += "</p>";

            if (blnRegister)
            {
                UserService.UserCRUDClient service = new UserService.UserCRUDClient();
                service.Open();
                service.insertUser(txtUsername.Value, Security.HashPassword(txtPassword.Value), txtFirstName.Value, txtLastName.Value, txtEmail.Value, txtCellNumber.Value, Convert.ToDateTime(txtDoB.Value), DateTime.Today, 0, 0, 0);
                service.Close();
                changePage();
               
            }
            else
            {
                invalidRegister.InnerHtml = innerHTML;
            }
        }


        //Changing the page to look like the successfull registration page
        protected void changePage()
        {
            regCard.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
            regCard.InnerHtml += "<div class='card white'>";
            regCard.InnerHtml += "<div class='card-content Black-text'>";
            regCard.InnerHtml += "<span class='card-title bold'>Registration Successful</span>";
            regCard.InnerHtml += "<p>You have successfully registered your account</p>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "<div class='card-action'>";
            regCard.InnerHtml += "<a href=\"Login.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "</div>";
            regCard.InnerHtml += "</div>";
        }

        

    }
}