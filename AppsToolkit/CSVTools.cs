using System.IO;

namespace AppsToolkit
{
    public class CSVTools
    {
        private string basePath, appName;
        private string separator = ";";
        private string extension = ".csv";

        public CSVTools(string app)
        {
            this.basePath = Path.GetTempPath() + app;
            this.appName = app;
        }

        public void Clean()
        {
            string[] csvFiles = Directory.GetFiles(Path.GetTempPath(), "*" + extension);
            foreach (string f in csvFiles)
            {
                if (File.Exists(f)) File.Delete(f);
            }
        }

        public void Append(long memUsed, string process)
        {
            string logFile = GetFilename(process);

            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.Write(memUsed.ToString() + separator);
            }

        }

        public string GetFilename(string process)
        {
            return basePath + "_" + process + extension;
        }
    }
}
