<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IFMTYP_team02.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    
    <div class="row">
        
        <div class="col s12 m6 l4 push-l4 push-m3">
          <div class="card white">
            <div class="card-content black-text">
                 <!--Card Information-->
              <span class="card-title">Sign In</span>

                <div id="invalidLogin" class="row red-text text-lighten-2" runat="server">

                </div>
              
                 <div class="row">
                    <div class="input-field col s12">
                        <input id="user_name" type="text" class="validate black-text" runat="server" autofocus/> 
                        <label for="user_name">Username/Email</label>
                    </div>
               </div>
                <div class="row">
                    <div class="input-field col s12">
                        <input id="password" type="password" class="validate black-text" runat="server"/>
                        <label for="password">Password</label>
                    </div>
                </div>

                <!--Card Actions-->
              
                <div class="row">
                    <button id="btnLogin" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="LoginUser_ServerClick">Login</button>
                    <a id="btnRegister" href="Registration.aspx" class="waves-effect waves-light btn orange lighten-2">Register</a>
                    <div  id="loginSpinner" class="preloader-wrapper small active" runat="server" visible="false">
                        <div class="spinner-layer spinner-blue-only">
                            <div class="circle-clipper left">
                                <div class="circle"></div>
                            </div>
                            <div class="gap-patch">
                                <div class="circle"></div>
                            </div>
                            <div class="circle-clipper right">
                                <div class="circle"></div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
            
          </div>
        </div>
           
      </div>
    

</asp:Content>
