using ExampleExercise.Controllers;

namespace ExampleExercise
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            HotelController hotelController = new HotelController();

            Console.WriteLine("1. Показване на всички гости \r\n" +
                "2. Добавяне на нов гост \r\n" +
                "3. Стаи с цена между 80 и 100 лв (в низходящ ред) \r\n" +
                "4. Изтриване на резервация по ID \r\n" +
                "5. Брой свободни стаи \r\n" +
                "6. Минимална цена по статус \r\n" +
                "7. ID-та на активни резервации \r\n" +
                "0. Изход ");

            Console.Write("Моля, въведете избора си: ");
            string command = Console.ReadLine();
            Console.WriteLine();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        foreach (var item in await hotelController.AllGuests())
                        {
                            Console.WriteLine($"{item.FirstName} {item.LastName}");
                        }
                        break;

                    case "2":
                        Console.Write("Име: ");
                        string firstName = Console.ReadLine();

                        Console.WriteLine();

                        Console.Write("Фамилия:");
                        string lastName = Console.ReadLine();

                        Console.WriteLine();

                        Console.Write("Егн: ");
                        string egn = Console.ReadLine();

                        Console.WriteLine();

                        Console.Write("Телефон: ");
                        string phonenumber = Console.ReadLine();

                        Console.WriteLine();

                        await hotelController.AddGuest(firstName, lastName, egn, phonenumber);

                        Console.WriteLine("Гостът е успешно добавен. ");
                        break;

                    case "3":
                        foreach (var item in await hotelController.GetRoomsBetweenPrice())
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "4":
                        Console.Write("Въведете ID на резервацията:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        await hotelController.DeleteReservation(id);
                        Console.WriteLine($"Резервацията с ID {id} е изтрита успешно. ");
                        break;

                    case "5":
                        Console.WriteLine($"Свободни стаи: {await hotelController.CountOfAvailableRooms()}");
                        break;

                    case "6":
                        Console.Write("Въведете статус на стаята:");
                        string status = Console.ReadLine();

                        Console.WriteLine();

                        Console.WriteLine($"Минимална цена: {await hotelController.MinPrice(status)}lv.");
                        break;

                    case "7":
                        Console.WriteLine("Резервации, които още не са приключили: ");
                        foreach (var item in await hotelController.GetValidReservationsIds())
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    default:
                        break;
                }
                Console.Write("Моля, въведете избора си: ");
                command = Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
