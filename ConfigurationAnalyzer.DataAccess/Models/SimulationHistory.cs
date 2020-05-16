using System;
using System.Collections.Generic;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class SimulationHistory
    {
        public SimulationHistory()
        {
            ProcedureHistory = new HashSet<ProcedureHistory>();
            ResourceHistory = new HashSet<ResourceHistory>();
        }

        public int SimulationHistoryId { get; set; }
        public int Duration { get; set; }
        public decimal TotalCost { get; set; }
        public double Complexity { get; set; }
        public int WaitingTime { get; set; }
        public DateTime DateTime { get; set; }
        public int? SimulationNameId { get; set; }
        public string Username { get; set; }
        public string AuthorName { get; set; }
        public int Step { get; set; }

        public virtual SimulationName SimulationName { get; set; }
        public virtual ICollection<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual ICollection<ResourceHistory> ResourceHistory { get; set; }
    }
}
