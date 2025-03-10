namespace CakeFactrory_2._0.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public List<Cake> Cakes { get; set; } = new List<Cake>();

        public string PhoneNumber { get; set; } = null!;

        public string Address { get; set; } = null!;

        public Customer(int id, string firstName, string lastName, string phoneNumber, string address)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
        }
    }
}
