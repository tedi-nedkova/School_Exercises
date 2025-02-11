namespace excersice_streams
{
    public interface ILog
    {
        public void Log(string message);

        public void Save(string filePath);
    }
}
