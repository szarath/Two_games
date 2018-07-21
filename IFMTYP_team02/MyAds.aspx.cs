using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class MyAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "twoGAMES: My Ads";
                AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
                adCRUDService.Open();
                Object[][] ads = adCRUDService.getUserAds(((UserData)Session["User"]).getID());
                adCRUDService.Close();

                if(ads == null)
                {
                    mainMyAdsView.InnerHtml = "<div class='col s12 m10 l8 push-m1 push-l2'>";
                    mainMyAdsView.InnerHtml += "<div class='card white'>";
                    mainMyAdsView.InnerHtml += "<div class='card-content Black-text'>";
                    mainMyAdsView.InnerHtml += "<span class='card-title bold'>You Don't Have Any Ads</span>";
                    mainMyAdsView.InnerHtml += "<div class='row'>";
                    mainMyAdsView.InnerHtml += "<p>It looks like you haven't posted any ads yet<br/><b/>Let's see if we can help with that...try clicking the \"Post My First Ad\" button bellow to post your first ad</p>";
                    mainMyAdsView.InnerHtml += "</div>";
                    mainMyAdsView.InnerHtml += "<div class='row'>";
                    mainMyAdsView.InnerHtml += "<a href=\"PostAd.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Post My First Ad</a> ";
                    mainMyAdsView.InnerHtml += "<a href=\"Index.aspx\" runat=\"server\" class=\"btn waves-effect waves-light red\">Cancel</a>";
                    mainMyAdsView.InnerHtml += "</div>";
                    mainMyAdsView.InnerHtml += "</div>";
                    mainMyAdsView.InnerHtml += "</div>";
                    mainMyAdsView.InnerHtml += "</div>";
                }
                else
                {
                    string userAdsView = "<div class='row'>";

                    for(int k = 0; k < ads.Length; k++)
                    {
                        if ((k % 2) != 0)
                        {
                            userAdsView += AdCard.createAdCard((string)ads[k][0], (string)ads[k][1], (string)ads[k][2], (string)ads[k][3], (string)ads[k][4], (string)ads[k][5], Convert.ToBoolean(ads[k][6]), "EditAdPage.aspx", true);
                            userAdsView += "</div>";
                            userAdsView += "<div class=\"row\">";
                        }
                        else
                        {
                            userAdsView += AdCard.createAdCard((string)ads[k][0], (string)ads[k][1], (string)ads[k][2], (string)ads[k][3], (string)ads[k][4], (string)ads[k][5], Convert.ToBoolean(ads[k][6]), "EditAdPage.aspx", true);
                        }
                    }

                    userAdsView += "</div>";

                    mainMyAdsView.InnerHtml = userAdsView;
                }
            }
        }
    }
}