using ClosedXML.Excel;

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

        private List<string> logHistory = new();

        public Team(string name)
        {
            this.Name = name;
            this.players = new();
            this.logHistory.Add($"Team {name} has been created at {DateTime.Now}.");
        }


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
            this.logHistory.Add($"Player {player.Name} joined team {this.Name} at {DateTime.Now}.");
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player != null)
            {
                players.Remove(player);
                this.logHistory.Add($"At {DateTime.Now} player {playerName} left the team {this.Name}.");
            }
        }

        public void PrintTeam(string filePath, ILog logPrint)
        {
            logPrint.Log("Print");
            logPrint.Log($"Team {this.Name}");

            foreach (var player in this.players)
            {
                logPrint.Log($"{player.Name} at position - {player.Position}");
            }

            logPrint.Save(filePath);
        }

        public void PrintHistory(string filePath, ILog logForHistory)
        {
            logForHistory.Log("History");
            logForHistory.Log($"Team {this.Name}");

            foreach (var line in this.logHistory)
            {
                logForHistory.Log(line);
            }
            logForHistory.Save(filePath);
        }
    }
}
