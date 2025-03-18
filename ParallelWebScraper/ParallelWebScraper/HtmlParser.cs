using HtmlAgilityPack;

namespace ParallelWebScraper
{
    public class HtmlParser
    {
        public static List<string> ExtractHeadlines(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var headlines = new List<string>();
            var headlineNodes = doc.DocumentNode.SelectNodes("//h1");

            if (headlineNodes != null)
            {
                foreach (var node in headlineNodes)
                {
                    headlines.Add(node.InnerText.Trim());
                }
            }

            return headlines;
        }
    }
}
