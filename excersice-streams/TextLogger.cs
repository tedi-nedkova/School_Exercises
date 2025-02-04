using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            File.WriteAllLines("../../../Files-excercise-streams/" + filePath, logs);
        }
    }
}
