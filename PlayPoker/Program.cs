using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    enum HandType
    {
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }

    class Poker
    {

        static void Main(string[] args)
        {
            string[] hand1 = GetHandFromConsole("Player 1");
            string[] hand2 = GetHandFromConsole("Player 2");

            HandType ht1 = EvaluateHand(hand1);
            HandType ht2 = EvaluateHand(hand2);

            if (ht1 > ht2)
                Console.WriteLine("Player 1's " + ht1 + " beats player 2's " + ht2);
            else if (ht2 > ht1)
                Console.WriteLine("Player 2's " + ht2 + " beats player 1's " + ht1);
            else
                Console.WriteLine("Tie between {0} and {1}!", ht1, ht2);
            Console.ReadLine();
            //{
            //    int tieBreaker = BreakTie(hand1, hand2, ht1);
            //    if (tieBreaker > 0)
            //        Console.WriteLine("Player 1's " + ht1 + " beats player 2's");
            //    else if (tieBreaker < 0)
            //        Console.WriteLine("Player 2's " + ht1 + " beats player 1's");
            //    else
            //        Console.WriteLine("The hands are identical. Split the pot.");
            //}
        }

        /// <summary>
        /// Get 5 cards from the console.
        /// Each card is a string of two characters: rank and suit.
        /// Ranks are: 23456789TJQKA
        /// Suits are: CDHS
        /// Examples: 2C == two of clubs
        ///           TH == ten of hearts
        ///           AS == ace of spades
        /// </summary>
        
        static string[] GetHandFromConsole(string label)
        {
            Console.WriteLine("{0} : Type 5 cards in the form of 2C 5H KS...\n", label);
            string input = Console.ReadLine();
            string[] cards = input.Split(' ');
            return cards;
            
        }

        /// <summary>
        /// Evaluate the hand, to determine broadly what kind of hand it is
        /// </summary>
        /// <param name="cards">An unsorted array of 5 card strings</param>
        /// <returns>One of the hand types</returns>
        static HandType EvaluateHand(string[] cards)
        {
            List<int> cardNums = changeLettersToNums(cards);

            //Check for Straight Flush
            if (isFlush(cards) == true && isStraight(cardNums) == true)
            {
                return HandType.StraightFlush;
            }

            //Check for Flush
            else if (isFlush(cards) == true)
            {
                return HandType.Flush;
            }

            //Check for Straight
            else if (isStraight(cardNums) == true)
            {
                return HandType.Straight;
            }

            //Check for Four of a Kind
            else if (isMultiple(cardNums) == 4)
            {
                return HandType.FourOfAKind;
            }

            //Check for Full House
            else if (isMultiple(cardNums) == 7)
            {
                return HandType.FullHouse;
            }
            //Check for Three
            else if (isMultiple(cardNums) == 3)
            {
                return HandType.ThreeOfAKind;
            }

            //Check for Two Pair
            else if (isMultiple(cardNums) == 5)
            {
                return HandType.TwoPair;
            }

            //Check for Pair
            else if (isMultiple(cardNums) == 2)
            {
                return HandType.Pair;
            }

            //Find High Card
            else if (isMultiple(cardNums) == 0)
            {
                return HandType.HighCard;
            }
            else
                return HandType.HighCard;
        }

        private static int isMultiple(List<int> cardNums)
        {
            Dictionary<int, int> multiplesDictionary = new Dictionary<int, int>();

            foreach (var card in cardNums)
            {
                //string cardString = card.ToString();
                if (!multiplesDictionary.ContainsKey(card))
                    multiplesDictionary.Add(card, 1);
                else
                    multiplesDictionary[card] += 1;
            }

            //Full House
            if (multiplesDictionary.ContainsValue(2) && multiplesDictionary.ContainsValue(3))
            {
                return 7;
            }
            //Four of A Kind
            else if (multiplesDictionary.ContainsValue(4))
            {
                return 4;
            }
            //Three of A Kind
            else if (multiplesDictionary.ContainsValue(3))
            {
                return 3;
            }
            //Two Pair or Pair
            else if (multiplesDictionary.ContainsValue(2))
            {
                int pairs = 0;
                int result = 0;
                foreach (var pair in multiplesDictionary)
                {
                    if (pair.Value == 2)
                    {
                        pairs += 1;
                    }
                }
                if (pairs == 2)
                {
                    return result = 5;
                }
                if (pairs == 1)
                {
                    return result = 2;
                }
                return result;
            }
            //High Card
            else
            {
                return 0;
            }
        }

        private static List<int> changeLettersToNums(string[] cards)
        {
            List<int> cardNums = new List<int>();

            for (int i = 0; i < cards.Length; i++)
            {
                switch (cards[i][0])
                {
                    case 'T':
                        cardNums.Add(10);
                        break;
                    case 'J':
                        cardNums.Add(11);
                        break;
                    case 'Q':
                        cardNums.Add(12);
                        break;
                    case 'K':
                        cardNums.Add(13);
                        break;
                    case 'A':
                        cardNums.Add(14);
                        break;
                    default:
                        cardNums.Add(cards[i][0]);
                        break;
                }
            }
            foreach (var card in cardNums)
            {
                Console.WriteLine(card);
            }
            return cardNums;

        }

        private static bool isFlush(string[] cards)
        {
            return false;
        }

        private static bool isStraight(List<int> arr)
        {
            //int pivot = arr[0];
            //List<int> leftArr = new List<int>();
            //List<int> rightArr = new List<int>();

            //if (arr.Count == 0)
            //{
            //    return 
            //}
            return false;
        }

        private static string highCard(string[] cards)
        {
            int highestCardValue = 0;
            string highestCard = "";
            for (int i = 0; i < cards.Length; i++)
            {
                for (int k = 0; i < 2; i++)
                {
                    if (cards[i][0] > highestCardValue)
                    {
                        highestCardValue = cards[i][0];
                        highestCard = cards[i];
                    }
                }
            }
            return highestCard;
        }

        /// <summary>
        /// Only called if two people have the same hand type.
        /// Determines which one is the better of that type.
        /// For Pairs, ThreeOfAKind, etc., the winner is whomever's pair (3-of-a-kind, ...) is higher
        /// For TwoPair, compare the better pair, and then the lower pair, so 8s & 4s beats 7s & 6s.
        /// For everything else, including for pairs that remain tied, compare best card against 
        /// best card, then 2nd against 2nd, etc.
        /// </summary>
        /// <param name="cards1">Player 1s cards</param>
        /// <param name="cards2">Player 2s cards</param>
        /// <param name="ht">The hand type that was already determined (and the same for both)</param>
        /// <returns>a positive number is cards1 is better; 
        ///          a negative number if cards2 is better;
        ///          zero if they are still tied</returns>
        static int BreakTie(string[] cards1, string[] cards2, HandType ht)
        {
            return 0; // TODO
        }
    }
}
