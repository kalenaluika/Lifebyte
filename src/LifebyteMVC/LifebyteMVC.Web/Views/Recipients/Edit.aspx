<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Lifebyte Edit Recipient Dan Stewart
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li><a href="/donate">Donate</a></li>
            <li><a href="/request">Request</a></li>
            <li><a href="/volunteer">Volunteer</a></li>
            <li><a href="/inventory">Inventory</a></li>
            <li class="current_page_item"><a href="/recipients">Recipients</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte Edit Recipient Dan Stewart</h1>
    <div>
        <label>
            Status:</label>
        <select name="RecipientStatusDropDownList" id="RecipientStatusDropDownList">
            <option selected="selected" value="4">Completed</option>
            <option value="2">Needs Computer</option>
            <option value="3">Needs Repair</option>
            <option value="1">New</option>
            <option value="5">Scheduled</option>
        </select>
    </div>
    <div>
        <label>
            * First Name:</label>
        <input name="FirstNameTextBox" type="text" value="Dan" maxlength="50" id="FirstNameTextBox" />
    </div>
    <div>
        <label>
            * Last Name:</label>
        <input name="LastNameTextBox" type="text" value="Stewart" maxlength="50" id="LastNameTextBox" />
    </div>
    <div>
        <label>
            Company:</label>
        <input name="CompanyTextBox" type="text" maxlength="100" id="CompanyTextBox" />
    </div>
    <div>
        <label>
            Address:</label>
        <input name="AddressTextBox" type="text" value="123 Some Street" maxlength="200"
            id="AddressTextBox" />
    </div>
    <div>
        <label>
            City:</label>
        <input name="CityTextBox" type="text" value="Denver" maxlength="50" id="CityTextBox" />
    </div>
    <div>
        <label>
            State:</label>
        <select name="StateDropDownList" id="StateDropDownList">
            <option value="AK">Alaska</option>
            <option value="AL">Alabama</option>
            <option value="AR">Arkansas</option>
            <option value="AZ">Arizona</option>
            <option value="CA">California</option>
            <option value="CD">Cambodia</option>
            <option selected="selected" value="CO">Colorado</option>
            <option value="CT">Connecticut</option>
            <option value="DC">District of Columbia</option>
            <option value="DE">Delaware</option>
            <option value="FL">Florida</option>
            <option value="GA">Georgia</option>
            <option value="HI">Hawaii</option>
            <option value="IA">Iowa</option>
            <option value="ID">Idaho</option>
            <option value="IL">Illinois</option>
            <option value="IN">Indiana</option>
            <option value="KS">Kansas</option>
            <option value="KY">Kentucky</option>
            <option value="LA">Louisiana</option>
            <option value="MA">Massachusetts</option>
            <option value="MD">Maryland</option>
            <option value="ME">Maine</option>
            <option value="MI">Michigan</option>
            <option value="MN">Minnesota</option>
            <option value="MO">Missouri</option>
            <option value="MS">Mississippi</option>
            <option value="MT">Montana</option>
            <option value="NC">North Carolina</option>
            <option value="ND">North Dakota</option>
            <option value="NE">Nebraska</option>
            <option value="NH">New Hampshire</option>
            <option value="NJ">New Jersey</option>
            <option value="NM">New Mexico</option>
            <option value="NV">Nevada</option>
            <option value="NY">New York</option>
            <option value="OH">Ohio</option>
            <option value="OK">Oklahoma</option>
            <option value="OR">Oregon</option>
            <option value="PA">Pennsylvania</option>
            <option value="RI">Rhode Island</option>
            <option value="SC">South Carolina</option>
            <option value="SD">South Dakota</option>
            <option value="TN">Tennessee</option>
            <option value="TX">Texas</option>
            <option value="UG">Uganda</option>
            <option value="UT">Utah</option>
            <option value="VA">Virginia</option>
            <option value="VT">Vermont</option>
            <option value="WA">Washington</option>
            <option value="WI">Wisconsin</option>
            <option value="WV">West Virginia</option>
            <option value="WY">Wyoming</option>
        </select>
    </div>
    <div>
        <label>
            Zip:</label>
        <input name="ZipTextBox" type="text" value="80204" maxlength="10" id="ZipTextBox" />
    </div>
    <div>
        <label>
            Home Phone:</label>
        <input name="HomePhoneTextBox" type="text" value="303-555-1212" maxlength="50" id="HomePhoneTextBox" />
    </div>
    <div>
        <label>
            Cell Phone:</label>
        <input name="CellPhoneTextBox" type="text" maxlength="50" id="CellPhoneTextBox" />
    </div>
    <div>
        <label>
            E-mail:</label>
        <input name="EmailTextBox" type="text" maxlength="200" id="EmailTextBox" />
    </div>
    <div>
        <label>
            Scheduled Date / Time:</label>
        <input name="ScheduleDateTextBox" type="text" maxlength="200" id="ScheduleDateTextBox" />
        <span id="ScheduleDateErrorLabel" style="color: Red;"></span>
    </div>
    <div>
        <label>
            Scheduled Type:</label>
        <select name="ScheduleTypeDropDownList" id="ScheduleTypeDropDownList">
            <option value="0"></option>
            <option value="1">Delivery</option>
            <option value="2">Pick-Up</option>
        </select>
    </div>
    <div>
        <label>
            Notes:</label>
        <textarea name="NotesTextBox" rows="5" cols="20" id="NotesTextBox"></textarea>
    </div>
    <div>
        <label>
            Inventory:</label>
        <a href="/inventory/edit/6F9619FF-8B86-D011-B42D-00C04FC964FF">LB0217</a>
    </div>
    <div>
        <label>
            * Call Date:</label>
        <input name="CallDateTextBox" type="text" value="6/3/2006 12:00:00 AM" maxlength="25"
            id="CallDateTextBox" />
        <span id="CallDateRequired" style="color: Red; display: none;">Call Date Required</span>
    </div>
    <div>
        <label>
            Create By:</label>
        <span id="CreateByLabel">Dan Stewart</span>
    </div>
    <div>
        <label>
            Last Modified Date:</label>
        <span id="LastModifiedLabel"></span>
    </div>
    <div>
        <label>
            Last Modified By:</label>
        <span id="LastModByLabel"></span>
    </div>
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