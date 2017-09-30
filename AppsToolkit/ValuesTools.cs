namespace AppsToolkit
{
    public static class ValuesTools
    {
        public static int NormalizeInt(int value, int valueMin, int valueMax, int valueDefault)
        {
            int result = value;
            if (value < valueMin || value > valueMax) result = valueDefault;
            return result;
        }

        public static string elapsedToString(long totalElapsed)
        {
            return (totalElapsed > 2000) ? string.Format("{0} s", totalElapsed / 1000.00) : string.Format("{0} ms", totalElapsed);
        }
    }
}
