<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayGame.aspx.cs" Inherits="BlackJWebApp.PlayGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="MainPanel" runat="server">
        <div class="container playTable">
            <asp:Panel runat="server">

                <section id="main_content">

                    <div class="row">
                        <br />
                        <asp:Label ID="lblDealer" runat="server" CssClass="lblBank" Text="Dealer"></asp:Label>
                        <asp:Label ID="lblDealerValue" runat="server"></asp:Label><br />
                        <asp:Image ID="ImgPeople" runat="server" ImageUrl="./images/person.png" class="person" />
                        <asp:Image ID="dlImage1" runat="server" Visible="false" class="img1 imgB1" />
                        <asp:Image ID="dlImage2" runat="server" Visible="false" class="img1 imgB2" />
                        <asp:Image ID="dlImage3" runat="server" Visible="false" class="img1 imgB3" />
                        <asp:Image ID="dlImage4" runat="server" Visible="false" class="img1 imgB4" />
                        <asp:Image ID="dlImage5" runat="server" Visible="false" class="img1 imgB5" />
                        <asp:Image ID="dlImage6" runat="server" Visible="false" class="img1 imgB6" />
                        <asp:Image ID="dlImage7" runat="server" Visible="false" class="img1 imgB7" />
                        <asp:Image ID="dlImage8" runat="server" Visible="false" class="img1 imgB8" />
                        <asp:Image ID="dlImage9" runat="server" Visible="false" class="img1 imgB9" />
                        <asp:Image ID="dlImage10" runat="server" Visible="false" class="img1 imgB10" />
                        <asp:Image ID="dlImage11" runat="server" Visible="false" class="img1 imgB11" />
                        <br />
                        <br />
                    </div>

                    <div>
                        <asp:Label ID="lblBet" runat="server" CssClass="lblBank" Text="Bet : "></asp:Label>
                        <asp:Label ID="lblBetAmount" runat="server" CssClass="lblBank lblAmt"></asp:Label>
                        <asp:Button ID="btnDeal" runat="server" Text="DEAL" CssClass="btnDeal" OnClick="btnDeal_Click" />


                        <asp:Button ID="btnHit" runat="server" Text="HIT" CssClass="btnDeal btnHit" Visible="false" OnClick="btnHit_Click" />
                        <asp:Button ID="btnStand" runat="server" Text="STAND" CssClass="btnDeal btnStand" Visible="false" OnClick="btnStand_Click" />
                        <asp:Button ID="btnNewGame" runat="server" Text="PLAY AGAIN" CssClass="btnDeal btnNewGame" Visible="false" OnClick="btnNewGame_Click" />
                        <span class="messagealert" id="alert_container" />
                    </div>

                    <div class="row">
                        <br />
                        <br />
                        <asp:Image ID="Image1" runat="server" ImageUrl="./images/person.png" class="person" />
                        <asp:Image ID="plImage1" runat="server" Visible="false" class="img1 imgB1" />
                        <asp:Image ID="plImage2" runat="server" Visible="false" class="img1 imgB2" />
                        <asp:Image ID="plImage3" runat="server" Visible="false" class="img1 imgB3" />
                        <asp:Image ID="plImage4" runat="server" Visible="false" class="img1 imgB4" />
                        <asp:Image ID="plImage5" runat="server" Visible="false" class="img1 imgB5" />
                        <asp:Image ID="plImage6" runat="server" Visible="false" class="img1 imgB6" />
                        <asp:Image ID="plImage7" runat="server" Visible="false" class="img1 imgB7" />
                        <asp:Image ID="plImage8" runat="server" Visible="false" class="img1 imgB8" />
                        <asp:Image ID="plImage9" runat="server" Visible="false" class="img1 imgB9" />
                        <asp:Image ID="plImage10" runat="server" Visible="false" class="img1 imgB10" />
                        <asp:Image ID="plImage11" runat="server" Visible="false" class="img1 imgB11" /><br />

                        <asp:Label ID="lblPlayer" runat="server" CssClass="lblBank" Text="Player"></asp:Label>
                        <asp:Label ID="lblPlayerValue" runat="server"></asp:Label>
                        <br />
                    </div>
                </section>
                <aside class="aside">
                    <div>
                        <span style="width: 80px">
                            <asp:Label ID="lblBank" runat="server" CssClass="lblBank lblAmt" Text="Bank "></asp:Label>
                            <asp:Label ID="lblBankAmount" runat="server" CssClass="lblBank lblAmt"></asp:Label>
                        </span>

                        <asp:Panel runat="server" CssClass="panelCoin" ID="panelCoins">
                            <span>
                                <asp:Button ID="btnOne" runat="server" CssClass="roundcorner btnOne" Text="1" OnClick="btnOne_Click" />
                                <asp:Button ID="btnFive" runat="server" CssClass="roundcorner btnFive" Text="5" OnClick="btnFive_Click" />
                                <asp:Button ID="btnTwentyFive" runat="server" CssClass="roundcorner btnTwentyFive" Text="25" OnClick="btnTwentyFive_Click" />
                                <asp:Button ID="btnFifty" runat="server" CssClass="roundcorner btnFifty" Text="50" OnClick="btnFifty_Click" />
                                <asp:Button ID="btnHundred" runat="server" CssClass="roundcorner btnHundred" Text="100" OnClick="btnHundred_Click" />
                                <asp:Button ID="BtnClearBet" runat="server" CssClass="roundcorner btnClearBet" Text="Clear Bet" OnClick="BtnClearBet_Click" />
                            </span>
                        </asp:Panel>
                    </div>
                </aside>


            </asp:Panel>
        </div>
    </asp:Panel>

    <asp:Panel ID="PanelRestart" runat="server" Visible="false" CssClass="RestartPanel">
        <asp:Label ID="Label1" runat="server" Text="GAME OVER" Style="color: white; text-align: center; width: 1412px; height: 46px; font-size: 40px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif"></asp:Label>
        <br />

        <table class="center">
            <tr>
                <td>
                    <asp:Label ID="lblHighBank" runat="server" Text="Highest Bank " CssClass="lblAmt" Font-Bold="true" ForeColor="white"></asp:Label></td>
                <td>
                    <asp:Label ID="lblHighBankValue" runat="server" Text="" CssClass="lblAmt" ForeColor="white"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPlayerWon" runat="server" Text="You Won " CssClass="lblAmt" Font-Bold="true" ForeColor="white"></asp:Label></td>
                <td>
                    <asp:Label ID="lblPlayerWonValue" runat="server" Text="0" CssClass="lblAmt" ForeColor="white"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDealerWon" runat="server" Text="Dealer Won " CssClass="lblAmt" Font-Bold="true" ForeColor="white"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDealerWonValue" runat="server" Text="0" CssClass="lblAmt" ForeColor="white"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPush" runat="server" Text="Push " CssClass="lblAmt" Font-Bold="true" ForeColor="white"></asp:Label></td>
                <td>
                    <asp:Label ID="lblPushValue" runat="server" Text="0" CssClass="lblAmt" ForeColor="white"></asp:Label></td>
            </tr>
            <tr>
                <td><br /></td>
                <td></td>
            </tr>
            <tr>
                <td><span><asp:Button ID="btnRestart" runat="server" Text="RESTART" Visible="true" BackColor="Maroon" ForeColor="white" Font-Bold="true" Font-Size="15px" OnClick="btnRestart_Click" /></span></td>
                <td><span><asp:Button ID="btnHome" runat="server" Text="HOME" Visible="true" BackColor="Maroon" ForeColor="white" Font-Bold="true" Font-Size="15px" OnClick="btnHome_Click" /></span></td>
            </tr>
        </table>
        <br />
        <br />
    </asp:Panel>


</asp:Content>

