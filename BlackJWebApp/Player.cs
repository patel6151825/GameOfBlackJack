using BLackJackGameWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJWebApp
{
    public class Player : Card
    {

        //public List<int> playerallCards = new List<int>();
        int total = 0;
        int[] ace = new int[] { 1, 14, 27, 40 };
        /// <summary>
        /// To add player's cards
        /// </summary>
        /// <param name="playerallCards"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<int> AddPlayerCard(List<int> playerallCards, int num)
        {
            playerallCards.Add(num);
            return playerallCards;
        }
        /// <summary>
        /// To get player's cards values
        /// </summary>
        /// <param name="playerallCards"></param>
        /// <returns></returns>
        public int getPlayersCardsValues(List<int> playerallCards)
        {
            for(int i = 0; i < playerallCards.Count; i++)
            {
                total = total + GetCardValue(playerallCards[i]);
                
            }
            //if player's cards values burst's then checking if it contains ace
            if (total > 21)
            {
                for (int i = 0; i < playerallCards.Count; i++)
                {
                    if (ace.Contains(playerallCards[i]))
                    {
                        total -= 10;
                        if (total < 21)
                        {
                            break;
                        }
                    }
                    

                }
            }

            return total;
        }
    }
}