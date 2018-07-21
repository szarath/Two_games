<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PremUserReg.aspx.cs" Inherits="IFMTYP_team02.PremUserReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m6 l4 push-l4 push-m3">
            <div class="card white">
                <div id="activatePremCard" class="card-content black-text" runat="server">
                    <!--Card Information-->
                    <span id="lblPremUserReg" class="card-title" runat="server">Become a Premium User</span>

                    <div id="invalidPremActivation" class="row red-text text-lighten-2" runat="server">

                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtCardNum" type="text" class="validate black-text" runat="server" autofocus/> 
                            <label for="txtCardNum">Your Card Number</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtEmail" type="email" class="validate black-text" runat="server"/> 
                            <label for="txtEmail">Your Email Address</label>
                        </div>
                    </div>

                    <!--<div class="row">
                        <div class="input-field col s12">
                            <input type="date" id="txtDoB" runat="server" class="datepicker black-text"/>
                            <label for="txtDoB">Your Date Of Birth</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtCellNumber" runat="server" type="tel" class="validate black-text"/>
                            <label for="txtCellNumber">Your Cellphone Number</label>
                        </div>
                    </div>-->

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtUserPass" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtUserPass">Your Password</label>
                        </div>
                    </div>

                    <!--Card Actions-->
              
                    <div class="row">
                        <button id="btnActivatePrem" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnActivatePrem_ServerClick">Activate</button>
                        <a href="MyProfile.aspx" runat="server"  class="waves-effect waves-light btn red">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
