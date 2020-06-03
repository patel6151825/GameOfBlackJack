using BLackJackGameWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJWebApp
{
    public class Dealer : Card
    {

        //public List<int> dealerallCards = new List<int>();
        
        
        int[] ace = new int[] { 1, 14, 27, 40 };

        /// <summary>
        /// To add dealer card
        /// </summary>
        /// <param name="dealerallCards"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<int> AddDealerCard(List<int> dealerallCards, int num)
        {
            dealerallCards.Add(num);
            return dealerallCards;
        }
        /// <summary>
        /// To get dealers cards values
        /// </summary>
        /// <param name="dealerallCards"></param>
        /// <returns></returns>
        public int getDealersCardsValues(List<int> dealerallCards)
        {
            int total = 0;
            for (int i = 0; i < dealerallCards.Count; i++)
            {
                total = total + GetCardValue(dealerallCards[i]);

            }
            //if dealer's cards values burst's then checking if it contains ace
            if (total > 21)
            {
                for (int i = 0; i < dealerallCards.Count; i++)
                {
                    if (ace.Contains(dealerallCards[i]))
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