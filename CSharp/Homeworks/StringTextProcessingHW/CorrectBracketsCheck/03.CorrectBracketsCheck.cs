using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CorrectBracketsCheck
{/*03. Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).*/
    /*TESTS
     (-15)+25*48*(4+58%68)
     -15)+25*48*(4+58%68)
     -15)+25*(8*(4+58%68)
     (-15)+25*8)*(4+58%(68)
     (-15)+25*8(*(4+58%(68)))
     (-15)+(25*8*)(4+58%(68)
     (-15)+(25*8%)(4+58%(68))
     */
    class CorrectBracketsCheckClass
    {
        static void Main(string[] args)
        {
            string expr = string.Empty;
            while (expr != "end")
            {
                try
                {
                    Console.Write("Insert the expression or end: ");
                    expr = Console.ReadLine().Replace(" ", "").ToLower();
                    if (expr == string.Empty) throw new Exception("Expression can not be empty!");
                    if (expr == "end") return;
                    //if the number of opening and closing brackets is different
                    // or a closing bracket ocuurs without a pair of (),throw Exception
                    byte bracketPair = 0;
                    for (int i = 0; i < expr.Length; i++)
                    {
                        if (expr[i] == '(') bracketPair++;
                        if (expr[i] == ')')
                        {
                            if (bracketPair <= 0)
                            {
                                throw new Exception("There is a closing bracket before an opening bracket was put.");
                            }
                            else bracketPair--;
                        }
                    }
                    if (bracketPair != 0) throw new Exception("The expression is invalid: the number of opening and closing brackets is different.");
                    //#region Different Brackets number
                    //Regex openBracket = new Regex(@"[(]");
                    //Regex closingBracket = new Regex(@"[)]");
                    //MatchCollection openings = openBracket.Matches(expr);
                    //MatchCollection closings = closingBracket.Matches(expr);
                    //if (closings.Count != openings.Count) throw new Exception("The expression is invalid: the number of opening and closing brackets is different.");
                    //#endregion

                    List<string> regExpr = new List<string> {@"^[0-9a-f+\-\*\/\%\^]*[)]+[0-9a-f\+\-\*\/\%\^)(]*",//Closing before opening bracket
                    @"[0-9a-z\/\*\-\+\^)(]*[(]+[0-9a-z\/\*\-\+\^(]+$",//not closed opening bracket
                    @"[(][)\*\/\%\^]+",//operator *, /, % or closing bracket directly after an opening bracket
                    @"[(][\-\+]+[\+\-\*\/\%\^]",//operators *,+,-,/ or % after +,- directly after an opening bracket
                    @"[\/\*\+\-\%\^(]+[)]",//closing bracket after an operator or after an opening bracket
                };
                    foreach (var item in regExpr)
                    {
                        Regex regex = new Regex(@"" + item + @"");
                        if (regex.IsMatch(expr)) throw new Exception("The expression is invalid: " + item);
                    }
                    Console.WriteLine("The brackets in the expression are put correctly.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
