namespace excersice_streams
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<Player> players = new List<Player>();

            ILog txtLogger = new TextLogger();
            ILog xlsxLog = new ExcelLogger();

            bool running = true;

            List<string> command = Console.ReadLine()
         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
         .ToList();

            while (command[0] != "exit")
            {

                if (command[0] == "create_team")
                {
                    try
                    {
                        Team team = new Team(command[1]);
                        teams.Add(team);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Cannot create team! Invalid number of parameters. {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Cannot create team! Invalid arguments. {ex.Message}");
                    }
                }

                if (command[0] == "create_player")
                {
                    try
                    {
                        Player player = new Player(command[1], command[2]);
                        players.Add(player);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Cannot create player! Invalid number of parameters. {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Cannot create player! Invalid arguments. {ex.Message}");
                    }
                }

                if (command[0] == "add_player")
                {
                    try
                    {
                        Team? teamToAdd = teams.FirstOrDefault(t => t.Name == command[1]);

                        if (teamToAdd == null)
                        {
                            Console.WriteLine("Team not found!");
                            command = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToList();
                            continue;
                        }

                        Player? playerToAdd = players.FirstOrDefault(t => t.Name == command[2] &&
                            t.Position == command[3]);

                        if (playerToAdd == null)
                        {
                            Console.WriteLine("Player not found!");
                            command = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
<<<<<<< HEAD:ExerciseStreams/excersice-streams/Program.cs
                                .ToList(); command = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
=======
>>>>>>> ee08c5acc4720a4d14004c8c98720bee328a13c7:excersice-streams/Program.cs
                                .ToList();
                            continue;
                        }

                        teamToAdd.AddPlayer(playerToAdd);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Cannot find team or player! Invalid number of parameters. {ex.Message}");
                    }
                }

                if (command[0] == "remove_player")
                {
                    try
                    {
                        Team teamToRemove = teams.FirstOrDefault(t => t.Name == command[1]);

                        if (teamToRemove == null)
                        {
                            Console.WriteLine("Team not found!");
                            command = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToList();
                            continue;
                        }

                        teamToRemove.RemovePlayer(command[2]);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Cannot find team! Invalid number of parameters. {ex.Message}");
                    }
                }

                if (command[0] == "print_team")
                {
                    try
                    {
                        Team teamToPrint = teams.FirstOrDefault(t => t.Name == command[1]);

                        if (teamToPrint == null)
                        {
                            Console.WriteLine("Team not found!");
                            command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                            continue;
                        }

                        string filePathToPrint = command[2];
                        string typeOfLogger = command[3];

                        if (typeOfLogger == "txt")
                        {
                            teamToPrint.PrintTeam(filePathToPrint, txtLogger);
                        }
                        else if(typeOfLogger == "excel")
                        {
                            teamToPrint.PrintTeam(filePathToPrint, xlsxLog);
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Invalid number of parameters! " + ex.Message);
                    }
                }

                if (command[0] == "print_log_txt")
                {
                    try
                    {
                        Team teamToPrintLog = teams.FirstOrDefault(t => t.Name == command[1]);

                        if (teamToPrintLog == null)
                        {
                            Console.WriteLine("Team not found!");
                            command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                            continue;
                        }

                        string filePath = command[2];
                        teamToPrintLog.PrintHistory(filePath, txtLogger);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Invalid number of parameters! " + ex.Message);
                    }
                }

                if (command[0] =="print_log_excel")
                {
                    try
                    {
                        Team teamToPrintLog = teams.FirstOrDefault(t => t.Name == command[1]);

                        if (teamToPrintLog == null)
                        {
                            Console.WriteLine("Team not found!");
                            continue;
                        }

                        string filePath = command[2];
                        teamToPrintLog.PrintHistory(filePath, xlsxLog);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Invalid number of parameters! " + ex.Message);
                    }
                }
       

                    command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
        }
    }
}
