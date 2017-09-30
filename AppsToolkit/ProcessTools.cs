using System.Diagnostics;
using System.Globalization;

namespace AppsToolkit
{
    public static class ProcessTools
    {
        public static long[] getUsedMem(string processToCheck)
        {
            Process[] processes = Process.GetProcesses();
            long totalMemUsed = 0;
            long pCount = 0;

            foreach (Process p in processes)
            {
                if (p.ProcessName.ToLower().Equals(processToCheck.ToLower()))
                {
                    totalMemUsed += p.PrivateMemorySize64;
                    pCount++;
                }
            }

            long[] rA = { totalMemUsed / 1024L / 1024L, pCount };

            return rA;
        }

        public static string getMemUsedString(long[] ProcessUsedMem)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = " ";

            string memUsed = ProcessUsedMem[0].ToString("n", nfi).Split('.')[0];
            string pCount = ProcessUsedMem[1].ToString();

            return string.Format("{0} Mo ({1} processus)", memUsed, pCount);
        }
    }
}
