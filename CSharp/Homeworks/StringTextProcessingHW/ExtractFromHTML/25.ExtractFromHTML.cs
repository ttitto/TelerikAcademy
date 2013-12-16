using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ExtractFromHTML
{/*25.Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
    <html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>
      */
    class ExtractFromHTMLClass
    {
        static void Main(string[] args)
        {
            //Insert a text that may contain multiple lines
            Console.WriteLine("Insert the HTML text and push ENTER, ctrl+Z, ENTER");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string html = Console.In.ReadToEnd();
            //clears the new line and carriage return from the html
            html = new string(html.Replace('\n', ' ').ToString().ToArray());
            html = new string(html.Replace('\r', ' ').ToString().ToArray());
            //extracts the title
            Regex rgxTitle = new Regex(@"(?<=<title>)\n*.*\n*(?=<\/title>)");
            string strTitle = rgxTitle.Match(html).ToString();
            Console.WriteLine(strTitle);
            //extracts the body inclusive the other tags
            Regex rgxBody = new Regex(@"(?<=<body>).*(?=<\/body>)");
            string completeBody = rgxBody.Match(html).ToString();
            //extracts only the text outside of the tags in the body region
            Regex rgxNoTags = new Regex(@"(?<=>).*?(?=<)");
            MatchCollection matches = rgxNoTags.Matches(completeBody);
            foreach (var item in matches)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
