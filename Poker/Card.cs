using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card : IComparable<Card> // Angle brackets are templates
    {
        public int rank; // 2-14 (ace high)
        public char suit; // c, s, h or d

        public override string ToString()
        {
            return rank + " of " + suit;
        }

        public bool isValid()
        {
            return rank != 0 && suit != '\0';
        }

        public void SetFromChar(char ch)
        {
            // case sensitive sucks!
            ch = char.ToUpper(ch);
            // 2-9 are easy because one bit of code can get all of them
            if (ch >= '2' && ch <= '9')
                rank = ch - '0'; // This is for converting simple digits to characters
            // 10, J, Q, K and Ace are random, so special case
            else if (ch == 'T')
                rank = 10;
            else if (ch == 'J')
                rank = 11;
            else if (ch == 'Q')
                rank = 12;
            else if (ch == 'K')
                rank = 13;
            else if (ch == 'A')
                rank = 14;
            else if (ch == 'S' || ch == 'C' || ch == 'D' || ch == 'H')
                suit = ch;
            // Everything else is a suit
        }

        public int CompareTo(Card other)
        {
            return this.rank - other.rank;
        }
    }

}
                              