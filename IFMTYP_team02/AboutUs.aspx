<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="IFMTYP_team02.AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

    <br/>
    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 class="thin" >Our Team</h4>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m5 l2 push-m1 push-l2">
            <div class="card">
                <div class="card-image">
                    <img class="materialboxed responsive-img" data-caption="James McGuire" src="WebPictures\James.png" /> </div>
                <div class="card-content">
                    <p style="font-size:16px;">
                        <b>James <br />McGuire</b>
                        <br/>
                        <br />
                        &#8226 Leader
                        <br />
                        &#8226 Web Developer
                        <br />
                        <br />
                    </p>
                </div>
            </div>
        </div>

        <div class="col s12 m5 l2 push-m1 push-l2">
            <div class="card">
                <div class="card-image">
                    <img class="materialboxed responsive-img" data-caption="Devin Harmse" src="WebPictures\Devin.png" />
                </div>
                <div class="card-content">
                    <p style="font-size:16px;">
                        <b>Devin <br />Harmse</b>
                        <br />
                        <br />
                        &#8226 Co-Leader
                        <br />
                        &#8226 Web Developer
                        <br />
                        <br />
                    </p>
                </div>
            </div>
        </div>

        <div class="col s12 m5 l2 push-m1 push-l2">
            <div class="card">
                <div class="card-image">
                    <img class="materialboxed responsive-img" data-caption="Szarathkumar Jayakumar" src="WebPictures\Kumar.png" />
                </div>
                <div class="card-content">
                    <p style="font-size:16px;">
                        <b>Szarathkumar <br />Jayakumar</b>
                        <br />
                        <br />
                        &#8226 Mobile Developer
                        <br />
                        <br />
                        <br />
                    </p>
                </div>
            </div>
        </div>

        <div class="col s12 m5 l2 push-m1 push-l2">
            <div class="card">
                <div class="card-image">
                    <img class="materialboxed responsive-img" data-caption="Schalk Rust" src="WebPictures\Schalk.png" />
                </div>
                <div class="card-content">
                    <p style="font-size:16px;">
                        <b>Schalk <br />Rust</b>
                        <br />
                        <br />
                        &#8226 Documentation 
                        <br />
                        &#8226 Research Assistant
			<br />
			<br />
                    </p>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 class="thin">Our Project</h4>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m10 l8 push-l2 push-m1">
            <div class="card white">
                <div class="card-content black-text">
                    <span class="card-title">twoGAMES</span>
                <div class="section">    
		<p>
                        twoGAMES, developed by PRIME, is an online classifieds website that purely focuses on connecting two parties together that are interested in the buying and selling of second hand console games. twoGAMES will revolutionize the way current online classifieds websites operate by focusing on providing the best customer experience as well as tackling the current issues and flaws in current solutions.
                        <br />
                        <br />
                        Our system includes, apart from the standard features, additional revolutionary features which help provide the best customer experience, all in a sleek, adaptable, mobile friendly and clean package. This is done in many ways for example by having ads automatically deactivated after a period of time which eliminates outdated ads which users haven’t taken down.
			<br />
			<br />
			There is a user and ad reporting system allowing viewers to quickly report either an ad or user, which can then be efficiently and easily assessed by our Moderators and Administrators who will then take appropriate action. To further discourage and aid in the fight against inappropriate content our system utilizes Google’s Machine Learning Cloud API called Vision which analyzes each photo a user selects to upload. Our system then proceeds to block any images suspected to be inappropriate or spam.
			<br />
			<br />
			Not only can viewers sign up a free secure account, but they can also choose to sign up to a flexible Premium Member package where for a very reasonable and competitive cost, they will not only gain trusted “Premium Member” status visible to other viewers, but have their ads automatically prioritized in listings. Along with a visible “Premium Member” status on their detailed ad page, there will be an indicator for each one one of their ads visible to viewers indicating they are “Premium Ads.”
                        </p></div><br/>
                        <div class="divider"></div>
			<div class="section">
                        <h5>Standard Functionality</h5>
                        <p>
                        <i>
                            &#8226 Create a free account
                            <br />
                            &#8226 Manage your account
                            <br />
                            &#8226 Browse adverts
                            <br />
                            &#8226 Post new adverts
                            <br />
                            &#8226 Aquire relevant information on other users ads
                            <br />
                            &#8226 Intuitive & efficient Help & Support services
                        </i>
                        </p>
			<br/>
                        <h5>Additional Functionality</h5>
                        <p>
                        <i>
                            &#8226 Premium Membership packages
                            <br />
                            &#8226 Built-in Managerial & Administrative features
                            <br />
                            &#8226 User & Ad reporting
                            <br />
                            &#8226 Automatic “old advert” takedown
                            <br />
                            &#8226 Across the board enforcement of at least one photo per advert
                            <br />
                            &#8226 Google maps integration for posting an adverts location
                            <br />
                            &#8226 Interactive & dynamic Google Maps map per detailed advert
                            <br />
                            &#8226 Youtube integration for an embedded video playlist per detailed advert
                            <br />
                            &#8226 Google's Cloud Machine Learning Vision API integration for photo auditing
                        </i>
                    </p></div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
