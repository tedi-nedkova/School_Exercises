using FormulaOne_2._0.Presentation;

namespace FormulaOne_2._0
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Display display = new Display();

            await display.ShowMenu();
        }
    }
}
