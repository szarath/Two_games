<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IFMTYP_team02.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 id="indexTitle" class="thin" runat="server">Welcome, here are the latest ads</h4>
        </div>
    </div>

    <div id="recentlyAddedView" runat="server" class="row">

    </div>
</asp:Content>
