using FormulaOne_2._0.Controllers;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne_2._0.Presentation
{
    public class Display
    {
        private DriverController DriverController { get; set; } = new DriverController();

        private TeamController TeamController { get; set; } = new TeamController();

        public async Task ShowMenu()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Get Teams ");
            Console.WriteLine("2. Get Team By Id ");
            Console.WriteLine("3. Get Teams By Country ");
            Console.WriteLine("4. Get Oldest Team ");
            Console.WriteLine("5. Get Drivers ");
            Console.WriteLine("6. Get Driver By Id ");
            Console.WriteLine("7. Get Driver By Last Name ");
            Console.WriteLine("8. Get Drivers By Nationality ");
            Console.WriteLine("--------------------");

            string command = Console.ReadLine();

            while (command != "0")
            {
                try
                {
                    switch (command)
                    {
                        case "1":
                            var getTeams =  await TeamController.GetAllTeams();

                            if (getTeams.Count == 0)
                            {
                                Console.WriteLine("Not teams yet");
                            }

                            foreach (var item in getTeams)
                            {
                                Console.WriteLine($"{item.TeamName} - {item.Country} - {item.FoundationYear}");
                            }
                            
                            break;

                        case "2":
                            Console.WriteLine("Id: ");

                            int id = int.Parse(Console.ReadLine());

                            var teamById = await TeamController.GetTeamById(id);

                            if (teamById == null)
                            {
                                Console.WriteLine("No team found");
                            }

                            Console.WriteLine($"{teamById.TeamName} - {teamById.Country} - {teamById.FoundationYear}");
                            break;

                        case "3":
                            Console.WriteLine("Country: ");
                            string country = Console.ReadLine();

                            var teamsByCountry = await TeamController.GetTeamsByCountry(country);

                            if (teamsByCountry.Count == 0)
                            {
                                Console.WriteLine("There are no teams from this country");
                            }

                            foreach (var item in teamsByCountry)
                            {
                                Console.WriteLine($"{item.TeamName} - {item.Country} - {item.FoundationYear}");
                            }
                            break;

                        case "4":
                            var oldestTeam = await TeamController.GetOldestTeam();

                            Console.WriteLine($"{oldestTeam.TeamName} {oldestTeam.Country}");
                            break;

                        case "5":
                            var drivers = await DriverController.GetAllDrivers();

                            if (drivers.Count == 0)
                            {
                                Console.WriteLine("There are no drivers");
                            }

                            foreach (var item in drivers)
                            {
                                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Nationality} - {item.BirthDate}");
                            }
                            break;

                        case "6":
                            Console.WriteLine("Id: ");
                            int idDriver = int.Parse(Console.ReadLine());

                            var driverById = await DriverController.GetDriverById(idDriver);

                            if (driverById == null)
                            {
                                Console.WriteLine("No driver found");
                            }

                            Console.WriteLine($"{driverById.FirstName} {driverById.LastName} - {driverById.Nationality} - {driverById.BirthDate}");
                            break;

                        case "7":
                            Console.WriteLine("Last Name: ");
                            string lastName = Console.ReadLine();

                            var driversByLastName = await DriverController.GetDriversByLastName(lastName);

                            if (driversByLastName.Count == 0)
                            {
                                Console.WriteLine("There are no drivers found");
                            }

                            foreach (var item in driversByLastName)
                            {
                                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Nationality} - {item.BirthDate}");
                            }
                            break;

                        case "8":
                            Console.WriteLine("Nationality: ");
                            string nationality = Console.ReadLine();

                           var driversByNationality = await DriverController.GetDriversByNationality(nationality);

                            if (driversByNationality.Count == 0)
                            {
                                Console.WriteLine("There are no drivers found");
                            }

                            foreach (var item in driversByNationality)
                            {
                                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Nationality} - {item.BirthDate}");
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                command = Console.ReadLine();
            }
        }
    }
}
