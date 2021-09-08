using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    class ExtraCode
    {
        private static async Task StartCrawlerAsync()
        {
            var url = "";
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("PaidJob")).ToList();


            foreach (var div in divs)
            {


                var title = div?.Descendants("b")?.FirstOrDefault().InnerText;

                var img = div?.Descendants("img").FirstOrDefault().Attributes["src"].Value;
                var firma = div?.Descendants("img").FirstOrDefault().Attributes["alt"].Value;
                //var img1 = div?.Descendants("img").FirstOrDefault().Attributes["align"].Value;

                /*.ChildAttributes("img")?.FirstOrDefault().Value*/
                ;
                var regions = div.Descendants("p").FirstOrDefault().InnerText.Split(',')[1].Trim();
                //var li = div.Descendants("p").Where(d => d.InnerText == "p");
                var l = div.Element("p").NextSibling.InnerText;
                //var announce = div.Descendants("p").FirstOrDefault().InnerText;
                //var announce = div.Descendants.Skip("p").InnerText;


            }
        }
    }
}
