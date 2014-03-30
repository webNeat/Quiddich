<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="matches.aspx.cs" Inherits="SiteWebQuidditch.matches" %>
<asp:Content ID="bodyContent" ContentPlaceHolderID="content" runat="server">
    <h1>Les matches</h1>
    <div id="matches">

    </div>
</asp:Content>
<asp:Content ID="matchesScrpits" ContentPlaceHolderID="scripts" runat="server">
    <script>
        var data = <%=matchesObject%>;
    </script>
    <script type="text/javascript" src="Javascripts/matches.js"></script>
</asp:Content>
