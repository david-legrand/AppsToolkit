using System;
using System.Diagnostics;
using System.IO;

namespace AppsToolkit
{
    public static class FilesTools
    {
        public static void GenerateData(int nbFiles, int totalFilesMB)
        {
            int sizeMB = totalFilesMB / nbFiles;
            string tempFolderName = Path.GetTempPath() + Path.GetRandomFileName();
            Directory.CreateDirectory(tempFolderName);

            byte[] data = new byte[8192];
            Random rng = new Random();

            for (int i = 0; i < nbFiles; i++)
            {
                string fileName = string.Format(@"{0}\{1}.{2}", tempFolderName, i, Path.GetRandomFileName());
                using (FileStream stream = File.OpenWrite(fileName))
                {
                    for (int j = 0; j < sizeMB * 128; j++)
                    {
                        rng.NextBytes(data);
                        stream.Write(data, 0, data.Length);
                    }
                }
            }

            Process.Start(tempFolderName);
        }

        public static string CleanDirectoryName(string path)
        {
            string cleanedPath = path;
            int length = path.Length;
            char pathLastCaracter = path[length - 1];

            if (pathLastCaracter.Equals('\\') || pathLastCaracter.Equals('"')) cleanedPath = path.Remove(length - 1);

            return cleanedPath;
        }
    }
}
