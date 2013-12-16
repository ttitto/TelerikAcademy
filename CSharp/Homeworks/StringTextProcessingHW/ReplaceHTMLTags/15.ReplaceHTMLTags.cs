using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ReplaceHTMLTags
{/*15.Write a program that replaces in a HTML document given as string all the tags
  * <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
  * Sample HTML fragment:
  
  <p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. 
  Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
  
  <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
  Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/
    class ReplaceHTMLTagsClass
    {
        static void Main(string[] args)
        {
            //Insert a text that may contain new line symbol
            Console.WriteLine("Insert the text and confirm with ENTER, ctrl+Z, ENTER");
            byte[] inputBuffer = new byte[2048];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string html = Console.In.ReadToEnd();

           html=html.Replace("<a href=\"","[URL=");
           html = html.Replace("\">","]");
           html = html.Replace("</a>","[/URL]");
           Console.WriteLine(html);
        }
    }
}
