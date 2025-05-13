using CourierFirm.Core;
using CourierFirm.Data;

namespace CourierFirm.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Display display = new Display();

            await display.SeedDataBase();

            await display.Menu();
        }
    }
}
