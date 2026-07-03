using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Models.Reports
{
    class DroneReport: Report
    {
        const int IMAGE_GOOD_QUALITY = 80;
        const int IMAGE_MEDIUM_QUALITY = 50;
        const int MIN_GOOD_ALTITUDE = 500;
        const int MAX_GOOD_ALTITUDE = 3000;
        const int BAD_ALTITUDE = 700;

        private int _altitude;
        private int _imageQuality;

        public int Altitude { get => _altitude; protected set => _altitude = value; }
        public int ImageQuality { get => _imageQuality; protected set => _imageQuality = value; }

        public DroneReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            int altitude, int imageQuality)
            : base(reportId, timestamp, latitude, longitude, description)
        {
            Altitude = altitude;
            ImageQuality = imageQuality;
        }

        public override string GetSourceType() => "Drone";
        public override int CalculateReliabilityScore()
        {
            int BaseReliability = 5;

            if (ImageQuality > IMAGE_GOOD_QUALITY) { BaseReliability += 3; }
            else if (ImageQuality > IMAGE_MEDIUM_QUALITY) { BaseReliability += 2; }

            if (Altitude >= MIN_GOOD_ALTITUDE && Altitude <= MAX_GOOD_ALTITUDE) { BaseReliability += 2; }
            if (Altitude >= BAD_ALTITUDE) { BaseReliability -= 2; }

            return BaseReliability;
        }




    }
}