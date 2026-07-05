using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class PriorityCalculator
    {
        public Priority Calculate(Report report)
        {
            //critical check
            if (report is RadarReport radarReport1 && radarReport1.Speed >= 800)
                return Priority.Critical;

            if (ContainsKeyword(report.Description , ["missile", "explosion", "attack", "fire"]))
                return Priority.Critical;

            if (report is SignalReport signalReport)
                if (ContainsKeyword(signalReport.Content, ["missile", "explosion", "attack", "fire"]))
                    return Priority.Critical;
                else if (ContainsKeyword(signalReport.Content, ["attack"]) && ContainsKeyword(signalReport.Content, ["target"]))
                    return Priority.Critical;

            // high check
            if (report is RadarReport radarReport2 && radarReport2.Speed >= 400)
                return Priority.High;

            if (report is DroneReport droneReport && droneReport.Altitude <= 500)
                return Priority.High;

            if (report is SoldierReport soldierReport
                && soldierReport.ConfidenceLevel >= 4
                && ContainsKeyword(soldierReport.Description, ["movement"]))
                return Priority.High;

            if (ContainsKeyword(report.Description, ["weapon", "suspicious", "border"]))
                return Priority.High;

            // Medium check
            if (report is RadarReport radarReport3 && radarReport3.Speed >= 120)
                return Priority.Medium;

            if (report.ReliabilityScore >= 7)
                return Priority.Medium;

            if (ContainsKeyword(report.Description, ["movement", "vehicle", "activity"]))
                return Priority.Medium;

            // Low Priority
            return Priority.Low;

        }

        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach (string word in keywords)
            {
                if (text.Contains(word))
                    return true;
            }
            return false;
        }




    }
}