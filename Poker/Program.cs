using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Hand hand = Get5Cards();
            HandType ht1 = hand.Evaluate();
            
            Hand hand2 = Get5Cards();
            HandType ht2 = hand2.Evaluate();

            // If types are different, better one wins
            if (ht1 > ht2)
                Console.WriteLine("Hand 1 is better");
            else if (ht1 < ht2)
                Console.WriteLine("Hand 2 is better");
            else
            // If types are same, evaluate with a tie breaker
            {
                TieBreak(ht1, hand, hand2);
            }
            Console.ReadLine();
            
        }

        private static void TieBreak(HandType ht1, Hand hand, Hand hand2)
        {
            throw new NotImplementedException();
        }

        static Hand Get5Cards()
        {
            Console.WriteLine("Please enter 5 cards, one per line");
            Hand hand = new Hand();
            for (int i = 0; i < 5; i++)
                hand.cards[i] = ReadCardfromConsole();
            Console.WriteLine("Confirming, your hand is:" + hand);
            return hand;
        }
        static Card ReadCardfromConsole()
        {
            Card c = new Card();
            // two characters: one is suit, one is rank
            // fill in card and return it
            // blank line returns null, meaning done
            while (!c.isValid())
            {
                string s = Console.ReadLine();
                if (s.Length != 2)
                    return null;
                c.SetFromChar(s[0]);
                c.SetFromChar(s[1]);
                if (!c.isValid())
                {
                    Console.WriteLine("Invalid card, try again");
                    c = new Card();
                }
            }
            return c;            
        }
    }
}
