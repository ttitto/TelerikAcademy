using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtractPartsOfURL
{/*12.Write a program that parses an URL address given in the format:
    [protocol]://[server]/[resource]
		and extracts from it the [protocol], [server] and [resource] elements.
  * For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"
*/
    class ExtractPartsOfURLClass
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the URL: ");
            string myURL = Console.ReadLine();
            Regex protocol = new Regex(@"^.*?(?=\:\/\/)", RegexOptions.IgnoreCase);
            Regex server = new Regex(@"(?<=\:\/\/).*?(?=\/)", RegexOptions.IgnoreCase);
            Regex resource = new Regex(@"(?<=\:\/\/.*?\/).*$", RegexOptions.IgnoreCase);
            Console.WriteLine("[protocol] = \"{0}\"",protocol.Match(myURL));
            Console.WriteLine("[server] = \"{0}\"", server.Match(myURL));
            Console.WriteLine("[resource] = \"{0}\"", resource.Match(myURL));
        }
    }
}
