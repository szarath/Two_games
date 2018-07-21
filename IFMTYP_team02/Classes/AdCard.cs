using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IFMTYP_team02.Classes
{
    public abstract class AdCard
    {

        
        public static string createAdCard(string gameID, string picturePath, string gameTitle, string gamePlatform, string gameLocation, string gamePrice, Boolean premiumAd, string cardAnchorLinkPage, Boolean showViews)
        {



            string card = "";

            card += "<a href=\""+cardAnchorLinkPage+"?ad=" + gameID + "\">";
            card += "<div class=\"col s12 m5 l4 push-m1 push-l2\">";
            card += "<div class=\"card horizontal hoverable\">";
            card += "<div class=\"card-image\">";
            if (!picturePath.Equals("NOPIC"))
            {
                card += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + picturePath + "'/>";
            }
            card += "</div>";
            card += "<div class=\"card-stacked\">";
            card += "<div class=\"card-content black-text\">";
            card += "<span class='card-title'><p class='trunctext'>" + gameTitle + "</p>";
           
            card += "</span>";
            card += "<p>Platform: " + gamePlatform + "</p>";
            card += "<p class='trunctext'>Location: " + gameLocation + "</p>";
            card += "<p>Price: <b>R" + gamePrice + "</b></p>";

            if (showViews || premiumAd)
            { card += "<br/>"; }

            if (showViews)
            {
                AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
                adCRUDService.Open();
                int views = adCRUDService.getViewCount(Convert.ToInt32(gameID));
                adCRUDService.Close();
                card += " <p class='left' ><b>Views: "+ views +"</b></p>";
            }

            if (premiumAd)
            {
                card += " <i class='material-icons right tooltipped' data-position='left' data-tooltip='Premium Ad'>star</i>";
            }
            card += "</div>";
            card += "</div>";
            card += "</div>";
            card += "</div>";
            card += "</a>";

            return card;
        }
    }
}