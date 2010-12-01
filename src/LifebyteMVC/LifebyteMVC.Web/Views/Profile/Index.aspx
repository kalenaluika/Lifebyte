<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProfileViewModel>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Lifebyte Profile Edit
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><%: Html.ActionLink("Home", "Index", "Home") %></li>
            <li><%: Html.ActionLink("Donate", "Index", "Donate")%></li>
            <li><%: Html.ActionLink("Request", "Index", "Request")%></li>
            <li><%: Html.ActionLink("Volunteer", "Index", "Volunteer")%></li>
            <li><%: Html.ActionLink("Inventory", "Index", "Inventory")%></li>
            <li><%: Html.ActionLink("Recipients", "Index", "Recipients")%></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Edit Your Profile</h1>
      <%: Html.EditorForModel() %>
    <div>
        <label>
            &nbsp;</label>
        <input type="submit" name="SaveButton" value="Save" id="SaveButton" />
    </div>
    <p>
    </p>
    <p>
    </p>
    <div>
        <input type="submit" name="DeleteButton" value="Delete" id="DeleteButton" />
    </div>
</asp:Content>