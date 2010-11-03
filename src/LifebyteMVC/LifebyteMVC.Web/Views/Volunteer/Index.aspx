<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li><a href="/donate">Donate</a></li>            
            <li><a href="/request">Request</a></li>
            <li class="current_page_item"><a href="/volunteer">Volunteer</a></li>
            <li><a href="/inventory">Inventory</a></li>
            <li><a href="/recipients">Recipients</a></li>            
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to the Volunteer Page!</h2>

</asp:Content>
