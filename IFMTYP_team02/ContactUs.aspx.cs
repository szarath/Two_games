using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Title = "twoGAMES: Contact Us";
                txtName.Value = ((UserData)Session["User"]).getFirstName() + " " + ((UserData)Session["User"]).getSurname();
                UserService.UserCRUDClient userCRUDServ = new UserService.UserCRUDClient();
                userCRUDServ.Open();
                txtEmail.Value = userCRUDServ.getUserEmail(((UserData)Session["User"]).getID());
                userCRUDServ.Close();
                txtSubject.Focus();
            }
            else
            {
                txtName.Focus();
            }
        }


        protected void Submit_ServerClick(object sender, EventArgs e)
        {


            if (txtName.Value == "" || txtEmail.Value == "" || txtDesc.Value == "" || drpdwnSubject.SelectedIndex == 0)
            {
                errorContactUs.InnerHtml = "<p class='red-text'>Please fill in all the appropriate fields</p>";
            }
            else
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("twogamesza@gmail.com", "IFMTYP2016"),
                    EnableSsl = true
                };



                String mailBody = "";
                if (!(Session["User"] == null))
                { 
                    mailBody += "User ID: " + ((UserData)Session["User"]).getID() + "\r\n";
                    mailBody += "Username: " + ((UserData)Session["User"]).getUsername() + "\r\n";
                }
                mailBody += "Name: " + txtName.Value + "\r\n";
                mailBody += "Email: " + txtEmail.Value + "\r\n";
                mailBody += "Category: " + drpdwnSubject.Items[drpdwnSubject.SelectedIndex].Text + "\r\n\r\n";
                mailBody += "Issue: \r\n";
                mailBody += txtDesc.Value + "\r\n\r\n\r\n";




                System.Web.HttpBrowserCapabilities browser = Request.Browser;
                mailBody += "Browser Capabilities\r\n"
                    + "Type = " + browser.Type + "\r\n"
                    + "Name = " + browser.Browser + "\r\n"
                    + "Version = " + browser.Version + "\r\n"
                    + "Major Version = " + browser.MajorVersion + "\r\n"
                    + "Minor Version = " + browser.MinorVersion + "\r\n"
                    + "Platform = " + browser.Platform + "\r\n"
                    + "Is Mobile Device = " + browser.IsMobileDevice + "\r\n"
                    + "Mobile Device Manufacturer = " + browser.MobileDeviceManufacturer + "\r\n"
                    + "Mobile Device Model = " + browser.MobileDeviceModel + "\r\n"
                    + "Is Beta = " + browser.Beta + "\r\n"
                    + "Is Crawler = " + browser.Crawler + "\r\n"
                    + "Is AOL = " + browser.AOL + "\r\n"
                    + "Is Win16 = " + browser.Win16 + "\r\n"
                    + "Is Win32 = " + browser.Win32 + "\r\n"
                    + "Supports Frames = " + browser.Frames + "\r\n"
                    + "Supports Tables = " + browser.Tables + "\r\n"
                    + "Supports Cookies = " + browser.Cookies + "\r\n"
                    + "Supports VBScript = " + browser.VBScript + "\r\n"
                    + "Supports JavaScript = " +
                        browser.EcmaScriptVersion.ToString() + "\r\n"
                    + "Supports Java Applets = " + browser.JavaApplets + "\r\n"
                    + "Supports ActiveX Controls = " + browser.ActiveXControls
                          + "\n"
                    + "Supports JavaScript Version = " +
                        browser["JavaScriptVersion"] + "\r\n";


                try
                {

                    client.Send("twogamesza@gmail.com", "devinharmse@gmail.com, mcguire.jamesc@gmail.com", "[twoGames Support] " + drpdwnSubject.Items[drpdwnSubject.SelectedIndex].Text, mailBody);
                    contactUsDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    contactUsDiv.InnerHtml += "<div class='card white'>";
                    contactUsDiv.InnerHtml += "<div class='card-content Black-text'>";
                    contactUsDiv.InnerHtml += "<span class='card-title bold'>Successfully Submited</span>";
                    contactUsDiv.InnerHtml += "<p>You have successfully submited your issue. Please wait patiently and we shall get back to you as soon as we can</p>";

                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "<div class='card-action'>";
                    contactUsDiv.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "</div>";
                }
                catch (SmtpException ex)
                {
                    contactUsDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    contactUsDiv.InnerHtml += "<div class='card white'>";
                    contactUsDiv.InnerHtml += "<div class='card-content Black-text'>";
                    contactUsDiv.InnerHtml += "<span class='card-title bold'>Unable to submit issue</span>";
                    contactUsDiv.InnerHtml += "<p>Clearly there was an issue submitting your query but it should be resolved soon. Please try again later</p>";

                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "<div class='card-action'>";
                    contactUsDiv.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "</div>";
                    contactUsDiv.InnerHtml += "</div>";
                }
            }

        }
    }
}