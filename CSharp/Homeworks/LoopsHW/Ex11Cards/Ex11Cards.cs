using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11Cards
{
    /*11. Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
     * The cards should be printed with their English names. Use nested for loops and switch-case.*/
    class Ex11CardsClass
    {
        static void Main(string[] args)
        {
            string[] suits = new string[4] { "Spades", "Hearts", "Diamonds", "Clubs" };
            foreach (string suit in suits)
            {
                for (int card = 2; card <= 14; card++)
                {
                    switch (card)
                    {
                        case 2: Console.WriteLine("Two of {0}", suit); break;
                        case 3: Console.WriteLine("Three of {0}", suit); break;
                        case 4: Console.WriteLine("Four of {0}", suit); break;
                        case 5: Console.WriteLine("Five of {0}", suit); break;
                        case 6: Console.WriteLine("Six of {0}", suit); break;
                        case 7: Console.WriteLine("Seven of {0}", suit); break;
                        case 8: Console.WriteLine("Eight of {0}", suit); break;
                        case 9: Console.WriteLine("Nine of {0}", suit); break;
                        case 10: Console.WriteLine("Ten of {0}", suit); break;
                        case 11: Console.WriteLine("Jack of {0}", suit); break;
                        case 12: Console.WriteLine("Queen of {0}", suit); break;
                        case 13: Console.WriteLine("King of {0}", suit); break;
                        case 14: Console.WriteLine("Ace of {0}", suit); break;
                    }
                }
            }
        }
    }
}
