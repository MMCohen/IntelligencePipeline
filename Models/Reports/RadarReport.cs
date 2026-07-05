using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline.Models.Reports
{
    class RadarReport : Report
    {
        private int _speed;
        private int _direction;
        private int _distance;
        


        public int Speed { get => _speed ; protected set => _speed = value; }
        public int Direction { get => _direction ; protected set => _direction = value; }
        public int Distance { get => _distance; protected set => _distance = value; }

public RadarReport(int reportId, DateTime timestamp, double latitude,
    double longitude, string description,
    int speed, int direction, int distance)
    : base(reportId, timestamp, latitude, longitude, description)
        {
            Speed = speed;
            Direction = direction;
            Distance = distance;
        }
        public override string GetSourceType() => "Radar";

        public override int CalculateReliabilityScore()
        {
            int BaseReliability = 6;

            if (Distance >= 500 && Distance <= 30000) BaseReliability += 2;
            else if (Distance > 70000) BaseReliability -= 2;

            if (Speed >= 10 && Speed <= 900) BaseReliability += 1;
            else if (Speed > 1500) BaseReliability -= 2;

            return Math.Clamp(BaseReliability, 1, 10);
        }



    }

}
