using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Models.Reports
{
    abstract class Report
    {

        private int _reportId;
        private DateTime _timestamp;
        private double _latitude;
        private double _longitude;
        private string _description;
        private ReportStatus _status;
        private Priority _priority;
        private Classification _classification;
        private int _reliabilityScore;
        private string _rejectionReason;

        protected Report(int reportId, DateTime timestamp, double latitude,
            double longitude, string description)
        {
            ReportId = reportId;
            Timestamp = timestamp;
            Latitude = latitude;
            Longitude = longitude;
            Description = description;
            Status = ReportStatus.New;
            //Priority = ;
            //Classification = ;
            //ReliabilityScore = ;
            //RejectionReason = ;
        }


        public int ReportId { get => _reportId; protected set => _reportId = value ; }
        public DateTime Timestamp { get => _timestamp; protected set => _timestamp = value ; }
        public double Latitude { get => _latitude; protected set { _latitude = value ; } }
        public double Longitude { get => _longitude; protected set => _longitude = value; }
        public string Description { get => _description; protected set => _description = value; }
        public ReportStatus Status { get => _status; set => _status = value; }
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; }
        public string RejectionReason { get; set; }


        /// <summary>
        /// Returns a formatted summary of the report. Derived classes can override for source-specific formatting.
        /// </summary>
        /// <returns></returns>
        public abstract string GetSourceType(); 
        public abstract int CalculateReliabilityScore();
        public virtual string GetSummary()
                => $"ReportId: {ReportId} | Status: {Status} | Description: {Description} ";
        public override string ToString()
            => $"ReportId: {ReportId} | Time: {Timestamp}" +
            $" | Latitude: {Latitude} | Longitude: {Longitude} |" +
            $" Status: {Status} | Description: {Description} ";
    }
}