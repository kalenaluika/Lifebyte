<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
    <div id="menu">
        <ul>
            <li><a href="/home">Home</a></li>
            <li><a href="/donate">Donate</a></li>
            <li><a href="/request">Request</a></li>
            <li class="current_page_item"><a href="/volunteer">Volunteer</a></li>
            <li><a href="/inventory">Inventory</a></li>
            <li><a href="/recipients">Recipients</a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Lifebyte - Volunteer</h1>
    <p>
        If you are interested in volunteering with us, call 303-256-1224 or e-mail 
        <a href="mailto:webmaster@lifebyte.org">webmaster@lifebyte.org</a>.
    </p>
    <p>
        Lifebyte has several teams that you can be a part of.
    </p>
    <p>
        <b>Donation Pick-up Team</b> - We often have large donations that require several
        members getting together to collect it. A member of the pick-up team will get an
        e-mail of when and where the donation is to be picked up. The donation is then brought
        to our storage unit.
    </p>
    <p>
        We also need help picking up computers through out partnership with 
        <a href="http://www.aidmatrix.org/">Aidmatrix</a>. Aidmatrix develops their network by building partnerships, and
        they have chosen Lifebyte as one of those partners. They consider donating computers
        to Lifebyte as providing "The Right Aid to the Right People at the Right Time<sup>TM</sup>".</p>
    <p>
        <b>Rebuild Team</b> - Once a donation is picked-up and dropped off in our storage
        unit. A member of the rebuild team takes it and works on it. The first thing we
        do is wipe the hard drive with 
        <a href="http://www.dban.org/">DBAN</a>. Once the hard drive is wiped we install Windows under our 
        <a href="http://www.techsoup.org/mar/marList_detail.aspx?ID=248856">Microsoft Authorized Refurbisher</a> 
        license. The other major software we install is:
    </p>
        <ul>
            <li><a href="http://www.adobe.com/">Abobe Acrobat Reader</a> </li>
            <li><a href="http://www.lavasoft.com/">Ad-Aware</a> </li>
            <li><a href="http://free.avg.com/">AVG Anti-Virus</a> </li>
            <li><a href="http://www.belarc.com/">Belarc Advisor - Free Personal PC Audit</a>
            </li>
            <li><a href="http://www.e-sword.net/">e-Sword Bible</a> </li>
            <li><a href="http://www.openoffice.org/">Open Office</a> </li>
        </ul>
    <p>
        <a id="Delivery"></a><b>Delivery Team</b> - Do you know how to plug a computer in?
        Then you can be a part of our delivery team.</p>
    <blockquote>
        <sup>19</sup>Lay not up for yourselves treasures upon earth, where moth and rust
        doth corrupt, and where thieves break through and steal:
        <br />
        <sup>20</sup>But lay up for yourselves treasures in heaven, where neither moth nor
        rust doth corrupt, and where thieves do not break through nor steal:
        <br />
        <sup>21</sup>For where your treasure is, there will your heart be also.
        <br />
        Matthew 6:19-21 <acronym title="King James Version">KJV</acronym>
    </blockquote>
    <p>
        There's no doubt that a computer is a treasure. The delivery team doesn't just deliver
        computers, they deliver heavenly treasures into people's hearts. Computer's don't
        change lives, the saving power of Jesus does. The delivery team is the most exciting
        team in Lifebyte. Every member is encouraged to deliver computers and share the
        love of God with the community.</p>
    <p>
        <a id="PCWash"></a><b>PC Wash</b> - Some organizations raise money by washing cars,
        we do it by "washing" PC's. We open the chasis and blow out the dust bunnies with
        compressed air. Then we run anti-virus software to clean out the bugs. You can join
        us and help people get their infected computers clean.
    </p>
    <p>
        <b>Prayer</b> - Last, but certainly not least, we need prayer! Many of our members
        are not full-time volunteers. They juggle home, work, and school to volunteer with
        Lifebyte. We need your prayers to keep this ministry going.</p>
</asp:Content>
