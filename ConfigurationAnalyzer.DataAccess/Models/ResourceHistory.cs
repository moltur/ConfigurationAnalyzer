using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ResourceHistory
    {
        public ResourceHistory()
        {
            ResourceUseHistory = new HashSet<ResourceUseHistory>();
        }

        public int ResourceHistoryId { get; set; }
        public string ResourceName { get; set; }
        public int ResourceId { get; set; }
        public int UseTime { get; set; }
        public int Downtime { get; set; }
        public decimal Cost { get; set; }
        public int? SimulationHistoryId { get; set; }

        public virtual SimulationHistory SimulationHistory { get; set; }
        public virtual ICollection<ResourceUseHistory> ResourceUseHistory { get; set; }
    }
}
