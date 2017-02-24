using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        public Card[] cards = new Card[5]; // if I only have the left side, it defaults to null. The right side gives it an ability to talk about 5 cards.

        public override string ToString()
        {
            string s = "";
            foreach (Card c in cards)
                s += c.ToString() + ", ";
            return s;
        }

        public HandType Evaluate()
        {
            Array.Sort(cards);
            // Am I a flush?
            bool flush = IsFlush();
            bool four = IsFourOfAKind();
            bool fullHouse = IsFullHouse();
            int pairs = CountPairs();
            if (flush == true)
            {
                return (HandType)5;
            }
            else if (four == true)
            {
                return (HandType)7;
            }
            else if (pairs == 2)
            {
                return (HandType)2;
            }

            else if (pairs == 1)
            {
                return (HandType)1;
            }
            else
            {
                return (HandType)0;
            }
            // Am I a straight?
            //bool straight = IsStraight();
            // Do I have pairs? Or more of a kind?
            
            //int mostOfAKind = MostOfAKind();
        }

        private bool IsFullHouse()
        {
            Dictionary<int, int> FHouse = new Dictionary<int, int>();
            for (int i = 0; i < cards.Length; i++)
            {
                if (FHouse.ContainsKey(cards[i].rank))
                {
                    FHouse[cards[i].rank] = FHouse[cards[i].rank] + 1;
                }
                else
                {
                    FHouse[cards[i].rank] = 1;
                }
            }
            if (FHouse.ContainsValue(4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFourOfAKind()
        {
            Dictionary<int, int> Fours = new Dictionary<int, int>();
            for (int i = 0; i < cards.Length; i++)
            {
                if (Fours.ContainsKey(cards[i].rank))
                {
                    Fours[cards[i].rank] = Fours[cards[i].rank] + 1;
                }
                else
                {
                    Fours[cards[i].rank] = 1;
                }
            }
                if (Fours.ContainsValue(4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        //private bool IsStraight()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Are all cards in the hand the same suit?
        /// </summary>
        private bool IsFlush()
        {
            // iterate through card array
            // checking each card's suit against 1st card
            char suit = cards[0].suit;
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i].suit != suit)
                    return false;
            }
            return true;
        }
        private int CountPairs()
        {
            System.Collections.Generic.Dictionary<int, int> Pairs = new Dictionary<int, int>();
            for (int i = 0; i < cards.Length; i++)
            {
                if (Pairs.ContainsKey(cards[i].rank))
                {
                    Pairs[cards[i].rank] = Pairs[cards[i].rank] + 1;
                }
                else
                {
                    Pairs[cards[i].rank] = 1;
                }
            }
            if (Pairs.ContainsValue(2))
            {
                return 2;
            }
            else if (Pairs.ContainsValue(2))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
