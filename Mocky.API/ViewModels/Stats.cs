namespace Mocky.API.ViewModels
{
    public class Stats
    {
        public long NumberOfMocks { get; set; }
        public long TotalAccess { get; set; }

        public long NumberOfMocksAccessedInMonth { get; set; }
        public long NumberOfMocksCreatedInMonth { get; set; }

        public long NumberOfMocksNeverAccessed { get; set; }
        public long NumberOfMocksNotAccessedInYear { get; set; }

        public long NumberOfDistinctIps { get; set; }
        public double MockAverageLength { get; set; }
    }
}