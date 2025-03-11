namespace Library.Models
{
    public class Book
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string genre;

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        private int copyCount;

        public int CopyCount
        {
            get { return copyCount; }
            set { copyCount = value; }
        }

        private int borrowCount;

        public int BorrowCount
        {
            get { return borrowCount; }
            set { borrowCount = value; }
        }

        public Book(string title, string author, string genre, int copyCount)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.CopyCount = copyCount;
            this.BorrowCount = 0;
        }
    }
}
