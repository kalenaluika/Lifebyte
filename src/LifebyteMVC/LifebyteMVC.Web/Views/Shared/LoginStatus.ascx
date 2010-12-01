<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% if (Request.IsAuthenticated)
   { %>
        Welcome <strong><%: Page.User.Identity.Name%></strong>!<br />
        <%: Html.ActionLink("Sign Out", "SignOut", "Account")%>|
        <%: Html.ActionLink("Edit Profile", "Index", "Profile")%>
<% }
   else
   { %>
        <%: Html.ActionLink("Sign In", "Index", "Account")%>
<% } %>