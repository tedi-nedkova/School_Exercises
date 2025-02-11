namespace excersice_streams
{
    public class Player
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public Player(string name, string position)
        {
            this.Name = name;
            this.Position = position;
        }
    }
}
