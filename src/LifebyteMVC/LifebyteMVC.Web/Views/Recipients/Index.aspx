<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Lifebyte Recipients
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><%: Html.ActionLink("Home", "Index", "Home") %></li>
            <li><%: Html.ActionLink("Donate", "Index", "Donate")%></li>
            <li><%: Html.ActionLink("Request", "Index", "Request")%></li>
            <li><%: Html.ActionLink("Volunteer", "Index", "Volunteer")%></li>
            <li><%: Html.ActionLink("Inventory", "Index", "Inventory")%></li>
            <li class="current_page_item"><%: Html.ActionLink("Recipients", "Index", "Recipients")%></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte Recipients</h1>
        <div id="search">
            <form id="searchform" method="get" action="">
            <fieldset>
                <input type="text" name="s" id="s" size="15" value="" />
                <input type="submit" id="x" value="Search" />
            </fieldset>
            </form>
        </div>
    <table cellspacing="5" cellpadding="5" rules="all" border="0" id="RecipientDataGrid"
        style="border-width: 0px; width: 100%;">
        <tr class="HeaderRow" align="center">
            <td>
                <a href="#">Edit</a>
            </td>
            <td>
                <a href="#">Call Date</a>
            </td>
            <td>
                <a href="#">First Name</a>
            </td>
            <td>
                <a href="#">Last Name</a>
            </td>
            <td>
                <a href="#">Status</a>
            </td>
            <td>
                <a href="#">Scheduled</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                6/3/2006 12:00:00 AM
            </td>
            <td>
                Lorem
            </td>
            <td>
                ipsum
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                12/11/2004 4:22:10 PM
            </td>
            <td>
                dolor
            </td>
            <td>
                sit
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/26/2005 12:00:00 AM
            </td>
            <td>
                amet
            </td>
            <td>
                consectetur
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                7/7/2007 12:16:37 PM
            </td>
            <td>
                adipiscing
            </td>
            <td>
                elit
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                7/14/2007 12:17:34 PM
            </td>
            <td>
                Etiam
            </td>
            <td>
                tempor
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/23/2009 3:08:59 PM
            </td>
            <td>
                tristique
            </td>
            <td>
                turpis
            </td>
            <td>
                Completed
            </td>
            <td>
                5/8/2010 10:45:00 AM
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                9/22/2007 12:00:00 AM
            </td>
            <td>
                imperdiet
            </td>
            <td>
                volutpat
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                8/3/2008 12:18:33 AM
            </td>
            <td>
                quis
            </td>
            <td>
                Suspendisse
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/26/2008 6:40:00 PM
            </td>
            <td>
                nisl
            </td>
            <td>
                mattis
            </td>
            <td>
                Completed
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <a href="/recipients/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                12/2/2009 11:26:23 PM
            </td>
            <td>
                pharetra
            </td>
            <td>
                tempor
            </td>
            <td>
                Completed
            </td>
            <td>
                5/8/2010 9:45:00 AM
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <span>1</span>&nbsp;<a href="#">2</a>&nbsp;<a href="#">3</a>&nbsp;<a href="#">4</a>&nbsp;<a
                    href="#">...</a>
            </td>
        </tr>
    </table>
</asp:Content>
