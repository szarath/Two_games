<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="IFMTYP_team02.DeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        
        <div class="col s12 m6 l4 push-l4 push-m3">
          <div class="card white">
            <div class="card-content black-text" id="deleteUserView" runat="server">
                 <!--Card Information-->
              <span class="card-title" id="verifyHeading" runat="server">Verify Deletion of User</span>

                <div id="invalidVerify" class="row red-text text-lighten-2" runat="server">

                </div>
              
                <div class="row">
                    <div class="input-field col s12">
                        <input id="txtPassword" type="password" class="validate black-text" runat="server"/>
                        <label for="txtPassword">Password</label>
                    </div>
                </div>

                <!--Card Actions-->
              
                <div class="row">
                    <button id="btnVerify" type="submit" class="btn waves-effect waves-light red" runat="server" onserverclick="btnVerifyDelete_ServerClick">Verify & Delete</button> 
                    <a id="btnRegister" href="UserManagement.aspx" class="waves-effect waves-light btn orange lighten-2">Cancel</a>
                </div>


            </div>
            
          </div>
        </div>
           
      </div>
</asp:Content>
