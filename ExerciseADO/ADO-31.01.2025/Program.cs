using Microsoft.Data.SqlClient;

namespace ADO_31._01._2025
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using(sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT g.first_name, g.last_name, r.days, rm.number FROM [reservations] r JOIN guests g ON r.guest_id = g.id JOIN rooms rm ON r.room_id = rm.id",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]} - {sqlDataReader[2]} - {sqlDataReader[3]}");
                    }
                }
            }
        }

        public void Exc1()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT TOP 5 [number], [status], [price] FROM [rooms] " +
                    "WHERE [price] BETWEEN 80 AND 100 ORDER BY [price] DESC",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]} - {sqlDataReader[2]}");
                    }
                }
            }
        }

        public void Exc2()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT [first_name], [last_name] FROM [guests] WHERE [phone_number] LIKE '0033%'",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
                    }
                }
            }
        }

        public void Exc3()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT [status], MIN(price) as [Min Price] FROM [rooms] GROUP BY [status]",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
                    }
                }
            }
        }

        public void Exc4()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT TOP 1 [accommodation_date], [release_date] FROM [reservations] ORDER BY [days] DESC",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
                    }
                }
            }
        }   

        public void Exc5()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT [number], [status] FROM [rooms] WHERE [room_type_id] = 2",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
                    }
                }
            }
        }

        public void Exc6()
        {
            string connectionString = @"Data Source=DESKTOP-6VQ6QDR\SQLEXPRESS;Initial Catalog=hotel_manager;Integrated Security=True;Encrypt=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
                SqlCommand firstExc = new SqlCommand("SELECT [accommodation_date], [release_date] FROM [reservations] rs JOIN rooms rm ON rm.id = rs.room_id WHERE rm.status = 'busy'",
                    sqlConnection);

                SqlDataReader sqlDataReader = firstExc.ExecuteReader();

                using (sqlDataReader)
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine($"{sqlDataReader[0]} - {sqlDataReader[1]}");
                    }
                }
            }
        }
    }
}
