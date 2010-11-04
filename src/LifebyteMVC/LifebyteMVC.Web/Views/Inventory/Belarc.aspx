<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Belarc
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
    <h2>
        Belarc Advisor Current Profile</h2>
    <p>
        Computer Name: Lifebyte (in WORKGROUP)</p>
    <p>
        Profile Date:&nbsp;Tuesday, February 14, 2006 10:22:27 AM</p>
    <p>
        Advisor Version:&nbsp;7.0t</p>
    <p>
        Windows Logon: User</p>
    <p>
        Operating System: Windows XP Professional Service Pack 2 (build 2600)</p>
    <p>
        System Serial Number: 111111111</p>
    <p>
        Processor Main Circuit Board: 550 megahertz Intel Pentium III 32 kilobyte primary
        memory cache 512 kilobyte secondary memory cache</p>
    <p>
        Board: Asus P2BVT 1.02</p>
    <p>
        BIOS: Phoenix Technologies LTD 1.05 08/23/99</p>
    <p>
        Drives</p>
    <p>
        Gigabytes Usable Hard Drive Capacity: 17.84 Gigabytes Hard Drive Free Space</p>
    <p>
        HITACHI DVD-ROM GD-2500 [CD-ROM = drive] R/RW 4x4x24 [CD-ROM drive]</p>
    <p>
        3.5" format removeable media [Floppy drive]</p>
    <p>
        IC35L020AVER07-0 [Hard drive] (20.42 GB)</p>
    <p>
        Drive Volumes</p>
    <p>
        c: (NTFS on drive 0) 20.41 GB 17.84 GB free</p>
    <p>
        NVIDIA RIVA TNT(Microsoft Corporation) [Display adapter]</p>
    <p>
        Proview PZ456 = [Monitor] (13.8" vis, s/n FIOL3A392778U, November 2003)</p>
    <p>
        Bus Adapters</p>
    <p>
        Multimedia</p>
    <p>
        Intel(R) 82371AB/EB PCI to USB Universal Host Controller</p>
    <p>
        Riptide Audio Device Riptide Bus / Firmware Downloader Riptide Gameport Riptide
        Input Device</p>
    <p>
        56K PCI Modem</p>
    <p>
        HP EN1207D-TX PCI 10/100 Fast Ethernet Adapter</p>
    <p>
        Standard 101/102-Key or Microsoft Natural PS/2 Keyboard</p>
    <p>
        PS/2 Compatible Mouse</p>
    <p>
        USB Root Hub</p>
    <p>
        Virus Protection: AVG Anti-Virus 7.1.375 Version 7.1.375</p>
    <p>
        Lavasoft Ad-Aware</p>
    <p>
        Windows Movie Maker Version 2.1.4026.0</p>
    <p>
        OpenOffice.org 2.0</p>
</asp:Content>