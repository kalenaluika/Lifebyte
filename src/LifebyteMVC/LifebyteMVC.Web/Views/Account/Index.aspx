<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SignInViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lifebyte - Sign In
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm())
   { %>
    <%:Html.ValidationSummary()%>
	<p>Please sign in using Open ID.</p>

    <div>
        <img id="google" src="/content/images/google.gif" alt="Google" title="Sign in with Google" />
        <img id="yahoo" src="/Content/images/yahoo.gif" alt="Yahoo" title="Sign in with Yahoo!" />
        <img id="aol" src="/Content/images/aol.gif" alt="AOL" title="Sign in with AOL" />        
    </div>
	
    <p>If you do not see your Open ID provider in the list above, let us know. We can add them.</p>
    <p>In the meantime, you can enter your Open ID provider's URL in the textbox below.</p>
    <p>
    <label for="openIdUrl">* Open ID:</label>
    <%: Html.TextBox("OpenIdUrl", Model.OpenIdUrl) %>
    </p>
    <p>
	<input id="submitButton" type="submit" value="Sign In" />
    </p>
    <%: Html.Hidden("ReturnUrl", HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"])) %>
<% } %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        var openidTextbox = $("#OpenIdUrl");
        openidTextbox.focus();

        var submitButton = $("#submitButton");

        $("#google").click(function () {
            openidTextbox.val("https://www.google.com/accounts/o8/id");
            submitButton.click();
        });

        $("#yahoo").click(function () {
            openidTextbox.val("https://me.yahoo.com/");
            submitButton.click();
        });

        $("#aol").click(function () {
            openidTextbox.val("https://openid.aol.com/");
            submitButton.click();
        });
	</script>
</asp:Content>
