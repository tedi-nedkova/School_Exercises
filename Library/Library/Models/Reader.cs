namespace Library.Models
{
    public class Reader
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		private List<Book> books;

		public List<Book> Books
		{
			get { return books; }
			set { books = value; }
		}

        public Reader(string name, int id, int age)
        {
            this.Name = name;
			this.Id = id;
			this.Age = age;
			this.Books = new List<Book>();
        }

    }
}
