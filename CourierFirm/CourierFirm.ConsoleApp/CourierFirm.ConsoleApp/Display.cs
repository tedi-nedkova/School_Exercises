using CourierFirm.Core;
using CourierFirm.Core.Controllers;
using CourierFirm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace CourierFirm.ConsoleApp
{
    public class Display
    {

        private CourierFirmDbContext context;

        private CourierController courierCtrl;
        private CustomerController customerCtrl;
        private DeliveryRouteController routeCtrl;
        private OfficeContoller officeCtrl;
        private PackageController packageCtrl;
        private VehicleController vehicleCtrl;

        public Display()
        {
            context = new CourierFirmDbContext();

            courierCtrl = new CourierController(context);
            customerCtrl = new CustomerController(context);
            routeCtrl = new DeliveryRouteController(context);
            officeCtrl = new OfficeContoller(context);
            packageCtrl = new PackageController(context);
            vehicleCtrl = new VehicleController(context);
        }

        public async Task SeedDataBase()
        {
            DataSeed dataSeed = new DataSeed(context);

            await dataSeed.SeedOfficesAsync();
            await dataSeed.SeedVehiclesAsync();
            await dataSeed.SeedDeliveryRoutesAsync();
            await dataSeed.SeedCouriersAsync();
            await dataSeed.SeedCouriersVehiclesAsync();
            await dataSeed.SeedCouriersDeliveryRoutesAsync();
            await dataSeed.SeedCustomersAsync();
            await dataSeed.SeedPackagesAsync();
        }

        public async Task Menu()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            PrintNavigation();

            while (true)
            {
                Console.Write("Изберете опция: ");
                Console.WriteLine();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        List<Courier> allCouriers = await courierCtrl.GetAllAsync();
                        
                        allCouriers.ForEach(c => Console.WriteLine($"{c.Id}. {c.Name} ({c.Office.Name}, {c.Vehicle.Model})"));
                        break;

                    case "2":
                        Console.Write("ID на куриер: ");
                        int courierId = int.Parse(Console.ReadLine());

                        Courier courier = await courierCtrl.GetByIdAsync(courierId);
                        if (courier != null)
                        {
                            Console.WriteLine($"{courier.Id}. {courier.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Куриерът не е намерен");
                        }

                        break;

                    case "3":
                        Console.Write("Име на куриер: ");
                        string name = Console.ReadLine();

                        Console.Write("Офис ID: ");
                        int officeId = int.Parse(Console.ReadLine());

                        Console.Write("Превозно средство ID: ");
                        int vehicleId = int.Parse(Console.ReadLine());

                        await courierCtrl.AddAsync(new Courier
                        {
                            Name = name,
                            OfficeId = officeId,
                            VehicleId = vehicleId
                        });

                        Console.WriteLine("Куриера е добавен!");
                        break;

                    case "4":
                        Console.Write("ID на куриер за актуализация: ");
                        int updCourierId = int.Parse(Console.ReadLine());

                        var exist = await courierCtrl.GetByIdAsync(updCourierId);

                        if (exist != null)
                        {
                            Console.Write("Ново име: ");
                            exist.Name = Console.ReadLine();

                            Console.Write("Ново Office ID: ");
                            exist.OfficeId = int.Parse(Console.ReadLine());

                            Console.Write("Ново Vehicle ID: ");
                            exist.VehicleId = int.Parse(Console.ReadLine());

                            await courierCtrl.UpdateAsync(exist);

                            Console.WriteLine("Обновено успешно.");
                        }
                        break;

                    case "5":
                        Console.Write("ID на куриер: ");
                        int courierVhId = int.Parse(Console.ReadLine());

                        List<Vehicle> vehicles = await courierCtrl.GetVehiclesByCourierId(courierVhId);

                        if (vehicles.Count == 0)
                        {
                            Console.WriteLine("Няма намерени превозни средство");
                        }

                        vehicles.ForEach(v => Console.WriteLine($"{v.Id}. {v.Model}"));

                        break;

                    case "6":
                        Console.Write("Име на куриер: ");
                        string courierNameRoute = Console.ReadLine();

                        List<DeliveryRoute> routes = await courierCtrl.GetDeliveryRouteByCourierName(courierNameRoute);

                        if (routes.Count == 0)
                        {
                            Console.WriteLine("Няма намерени маршрути");
                        }

                        routes.ForEach(r => Console.WriteLine($"{r.Id}. {r.StartLocation} → {r.EndLocation}"));
                        break;

                    case "7":
                        Console.Write("ID на куриер: ");
                        int courierIdPck = int.Parse(Console.ReadLine());

                        List<Package> packages = await courierCtrl.GetPackagesByCourierId(courierIdPck);

                        if (packages.Count == 0)
                        {
                            Console.WriteLine("Няма намерени пакети");
                        }

                        packages.ForEach(p => Console.WriteLine($"{p.TrackingNumber} - {p.Type} -> {p.Customer.FirstName} {p.Customer.LastName}"));
                        break;

                    case "8":
                        var allCustomers = await customerCtrl.GetAllAsync();

                        if (allCustomers.Count == 0)
                        {
                            Console.WriteLine("Няма намерени клиенти");
                        }

                        allCustomers.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName}"));
                        break;

                    case "9":
                        Console.Write("ID на клиент: ");
                        int customerId = int.Parse(Console.ReadLine());

                        Customer customer = await customerCtrl.GetByIdAsync(customerId);

                        if (customer == null)
                        {
                            Console.WriteLine("Клиентът не е намерен");
                        }
                        else
                        {
                            Console.WriteLine($"{customer.Id}. {customer.FirstName} {customer.LastName} - {customer.Address} - {customer.PhoneNumber}");
                        }
                        break;

                    case "10":
                        Console.Write("Име: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Фамилия: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Телефонен номер: ");
                        string phoneNumber = Console.ReadLine();

                        Console.Write("E-mail: ");
                        string email = Console.ReadLine();

                        Console.Write("Адрес: ");
                        string address = Console.ReadLine();

                        await customerCtrl.AddAsync(new Customer
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            PhoneNumber = phoneNumber,
                            Address = address
                        });

                        Console.WriteLine("Клиентът е добавен!");
                        break;

                    case "11":
                        Console.Write("ID на клиент: ");
                        int customerIdUpd = int.Parse(Console.ReadLine());

                        var customerToUpdate = await customerCtrl.GetByIdAsync(customerIdUpd);

                        if (customerToUpdate != null)
                        {
                            Console.Write("Ново име: ");
                            customerToUpdate.FirstName = Console.ReadLine();

                            Console.Write("Нова фамилия: ");
                            customerToUpdate.LastName = Console.ReadLine();

                            Console.Write("Нов имейл: ");
                            customerToUpdate.Email = Console.ReadLine();

                            Console.Write("Нов телефонен номер: ");
                            customerToUpdate.PhoneNumber = Console.ReadLine();

                            Console.Write("Нов адрес: ");
                            customerToUpdate.Address = Console.ReadLine();

                            await customerCtrl.UpdateAsync(customerToUpdate);
                            Console.WriteLine("Клиентът е обновен!");
                        }
                        else
                        {
                            Console.WriteLine("Клиентът не е намерен");
                        }
                        break;

                    case "12":
                        List<Customer> active = await customerCtrl.GetCustomersWithActiveDeliveries();

                        if (active.Count == 0)
                        {
                            Console.WriteLine("Няма намерени поръчки");
                        }

                        active.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName}"));
                        break;

                    case "13":
                        List<Customer> topFive = await customerCtrl.GetTopFiveCustomersByPackagesCount();

                        if (topFive.Count == 0)
                        {
                            Console.WriteLine("Няма намерени клиенти");
                        }

                        topFive.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName} ({c.Packages.Count})"));
                        break;

                    case "14":
                        Console.Write("Име на куриер: ");
                        string courierName = Console.ReadLine();

                        List<Customer> customers = await customerCtrl.GetCustomersByCourierName(courierName);

                        if (customers.Count == 0)
                        {
                            Console.WriteLine("Няма клиенти които са обслужвани от този куриер!");
                        }

                        customers.ForEach(c => Console.WriteLine($"{c.Id}. {c.FirstName} {c.LastName}"));
                        break;

                    case "15":
                        List<DeliveryRoute> allRoutes = await routeCtrl.GetAllAsync();

                        if (allRoutes.Count == 0)
                        {
                            Console.WriteLine("Няма намерени маршрути");
                        }

                        allRoutes.ForEach(r => Console.WriteLine($"{r.Id}: {r.StartLocation} → {r.EndLocation}"));
                        break;

                    case "16":
                        Console.Write("ID на маршрут: ");
                        int routeId = int.Parse(Console.ReadLine());

                        DeliveryRoute route = await routeCtrl.GetByIdAsync(routeId);

                        if (route == null)
                        {
                            Console.WriteLine("Маршрутът не е намерен");
                        }
                        else
                        {
                            Console.WriteLine($"{route.Id}. {route.StartLocation} → {route.EndLocation}");
                        }
                        break;

                    case "17":
                        Console.Write("Начална локация: ");
                        string start = Console.ReadLine();

                        Console.Write("Крайна локация: ");
                        string end = Console.ReadLine();

                        await routeCtrl.AddAsync(new DeliveryRoute
                        {
                            StartLocation = start,
                            EndLocation = end
                        });

                        Console.WriteLine("Маршрутът е добавен!");
                        break;

                    case "18":
                        Console.Write("ID на маршрут: ");
                        int routeIdUpd = int.Parse(Console.ReadLine());

                        var routeToUpdate = await routeCtrl.GetByIdAsync(routeIdUpd);

                        if (routeToUpdate != null)
                        {
                            Console.Write("Нова начална локация: ");
                            routeToUpdate.StartLocation = Console.ReadLine();

                            Console.Write("Нова крайна локация: ");
                            routeToUpdate.EndLocation = Console.ReadLine();

                            await routeCtrl.UpdateAsync(routeToUpdate);
                            Console.WriteLine("Маршрутът е обновен!");
                        }
                        else
                        {
                            Console.WriteLine("Няма такъв маршрут.");
                        }

                        break;

                    case "19":
                        Console.Write("ID за изтриване: ");
                        int routeIdDelete = int.Parse(Console.ReadLine());

                        bool routeIsDeleted = await routeCtrl.DeleteAsync(routeIdDelete);

                        if (routeIsDeleted)
                        {
                            Console.WriteLine("Успешно изтриване!");
                        }
                        else
                        {
                            Console.WriteLine("Неуспешно изтриване!");
                        }
                        break;

                    case "20":
                        var allOffices = await officeCtrl.GetAllAsync();

                        if (allOffices.Count == 0)
                        {
                            Console.WriteLine("Няма намерени офиси");
                        }

                        allOffices.ForEach(o => Console.WriteLine($"{o.Id}. {o.Name} - {o.Location}"));
                        break;

                    case "21":
                        Console.Write("ID на офис: ");
                        int officeIdGet = int.Parse(Console.ReadLine());

                        Office office = await officeCtrl.GetByIdAsync(officeIdGet);

                        if (office != null)
                        {
                            Console.WriteLine($"{office.Id}. {office.Name} - {office.Location}");
                        }
                        else
                        {
                            Console.WriteLine("Офисът не е намерен");
                        }
                        break;

                    case "22":
                        Console.Write("Име на офис: ");
                        string officeName = Console.ReadLine();

                        Console.Write("Локация: ");
                        string officeLocation = Console.ReadLine();

                        await officeCtrl.AddAsync(new Office
                        {
                            Name = officeName,
                            Location = officeLocation
                        });

                        Console.WriteLine("Офисът е добавен!");
                        break;

                    case "23":
                        Console.Write("ID на офис: ");
                        int officeIdUpd = int.Parse(Console.ReadLine());

                        var officeToUpdate = await officeCtrl.GetByIdAsync(officeIdUpd);

                        if (officeToUpdate != null)
                        {
                            Console.Write("Ново име: ");
                            officeToUpdate.Name = Console.ReadLine();
                            Console.Write("Нова локация: ");
                            officeToUpdate.Location = Console.ReadLine();

                            await officeCtrl.UpdateAsync(officeToUpdate);
                            Console.WriteLine("Офисът е обновен!");
                        }
                        else
                        {
                            Console.WriteLine("Няма такъв офис.");
                        }
                        break;

                    case "24":
                        Office topOffice = await officeCtrl.GetOfficeWithMostCouriers();

                        if (topOffice == null)
                        {
                            Console.WriteLine("Офисът не е намерен");
                        }
                        else
                        {
                            Console.WriteLine($"{topOffice.Id}. {topOffice.Name} - {topOffice.Couriers.Count} куриери");
                        }

                        break;

                    case "25":
                        var allPackages = await packageCtrl.GetAllAsync();

                        if (allPackages.Count == 0)
                        {
                            Console.WriteLine("Няма намерени пакети");
                        }

                        allPackages.ForEach(p => Console.WriteLine($"{p.Id}. {p.TrackingNumber}"));
                        break;

                    case "26":
                        Console.Write("ID на пакет: ");
                        int packageId = int.Parse(Console.ReadLine());

                        var package = await packageCtrl.GetByIdAsync(packageId);

                        if (package == null)
                        {
                            Console.WriteLine("Пакетът не е намерен");
                        }
                        else
                        {
                            Console.WriteLine($"{package.Id}. {package.TrackingNumber}");
                        }

                        
                        break;

                    case "27":
                        Console.Write("Номер за проследяване: ");
                        string tracking = Console.ReadLine();

                        Console.Write("Тип: ");
                        string packageType = Console.ReadLine();

                        Console.Write("Тегло: ");
                        int weightInKg = int.Parse(Console.ReadLine());

                        Console.Write("ID на клиент: ");
                        int customerIdAdd = int.Parse(Console.ReadLine());

                        Console.Write("Дата на доставка (гггг-мм-дд): ");
                        DateTime deliveryDate = DateTime.Parse(Console.ReadLine());

                        await packageCtrl.AddAsync(new Package
                        {
                            TrackingNumber = tracking,
                            Type = packageType,
                            WeightInKg = weightInKg,
                            CustomerId = customerIdAdd,
                            DeliveryDate = deliveryDate
                        });

                        Console.WriteLine("Пакетът е добавен!");
                        break;

                    case "28":
                        Console.Write("ID на пакет: ");
                        int packageIdUpdate = int.Parse(Console.ReadLine());

                        var packageToUpdate = await packageCtrl.GetByIdAsync(packageIdUpdate);

                        if (packageToUpdate != null)
                        {
                            Console.Write("Нов номер за проследяване: ");
                            packageToUpdate.TrackingNumber = Console.ReadLine();

                            Console.Write("Нов тип: ");
                            packageToUpdate.Type = Console.ReadLine();

                            Console.Write("Ново тегло: ");
                            packageToUpdate.WeightInKg = int.Parse(Console.ReadLine());

                            Console.Write("Нов клиент ID: ");
                            packageToUpdate.CustomerId = int.Parse(Console.ReadLine());

                            Console.Write("Нова дата за доставка (гггг-мм-дд): ");
                            packageToUpdate.DeliveryDate = DateTime.Parse(Console.ReadLine());

                            await packageCtrl.UpdateAsync(packageToUpdate);
                            Console.WriteLine("Пакетът е обновен!");
                        }
                        else Console.WriteLine("Няма такъв пакет.");

                        break;

                    case "29":
                        List<Package> late = await packageCtrl.GetLateDeliveries();

                        if (late.Count == 0)
                        {
                            Console.WriteLine("Няма намерени пакети");
                        }

                        late.ForEach(p => Console.WriteLine($"{p.TrackingNumber} - {p.DeliveryDate.ToString()}"));
                        break;

                    case "30":
                        Console.Write("Тип: ");
                        var type = Console.ReadLine();

                        Console.Write("Минимално тегло: ");
                        int minWeight = int.Parse(Console.ReadLine());

                        Console.Write("Максимално тегло: ");
                        int maxWeight = int.Parse(Console.ReadLine());

                        List<Package> packagesSorted = await packageCtrl.GetPackagesByTypeAndWeight(type, minWeight, maxWeight);

                        if (packagesSorted.Count == 0)
                        {
                            Console.WriteLine("Няма намерени пакети");
                        }

                        packagesSorted.ForEach(p => Console.WriteLine($"{p.TrackingNumber} - {p.Type}"));
                        break;

                    case "31":
                        List<Package> unassigned = await packageCtrl.GetUnassignedPackages();

                        if (unassigned.Count == 0)
                        {
                            Console.WriteLine("Няма намерени пакети");
                        }

                        unassigned.ForEach(p => Console.WriteLine($"{p.TrackingNumber} - {p.Type}"));
                        break;

                    case "32":
                        var allVehicle = await vehicleCtrl.GetAllAsync();

                        if (allVehicle.Count == 0)
                        {
                            Console.WriteLine("Няма намерени превозни средства");
                        }

                        allVehicle.ForEach(v => Console.WriteLine($"{v.Id}. {v.Model} {v.PlateNumber}"));
                        break;

                    case "33":
                        Console.Write("ID на превозно средство: ");
                        int vehicleIdGet = int.Parse(Console.ReadLine());

                        var v = await vehicleCtrl.GetByIdAsync(vehicleIdGet);

                        if (v == null)
                        {
                            Console.WriteLine("Превозното средство не е намерено");
                        }
                        else
                        {
                            Console.WriteLine($"{v.Id}. {v.Model}");
                        }
                        break;

                    case "34":
                        Console.Write("Регистрационен номер: ");
                        string plateNumber = Console.ReadLine();

                        Console.Write("Модел на превозното средство: ");
                        string model = Console.ReadLine();

                        Console.Write("Вид превозното средство: ");
                        string vehicleType = Console.ReadLine();

                        await vehicleCtrl.AddAsync(new Vehicle
                        {
                            Type = vehicleType,
                            PlateNumber = plateNumber,
                            Model = model
                        });

                        Console.WriteLine("Добавено превозно средство!");
                        break;

                    case "35":
                        Console.Write("ID на превозно средство: ");
                        int vehicleIdUpd = int.Parse(Console.ReadLine());

                        var vehToUpdate = await vehicleCtrl.GetByIdAsync(vehicleIdUpd);

                        if (vehToUpdate != null)
                        {
                            Console.Write("Нов модел: ");
                            vehToUpdate.Model = Console.ReadLine();

                            Console.Write("Нов регистрационен номер: ");
                            vehToUpdate.PlateNumber = Console.ReadLine();

                            Console.Write("Нов тип превозно средство: ");
                            vehToUpdate.Type = Console.ReadLine();

                            await vehicleCtrl.UpdateAsync(vehToUpdate);
                            Console.WriteLine("Обновено превозно средство!");
                        }
                        else
                        {
                            Console.WriteLine("Няма такова превозно средство.");
                        }
                        break;

                    case "36":
                        Console.Write("ID за изтриване: ");
                        int vehicleIdDelete = int.Parse(Console.ReadLine());

                        bool vehicleIsDeleted = await packageCtrl.DeleteAsync(vehicleIdDelete);

                        if (vehicleIsDeleted)
                        {
                            Console.WriteLine("Успешно изтриване!");
                        }
                        else
                        {
                            Console.WriteLine("Неуспешно изтриване!");
                        }
                        break;

                    case "37":
                        Console.Write("ID на превозно средство: ");
                        int cvId = int.Parse(Console.ReadLine());

                        List<Courier> cs = await vehicleCtrl.GetCouriersByVehicleId(cvId);

                        if (cs.Count == 0)
                        {
                            Console.WriteLine("Няма намерени куриери");
                        }

                        cs.ForEach(c => Console.WriteLine($"{c.Id}. {c.Name}"));
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невалидна опция.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private void PrintNavigation()
        { 
            Console.WriteLine();
            Console.WriteLine("=== Управление на Теди Експрес ===");
            Console.WriteLine("= За куриери =");
            Console.WriteLine("01. Списък всички");
            Console.WriteLine("02. По ID");
            Console.WriteLine("03. Добавяне");
            Console.WriteLine("04. Актуализация");
            Console.WriteLine("05. Превозни средства по куриер ID");
            Console.WriteLine("06. Маршрути по име на куриер(Име Фамилия)");
            Console.WriteLine("07. Пакети по куриер ID");
            Console.WriteLine();
            Console.WriteLine("= За клиенти =");
            Console.WriteLine("08.  Списък всички");
            Console.WriteLine("09. По ID");
            Console.WriteLine("10. Добавяне");
            Console.WriteLine("11. Актуализация");
            Console.WriteLine("12. Клиенти с активни доставки");
            Console.WriteLine("13. Топ 5 по брой пакети");
            Console.WriteLine("14. Клиенти по куриерско име");
            Console.WriteLine();
            Console.WriteLine("= За маршрути =");
            Console.WriteLine("15. Списък всички");
            Console.WriteLine("16. По ID");
            Console.WriteLine("17. Добавяне");
            Console.WriteLine("18. Актуализация");
            Console.WriteLine("19. Изтриване");
            Console.WriteLine();
            Console.WriteLine("= За офиси =");
            Console.WriteLine("20. Списък всички");
            Console.WriteLine("21. По ID");
            Console.WriteLine("22. Добавяне");
            Console.WriteLine("23. Актуализация");
            Console.WriteLine("24. Офис с най-много куриери");
            Console.WriteLine();
            Console.WriteLine("= За пакети =");
            Console.WriteLine("25. Списък всички");
            Console.WriteLine("26. По ID");
            Console.WriteLine("27. Добавяне");
            Console.WriteLine("28. Актуализация");
            Console.WriteLine("29. Закъснели доставки");
            Console.WriteLine("30. По тип и тегло");
            Console.WriteLine("31. Неназначени");
            Console.WriteLine();
            Console.WriteLine("= За превозни средства =");
            Console.WriteLine("32. Списък всички");
            Console.WriteLine("33. По ID");
            Console.WriteLine("34. Добавяне");
            Console.WriteLine("35. Актуализация");
            Console.WriteLine("36. Изтриване");
            Console.WriteLine("37. Куриери по превозно ID");
            Console.WriteLine();
            Console.WriteLine("0. Изход");
            Console.WriteLine();
        }
    }
}
