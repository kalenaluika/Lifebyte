<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Lifebyte Edit LB0001
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li><a href="/donate">Donate</a></li>
            <li><a href="/request">Request</a></li>
            <li><a href="/volunteer">Volunteer</a></li>
            <li class="current_page_item"><a href="/inventory">Inventory</a></li>
            <li><a href="/recipients">Recipients</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte Edit LB0001</h1>
    <div>
        <label for="InventoryStatusDropDownList">
            Status:</label>
        <select name="InventoryStatusDropDownList" id="InventoryStatusDropDownList">
            <option value="1">Build</option>
            <option selected="selected" value="2">Delivered</option>
            <option value="3">Ready for Delivery</option>
            <option value="4">Repair</option>
        </select>
    </div>
    <div>
        <label for="RecipientDropDownList">
            Recipient:</label>
        <select name="RecipientDropDownList" id="RecipientDropDownList">
            <option value=""></option>
            <option value="6F9619FF-8B86-D011-B42D-00C04FC964FF">Dan Stewart</option>
            <option selected="selected" value="6F9619FF-8B86-D011-B42D-00C04FC964FF">StewShack</option>
        </select>
    </div>
    <div>
        <label>
            LB Number:</label>
        <span id="LBNumberLabel">LB0001</span>
    </div>
    <div>
        <label>
            License Type:</label>
        <span id="LicenseTypeLabel"></span>
    </div>
    <div>
        <label>
            Lifebyte MAR License:</label>
        <span id="LicenseLabel"></span>
    </div>
    <div>
        <label for="NotesTextBox">
            Notes:</label>
        <textarea name="NotesTextBox" rows="5" cols="20" id="NotesTextBox">
            </textarea>
    </div>
    <div>
        <label for="BelarcLiteral">
            Belarc File:</label>
        <a href="/Inventory/Belarc/6F9619FF-8B86-D011-B42D-00C04FC964FF">Belarc</a>
    </div>
    <div>
        <label for="BelarcFileUpload">
            Belarc Upload:</label>
        <input type="file" name="BelarcFileUpload" id="BelarcFileUpload" />
    </div>
    <div>
        <label>
            Create Date:</label>
        <span id="CreateDateLabel">11/3/2010 10:07:15 AM</span>
    </div>
    <div>
        <label>
            Create By:</label>
        <span id="CreateByLabel">Dan Stewart</span>
    </div>
    <div>
        <label>
            Last Modified Date:</label>
        <span id="LastModifiedLabel">11/3/2010 7:38:12 AM</span>
    </div>
    <div>
        <label>
            Last Modified By:</label>
        <span id="LastModByLabel">Dan Stewart</span>
    </div>
    <div>
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
