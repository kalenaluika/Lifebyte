<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li class="current_page_item"><a href="/donate">Donate</a></li>
            <li><a href="/request">Request</a></li>
            <li><a href="/volunteer">Volunteer</a></li>
            <li><a href="/inventory">Inventory</a></li>
            <li><a href="/recipients">Recipients</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte - Computer Donation</h1>
    <p>
        You may drop off your donation at Colorado Community Church (for both sites)
        any weekday between 8 a.m. - 5 p.m. of before and after services on the weekends.
        Please ask the staff for a donation receipt.
    </p>
    <div style="float: left; width: 50%">
        Aurora Campus<br />
        2220 S. Chambers Rd.<br />
        Aurora, CO 80014<br />
        (303) 783-3838
    </div>
    <div style="float: left; width: 50%">
        Englewood Campus<br />
        3651 S. Colorado Blvd.<br />
        Englewood, CO 80113<br />
        (303) 783-3838
    </div>
    <p>
        We are always looking for computers and computer parts. If your computer was purchased
        in at least the year 2000, chances are we can use it. We accept computers, working
        or not, that are at least 500MHz or faster.
    </p>
    <p>
        The computer you are donating does not have to have any of these, but we also need
        56K PCI modems, wireless network cards, Ethernet network cards, DVD and CDRW ROM
        drives, hard drives greater than 10GB, RAM at least 128MB of PC100 or greater.
    </p>
    <p>
        We accept all working monitors with a $10 donation in case we need to recycle it.
    </p>
    <p>
        We recommend <a href="http://www.luminousrecycling.com/wp/">Luminous Recycling</a>
        as a trusted partner.</p>
    <p>
        Lifebyte has recycled over 9,960 pounds (4 tons) of computer equipment through Luminous.</p>
    <p>
        Luminous Electronic Recycling<br />
        <a href="http://maps.google.com/maps?f=q&hl=en&geocode=&time=&date=&ttype=&q=11809+E.+51st+St.++Denver,+CO+80239&sll=37.0625,-95.677068&sspn=46.226656,60.380859&ie=UTF8&om=1&s=AARTsJpfX8ENQijPUsfA5gJ8Bwhw7_cymA&view=map">11809 E. 51st St.</a><br />
        Denver, CO 80239</p>
    <p>
        We also need surge protectors and speakers.
    </p>
    <p>
        If you would like to help our ministry, but don't have a computer or computer parts,
        there are other things we can use as well. We often need help picking up donations,
        and can always use monetary contributions. We also need people to help us build
        computers and deliver them to recipients once they are configured. Most of all we
        need prayers that our ministry continues to be blessed so that we can bless the
        lives of others. To make a donation, call 303-256-1224 or e-mail 
        <a href="mailto:webmaster@Lifebyte.org">webmaster@Lifebyte.org</a>. A Lifebyte member will contact you as soon as possible.
        We will provide you with a donation receipt for tax purposes.
    </p>
    <p>
        We take your data seriously. We use <a href="http://www.dban.org/">DBAN</a> to erase
        the hard drive before we refurbish it.
    </p>   
</asp:Content>
