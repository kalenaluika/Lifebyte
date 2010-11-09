<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><%: Html.ActionLink("Home", "Index", "Home") %></li>
            <li><%: Html.ActionLink("Donate", "Index", "Donate")%></li>
            <li><%: Html.ActionLink("Request", "Index", "Request")%></li>
            <li><%: Html.ActionLink("Volunteer", "Index", "Volunteer")%></li>
            <li class="current_page_item"><%: Html.ActionLink("Inventory", "Index", "Inventory")%></li>
            <li><%: Html.ActionLink("Recipients", "Index", "Recipients")%></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte - Computer Inventory</h1>
    <table>
        <tr>
            <td>
                Edit
            </td>
            <td>
                <a href="#">Last Modified</a>
            </td>
            <td>
                <a href="#">LB Number</a>
            </td>
            <td>
                <a href="#">Belarc</a>
            </td>
            <td>
                <a href="#">Notes</a>
            </td>
            <td>
                <a href="#">Status</a>
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/20/2009 7:38:12 AM
            </td>
            <td>
                LB0201
            </td>
            <td>
                <a href="/Inventory/Belarc/6F9619FF-8B86-D011-B42D-00C04FC964FF">Belarc</a>
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                1/13/2008 2:09:55 PM
            </td>
            <td>
                LB0198
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                1/20/2008 12:45:09 PM
            </td>
            <td>
                LB0199
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                10/29/2008 8:17:17 AM
            </td>
            <td>
                LB0206
            </td>
            <td>
                <a href="/Inventory/Belarc/6F9619FF-8B86-D011-B42D-00C04FC964FF">Belarc</a>
            </td>
            <td>
                Computer N...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/25/2008 5:41:22 PM
            </td>
            <td>
                LB0073
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                1/20/2008 2:30:00 PM
            </td>
            <td>
                LB0155
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/7/2008 12:42:39 AM
            </td>
            <td>
                LB0120
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/7/2008 1:16:54 AM
            </td>
            <td>
                LB0084
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                1/20/2008 2:25:47 PM
            </td>
            <td>
                LB0153
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td>
                <a href="/Inventory/Edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">Edit</a>
            </td>
            <td>
                2/25/2008 3:53:35 PM
            </td>
            <td>
                LB0182
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                Entered by...
            </td>
            <td>
                Delivered
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <span>1</span>&nbsp;<a href="#">2</a>&nbsp;<a href="#">3</a>&nbsp;<a href="#">4</a>&nbsp;<a
                    href="#">5</a>&nbsp;<a href="#">6</a>&nbsp;<a href="#">...</a>
            </td>
        </tr>
    </table>
</asp:Content>
