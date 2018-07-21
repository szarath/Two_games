<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="IFMTYP_team02.UserMangement" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 id="userManageTitle" class="thin" runat="server">User Management</h4>
        </div>
    </div>

    <div class="row">
        <div id="reportedDiv" class="col s12 m5 l2 push-m1 push-l2" runat="server">
            <a id="reported" runat="server" onserverclick="reported_ServerClick">
                <div class="card hoverable">
                    <div class="card-content black-text">
                        <span class="card-title">Reported Users</span>
                    </div>
                </div>
            </a>
        </div>

        <div id="flaggedDiv" class="col s12 m5 l2 push-m1 push-l2" runat="server">
            <a id="flagged" runat="server" onserverclick="flagged_ServerClick">
                <div class="card hoverable">
                    <div class="card-content black-text">
                        <span class="card-title">Flagged Users</span>
                    </div>
                </div>
            </a>
        </div>

        <div id="viewAllDiv" class="col s12 m5 l2 push-m1 push-l2"  runat="server">
            <a id="viewAll" runat="server" onserverclick="viewAll_ServerClick">
                <div class="card hoverable">
                    <div class="card-content black-text">
                        <span class="card-title">All Users</span>
                    </div>
                </div>
            </a>
        </div>
        
        <!--<div id="searchDiv" class="col s12 m5 l2 push-m1 push-l2"  runat="server">
            <a id="search" runat="server" href="Search.aspx">
                <div class="card hoverable">
                    <div class="card-content black-text">
                        <span class="card-title">Search Users</span>
                    </div>
                </div>
            </a>
        </div>-->

        <div id="statsDiv" class="col s12 m5 l2 push-m1 push-l2"  runat="server">
            <a id="stats" runat="server" onserverclick="stats_ServerClick">
                <div class="card hoverable">
                    <div class="card-content black-text">
                        <span class="card-title">User Stats</span>
                    </div>
                </div>
            </a>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
            <div class="card">
                <div id="UserManageView" class="card-content" runat="server">
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
