namespace StepsAnalyzer.Models
{
    public class Day
    {
        public uint Number { get; init; }
        public uint UserRank { get; init; }
        public uint UserSteps { get; init; }
        public Status Status { get; init; }
    }

    public enum Status
    {
        Finished,
        InProgress,
        Refused
    }
}
