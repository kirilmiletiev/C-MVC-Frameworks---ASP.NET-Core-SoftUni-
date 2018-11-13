
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace ScratcherDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter valid url to get Source code: ");
            var url = Console.ReadLine();

            Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
            // Match the regular expression pattern against a text string.
            Match m = r.Match(url);

            if (m.Success)
            {
                Console.WriteLine(ExtraxtHtmlFromGivenPage(url));
            }
            else
            {
                Console.WriteLine("Sorry. but this url is not valid. Try again later...");
            }

            //while (m.Success)
            //{
            //    Console.WriteLine(ExtraxtHtmlFromGivenPage(url));
            //    //do things with your matching text 
            //    m = m.NextMatch();
            //}

            // UrlAttribute urlAttribute = new UrlAttribute();

            // XmlUrlResolver xmlUrlResolver = new XmlUrlResolver();

            // WebClient webClient = new WebClient();

            // string url = "https://www.imot.bg/pcgi/imot.cgi?act=5&adv=1b151273911055440";

            // var html = ExtraxtHtmlFromGivenPage(url);

            // Console.WriteLine(html);

            // for (int i = 0; i < 200; i++)
            // {
            //     var htmlRaw = ExtraxtHtmlFromGivenPage(url);
            //     System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

            //     Console.WriteLine(i);
            // }
            //var rawHtml =  ExtraxtHtmlFromGivenPage(url);

            // Console.WriteLine(rawHtml);

        }

        private static string  ExtraxtHtmlFromGivenPage(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            WebRequest.DefaultWebProxy = null;//Ensure that we will not loop by going again in the proxy
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string charSet = response.CharacterSet;
            Encoding encoding;
            if (String.IsNullOrEmpty(charSet))
                encoding = Encoding.Default;
            else
                encoding = Encoding.GetEncoding(charSet);
              // encoding = Encoding.GetEncodings()

            StreamReader resStream = new StreamReader(response.GetResponseStream(), encoding);
            return resStream.ReadToEnd();
        }

    }
}
