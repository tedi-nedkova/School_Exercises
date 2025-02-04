namespace excersice_streams
{
    public class Team
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        private ILog logHistory;
        private ILog logPrint;

        public Team(string name, ILog logHistory, ILog logPrint)
        {
            this.Name = name;
            this.logHistory = logHistory;
            this.logPrint = logPrint;
            this.players = new();
            this.logHistory.Log($"Team {name} has been created at {DateTime.Now}.");
        }


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
            this.logHistory.Log($"Player {player.Name} joined team {this.Name} at {DateTime.Now}.");
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player != null)
            {
                players.Remove(player);
                this.logHistory.Log($"At {DateTime.Now} player {playerName} left the team {this.Name}.");
            }
        }

        public void PrintTeam(string filePath)
        {
            this.logPrint.Log($"Team: {this.Name}");

            foreach (var player in this.players)
            {
                this.logPrint.Log($"Player in this team: {player.Name} at {player.Position} position");
            }

            this.logPrint.Save(filePath);
        }

        public void PrintHistory(string filePath)
        {
            this.logHistory.Save(filePath);
        }
    }
}
