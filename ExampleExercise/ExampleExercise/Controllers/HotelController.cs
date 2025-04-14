using ExampleExercise.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleExercise.Controllers
{
    public class HotelController
    {
        public HotelManagementContext hotelManagementContext;

        public HotelController()
        {
            hotelManagementContext = new HotelManagementContext();
        }

        public async Task<List<Guest>> AllGuests()
        {
            var guests = await hotelManagementContext.Guests
                .ToListAsync();

            return guests;
        }

        public async Task AddGuest(string firstName, string lastName, string ucn, string phonenumber)
        {
            Guest guest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                Ucn = ucn,
                PhoneNumber = phonenumber
            };

            await hotelManagementContext.Guests.AddAsync(guest);

            hotelManagementContext.SaveChanges();
        }

        public async Task<List<int>> GetRoomsBetweenPrice()
        {
            var rooms = await hotelManagementContext.Rooms
                .Where(r => r.Price >= 80 && r.Price <= 100)
                .OrderByDescending(r => r.Price)
                .Select(r => r.Number)
                .ToListAsync();

            return rooms;
        }

        public async Task DeleteReservation(int id)
        {
            var reservation = await hotelManagementContext.Reservations
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation != null)
            {
                hotelManagementContext.Reservations.Remove(reservation);
            }

            hotelManagementContext.SaveChanges();
        }

        public async Task<int> CountOfAvailableRooms()
        {
            int count = await hotelManagementContext.Rooms
                 .Where(r => r.Status == "free")
                 .CountAsync();

            return count;
        }

        public async Task<decimal> MinPrice(string status)
        {
            decimal minPrice = await hotelManagementContext.Rooms
                .Where(r => r.Status == status)
                .OrderBy(r => r.Price)
                .Select(r => r.Price)
                .FirstOrDefaultAsync();

            return minPrice;
        }

        public async Task<List<int>> GetValidReservationsIds()
        {
            List<int> reservationsId = await hotelManagementContext.Reservations
                .Where(r => r.ReleaseDate > DateOnly.FromDateTime(DateTime.Now))
                .Select(r => r.Id)
                .ToListAsync();

            return reservationsId;
        }
    }
}
