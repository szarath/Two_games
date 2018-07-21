<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IFMTYP_team02.WebForm2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div id="regCard" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Register a New Account</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                        
                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <i class="material-icons prefix">account_circle</i>
                                      <input id="txtFirstName" runat="server" type="text" class="validate black-text"/>
                                      <label for="txtFirstName">First Name</label>
                                    </div>
                                    <div class="input-field col s12 m6 l6">
                                        <input id="txtLastName" runat="server" type="text" class="validate black-text"/>
                                      <label for="txtLastName">Last Name</label>
                                    </div>
                          </div>

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <i class="material-icons prefix">email</i>
                                      <input id="txtEmail" runat="server" type="email" class="validate black-text"/>
                                      <label for="txtEmail">Email</label>
                                    </div>
                                      <div class="input-field col s12 m6 l6">
                                      <input id="txtConfirmEmail" runat="server" type="email" class="validate black-text"/>
                                      <label for="txtConfirmEmail">Confirm Email</label>
                                    </div>
                          </div>

                            <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <i class="material-icons prefix">today</i>
                                        <input type="date" id="txtDoB" runat="server" class="datepicker black-text"/>
                                        <label for="txtDoB">Date Of Birth</label>
                                    </div>
                                    <div class="input-field col s12 m6 l6">
                                        <i class="material-icons prefix">call</i>
                                        <input id="txtCellNumber" runat="server" type="tel" class="validate black-text"/>
                                        <label for="txtCellNumber">Cellphone Number</label>
                                    </div>
                            </div>
                            
                            <div class="divider"></div>

                            <br />

                            <div class="row">
                                        <div class="input-field col s12 m6 l6">
                                            <i class="material-icons prefix">account_circle</i>
                                          <input id="txtUsername" runat="server" type="text" class="validate black-text"/>
                                          <label for="txtUsername">Username</label>
                                        </div>
                             </div>

                            <div class="row">
                                        <div class="input-field col s12 m6 l6">
                                            <i class="material-icons prefix">vpn_key</i>
                                          <input id="txtPassword" runat="server" type="password" class="validate black-text"/>
                                          <label for="txtPassword">Password</label>
                                        </div>
                                        <div class="input-field col s12 m6 l6">
                                          <input id="txtConfirmPassword" runat="server" type="password" class="validate black-text"/>
                                          <label for="txtConfirmPassword">Confirm Password</label>
                                        </div>
                            </div>


                            <!--Card Actions-->
                            <div class="row"></div>
                            <div class="row">
                                <a href="#" runat="server" class="btn waves-effect waves-light" onserverclick="RegisterUser_ServerClick">Create</a>
                                <a href="Login.aspx" runat="server"  class="waves-effect waves-light btn red">Cancel</a>
                            </div>

                        </div>
          </div>
        </div>
    </div>


</asp:Content>
