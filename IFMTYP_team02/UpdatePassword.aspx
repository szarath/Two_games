<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="IFMTYP_team02.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m6 l4 push-l4 push-m3">
            <div class="card white">
                <div id="updatePassCard" class="card-content black-text" runat="server">
                    <!--Card Information-->
                    <span id="lblUpdatePass" class="card-title" runat="server">Ok Let's Update Your Password</span>

                    <div id="invalidPassUpdate" class="row red-text text-lighten-2" runat="server">

                    </div>
              
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtEmailAddress" type="email" class="validate black-text" runat="server" autofocus/> 
                            <label for="txtEmailAddress">Your Email Address</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtOldPass" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtOldPass">Your Current/Old Password</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtNewPass" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtNewPass">Your New Password</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtNewPassConfirm" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtNewPassConfirm">Confirm New Password</label>
                        </div>
                    </div>

                    <div class="row">
                        <button id="btnUpdatePass" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnUpdatePass_ServerClick">Update</button>
                        <a href="MyProfile.aspx" runat="server"  class="waves-effect waves-light btn red">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
