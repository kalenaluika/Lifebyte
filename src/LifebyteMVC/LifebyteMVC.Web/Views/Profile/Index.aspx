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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Edit Your Profile</h1>
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
            Primary Phone:</label>
        <input name="PrimaryPhoneTextBox" type="text" value="303-555-1212" maxlength="50" id="HomePhoneTextBox" />
    </div>
    <div>
        <label>
            Secondary Phone:</label>
        <input name="SecondaryPhoneTextBox" type="text" maxlength="50" id="CellPhoneTextBox" />
    </div>
    <div>
        <label>
            * E-mail:</label>
        <input name="EmailTextBox" type="text" maxlength="200" id="EmailTextBox" />
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