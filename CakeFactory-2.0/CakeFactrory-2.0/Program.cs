using CakeFactrory_2._0.Models;
using System.Data;

namespace CakeFactrory_2._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Cake> cakes = new List<Cake>();

            List<Ingredient> ingredients = new List<Ingredient>();

            List<Customer> customers = new List<Customer>();

            Menu();

            string command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "1":
                        AddCake(cakes);
                        break;

                    case "2":
                        AddIngredient(ingredients);
                        break;

                    case "3":
                        AddCustomer(customers);
                        break;

                    case "4":
                        AddIngredientToCake(cakes, ingredients);
                        break;

                    case "5":
                        OrderCake(cakes, customers);
                        break;

                    case "6":
                        PrintMinCakePrice(cakes);
                        break;

                    case "7":
                        PrintAlphabeticallyOrderedMenu(cakes);
                        break;

                    case "8":
                        PrintCakePriceBelowSpecificPrice(cakes);
                        break;

                    case "9":
                        Console.WriteLine($"Most ordered cake: {MostOrderedCake(customers)}");
                        break;

                    case "10":
                        EditCustomerInfo(customers);
                        break;

                    default:
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Welcome to Cake Factory!");
            Console.WriteLine();
            Console.WriteLine("---Pick a number---");
            Console.WriteLine(" 1. Create a Cake");
            Console.WriteLine(" 2. Create an Ingredient");
            Console.WriteLine(" 3. Create a Customer");

            Console.WriteLine(" 4. Add an Ingredient to a Cake");
            Console.WriteLine(" 5. Order a Cake for a specified Customer");
            Console.WriteLine(" 6. Print the cake with the lowest price");
            Console.WriteLine(" 7. Print the cake menu alphabetically ordered");
            Console.WriteLine(" 8. Print cakes priced below the specified amount");
            Console.WriteLine(" 9. Print the most ordered cake");
            Console.WriteLine("10. Edit customer's information");
        }

        public static void AddCake(List<Cake> cakes)
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Cake's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Price:");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Occassion:");
            string occassion = Console.ReadLine();

            Console.WriteLine("Size:");
            string size = Console.ReadLine();

            Cake cake = new Cake(id, name, description, price, occassion, size);

            cakes.Add(cake);

            Console.WriteLine("You successfully added a cake!");
        }

        public static void AddIngredient(List<Ingredient> ingredients)
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Product's name:");
            string productName = Console.ReadLine();

            Console.WriteLine("Quantity:");
            decimal quantity = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Measurment unit:");
            string unit = Console.ReadLine();

            Ingredient ingredient = new Ingredient(id, productName, quantity, unit);

            ingredients.Add(ingredient);

            Console.WriteLine("You successfully added a ingredient!");
        }

        public static void AddCustomer(List<Customer> customers)
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("First name:");
            string firstName = Console.ReadLine();


            Console.WriteLine("Last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Address:");
            string address = Console.ReadLine();

            Customer customer = new Customer(id, firstName, lastName, phoneNumber, address);

            customers.Add(customer);

            Console.WriteLine("You successfully added a customer!");
        }

        public static void AddIngredientToCake(List<Cake> cakes, List<Ingredient> ingredients)
        {
            Console.WriteLine("Pick a ingredient and cake");

            ingredients.ForEach(i => Console.WriteLine($"{i.Id}.{i.ProductName} - {i.Quantity}{i.MeasurmentUnit}"));
            Console.WriteLine();
            cakes.ForEach(c => Console.WriteLine($"{c.Id}.{c.Name}"));

            Console.WriteLine("Ingredient id: ");
            int ingredientId = int.Parse(Console.ReadLine());

            Console.WriteLine("Cake id: ");
            int cakeId = int.Parse(Console.ReadLine());
            Cake cake = cakes.FirstOrDefault(c => c.Id == cakeId);

            Ingredient ingredient = ingredients.FirstOrDefault(i => i.Id == ingredientId);

            cake.Ingredients.Add(ingredient);

            Console.WriteLine("You successfully added the ingredient to the cake!");
        }

        public static void OrderCake(List<Cake> cakes, List<Customer> customers)
        {
            Console.WriteLine("Pick a customer and a cake");

            customers.ForEach(c => Console.WriteLine($"{c.Id}.{c.FirstName} {c.LastName}"));
            Console.WriteLine();
            cakes.ForEach(c => Console.WriteLine($"{c.Id}.{c.Name} - {c.Price}lv - {c.Size}"));

            Console.WriteLine("Customer id: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Cake id: ");
            int cakeId = int.Parse(Console.ReadLine());
            Cake cake = cakes.FirstOrDefault(c => c.Id == cakeId);

            Customer customer = customers.FirstOrDefault(i => i.Id == customerId);

            customer.Cakes.Add(cake);
            Console.WriteLine("You successfully ordered a cake for a customer!");
        }

        public static void PrintMinCakePrice(List<Cake> cakes)
        {
            Cake cake = cakes.OrderByDescending(c => c.Price).First();

            Console.WriteLine($"{cake.Id}. {cake.Name}");
            Console.WriteLine($"Price: {cake.Price}lv");
            Console.WriteLine($"Description: {cake.Description}");
            Console.WriteLine($"Occassion: {cake.Occassion}");
            Console.WriteLine($"Size: {cake.Size}");
        }

        public static void PrintAlphabeticallyOrderedMenu(List<Cake> cakes)
        {
            List<Cake> ordered = cakes.OrderBy(c => c.Name).ToList();

            foreach (var item in cakes)
            {
                Console.WriteLine($"Cake: {item.Name}");
                Console.WriteLine($"Size: {item.Size}");
                Console.WriteLine($"Occassion: {item.Occassion}");
                Console.WriteLine($"Price: {item.Price}lv");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Count of ingredients: {item.Ingredients.Count}");
                Console.WriteLine();
            }
        }

        public static void PrintCakePriceBelowSpecificPrice(List<Cake> cakes)
        {
            Console.WriteLine("Input a price:");
            decimal price = decimal.Parse(Console.ReadLine());

            List<Cake> filtered = cakes.Where(c => c.Price < price).ToList();

            filtered.ForEach(c => Console.WriteLine($"{c.Name} - {c.Size} - {c.Price}"));
        }

        public static string MostOrderedCake(List<Customer> customers)
        {
            Dictionary<string, int> kvp = new Dictionary<string, int>();

            foreach (var customer in customers)
            {
                foreach (var cake in customer.Cakes)
                {
                    if (!kvp.ContainsKey(cake.Name))
                    {
                        kvp.Add(cake.Name, 1);
                    }
                    else
                    {
                        kvp[cake.Name]++;
                    }
                }
            }

            string cakeName = kvp.OrderByDescending(v => v.Value).Select(v => v.Key).First();

            return cakeName;
        }

        public static void EditCustomerInfo(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName}"));
            Console.WriteLine();

            Console.WriteLine("Pick a customer:");
            int id = int.Parse(Console.ReadLine());

            Customer? customer = customers.FirstOrDefault(c => c.Id == id);

            Console.WriteLine("Pick a field to edit (firstName/lastName/phoneNumber/address)");
            string field = Console.ReadLine();

            Console.WriteLine("Input a changed info:");
            string? info = Console.ReadLine();

            if (field == "firstName")
            {
                customer.FirstName = info;
            }
            else if (field == "lastName")
            {
                customer.LastName = info;
            }
            else if (field == "phoneNumber")
            {
                customer.PhoneNumber = info;
            }
            else if (field == "address")
            {
                customer.Address = info;
            }

            Console.WriteLine("Changed info:");

            Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName} - {customer.PhoneNumber} - {customer.Address}");

        }
    }
}
