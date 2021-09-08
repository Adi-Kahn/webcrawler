using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCrawlerAsync();

            Console.ReadLine();

        }

        private static async Task StartCrawlerAsync()
        {

            int id = 248933;
            int jobid = id;

            for (int i = id; i <= 248933; i++)
            {
                try
                {
                    Console.WriteLine(i);
                    var url = "" + i;
                    var httpclient = new HttpClient();
                    var html = await httpclient.GetStringAsync(url);

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    var divs = htmlDocument.DocumentNode.Descendants("div")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("col-sm-9")).ToList();


                    foreach (var div in divs)
                    {

                        var img = div?.Descendants("img").FirstOrDefault().Attributes["src"].Value;
                        var imgatt = div?.Descendants("img").FirstOrDefault().Attributes["alt"].Value;
                        var title = div?.Descendants("h3").FirstOrDefault().InnerText;
                        var firma = div?.Descendants("h4").FirstOrDefault().InnerText;
                        var region = div?.Descendants("h4").FirstOrDefault().InnerText.Split(',')[1].Trim();

                        var li = div.Descendants("div")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Equals("jix_jobtext_add_wrap")).FirstOrDefault();

                        Console.WriteLine(li.InnerText);


                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Page Not Found", e);
                }
            }

            //var img = divs?.Descendants("img").FirstOrDefault().Attributes["src"].Value;

        }
    }
}
