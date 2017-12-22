using System;
using System.Net.Http;
using AngleSharp.Parser.Html;
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
                sampleAsync().Wait();
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

            //HTMLをストリームで持ってくる
            var doc = default(IHtmlDocument);
            using (var stream = await client.GetStreamAsync(new Uri(url)))
            {
                var parser = new HtmlParser();
                doc = await parser.ParseAsync(stream);
            }

            //日付とカウントを表示
            foreach (var item in doc.QuerySelectorAll("g > rect"))
            {
                Console.Write(item.Attributes["data-date"].Value + ":");
                Console.WriteLine(item.Attributes["data-count"].Value);               
            }
        }

    }
}
