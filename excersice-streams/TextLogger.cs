namespace excersice_streams
{
    public class TextLogger: ILog
    {
        public List<string> logs = new List<string>();

        public void Log(string message)
        {
            logs.Add(message);
        }

        public void Save(string filePath)
        {
            //File.WriteAllLines(filePath, logs);
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (string line in logs)
                {
                    streamWriter.WriteLine(line);
                }
            }
            this.logs.Clear();
        }
    }
}
