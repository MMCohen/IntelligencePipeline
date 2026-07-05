using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{
    class ClassificationCalculator
    {
        private bool IsContains(string text, params string[] keywords)
        {
            foreach (string word in keywords)
            {
                if (text.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }

        public Classification Calculate(Report report)
        {
            // TopSecret
            if (report.Priority == Priority.Critical)
                return Classification.TopSecret;

            if (report is SignalReport signalReport
                && IsContains(signalReport.Content, ["target", "attack", "missile"]))
                return Classification.TopSecret;

            // Secret
            if (report.Priority == Priority.High)
                return Classification.Secret;

            if (report.GetSourceType() == "Signal")
                return Classification.Secret;

            if (IsContains(report.Description, ["border"]) && IsContains(report.Description, ["weapon"]))
                return Classification.Secret;

            // Restricted
            if (report.Priority == Priority.Medium)
                return Classification.Restricted;

            if (report.GetSourceType() == "Soldier")
                return Classification.Restricted;

        // Unclassified
        return Classification.Unclassified;
        }
    }

}