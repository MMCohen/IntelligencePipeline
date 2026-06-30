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

        protected Report(int reportId, DateTime timestamp, double latitude, double longitude, string description)
        {

        }


        public int ReportId { get; } // Read-only, set in constructor
        public DateTime Timestamp { get; set; } // Validated: not in future, not before 2020-01-01
        public double Latitude { get; set; } // Validated: 29.5000–33.5000
        public double Longitude { get; set; } // Validated: 34.0000–36.0000
        public string Description { get; set; } // Validated: 10–500 characters
        public ReportStatus Status { get; set; } // Validated: must be valid enum value
        public Priority Priority { get; set; }
        public Classification Classification { get; set; }
        public int ReliabilityScore { get; set; } // Validated: 1–10
        public string RejectionReason { get; set; }
    }
}