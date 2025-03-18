using System.Net.Http;
using System.Threading.Tasks;

namespace ParallelWebScraper
{
    public class WebScraper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetHtmlContentAsync(string url)
        {
            await Task.Delay(1000);

            try
            {
                string htmlContent = await client.GetStringAsync(url);
                return htmlContent;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Request error for {url}: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error for {url}: {ex.Message}");
            }

            return null;
        }

        public static async Task<List<string>> ScrapeMultiplePagesAsync(string[] urls)
        {
            var tasks = urls.Select(url => GetHtmlContentAsync(url)).ToArray();
            var htmlContents = await Task.WhenAll(tasks);

            var allHeadlines = new List<string>();
            foreach (var html in htmlContents)
            {
                if (!string.IsNullOrEmpty(html))
                {
                    var headlines = HtmlParser.ExtractHeadlines(html);
                    allHeadlines.AddRange(headlines);
                }
            }

            return allHeadlines;
        }

        public static async Task<List<string>> ScrapeInBatchesAsync(string[] urls, int batchSize)
        {
            var allHeadlines = new List<string>();
            for (int i = 0; i < urls.Length; i += batchSize)
            {
                var batch = urls.Skip(i).Take(batchSize).ToArray();
                var batchHeadlines = await ScrapeMultiplePagesAsync(batch);
                allHeadlines.AddRange(batchHeadlines);
            }

            return allHeadlines;
        }

        public static void WriteToCsv(List<string> data, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var line in data)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV: {ex.Message}");
            }
        }
    }
}
