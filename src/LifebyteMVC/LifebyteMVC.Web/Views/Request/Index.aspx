<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
<div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li><a href="/donate">Donate</a></li>            
            <li class="current_page_item"><a href="/request">Request</a></li>
            <li><a href="/volunteer">Volunteer</a></li>
            <li><a href="/inventory">Inventory</a></li>
            <li><a href="/recipients">Recipients</a></li>            
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Welcome to the Request Page!</h2>
    <p>
            If you live in the Denver area and are in need of a computer, please call us at 303-256-1224. A Lifebyte member will contact you as soon as possible. Please be patient, as sometimes request fulfillments can take over a month or two.
            </p>
            <p>The Microsoft <a href="http://www.techsoup.org/mar/marFAQ.aspx#eligible">TAP</a> requirements for receiving a computer are:</p>

            <ul>
            <li>Live in a community with limited access to technology.</li>
            <li>Are registered as disabled.</li>
            <li>Is a member of a low income family.</li>
            </ul>
            <p>
            Computers are prepared with a Windows operating system, a virus scan application and Sun's Open Office suite (word processor, spreadsheet and presentation). Computers are bundled with a monitor, keyboard and mouse and are internet ready.
            </p><p>

            As a service of God, The Lifebyte Computer Ministry Team will do our best to repair any equipment that breaks under normal use.
            </p><p>
            The form below is another way to request a computer. Please be aware that this site does not use SSL to encrypt the information you enter. The data will be sent over clear text to our servers. Do not enter any information that you feel is too private to be read by third parties.
            </p>
            	
            <div class="row">
		    <label for="FirstNameTextBox">* First Name:</label>
		    <input name="FirstNameTextBox" type="text" maxlength="50" id="FirstNameTextBox" />
		    <!-- <span id="FirstNameRequired" style="color:Red;display:none;"><br />First Name Required</span> -->
		    </div>

		    <div class="row">		    
		    <label for="LastNameTextBox">* Last Name:</label>
		    <input name="LastNameTextBox" type="text" maxlength="50" id="LastNameTextBox" />
		    <!-- <span id="LastNameRequired" style="color:Red;display:none;"><br />Last Name Required</span> -->
		    </div>

		    <div class="row">
		    <label for="PhoneTextBox">* Phone Number:</label>
		    <input name="PhoneTextBox" type="text" maxlength="50" id="PhoneTextBox" />
		    <!-- <span id="PhoneRequired" style="color:Red;display:none;"><br />Phone Required</span> -->
		    <!-- <span id="PhoneValid" style="color:Red;display:none;"><br />We are a Denver, Colorado ministry.<br />Your phone number must begin with area code 303 or 720.<br />Please format it like:<br />303-555-1212 or 720-555-1212</span> -->
		    </div>

		    <div class="row">
		    <label for="StoryTextBox">My story (optional):</label>
		    <textarea name="StoryTextBox" rows="10" cols="20" id="StoryTextBox"></textarea>
		    </div>
            		    
		    <div class="row">
		    <label>&nbsp;</label>
		    <input type="submit" name="SubmitButton" value="Submit" id="SubmitButton" />
		    </div>
		    <p>
            <%: Html.ActionLink("Privacy Policy", "Index", "Privacy", null, null) %>
            </p>            
            



</asp:Content>
