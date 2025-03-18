namespace ParallelWebScraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] urls = new string[]
            {
                "https://open.spotify.com/",
                "https://pathfinder.techlab.cloud/",
                "https://guesthouseteodora.com/home"
            };

            foreach (string url in urls)
            {
                string page = WebScraper.GetHtmlContentAsync(url).Result;
                Console.WriteLine(page);
            }
        }
    }
}
