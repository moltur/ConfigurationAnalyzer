using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceUseHistory
    {
        public int ResourceUseHistoryId { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int? ResourceHistoryId { get; set; }

        public virtual ResourceHistory ResourceHistory { get; set; }
    }
}
