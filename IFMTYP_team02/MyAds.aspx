<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MyAds.aspx.cs" Inherits="IFMTYP_team02.MyAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 class="thin">My Ads</h4>
        </div>
    </div>

    <div id="mainMyAdsView" runat="server" class="row">

        <!--card template-->
        <div class="row">
                <a href="DetailedAd.aspx">
                    <div class="col s6 m5 l4 push-m1 push-l2">
                        <div class="card horizontal">
                            <div class="card-image">
                                <img class="responsive-img" src="#"/>
                            </div>
                            <div class="card-stacked">
                                <div class="card-content">
                                    <p>Description of Ad</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </a>
         </div>
    </div>


</asp:Content>
