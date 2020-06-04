using BLackJackGameWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlackJWebApp
{
    public partial class PlayGame : System.Web.UI.Page
    {
        private int betAmount;
        private int bankAmount;
        private List<int> allCards;
        private int dealerValue;
        private int playerValue;
        Hand hand = new Hand();
        Player player = new Player();
        Dealer dealer=new Dealer();

        List<int> dealerallCards = new List<int>();
        List<int> playerallCards = new List<int>();
        public PlayGame playGame { get; set; }
           
        protected void Page_Load(object sender, EventArgs e)
        {
            //GET
            if (!Page.IsPostBack)
            {
                playGame = new PlayGame();
                //Reset all the Session veriables
                Session["betAmount"] = 50;
                Session["bankAmount"] = 500;

                //list to track records of all the cards
                Session["allCards"] = new List<int>();
                Session["card2"] = 0;

                //list to track records of all the dealer cards and player cards
                Session["dealerallCards"] = new List<int>();
                Session["playerallCards"] = new List<int>();
                
                lblBetAmount.Text = Session["betAmount"].ToString() + " $";
                lblBankAmount.Text = Session["bankAmount"].ToString() + "$";

                //session objects to track all the records of who won, highest bank,push
                Session["PlayerWon"] = 0;
                Session["DealerWon"] = 0;
                Session["Push"] = 0;
                Session["highBank"] = 50;
                player = (Player)Session["player"];
                dealer = (Dealer)Session["dealer"];

            }
           
            //if bet amount is higher than bank amount
            if (Convert.ToInt32(Session["betAmount"]) > Convert.ToInt32(Session["bankAmount"]))
            {
                Session["betAmount"] = Convert.ToInt32(Session["bankAmount"]);
                lblBetAmount.Text = Session["betAmount"].ToString() + " $";
            }
        }
        /// <summary>
        /// method to increment bet amount
        /// </summary>
        /// <param name="betAmount"></param>
        public void IncrementBetAmount(int betAmount)
        {
            int actual = Convert.ToInt32(Session["betAmount"]);
            Session["betAmount"] = Convert.ToInt32(Session["betAmount"]) + betAmount;

            //call to method to check bet is valid or not
            int valid = CheckForValidBet();

            if (valid == -1)
            {
                ShowMessage("Sorry, It is not possible!");
                Session["betAmount"] = actual;
            }
            else if (valid == 1)
            {
                ShowMessage("The maximum bet amount is 100 $!");
                Session["betAmount"] = actual;
            }

            if (Convert.ToInt32(Session["betAmount"]) == 0)
            {
                btnDeal.Visible = false;
            }
            else
            {
                //valid
                btnDeal.Visible = true;
            }
            //setting bet and bank amount lables
            lblBetAmount.Text = Session["betAmount"].ToString() + " $";
            lblBankAmount.Text = Session["bankAmount"].ToString() + "$";

        }

        /// <summary>
        /// /method to check bet is valid or not
        /// </summary>
        /// <returns></returns>
        public int CheckForValidBet()
        {
            //if bet user tries to put bet higher than 100
            if (Convert.ToInt32(Session["betAmount"]) > 100)
            {
                return 1;
            }
            //if bet amount higher than bank amount
            else if (Convert.ToInt32(Session["betAmount"]) > Convert.ToInt32(Session["bankAmount"]))
            {
                return -1;
            }
            //valid
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// event handlers when user tries to increment bet values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOne_Click(object sender, EventArgs e)
        {
            betAmount = 1;
            IncrementBetAmount(betAmount);
        }

        protected void btnFive_Click(object sender, EventArgs e)
        {
            betAmount = 5;
            IncrementBetAmount(betAmount);
        }

        protected void btnTwentyFive_Click(object sender, EventArgs e)
        {
            betAmount = 25;
            IncrementBetAmount(betAmount);
        }

        protected void btnFifty_Click(object sender, EventArgs e)
        {
            betAmount = 50;
            IncrementBetAmount(betAmount);
        }

        protected void btnHundred_Click(object sender, EventArgs e)
        {
            betAmount = 100;
            IncrementBetAmount(betAmount);
        }

        protected void btnDeal_Click(object sender, EventArgs e)
        {
            Session["bankAmount"] = Convert.ToInt32(Session["bankAmount"]) - Convert.ToInt32(Session["betAmount"]);

            lblBankAmount.Text = Session["bankAmount"].ToString() + "$";
            //hiding coins panel and deal button
            panelCoins.Visible = false;
            btnDeal.Visible = false;

            //setting default images
            string defaultURL = @".\Resources\backside.jpg";
            dlImage1.ImageUrl = defaultURL;
            dlImage2.ImageUrl = defaultURL;
            plImage1.ImageUrl = defaultURL;
            plImage2.ImageUrl = defaultURL;

            dlImage1.Visible = true;
            dlImage2.Visible = true;
            plImage1.Visible = true;
            plImage2.Visible = true;

            //call to method to deals two cards each
            DealsTwocardEach();
            lblPlayerValue.CssClass = "roundValue";
            lblDealerValue.CssClass = "roundValue";
        }
        /// <summary>
        /// methods to deal two cards to both player and dealer
        /// </summary>
        internal void DealsTwocardEach()
        {
            allCards = (List<int>)Session["allCards"];
            dealerallCards = Session["dealerallCards"] as List<int>;
            playerallCards = Session["playerallCards"] as List<int>;
           
            //call to method to first card
            int card1 = hand.getNewCard();
            allCards.Add(card1);
            Session["dealerallCards"]=dealer.AddDealerCard(dealerallCards,card1);
            dlImage1.ImageUrl = @".\Resources\" + card1 + ".jpg";

            dealerallCards= Session["dealerallCards"] as List<int>;
            dealerValue = dealer.getDealersCardsValues(dealerallCards);
            //setting dealer points value
            lblDealerValue.Text = dealerValue.ToString();

            //call to method to second card
            int card2 = hand.getNewCard();
            //checking that the card is already taken or not if yes than get another
            while (allCards.Contains(card2))
            {
                card2 = hand.getNewCard();
            }
            allCards.Add(card2);
            Session["card2"] = card2;
            Session["dealerallCards"]=dealer.AddDealerCard(dealerallCards,card2);

            dealerallCards = Session["dealerallCards"] as List<int>;
            dealerValue = dealer.getDealersCardsValues(dealerallCards);
            Session["dealerBJ"] = dealerValue;
            
            //generating player's card
            int card3 = hand.getNewCard();
            while (allCards.Contains(card3))
            {
                card3 = hand.getNewCard();
            }
            allCards.Add(card3);
            Session["playerallCards"]=player.AddPlayerCard(playerallCards,card3);
            plImage1.ImageUrl = @".\Resources\" + card3 + ".jpg";
           
            int card4 = hand.getNewCard();
            while (allCards.Contains(card4))
            {
                card4 = hand.getNewCard();
            }
            allCards.Add(card4);
            Session["playerallCards"] = player.AddPlayerCard(playerallCards,card4);
            plImage2.ImageUrl = @".\Resources\" + card4 + ".jpg";
            
            playerallCards = Session["playerallCards"] as List<int>;
            playerValue = player.getPlayersCardsValues(playerallCards);

            Session["playerBJ"] = playerValue;

            lblPlayerValue.Text = playerValue.ToString();
            Session["player"] = player;
            Session["dealer"] = dealer;
           
            //making hit and stand button visible
            btnHit.Visible = true;
            btnStand.Visible = true;

            //if player has black jack
            if (playerValue == 21)
            {
                //open dealer's card
                OpenDealerCards();
            }

        }
        protected void ShowMessage(string Message)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','');", true);
        }

        /// <summary>
        /// event to handle when user wants another card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHit_Click(object sender, EventArgs e)
        {
            allCards = (List<int>)Session["allCards"];
            dealerallCards = Session["dealerallCards"] as List<int>;
            playerallCards = Session["playerallCards"] as List<int>;
            //getting another card and checking if does not exists already
            int playerNextCard = hand.getNewCard();
            while (allCards.Contains(playerNextCard))
            {
                playerNextCard = hand.getNewCard();
            }
            allCards.Add(playerNextCard);
            Session["playerallCards"]=player.AddPlayerCard(playerallCards,playerNextCard);
            //displaying generated card
            string plImgURL = @".\Resources\" + playerNextCard + ".jpg";

            if (plImage3.Visible == false)
            {
                plImage3.ImageUrl = plImgURL;
                plImage3.Visible = true;

            }
            else if (plImage4.Visible == false)
            {
                plImage4.ImageUrl = plImgURL;
                plImage4.Visible = true;

            }
            else if (plImage5.Visible == false)
            {
                plImage5.ImageUrl = plImgURL;
                plImage5.Visible = true;

            }
            else if (plImage6.Visible == false)
            {
                plImage6.ImageUrl = plImgURL;
                plImage6.Visible = true;

            }
            else if (plImage7.Visible == false)
            {
                plImage7.ImageUrl = plImgURL;
                plImage7.Visible = true;

            }
            else if (plImage8.Visible == false)
            {
                plImage8.ImageUrl = plImgURL;
                plImage8.Visible = true;

            }
            else if (plImage9.Visible == false)
            {
                plImage9.ImageUrl = plImgURL;
                plImage9.Visible = true;

            }
            else if (plImage10.Visible == false)
            {
                plImage10.ImageUrl = plImgURL;
                plImage10.Visible = true;

            }
            else if (plImage11.Visible == false)
            {
                plImage11.ImageUrl = plImgURL;
                plImage11.Visible = true;

            }
            playerallCards = Session["playerallCards"] as List<int>;
            
            playerValue = player.getPlayersCardsValues(playerallCards);

            lblPlayerValue.Text = playerValue.ToString();
            
            //if player value is 21 than hiding hit and stand button and opening dealer's card
            if (playerValue == 21)
            {
                btnHit.Visible = false;
                btnStand.Visible = false;
                lblPlayerValue.Text = playerValue.ToString();
                OpenDealerCards();
            }

            //if player value is higher than 21 than making dealer won showing play again button
            else if (playerValue > 21)
            {
                ShowMessage("Player Burst!");
                Session["DealerWon"] = Convert.ToInt32(Session["DealerWon"]) + 1;
                Session["bankAmount"] = Convert.ToInt32(Session["bankAmount"]);
                btnHit.Visible = false;
                btnStand.Visible = false;
                btnNewGame.Visible = true;


            }
            Session["allCards"] = allCards;
            Session["player"] = player;
            Session["dealer"] = dealer;
            //setting bet and bank amount value
            lblBankAmount.Text = Session["bankAmount"].ToString() + "$";
        }
        //event to handler when user clicks on stand button
        public void btnStand_Click(object sender, EventArgs e)
        {
            //call to meethod to open dealer's card
            OpenDealerCards();

        }

        //method to open dealer's card
        private void OpenDealerCards()
        {
            dlImage2.ImageUrl = @".\Resources\" + Convert.ToInt32(Session["card2"]) + ".jpg";
            dealerallCards = Session["dealerallCards"] as List<int>;
            dealerValue = dealer.getDealersCardsValues(dealerallCards);
            if (dealerValue != 21)
            {
                //if dealer points are less than 17 than take another card
                while (dealerValue < 17)
                {
                    allCards = (List<int>)Session["allCards"];

                    int dealerNextCard = hand.getNewCard();
                    while (allCards.Contains(dealerNextCard))
                    {
                        dealerNextCard = hand.getNewCard();
                    }
                    allCards.Add(dealerNextCard);
                    Session["dealerallCards"]=dealer.AddDealerCard(dealerallCards,dealerNextCard);
                    dealerallCards = Session["dealerallCards"] as List<int>;
                    dealerValue = dealer.getDealersCardsValues(dealerallCards);
                    string imgURL = @".\Resources\" + dealerNextCard + ".jpg";

                    if (dlImage3.Visible == false)
                    {
                        dlImage3.ImageUrl = imgURL;
                        dlImage3.Visible = true;
                    }
                    else if (dlImage4.Visible == false)
                    {
                        dlImage4.ImageUrl = imgURL;
                        dlImage4.Visible = true;
                    }
                    else if (dlImage5.Visible == false)
                    {
                        dlImage5.ImageUrl = imgURL;
                        dlImage5.Visible = true;
                    }
                    else if (dlImage6.Visible == false)
                    {
                        dlImage6.ImageUrl = imgURL;
                        dlImage6.Visible = true;
                    }
                    else if (dlImage7.Visible == false)
                    {
                        dlImage7.ImageUrl = imgURL;
                        dlImage7.Visible = true;
                    }
                    else if (dlImage8.Visible == false)
                    {
                        dlImage8.ImageUrl = imgURL;
                        dlImage8.Visible = true;
                    }
                    else if (dlImage9.Visible == false)
                    {
                        dlImage9.ImageUrl = imgURL;
                        dlImage9.Visible = true;
                    }
                    else if (dlImage10.Visible == false)
                    {
                        dlImage10.ImageUrl = imgURL;
                        dlImage10.Visible = true;
                    }
                    else if (dlImage11.Visible == false)
                    {
                        dlImage11.ImageUrl = imgURL;
                        dlImage11.Visible = true;
                    }

                    lblDealerValue.Text = dealerValue.ToString();

                    Session["allCards"] = allCards;
                    Session["player"] = player;
                    Session["dealer"] = dealer;

                }
            }

            dealerallCards = Session["dealerallCards"] as List<int>;
            dealerValue = dealer.getDealersCardsValues(dealerallCards);
            
            //playerallCards = Session["playerallCards"] as List<int>;
            //playerValue = player.getPlayersCardsValues(playerallCards);
            
            betAmount = Convert.ToInt32(Session["betAmount"]);
            bankAmount = Convert.ToInt32(Session["bankAmount"]);
            int playerBJ = Convert.ToInt32(Session["playerBJ"]);
            int dealerBJ = Convert.ToInt32(Session["dealerBJ"]);


            lblDealerValue.Text = dealerValue.ToString();
            playerValue = player.getPlayersCardsValues(Session["playerallCards"] as List<int>);
            Session["player"] = player;
            Session["dealer"] = dealer;
            //checking conditions of who won

            //if player and dealer both has black jack than push
            if ((playerBJ == 21) && (dealerBJ == 21))
            {
                ShowMessage("Push (Both have black jack)");
                Session["bankAmount"] = bankAmount + betAmount;
                Session["Push"] = Convert.ToInt32(Session["Push"]) + 1;
            }
            //if only player has black jack increment value by 3:2
            else if (playerBJ == 21)
            {
                ShowMessage("BlackJack, Player Won!");
                Session["bankAmount"] = bankAmount + 1.5*(2 * betAmount);
                Session["PlayerWon"] = Convert.ToInt32(Session["PlayerWon"]) + 1;
            }
            //if only dealer has black jack decrement value by 3:2
            else if (dealerBJ == 21)
            {
                ShowMessage("BlackJack, Dealer Won");
                Session["bankAmount"] = bankAmount - 1.5*(2 * betAmount);
                Session["DealerWon"] = Convert.ToInt32(Session["DealerWon"]) + 1;
            }
            //if dealer points are more than 21 than dealer bursts

            else if (dealerValue > 21)
            {
                ShowMessage("Dealer Burst!");
                Session["bankAmount"] = bankAmount + (2*betAmount);
                Session["PlayerWon"] = Convert.ToInt32(Session["PlayerWon"]) + 1;
                int p = Convert.ToInt32(Session["PlayerWon"]);
            }
            //if dealer points are more than player's points
            else if (dealerValue > playerValue)
            {
                ShowMessage("Dealer Won!");
                Session["bankAmount"] = bankAmount;
                Session["DealerWon"] = Convert.ToInt32(Session["DealerWon"]) + 1;
            }
            //if dealer points are less than player's points
            else if (dealerValue < playerValue)
            {
                ShowMessage("Player Won!");
                Session["bankAmount"] = bankAmount + (2*betAmount);
                Session["PlayerWon"] = Convert.ToInt32(Session["PlayerWon"]) + 1;
            }
            //else dealer points are same player's points
            else
            {
                ShowMessage("Push!");
                Session["bankAmount"] = bankAmount+betAmount;
                Session["Push"] = Convert.ToInt32(Session["Push"]) + 1;
            }
            lblBankAmount.Text = Session["bankAmount"].ToString() + "$";
            int currentValue = Convert.ToInt32(Session["bankAmount"]);
            if (currentValue > Convert.ToInt32(Session["highBank"]))
            {
                Session["highBank"] = currentValue;
            }

            //displaying button to start new game
            btnHit.Visible = false;
            btnStand.Visible = false;
            //Thread.Sleep(3000);
            btnNewGame.Visible = true;
            //StartNewRound();

        }
        //method to start new game
        private void StartNewRound()
        {
            ((List<int>)Session["allCards"]).Clear();
            //if bank amount is 0 or negative
            if (Convert.ToInt32(Session["bankAmount"]) <= 0)
            {
                ShowMessage("GAME OVER Sorry You don't have enough money");
                //hiding main panel
                MainPanel.Visible = false;
                //setting highet bank value, player won, dealer won and push values
                lblHighBankValue.Text = Convert.ToInt32(Session["highBank"]).ToString();
                lblPlayerWonValue.Text = Convert.ToInt32(Session["PlayerWon"]).ToString();
                lblDealerWonValue.Text = Convert.ToInt32(Session["DealerWon"]).ToString();
                lblPushValue.Text = Convert.ToInt32(Session["Push"]).ToString();

                //resetting all the objects
                Session["PlayerWon"] = 0;
                Session["DealerWon"] = 0;
                Session["Push"] = 0;
                Session["highBank"] = 500;
                Session["dealerallCards"] = new List<int>();
                Session["playerallCards"] = new List<int>();
                //displaying game restart panel
                Session["allCards"] = new List<int>();
                PanelRestart.Visible = true;
            }
            //starting new round
            else
            {
                //enabling all the coins
                btnOne.Enabled = true;
                btnFive.Enabled = true;
                btnTwentyFive.Enabled = true;
                btnFifty.Enabled = true;
                btnHundred.Enabled = true;

                //displaying deal button,coins panels and hiding hit,stand, play again button
                btnDeal.Visible = true;
                btnHit.Visible = false;
                btnStand.Visible = false;
                btnNewGame.Visible = false;
                panelCoins.Visible = true;

                dlImage1.Visible = false;
                dlImage2.Visible = false;
                dlImage3.Visible = false;
                dlImage4.Visible = false;
                dlImage5.Visible = false;
                dlImage6.Visible = false;
                dlImage7.Visible = false;
                dlImage8.Visible = false;
                dlImage9.Visible = false;

                plImage1.Visible = false;
                plImage2.Visible = false;
                plImage3.Visible = false;
                plImage4.Visible = false;
                plImage5.Visible = false;
                plImage6.Visible = false;
                plImage7.Visible = false;
                plImage8.Visible = false;
                plImage9.Visible = false;

                lblBetAmount.Text = "";
                lblDealerValue.Text = "";
                lblPlayerValue.Text = "";

                Session["betAmount"] = 50;
                Session["card2"] = 0;
                Session["dealerallCards"] = new List<int>();
                Session["playerallCards"] = new List<int>();
                Session["allCards"] = new List<int>();

                string defaultURL = @".\Resources\backside.jpg";
                dlImage1.ImageUrl = defaultURL;
                dlImage2.ImageUrl = defaultURL;
                plImage1.ImageUrl = defaultURL;
                plImage2.ImageUrl = defaultURL;

                lblPlayerValue.CssClass = lblPlayerValue.CssClass.Replace("roundValue", "");
                lblDealerValue.CssClass = lblDealerValue.CssClass.Replace("roundValue", "");

                if (Convert.ToInt32(Session["betAmount"]) > Convert.ToInt32(Session["bankAmount"]))
                {
                    Session["betAmount"] = Convert.ToInt32(Session["bankAmount"]);
                }

                lblBetAmount.Text = Session["betAmount"].ToString() + " $";
            }

        }
        //event to handle when user clicks on new game button
        protected void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewRound();
        }

        //event to handle when user clicks on clear bet button
        protected void BtnClearBet_Click(object sender, EventArgs e)
        {
            Session["betAmount"] = 0;
            lblBetAmount.Text = Session["betAmount"].ToString() + " $";
            btnDeal.Visible = false;
        }

        //event to handle when user clicks on restart game button
        protected void btnRestart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayGame");
        }

        //event to handle when user clicks on home button
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home");
        }
    }
}