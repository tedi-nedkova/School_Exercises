using Library.Models;
using System.ComponentModel;

namespace Library
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Reader> readers = new List<Reader>();

            List<Book> books = new List<Book>();

            List<Borrowing> borrowings = new List<Borrowing>();

            Menu();

            string command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "1":
                        CreateReader(readers);
                        break;

                    case "2":
                        CreateBook(books);
                        break;

                    case "3":
                        BorrowBook(borrowings, readers, books);
                        break;

                    case "4":
                        PrintBooks(books);
                        break;

                    case "5":
                        PrintReaders(readers);
                        break;

                    case "6":
                        PrintReaderBooks(readers);
                        break;

                    case "7":
                        ActiveLoans(borrowings);
                        break;

                    case "8":
                        PrintAvailableBooks(books);
                        break;

                    case "9":
                        LateReturns(borrowings);
                        break;

                    case "10":
                        TopThreeMostBorrowed(books);
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
            Console.WriteLine();
            Console.WriteLine("---Pick a number---");
            Console.WriteLine(" 1. Create a Reader");
            Console.WriteLine(" 2. Create a Book");

            Console.WriteLine(" 3. Specify a Reader to borrow a certain book");
            Console.WriteLine(" 4. Print all books");
            Console.WriteLine(" 5. Print all readers");
            Console.WriteLine(" 6. Print the borrowed books from a certain reader");
            Console.WriteLine(" 7. Print readers with active loans");
            Console.WriteLine(" 8. Print available books");
            Console.WriteLine(" 9. Late returns");
            Console.WriteLine("10. The three most borrowed books");
        }

        public static void CreateReader(List<Reader> readers)
        {
            Console.WriteLine("Id");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Age:");
            int age = int.Parse(Console.ReadLine());

            Reader reader = new Reader(name, id, age);

            readers.Add(reader);

            Console.WriteLine("You successfully created a reader!");
        }

        public static void CreateBook(List<Book> books)
        {
            Console.WriteLine("Title:");
            string title = Console.ReadLine();

            Console.WriteLine("Author");
            string author = Console.ReadLine();

            Console.WriteLine("Genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Count of available copies:");
            int copies = int.Parse(Console.ReadLine());

            Book book = new Book(title, author, genre, copies);

            books.Add(book);

            Console.WriteLine("You successfully created a book!");
        }

        public static void BorrowBook(List<Borrowing> borrowings, List<Reader> readers, List<Book> books)
        {
            Console.WriteLine("Pick a reader (by id)");

            readers.ForEach(r => Console.WriteLine($"{r.Id}. {r.Name}"));

            Console.WriteLine();
            int readerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Pick a book to borrow (by title)");

            books.ForEach(b => Console.WriteLine($"{b.Title} - {b.Author}"));

            Console.WriteLine();
            string bookTitle = Console.ReadLine();

            Console.WriteLine("Date of returning: ");
            DateTime returningDate = DateTime.Parse(Console.ReadLine());

            Reader reader = readers.FirstOrDefault(r => r.Id == readerId);

            Book book = books.FirstOrDefault(b => b.Title == bookTitle);

            if (book.CopyCount > 0)
            {
                book.BorrowCount++;

                book.CopyCount--;

                reader.Books.Add(book);

                Borrowing borrowing = new Borrowing(reader, book, DateTime.Now, returningDate);

                borrowings.Add(borrowing);

                Console.WriteLine($"{reader.Name} successfully borrowed {book.Title}.");
            }
            else
            {
                Console.WriteLine("There are no available copies for this book!");
            }

        }

        public static void PrintBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Available copies: {book.Genre}");
                Console.WriteLine($"Count of borrowings: {book.BorrowCount}");
                Console.WriteLine();
            }
        }

        public static void PrintReaders(List<Reader> readers)
        {
            foreach (Reader reader in readers)
            {
                Console.WriteLine($"Id: {reader.Id}");
                Console.WriteLine($"Name: {reader.Name}");
                Console.WriteLine($"Age: {reader.Age}");
                Console.WriteLine();
            }
        }

        public static void PrintReaderBooks(List<Reader> readers)
        {
            Console.WriteLine("Pick a reader (by id):");
            int readerId = int.Parse(Console.ReadLine());

            Reader reader = readers.FirstOrDefault(x => x.Id == readerId);

            if (reader.Books.Count == 0)
            {
                Console.WriteLine("This reader has'nt borrowed any books!");
            }

            foreach (var book in reader.Books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine();
            }
        }

        public static void ActiveLoans(List<Borrowing> borrowings)
        {
            foreach (Borrowing borrowing in borrowings)
            {
                if (borrowing.ReturnDate > DateTime.Now && borrowing.BorrowingDate < DateTime.Now)
                {
                    Console.WriteLine($"{borrowing.Reader.Id}. {borrowing.Reader.Name} - {borrowing.Reader.Age}");
                }
            }
        }

        public static void PrintAvailableBooks(List<Book> books)
        {
            foreach (Book book in books)
            {
                if (book.CopyCount > 0)
                {
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Genre: {book.Genre}");
                    Console.WriteLine($"Available copies: {book.Genre}");
                    Console.WriteLine($"Count of borrowings: {book.BorrowCount}");
                    Console.WriteLine();
                }
            }
        }

        public static void LateReturns(List<Borrowing> borrowings)
        {
            foreach (var borrowing in borrowings)
            {
                if (borrowing.ReturnDate < DateTime.Now)
                {
                    Console.WriteLine($"{borrowing.Reader.Name} still has'nt returned {borrowing.Book.Title}!");
                }
            }
        }

        public static void TopThreeMostBorrowed(List<Book> books)
        {
            List<Book> ordered = books.OrderByDescending(b => b.BorrowCount).Take(3).ToList();

            foreach (var book in ordered)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Genre: {book.Genre}");
                Console.WriteLine($"Available copies: {book.Genre}");
                Console.WriteLine($"Count of borrowings: {book.BorrowCount}");
                Console.WriteLine();
            }   
        }
    }
}
