using System.Runtime;

namespace Library.Models
{
    public class Borrowing
    {
		private Reader reader;

		public Reader Reader
		{
			get { return reader; }
			set { reader = value; }
		}

		private Book book;

		public Book Book
		{
			get { return book; }
			set { book = value; }
		}

		private DateTime borrowingDate;

		public DateTime BorrowingDate
		{
			get { return borrowingDate; }
			set { borrowingDate = value; }
		}

		private DateTime returnDate;

		public DateTime ReturnDate
		{
			get { return returnDate; }
			set { returnDate = value; }
		}

        public Borrowing(Reader reader, Book book, DateTime borrowingDate, DateTime returnDate)
        {
			this.Reader = reader;
			this.Book = book;
			this.BorrowingDate = borrowingDate; 
			this.ReturnDate = returnDate;
        }
    }
}
