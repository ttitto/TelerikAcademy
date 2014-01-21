using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PHPVariables
{
    class PHPVariablesClass
    {
        static List<string> sb = new List<string>();
        static StringBuilder currVar = new StringBuilder();
        static void Main(string[] args)
        {
            string input;
            //if (File.Exists(@"..\..\input3.txt"))
            //{
            //    input = File.ReadAllText(@"..\..\input3.txt");
            //}
            //else
            //{
            //    input = Console.In.ReadToEnd();
            //}
            input = Console.In.ReadToEnd();
            char[] arr = input.Split(new string[] { "<?php\r\n", "?>\r\n" }, StringSplitOptions.RemoveEmptyEntries)[0].ToCharArray();

            //bool isString = false;
            for (int ch = 0; ch < arr.Length; ch++)
            {
                //if is start of string
                ch = CheckInSingleQuotedString(arr, ch);
                ch = CheckInDoubleQuotedString(arr, ch);
                //if one line comment
                if (arr[ch] == '#' || (arr[ch] == '/' && (ch + 1) < arr.Length && arr[ch + 1] == '/'))
                {
                    while (true)
                    {
                        if (arr[ch] == '\r' && (ch + 1) < arr.Length && arr[ch + 1] == '\n')
                        {
                            ch++;
                            break;
                        }
                        else ch++;
                    }
                }
                //if multiple lines comment
                if (arr[ch] == '/' && arr[ch + 1] == '*')
                {
                    while (true)
                    {
                        if (arr[ch] == '*' && (ch + 1) < arr.Length && arr[ch + 1] == '/')
                        {
                            ch++;
                            break;
                        }
                        else ch++;
                    }
                }

                //if variable starts
                ch = ReadVariableName(arr, ch);
            }

            var items = sb.Distinct().OrderBy(item => item.First()).Select(item => item);

            Console.WriteLine(items.Count());
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static int CheckInSingleQuotedString(char[] arr, int ch)
        {
            if (arr[ch] == '\'' && ch - 1 >= 0 && arr[ch - 1] != '\\')
            {
                ch = CheckInDoubleQuotedString(arr, ch);
                do
                {
                    ch++;
                    ch = ReadVariableName(arr, ch);
                } while (arr[ch] == '\'');
            }
            return ch;
        }

        private static int CheckInDoubleQuotedString(char[] arr, int ch)
        {
            if (arr[ch] == '\"' && ch - 1 >= 0 && arr[ch - 1] != '\\')
            {
                ch = CheckInSingleQuotedString(arr, ch);
                do
                {
                    ch++;
                    ch = ReadVariableName(arr, ch);
                } while (arr[ch] == '\"');
            }
            return ch;
        }

        private static int ReadVariableName(char[] arr, int ch)
        {
            if (arr[ch] == '$' && ch - 1 >= 0 && arr[ch - 1] != '\\')
            {
                ch++;
                do
                {
                    currVar.Append(arr[ch]);
                    ch++;
                } while (Char.IsLetter(arr[ch]) || arr[ch] == '_' || Char.IsDigit(arr[ch]));

            }
            if (currVar.ToString() != String.Empty)
            {
                sb.Add(currVar.ToString());
            }
            currVar.Clear();
            return ch;
        }
    }
}
