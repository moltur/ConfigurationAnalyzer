namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class ProcedureHistory
    {
        public ProcedureHistory()
        {
        }

        public int ProcedureHistoryId { get; set; }
        public string ProcedureName { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int WaitingTime { get; set; }
        public int? SimulationHistoryId { get; set; }
        public string ProcedureAlias { get; set; }

        public virtual SimulationHistory SimulationHistory { get; set; }
    }
}
