using System.IO;

namespace ArdalisRating.Utils
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using var stream = File.AppendText("log.txt");
            stream.WriteLine(message);
            stream.Flush();
        }
    }
}
