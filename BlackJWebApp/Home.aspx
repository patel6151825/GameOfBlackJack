<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BlackJWebApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="bg"></div>
        <div class="bg bg2"></div>
        <div class="bg bg3"></div>
        <div class="content">
            <br />
            <h1 class="heading">Blackjack Game</h1>
            <br />
            <img alt="image" src="./images/bj.png" class="homeImg" />

            <div>
                <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="2000" OnTick="Timer1_Tick" />
                <asp:Timer ID="Timer2" runat="server" Enabled="False" Interval="2000" OnTick="Timer2_Tick" />
            </div>
            <br />
            <br />
            <asp:Button ID="BtnPlay" runat="server" Text="PLAY" CssClass="btnPlay" OnClick="BtnPlay_Click" />
            <br />
            <br />
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>--%>
        </div>
    </div>
</asp:Content>
