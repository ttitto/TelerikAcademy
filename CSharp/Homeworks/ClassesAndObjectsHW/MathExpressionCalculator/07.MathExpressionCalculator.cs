using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathExpressionCalculator
{/** Write a program that calculates the value of given arithmetical expression. 
  * The expression can contain the following elements only:
Real numbers, e.g. 5, 18.33, 3.14159, 12.6
Arithmetic operators: +, -, *, / (standard priorities)
Mathematical functions: ln(x), sqrt(x), pow(x,y)
Brackets (for changing the default priorities)
	Examples:
	(3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7)  ~ 10.6
	pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3)  ~ 21.22
	Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".
*/
    class MathExpressionCalculatorClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the expression in infix notation: ");
            string expr = Console.ReadLine().Replace(" ", "");

            Console.WriteLine("The result is {0:F3}", CalculatePostfixExpression(ConvertToRPN(expr)));
        }
        //returns the precedence of the operator
        private static ushort Precedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 2;
                case "*":
                case "/":
                    return 1;
                default: return 0;
            }
        }
        //check if token is a real number
        private static bool IsNumber(string str)
        {
            double dbl;
            if (double.TryParse(str, out dbl) == true) return true;
            else return false;
        }
        //returns the number of arguments an operator or function returns
        //private static ushort NumberOfArguments(string op)
        //{
        //    switch (op)
        //    {
        //        case "/":
        //        case "*":
        //        case "+":
        //        case "-":
        //        case "pow":
        //            return 2;
        //        case "sqrt":
        //        case "ln":
        //            return 1;
        //        default: throw new ArgumentOutOfRangeException("The inserted operator or function is not allowed to be used");
        //    }

        //}
        //converts infix notation to postfix notation
        private static Queue<string> ConvertToRPN(string expr)
        {
            List<string> operators = new List<string> { "*", "/", "+", "-" };
            List<string> functions = new List<string> { "ln", "sqrt", "pow" };
            List<string> brackets = new List<string> { "(", ")" };
            List<string> separator = new List<string> { "," };

            Queue<string> myQueue = new Queue<string>();
            Stack<string> myStack = new Stack<string>();

            string concatenation = null;
            //while there are tokens to be read
            for (int pos = 0; pos < expr.Length; pos++)
            {
                //read a token
                string token = concatenation + expr[pos].ToString();

                //token is number=> add to the Queue
                #region PositiveNegativeNumber
                if (IsNumber(token) || (token == "-" && pos == 0) || (token == "-" && (expr[pos - 1].ToString() == "(" || expr[pos - 1].ToString() == ",")))
                {
                    //check if the next token is number or decimal point
                    int counter = 1;
                    while ((pos + counter) < expr.Length && (expr[pos + counter].ToString() == "." || IsNumber(expr[pos + counter].ToString())))
                    {
                        token = token + expr[pos + counter].ToString();
                        counter++;
                    }
                    pos += counter - 1;
                    myQueue.Enqueue(token);
                    concatenation = null;
                    continue;
                }
                # endregion
                //token is a separator
                #region Separators
                if (separator.Contains(token))
                {

                    while (myStack.Peek() != "(")
                    {
                        /*Until the token at the top of the stack is a left parenthesis,
                         * pop operators off the stack onto the output queue.*/
                        myQueue.Enqueue(myStack.Pop());
                    }
                    /*If the stack runs out without finding a left parenthesis,
                                             * then there are mismatched parentheses.*/
                    if (!myStack.Contains("(")) throw new ArgumentException();
                    concatenation = null;
                    continue;
                }
                #endregion
                //token is bracket
                #region Brackets
                if (brackets.Contains(token))
                {
                    //token is left paranthesis=> push onto the stack
                    if (token == "(") myStack.Push(token);
                    //token is right paranthesis
                    if (token == ")")
                    {
                        /*If the stack runs out without finding a left parenthesis,
                         *then there are mismatched parentheses.*/
                        if (!myStack.Contains("(")) throw new ArgumentException();

                        /*Until the token at the top of the stack is a left parenthesis,*/
                        while (myStack.Peek() != "(")
                        {
                            /* pop operators off the stack onto the output queue.*/
                            myQueue.Enqueue(myStack.Pop());
                        }
                        /*Pop the left parenthesis from the stack, but not onto the output queue.*/
                        if (myStack.Peek() == "(") myStack.Pop();
                        /*If the token at the top of the stack is a function token, pop it onto the output queue.*/
                        if (myStack.Count() > 0 && functions.Contains(myStack.Peek())) myQueue.Enqueue(myStack.Pop());
                    }
                    concatenation = null;
                    continue;
                }
                #endregion
                #region Functions
                if (functions.Contains(token))
                {
                    myStack.Push(token);
                    concatenation = null;
                    continue;
                }
                #endregion
                #region Operators
                //If the token is an operator, o1, then:
                if (operators.Contains(token))
                {
                    /* while there is an operator token, o2, at the top of the stack, and
                       either o1 is left-associative and its precedence is equal to that of o2,
                       or o1 has precedence less than that of o2,*/
                    while (myStack.Count() > 0 && operators.Contains(myStack.Peek()) && Precedence(token) >= Precedence(myStack.Peek()))
                    {
                        //pop o2 off the stack, onto the output queue;
                        myQueue.Enqueue(myStack.Pop());
                    }
                    //push o1 onto the stack.
                    myStack.Push(token);
                    concatenation = null;
                    continue;
                }
                #endregion
                concatenation = token;
            }//end for
            //While there are still operator tokens in the stack:
            while (myStack.Count() > 0)
            {
                //If the operator token on the top of the stack is a parenthesis, then there are mismatched parentheses.
                if (brackets.Contains(myStack.Peek()))
                {
                    throw new ArgumentException("There are mismatched parentheses");
                }
                //Pop the operator onto the output queue.
                myQueue.Enqueue(myStack.Pop());
            }
            return myQueue;
        }
        //calculates the value of a postfix notated expression
        private static double CalculatePostfixExpression(Queue<string> myQueue)
        {
            Stack<string> myStack = new Stack<string>();
            string token;
            //While there are input tokens left 
            while (myQueue.Count > 0)
            {
                //Read the next token from input.
                token = myQueue.Dequeue();
                //If the token is a value, Push it onto the stack.
                if (IsNumber(token))
                {
                    myStack.Push(token);
                }
                //Otherwise, the token is an operator (operator here includes both operators, and functions). 
                else
                {
                    /*If there are fewer than n values on the stack
                    (Error) The user has not input sufficient values in the expression.*/
                    try
                    {
                        string myResult = null;
                        //Else, Pop the top n values from the stack.
                        switch (token)
                        {
                            case "/": { myResult = (1 / double.Parse(myStack.Pop()) * double.Parse(myStack.Pop())).ToString(); break; }
                            case "*": { myResult = (double.Parse(myStack.Pop()) * double.Parse(myStack.Pop())).ToString(); break; }
                            case "+": { myResult = (double.Parse(myStack.Pop()) + double.Parse(myStack.Pop())).ToString(); break; }
                            case "-": { myResult = (-double.Parse(myStack.Pop()) + double.Parse(myStack.Pop())).ToString(); break; }
                            case "pow": { myResult = Pow(exp: myStack.Pop(), myBase: myStack.Pop()).ToString(); break; }
                            case "sqrt": { myResult = Sqrt(myStack.Pop()).ToString(); break; }
                            case "ln": { myResult = Ln(myStack.Pop()).ToString(); break; }
                            default: //throw new ArgumentOutOfRangeException("The inserted operator or function is not allowed to be used");
                                break;
                        }
                        myStack.Push(myResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Calculation could not be done. It is probable that the user has not input sufficient data for the expressions. " + ex.Message);
                    }
                }

            }
            if (myStack.Count > 1)
            {
                throw new Exception(" The user input has too many values");
            }
            else return double.Parse(myStack.Pop());
        }
        //Calculates a Math.Power expression
        private static double Pow(string myBase, string exp)
        {
            double result = 0;
            try
            {
                result = Math.Pow(double.Parse(myBase), double.Parse(exp));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occured while calculating Math.Pow(). " + ex.Message);
            }
            return result;
        }
        //Calculates Math.Log expression
        private static double Ln(string num)
        {
            double result = 0;
            try
            {
                result = Math.Log(double.Parse(num));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occure while calculationg log." + ex.Message);
            }
            return result;
        }
        //Calculates a Math.Sqrt() expression
        private static double Sqrt(string num)
        {
            double result = 0; try
            {
                result = Math.Sqrt(double.Parse(num));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured while calculating SQRT()." + ex.Message);
            }
            return result;
        }
    }
}
