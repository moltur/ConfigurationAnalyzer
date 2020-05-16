using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class RandomEventHistory
    {
        public int RandomEventHistoryId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int? ProcedureHistoryId { get; set; }
        public string EventAlias { get; set; }
        public string EventName { get; set; }

        public virtual ProcedureHistory ProcedureHistory { get; set; }
    }
}
