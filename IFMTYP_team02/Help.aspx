<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="IFMTYP_team02.Help" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m8 l6 push-l3 push-m2">
            <div class="row">
                <h4 id="helpTitle">Having Trouble? That's Not Good</h4>
                <p>Take a look at the below FAQs for some help</p>
                <p>In case you don't find the help you're looking for, click <a class="teal-text" href="ContactUs.aspx">here</a></p>
            </div>
            <div class="row">
                <ul class="collapsible popout" data-collapsible="accordion">
                    <li>
                        <div class="collapsible-header"><i class="material-icons">add</i>How do I post an Ad?</div>
                        <div class="collapsible-body">
                            <p>You'll need a pesky but important account so if you don't have one, click <a class="teal-text" href="Registration.aspx">here</a> to register a new account.<br /><br />Once you are registered, you can procede to click on the large plus button in the top right corner of the website. This will take you to where you may post an ad.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">question_answer</i>How do I contact twoGames?</div>
                        <div class="collapsible-body">
                            <p>Click <a class="teal-text" href="ContactUs.aspx">here</a> to tell us how awesome we are...or if you have a super secret question to ask, you can do that too.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">info_outline</i>How many photos are required for an Ad</div>
                        <div class="collapsible-body">
                            <p>Ok before we carry on, remember an account is needed to post an Ad.<br />
                            So if you don't have one, then click <a class="teal-text" href="Registration.aspx">here</a> to register.<br /><br />
                            Now that we got out of the way, let's get back to your issue.<br /><br />
                            In order to provide the best user experience for everyone, as well as make everyone feel as comfortable as possible, we require each Ad to have at least one image of acceptable quality.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">mode_edit</i>How do I edit my posted Ad?</div>
                        <div class="collapsible-body">
                            <p>Once our special agent opperatives have approved your Ad, it will magically show up in the "My Ads" section where you can select and then edit it.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">perm_identity</i>How do I edit My Profile?</div>
                        <div class="collapsible-body">
                            <p>Once you have stepped past security and the HUGE bouncers to log into your account, a new icon will construct itself from pixels before your very eyes.<br />
                            The new collection of pixels will then reside in the top right corner of the website.<br /><br />
                            You will then be able to click on this icon, exposing a never before seen dropdown menu of options.<br /><br />
                            Now you will see the "My Profile" option which when clicked, will guide you to the sacred residence where your account information and options can be found.<br /><br />
                            From there you will be able to edit all your <a href="MyProfile.aspx">account details</a>.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">search</i>How and when can I search for an Ad?</div>
                        <div class="collapsible-body">
                            <p>You are able to search for any Ad your heart desires, even before you <a class="teal-text" href="Registration.aspx">register a new account</a> or <a class="teal-text" href="Login.aspx">login.</a><br /><br />
                            You can do so by clicking on the magnify glass in the top right corner.</p>
                        </div>
                    </li>
                    <li>
                        <div class="collapsible-header"><i class="material-icons">star</i>How do I become a Premium Member?</div>
                        <div class="collapsible-body">
                            <p>First you will have to create an account if you dont already have one. You can do that <a href="Registration.aspx">here</a>. Once you have done that you will then be able to login and sign up to be a premium member<br /><br />When you are logged in there will be user icon in the top right. If clicked this will show a drop down menu and you can then click on the <a href="MyProfile.aspx">My Profile</a> link. On this page at the bottom you can select the become a premium member option and follow the steps.</p>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
