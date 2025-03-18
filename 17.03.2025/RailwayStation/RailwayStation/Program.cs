using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RailwayStation.Data.Models;
using System.ComponentModel;

namespace RailwayStation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            RailwayStationDbContext dbContext = new RailwayStationDbContext();

            Console.WriteLine("PICK A NUMBER");
            Console.WriteLine("-------------------");
            Console.WriteLine(" 1. Print all routes");
            Console.WriteLine(" 2. Print all tickets");
            Console.WriteLine(" 3. Print all tracks");
            Console.WriteLine(" 4. Print all trains");
            Console.WriteLine(" 5. Print all employees");
            Console.WriteLine(" 6. Add a route");
            Console.WriteLine(" 7. Add a ticket");
            Console.WriteLine(" 8. Add a track");
            Console.WriteLine(" 9. Add a train");
            Console.WriteLine("10. Add a train");
            Console.WriteLine("11. Delete a route");
            Console.WriteLine("12. Delete a ticket");
            Console.WriteLine("13. Delete a track");
            Console.WriteLine("14. Delete a train");
            Console.WriteLine("15. Delete an employee");
            Console.WriteLine("16. Update a route");
            Console.WriteLine("17. Update a ticket");
            Console.WriteLine("18. Update a track");
            Console.WriteLine("19. Update a train");
            Console.WriteLine("20. Update an employee");
            Console.WriteLine("21. Filter routes by station");
            Console.WriteLine("22. Filter tickets by price");
            Console.WriteLine("23. Filter trains by capacity");
            Console.WriteLine("24. Filter employees by position");
            Console.WriteLine("25. Filter tracks by station");
            Console.WriteLine();

            string command = Console.ReadLine();

            while (true)
            {
                switch (command)
                {
                    case "1":
                        var routes = await dbContext.Routes
                           .Select(r => new
                           {
                               DepartrueStation = r.DepartureStation,
                               ArrivalStation = r.ArrivalStation,
                               DepartureTime = r.DepartureTime,
                               ArrivalTime = r.ArrivalTime,
                               TrainNumber = r.Train.TrainNumber
                           })
                           .ToListAsync();

                        foreach (var item in routes)
                        {
                            Console.WriteLine($"|{item.TrainNumber}| {item.DepartrueStation}/{item.DepartureTime} - {item.ArrivalStation}/{item.ArrivalTime}");
                        }

                        break;

                    case "2":
                        var tickets = await dbContext.Tickets
                            .Select(t => new
                            {
                                PassengerName = t.PassengerName,
                                SeatNumber = t.SeatNumber,
                                TrainNumber = t.Train.TrainNumber,
                                DepartureTime = t.Route.DepartureTime,
                                ArrivalTime = t.Route.ArrivalTime,
                                DepartureStation = t.Route.DepartureStation,
                                ArrivalStation = t.Route.ArrivalStation,
                                Price = t.Price
                            })
                            .ToListAsync();

                        foreach (var item in tickets)
                        {
                            Console.WriteLine($"{item.PassengerName}");
                            Console.WriteLine($"Departure: {item.DepartureStation} / {item.DepartureTime}");
                            Console.WriteLine($"Arrival: {item.ArrivalStation} / {item.ArrivalTime}");
                            Console.WriteLine($"{item.SeatNumber}");
                            Console.WriteLine($"{item.Price}lv");
                            Console.WriteLine();
                        }
                        break;

                    case "3":
                        var tracks = await dbContext.Tracks
                           .Select(t => new
                           {
                              StationName = t.StationName,
                              TrackNumber = t.TrackNumber,
                              TrainNumber = t.Train.TrainNumber
                           })
                           .ToListAsync();

                        foreach (var item in tracks)
                        {
                            Console.WriteLine($"{item.StationName} - {item.TrackNumber} - {item.TrainNumber}");
                        }
                        break;

                    case "4":
                        var trains = await dbContext.Trains
                           .Select(t => new
                           {
                              TrainNumber = t.TrainNumber,
                              Capacity = t.Capacity
                           })
                           .ToListAsync();

                        foreach (var item in trains)
                        {
                            Console.WriteLine($"{item.TrainNumber} - {item.Capacity}");
                        }
                        break;

                    case "5":
                        var employees = await dbContext.Employees
                           .Select(e => new
                           {
                               Name = e.Name,
                               Position = e.Position,
                               TrainNumber = e.Train.TrainNumber
                           })
                           .ToListAsync();

                        foreach (var item in employees)
                        {
                            Console.WriteLine($"{item.Name} - {item.Position} - {item.TrainNumber}");
                        }
                        break;

                    case "6":
                        Console.Write("Departure Station: ");
                        string departureStation = Console.ReadLine();
                        Console.Write("Arrival Station: ");
                        string arrivalStation = Console.ReadLine();
                        Console.Write("Departure Time (yyyy-MM-dd HH:mm): ");
                        DateTime departureTime = DateTime.Parse(Console.ReadLine());
                        Console.Write("Arrival Time (yyyy-MM-dd HH:mm): ");
                        DateTime arrivalTime = DateTime.Parse(Console.ReadLine());
                        Console.Write("Train ID: ");
                        int trainId = int.Parse(Console.ReadLine());

                        var newRoute = new Route 
                        { 
                            DepartureStation = departureStation,
                            ArrivalStation = arrivalStation,
                            DepartureTime = departureTime,
                            ArrivalTime = arrivalTime,
                            TrainId = trainId
                        };

                        dbContext.Routes.Add(newRoute);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine("Route added successfully.");
                        break;

                    case "7":
                        Console.Write("Passenger Name: ");
                        string passengerName = Console.ReadLine();
                        Console.Write("Seat Number: ");
                        string seatNumber = Console.ReadLine();
                        Console.Write("Route ID: ");
                        int routeId = int.Parse(Console.ReadLine());
                        Console.Write("Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        var newTicket = new Ticket
                        { 
                            PassengerName = passengerName,
                            SeatNumber = seatNumber,
                            RouteId = routeId, 
                            Price = price
                        };

                        dbContext.Tickets.Add(newTicket);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine("Ticket added successfully.");
                        break;

                    case "8":
                        Console.Write("Station Name: ");
                        string stationName = Console.ReadLine();
                        Console.Write("Track Number: ");
                        int trackNumber = int.Parse(Console.ReadLine());
                        Console.Write("Train ID: ");
                        int trackTrainId = int.Parse(Console.ReadLine());

                        var newTrack = new Track
                        {
                            StationName = stationName,
                            TrackNumber = trackNumber,
                            TrainId = trackTrainId
                        };

                        dbContext.Tracks.Add(newTrack);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine("Track added successfully.");
                        break;

                    case "9":
                        Console.Write("Train Number: ");
                        string trainNumber = Console.ReadLine();
                        Console.Write("Capacity: ");
                        int capacity = int.Parse(Console.ReadLine());

                        var newTrain = new Train 
                        { 
                            TrainNumber = trainNumber,
                            Capacity = capacity
                        };

                        dbContext.Trains.Add(newTrain);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine("Train added successfully.");
                        break;

                    case "10":
                        Console.Write("Employee Name: ");
                        string employeeName = Console.ReadLine();
                        Console.Write("Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Train ID: ");
                        int employeeTrainId = int.Parse(Console.ReadLine());

                        var newEmployee = new Employee 
                        {
                            Name = employeeName,
                            Position = position, 
                            TrainId = employeeTrainId 
                        };

                        dbContext.Employees.Add(newEmployee);
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine("Employee added successfully.");
                        break;

                    case "11":
                        Console.Write("Route ID to delete: ");
                        int deleteRouteId = int.Parse(Console.ReadLine());
                        var route = await dbContext.Routes.FindAsync(deleteRouteId);

                        if (route != null)
                        {
                            dbContext.Routes.Remove(route);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Route deleted successfully.");
                        }
                        break;

                    case "12":
                        Console.Write("Ticket ID to delete: ");
                        int deleteTicketId = int.Parse(Console.ReadLine());
                        var ticket = await dbContext.Tickets.FindAsync(deleteTicketId);

                        if (ticket != null)
                        {
                            dbContext.Tickets.Remove(ticket);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Ticket deleted successfully.");
                        }
                        break;

                    case "13":
                        Console.Write("Track ID to delete: ");
                        int deleteTrackId = int.Parse(Console.ReadLine());
                        var track = await dbContext.Tracks.FindAsync(deleteTrackId);

                        if (track != null)
                        {
                            dbContext.Tracks.Remove(track);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Track deleted successfully.");
                        }
                        break;

                    case "14":
                        Console.Write("Train ID to delete: ");
                        int deleteTrainId = int.Parse(Console.ReadLine());
                        var train = await dbContext.Trains.FindAsync(deleteTrainId);

                        if (train != null)
                        {
                            dbContext.Trains.Remove(train);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Train deleted successfully.");
                        }
                        break;

                    case "15":
                        Console.Write("Employee ID to delete: ");
                        int deleteEmployeeId = int.Parse(Console.ReadLine());
                        var employee = await dbContext.Employees.FindAsync(deleteEmployeeId);

                        if (employee != null)
                        {
                            dbContext.Employees.Remove(employee);
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Employee deleted successfully.");
                        }
                        break;

                    case "16":
                        Console.Write("Route ID to update: ");
                        int updateRouteId = int.Parse(Console.ReadLine());
                        var updateRoute = await dbContext.Routes.FindAsync(updateRouteId);
                        if (updateRoute != null)
                        {
                            Console.Write("New Departure Station: ");
                            updateRoute.DepartureStation = Console.ReadLine();
                            Console.Write("New Arrival Station: ");
                            updateRoute.ArrivalStation = Console.ReadLine();
                            Console.Write("New Departure Time (yyyy-MM-dd HH:mm): ");
                            updateRoute.DepartureTime = DateTime.Parse(Console.ReadLine());
                            Console.Write("New Arrival Time (yyyy-MM-dd HH:mm): ");
                            updateRoute.ArrivalTime = DateTime.Parse(Console.ReadLine());
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Route updated successfully.");
                        }
                        break;

                    case "17":
                        Console.Write("Ticket ID to update: ");
                        int updateTicketId = int.Parse(Console.ReadLine());
                        var updateTicket = await dbContext.Tickets.FindAsync(updateTicketId);
                        if (updateTicket != null)
                        {
                            Console.Write("New Passenger Name: ");
                            updateTicket.PassengerName = Console.ReadLine();
                            Console.Write("New Seat Number: ");
                            updateTicket.SeatNumber = Console.ReadLine();
                            Console.Write("New Price: ");
                            updateTicket.Price = decimal.Parse(Console.ReadLine());
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Ticket updated successfully.");
                        }
                        break;

                    case "18":
                        Console.Write("Track ID to update: ");
                        int updateTrackId = int.Parse(Console.ReadLine());
                        var updateTrack = await dbContext.Tracks.FindAsync(updateTrackId);
                        if (updateTrack != null)
                        {
                            Console.Write("New Station Name: ");
                            updateTrack.StationName = Console.ReadLine();
                            Console.Write("New Track Number: ");
                            updateTrack.TrackNumber = int.Parse(Console.ReadLine());
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Track updated successfully.");
                        }
                        break;

                    case "19":
                        Console.Write("Train ID to update: ");
                        int updateTrainId = int.Parse(Console.ReadLine());
                        var updateTrain = await dbContext.Trains.FindAsync(updateTrainId);
                        if (updateTrain != null)
                        {
                            Console.Write("New Train Number: ");
                            updateTrain.TrainNumber = Console.ReadLine();
                            Console.Write("New Capacity: ");
                            updateTrain.Capacity = int.Parse(Console.ReadLine());
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Train updated successfully.");
                        }
                        break;

                    case "20":
                        Console.Write("Employee ID to update: ");
                        int updateEmployeeId = int.Parse(Console.ReadLine());
                        var updateEmployee = await dbContext.Employees.FindAsync(updateEmployeeId);
                        if (updateEmployee != null)
                        {
                            Console.Write("New Employee Name: ");
                            updateEmployee.Name = Console.ReadLine();
                            Console.Write("New Position: ");
                            updateEmployee.Position = Console.ReadLine();
                            await dbContext.SaveChangesAsync();
                            Console.WriteLine("Employee updated successfully.");
                        }
                        break;

                    case "21":
                        Console.Write("Enter departure station to filter: ");
                        string filterStation = Console.ReadLine();
                        var filteredRoutes = await dbContext.Routes
                            .Where(r => r.DepartureStation.Contains(filterStation))
                            .ToListAsync();
                        foreach (var filteredRoute in filteredRoutes)
                        {
                            Console.WriteLine($"{filteredRoute.DepartureStation} - {filteredRoute.ArrivalStation}");
                        }
                        break;

                    case "22":
                        Console.Write("Enter maximum price: ");
                        decimal maxPrice = decimal.Parse(Console.ReadLine());
                        var filteredTickets = await dbContext.Tickets
                            .Where(t => t.Price <= maxPrice)
                            .ToListAsync();
                        foreach (var filteredTicket in filteredTickets)
                        {
                            Console.WriteLine($"{filteredTicket.PassengerName} - {filteredTicket.Price}lv");
                        }
                        break;

                    case "23":
                        Console.Write("Enter minimum train capacity: ");
                        int minCapacity = int.Parse(Console.ReadLine());
                        var filteredTrains = await dbContext.Trains
                            .Where(t => t.Capacity >= minCapacity)
                            .ToListAsync();
                        foreach (var filteredTrain in filteredTrains)
                        {
                            Console.WriteLine($"Train {filteredTrain.TrainNumber} - Capacity: {filteredTrain.Capacity}");
                        }
                        break;

                    case "24":
                        Console.Write("Enter employee position to filter: ");
                        string filterPosition = Console.ReadLine();
                        var filteredEmployees = await dbContext.Employees
                            .Where(e => e.Position.Contains(filterPosition))
                            .ToListAsync();
                        foreach (var filteredEmployee in filteredEmployees)
                        {
                            Console.WriteLine($"{filteredEmployee.Name} - {filteredEmployee.Position}");
                        }
                        break;

                    case "25":
                        Console.Write("Enter station name to filter tracks: ");
                        string trackStation = Console.ReadLine();
                        var filteredTracks = await dbContext.Tracks
                            .Where(t => t.StationName.Contains(trackStation))
                            .ToListAsync();
                        foreach (var filteredTrack in filteredTracks)
                        {
                            Console.WriteLine($"{filteredTrack.StationName} - Track {filteredTrack.TrackNumber}");
                        }
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
