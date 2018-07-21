<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UpdateEmail.aspx.cs" Inherits="IFMTYP_team02.UpdateEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m6 l4 push-l4 push-m3">
            <div class="card white">
                <div id="updateEmailCard" class="card-content black-text" runat="server">
                    <!--Card Information-->
                    <span id="lblUpdatePass" class="card-title" runat="server">Ok Let's Update Your Email Address</span>

                    <div id="invalidEmailUpdate" class="row red-text text-lighten-2" runat="server">

                    </div>
              
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtOldEmail" type="email" class="validate black-text" runat="server" autofocus/> 
                            <label for="txtOldEmail">Your Current/Old Email Address</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtNewEmail" type="email" class="validate black-text" runat="server"/> 
                            <label for="txtNewEmail">Your New Email Address</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtNewEmailConfirm" type="email" class="validate black-text" runat="server"/> 
                            <label for="txtNewEmailConfirm">Confirm New Email Address</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtUserPass" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtUserPass">Your Password</label>
                        </div>
                    </div>

                    <div class="row">
                        <button id="btnUpdateEmail" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnUpdateEmail_ServerClick">Update</button>
                        <a href="MyProfile.aspx" runat="server"  class="waves-effect waves-light btn red">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
