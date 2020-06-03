using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLackJackGameWebApp
{
    public class Hand
    {
        public int getNewCard()
        {
            int min = 1;
            int max = 53;
            Random number = new Random();
            return number.Next(min, max);
        }
    }
}