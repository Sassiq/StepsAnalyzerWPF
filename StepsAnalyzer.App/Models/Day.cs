using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsAnalyzer.Models
{
    internal class Day
    {
        public uint Number { get; init; }
        public uint UserRank { get; init; }
        public uint UserSteps { get; init; }
        public Status Status { get; init; }
    }

    internal enum Status
    {
        Finished,
        InProgress,
        Refused
    }
}
