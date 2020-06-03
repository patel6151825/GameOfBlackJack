using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLackJackGameWebApp
{
    public class Card
    {
        /// <summary>
        /// To get card's values
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int GetCardValue(int num)
        {
            int[] ace = new int[]   {  1, 14, 27, 40 };
            int[] two = new int[]   {  2, 15, 28, 41 };
            int[] three = new int[] {  3, 16, 29, 42 };
            int[] four = new int[]  {  4, 17, 30, 43 };
            int[] five = new int[]  {  5, 18, 31, 44 };
            int[] six = new int[]   {  6, 19, 32, 45 };
            int[] seven = new int[] {  7, 20, 33, 46 };
            int[] eight = new int[] {  8, 21, 34, 47 };
            int[] nine = new int[]  {  9, 22, 35, 48 };

            if (ace.Contains(num))
            {
                return 11;
            }
            else if (two.Contains(num))
            {
                return 2;
            }
            else if (three.Contains(num))
            {
                return 3;
            }
            else if (four.Contains(num))
            {
                return 4;
            }
            else if (five.Contains(num))
            {
                return 5;
            }
            else if (six.Contains(num))
            {
                return 6;
            }
            else if (seven.Contains(num))
            {
                return 7;
            }
            else if (eight.Contains(num))
            {
                return 8;
            }
            else if (nine.Contains(num))
            {
                return 9;
            }
            else
            {
                return 10;
            }

        }
    }
}