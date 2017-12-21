using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AngleSharp.Parser.Html;
using AngleSharp.Parser.Css;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;


namespace github_grass
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            try
            {
                sampleAsync();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }

        static async Task sampleAsync()
        {
            string url = "https://github.com/users/ap0sec/contributions";

            Console.WriteLine("async");

            //そもそもパースしてくるのはHTMLでいいのか不明。調査中
            var doc = default(IHtmlDocument);
            using (var stream = await client.GetStreamAsync(new Uri(url)))
            {
                var parser = new HtmlParser();
                doc = await parser.ParseAsync(stream);
            }

            //ここから先がいまいちわかってない
            var title = doc.QuerySelectorAll("svg");

            Console.WriteLine(title);
        }

    }
}
