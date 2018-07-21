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
    public partial class DetailedAd : System.Web.UI.Page
    {
        private Object[] adDetails = null;
        private int adnum = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string adID = Request.QueryString.Get("ad");
            bool isnumber = int.TryParse(adID, out adnum);

            if (isnumber)
            {
                AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
                adService.Open();
                this.adDetails = adService.getAdDetails(adID);
                adService.incViewCount(Convert.ToInt32(adID));
                adService.Close();
                if (this.adDetails != null)
                {
                    //--------------TITLE
                    lblGameTitle.InnerHtml = (string)adDetails[1];
                    Title = "twoGAMES: "+ (string)adDetails[1];

                    //--------------PRICE
                    lblGamePrice.InnerHtml = "Price: R" + (string)adDetails[6];

                    //--------------NEGOTIABLE
                    if (Convert.ToBoolean(adDetails[7]))
                    {
                        lblGamePrice.InnerHtml += " Negotiable";
                    }

                    //--------------USERNAME + PREMIUM ICON
                    UserService.UserCRUDClient userService = new UserService.UserCRUDClient();
                    userService.Open();
                    string username = userService.getUsername(Convert.ToInt32((string)adDetails[13]));
                    Boolean premiumUser = Convert.ToBoolean(userService.isUserPrem(Convert.ToInt32((string)adDetails[13])));
                    userService.Close();

                    editButtonSpan.InnerHtml = "Posted By: " + username;
                    if (premiumUser)
                    {
                        editButtonSpan.InnerHtml += " <i class='material-icons tooltipped' data-position='right' data-tooltip='Premium Member'>star</i>";
                    }

                    //--------------ADMIN MOD BUTTONS
                    //editButtonSpan.InnerHtml = "";
                    if (Session["User"] != null)
                    {
                        if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                        {
                            btnReportAd.Visible = false;
                            if (Convert.ToBoolean((string)adDetails[14]))
                            {
                                btnUnflagAdAdminMod.Visible = true;
                            }
                            else
                            {
                                btnFlagAdAdminMod.Visible = true;
                            }
                            editButtonSpan.InnerHtml += " <a class='btn right waves-effect waves-light orange lighten-2' href='EditAdPage.aspx?ad=" + Request.QueryString.Get("ad") + "'>Edit</a> ";
                        }
                    }

                    //--------------IMAGES
                    if (!((string)adDetails[9]).Equals("NOPIC"))
                    {
                        imgPic1.Src = "data:image/jpeg;base64," + (string)adDetails[9]; 
                    }
                    else
                    {
                        imgPic1.Visible = false;
                    }
                    if (!((string)adDetails[10]).Equals("NOPIC"))
                    {
                        imgPic2.Src = "data:image/jpeg;base64," + (string)adDetails[10];
                    }
                    else
                    {
                        imgPic2.Visible = false;
                    }
                    if (!((string)adDetails[11]).Equals("NOPIC"))
                    {
                        imgPic3.Src = "data:image/jpeg;base64," + (string)adDetails[11];
                    }
                    else
                    {
                        imgPic3.Visible = false;
                    }

                    //--------------PLATFORM
                    lblGamePlatform.InnerHtml = "Platform: " + (string)adDetails[2];

                    //--------------DESCRIPTION
                    txtGameDescription.Value = (string)adDetails[4];

                    //--------------LOCATION
                    txtGameLocation.Value = (string)adDetails[5];
                    String mapString = (string)adDetails[5];
                    mapString = mapString.Replace(" ", "+");
                    adMap.Src = "https://www.google.com/maps/embed/v1/place?key=AIzaSyB7eq5IZFtbXZitO0yI53upIROFqC5RBcY&q=" + mapString;

                    //--------------YOUTUBE SOURCE
                    adYoutubeFrame.Src = "https://www.youtube.com/embed?listType=search&list="+ (string)adDetails[1]+" ign review?theme=light&color=white";

                    //--------------CELL NUMBER
                    if (Convert.ToBoolean(adDetails[8]))
                    {
                        txtCellNumber.Value = (string)adDetails[16];
                    }
                    else
                    {
                        sellerCellNumberDiv.InnerHtml = "";
                    }
                }

                
            }
            else
                Response.Redirect("Index.aspx");
        }

        protected void unflagAd_ServerClick(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                {
                    AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
                    adService.Open();
                    int unflagAdResult = adService.unflagAd(Convert.ToInt32((string)this.adDetails[0]));
                    adService.Close();

                    if (unflagAdResult == 1)
                    {
                        detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                        detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Unflagged Successfully</span>";
                        detailedAdActionResutView.InnerHtml += "<p>You have successfully unflagged this ad.</p><br/>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Ads</a>";
                        detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
                    }
                    else
                    {
                        detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                        detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Unflagged Unsuccessfully</span>";
                        detailedAdActionResutView.InnerHtml += "<p>An error occured trying to unflag this ad. You can go back and try again.</p><br/>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                        detailedAdActionResutView.InnerHtml += "<a href='DetailedAd.aspx?" + (string)adDetails[0] + "' runat='server' class='btn waves-effect waves-light'>Go Back</a>";
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Ads</a>";
                        detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void flagAd_ServerClick(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                {
                    AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
                    adService.Open();
                    int flagAdResult = adService.flagAd(Convert.ToInt32((string)this.adDetails[0]));
                    adService.Close();

                    if (flagAdResult == 1)
                    {
                        detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                        detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Flagged Successfully</span>";
                        detailedAdActionResutView.InnerHtml += "<p>You have successfully flagged this ad. Our proficient team of Moderators and Administrators will review the ad and decide its fate.<br/><br/>We personally thank you for making twoGames even better!</p><br/>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                        detailedAdActionResutView.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Ads</a>";
                        detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
                    }
                    else
                    {
                        detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card'>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                        detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Flagged Unsuccessfully</span>";
                        detailedAdActionResutView.InnerHtml += "<p>An error occured trying to flag this ad. You can go back and try again.</p><br/>";
                        detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                        detailedAdActionResutView.InnerHtml += "<a href='DetailedAd.aspx?" + (string)adDetails[0] + "' runat='server' class='btn waves-effect waves-light'>Go Back</a>";
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Ads</a>";
                        detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnReportUser_ServerClick(object sender, EventArgs e)
        {
            UserService.UserCRUDClient userService = new UserService.UserCRUDClient();
            userService.Open();
            int reportUserResult = userService.reportUser(Convert.ToInt32((string)this.adDetails[13]));
            userService.Close();

            if (reportUserResult == 1)
            {
                detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                detailedAdActionResutView.InnerHtml += "<div class='card'>";
                detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>User Reported Successfully</span>";
                detailedAdActionResutView.InnerHtml += "<p>You have successfully reported this user. Our proficient team of Moderators and Administrators will review the user's account and ads, and will then decide their fate.<br/><br/>We personally thank you for making twoGames even better!</p><br/>";
                detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                detailedAdActionResutView.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1)
                    {
                        detailedAdActionResutView.InnerHtml += " <a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a>";
                    }
                }
                detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
            }
            else
            {
                detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                detailedAdActionResutView.InnerHtml += "<div class='card'>";
                detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>User Reported Unsuccessfully</span>";
                detailedAdActionResutView.InnerHtml += "<p>An error occured trying to report this user. You can go back and try again.</p><br/>";
                detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                detailedAdActionResutView.InnerHtml += "<a href='DetailedAd.aspx?" + (string)adDetails[0] + "' runat='server' class='btn waves-effect waves-light'>Go Back</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1)
                    {
                        detailedAdActionResutView.InnerHtml += " <a href='UserManagement.aspx' runat='server' class='btn waves-effect waves-light orange lighten-2'>Manage Users</a>";
                    }
                }
                detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
            }
        }

        protected void btnReportAd_ServerClick(object sender, EventArgs e)
        {
            AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
            adService.Open();
            int flagResult = adService.reportAd(Convert.ToInt32((string)this.adDetails[0]));
            adService.Close();

            if (flagResult == 1)
            {
                detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                detailedAdActionResutView.InnerHtml += "<div class='card'>";
                detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Reported Successfully</span>";
                detailedAdActionResutView.InnerHtml += "<p>You have successfully reported this ad. Our proficient team of Moderators and Administrators will review the ad and decide its fate.<br/><br/>We personally thank you for making twoGames even better!</p><br/>";
                detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                detailedAdActionResutView.InnerHtml += "<a href='Index.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                    {
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light'>Manage Ads</a>";
                    }
                }
                detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
            }
            else
            {
                detailedAdActionResutView.InnerHtml = "<div class='col s12 m6 l4 push-l4 push-m3'>";
                detailedAdActionResutView.InnerHtml += "<div class='card'>";
                detailedAdActionResutView.InnerHtml += "<div class='card-content black-text'>";
                detailedAdActionResutView.InnerHtml += "<span class='card-title bold'>Ad Reported Unsuccessfully</span>";
                detailedAdActionResutView.InnerHtml += "<p>An error occured trying to report this ad. You can go back and try again.</p><br/>";
                detailedAdActionResutView.InnerHtml += "<div class='card-action'>";
                detailedAdActionResutView.InnerHtml += "<a href='DetailedAd.aspx?" + (string)adDetails[0] + "' runat='server' class='btn waves-effect waves-light'>Go Back</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                    {
                        detailedAdActionResutView.InnerHtml += " <a href='AdManagement.aspx' runat='server' class='btn waves-effect waves-light'>Manage Ads</a>";
                    }
                }
                detailedAdActionResutView.InnerHtml += "</div></div></div></div>";
            }
        }





        protected void btnReplyAd_ServerClick(object sender, EventArgs e)
        {

            AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
            adService.Open();
            String[] userdetails = adService.getUserEmail(adnum);
            adService.Close();

            if (txtName.Value == "" || txtemail.Value == "" || txtMessage.Value == "")
            {
                replysentdiv.InnerHtml = "<p class='red-text'>Please fill in all the appropriate fields</p>";
            }
            else
            {

                NetworkCredential netCred = new NetworkCredential("twogamesza@gmail.com", "IFMTYP2016");
                SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
                smtpobj.EnableSsl = true;
                smtpobj.Credentials = netCred;
                //smtpobj.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("twogamesza@gmail.com", "twoGames");
                mailMessage.To.Add(new MailAddress(userdetails[0]));
                mailMessage.Subject = "You have a reply to your ad \"" + (string)adDetails[1] + "\"";
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = "<h1>Hi " + userdetails[1] + ",</h1><br/>";
                mailMessage.Body += "<b>" + txtName.Value + "</b> has replied to your advert <b>\"" + (string)adDetails[1] + "\"</b>";
                mailMessage.Body += "<br/><br/>";
                mailMessage.Body += "Their message: <br/>";
                mailMessage.Body += "\"<i>" + txtMessage.Value + "</i>\"";
                mailMessage.Body += "<br/><br/><a href='mailto:" + txtemail.Value + "?subject=[twoGames] \""+ (string)adDetails[1] + "\" Advert'><button>Click here to reply</button></a>";
                mailMessage.Body += "<br/><br/>Kind Regards<br/>twoGames";





                try
                {
                    smtpobj.Send(mailMessage);
                    btnReplyAd.Visible = false;
                    replysentdiv.InnerHtml = "<p>Your message has been sent successfully.</p>";
                }
                catch (SmtpException ex)
                {
                    replysentdiv.InnerHtml = "<p class='red-text'>Failed to send your message. Please try again.</p>";
                }
            }




        }
    }
}