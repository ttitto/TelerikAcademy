using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11NumbersInWords
{
    /* *11. Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation.
     * Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven"
*/
    class Ex11NumbersInWordsClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert number: ");
            string str = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int partOfNumber;
            partOfNumber = int.Parse(str[0].ToString());
            if (partOfNumber == 0)
            {
                Console.WriteLine("zero");
                return;
            }
            if (str.Substring(1, 2) == "00")
            {
                sb.Append(GetNumberString(partOfNumber, "hundreds"));
                Console.WriteLine(sb.ToString());
                return;
            }
            else
            {
                sb.Append(GetNumberString(partOfNumber, "hundreds"));
                partOfNumber = int.Parse(str.Substring(1, 2));
                sb.Append(GetNumberString(partOfNumber, "rest"));
            }


            Console.WriteLine(sb.ToString());
        }

        private static string GetNumberString(int partOfNumber, string position)
        {
            StringBuilder strBuilder = new StringBuilder();
            bool isFound = true;
            switch (partOfNumber)
            {
                case 1: strBuilder.Append("one");
                    break;
                case 2: strBuilder.Append("two");
                    break;
                case 3: strBuilder.Append("three");
                    break;
                case 4: strBuilder.Append("four");
                    break;
                case 5: strBuilder.Append("five");
                    break;
                case 6: strBuilder.Append("six");
                    break;
                case 7: strBuilder.Append("seven");
                    break;
                case 8: strBuilder.Append("eight");
                    break;
                case 9: strBuilder.Append("nine");
                    break;
                case 10: strBuilder.Append("ten");
                    break;
                case 11: strBuilder.Append("eleven");
                    break;
                case 12: strBuilder.Append("twelfe");
                    break;
                case 13: strBuilder.Append("thirteen");
                    break;
                case 14: strBuilder.Append("fourteen");
                    break;
                case 15: strBuilder.Append("fifteen");
                    break;
                case 16: strBuilder.Append("sixteen");
                    break;
                case 17: strBuilder.Append("seventeen");
                    break;
                case 18: strBuilder.Append("eighteen");
                    break;
                case 19: strBuilder.Append("nineteen");
                    break;
                case 20: strBuilder.Append("twenty");
                    break;
                case 30: strBuilder.Append("thirty");
                    break;
                case 40: strBuilder.Append("fourty");
                    break;
                case 50: strBuilder.Append("fifty");
                    break;
                case 60: strBuilder.Append("sixty");
                    break;
                case 70: strBuilder.Append("seventy");
                    break;
                case 80: strBuilder.Append("eighty");
                    break;
                case 90: strBuilder.Append("ninety");
                    break;
                default: isFound = false;
                    break;
            }
            if (position == "hundreds")
            {
                return strBuilder.ToString() + " hundred ";
            }
            else if (position == "rest" && isFound)
            {
                return "and " + strBuilder.ToString();
            }
            else if (position == "rest" && isFound == false)
            {
                int rest = partOfNumber % 10;
                partOfNumber /= 10;
                partOfNumber *= 10;
                return GetNumberString(partOfNumber, "rest") + " " + GetNumberString(rest, "");
            }

            else
            {
                return strBuilder.ToString();
            }
        }
    }
}
