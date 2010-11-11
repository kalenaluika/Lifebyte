<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lifebyte - Logon
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%:Html.ValidationSummary() %>
	<p>Please log in. </p>

    <div id="login_buttons">
        <img class="openid_large_btn_google"  src="/content/images/google.gif" alt="Google" title="Log in with Google" id="google_login"/>
        <a href="http://me.yahoo.com/"><img class="openid_large_btn_yahoo" src="../../Content/images/yahoo.gif" alt="Yahoo" title="Log in with Yahoo!" id="yahoo_login"/></a>
        <a href="http://openid.aol.com/"><img class="openid_large_btn_aol" src="../../Content/images/aol.gif" alt="AOL" title="Log in with AOL" id="aol_login" /></a>        
    </div>
	
    <form action="Authenticate?ReturnUrl=<%=HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]) %>" method="post" >
    <label for="openid_identifier">OpenID: </label>
	<input id="openid_identifier" name="openid_identifier" size="40" />
	<input id="submitButton" type="submit" value="Login" />
	</form> 
    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        var openidTextbox = $("#openid_identifier");
        openidTextbox.focus();
        $("#google_login").click(function () {
            openidTextbox.val("https://www.google.com/accounts/o8/id");
            $("#submitButton").click();
        });
	</script>
</asp:Content>
