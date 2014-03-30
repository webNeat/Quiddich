<%@ Page Title="Acceuil" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SiteWebQuidditch.index" %>
<asp:Content ID="bodyContent" ContentPlaceHolderID="content" runat="server">
    <h1> La liste des coupes </h1>
    <ul>
        <%= coupes %>
    </ul>
</asp:Content>
