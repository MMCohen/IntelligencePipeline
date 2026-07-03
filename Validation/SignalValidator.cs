using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Reflection.Metadata;

namespace IntelligencePipeline.Validation
{
    class SignalValidator : BaseValidator, IValidator
    {

        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SignalReport signalReport)
                return ValidationResult.Failure("report is not signal report");

            if (signalReport.Frequency < 1.0 || signalReport.Frequency > 3000.0)
                return ValidationResult.Failure("Frequency must be between 1-3000");

            if (signalReport.Content.Length < 5 || signalReport.Content.Length > 1000)
                return ValidationResult.Failure("Content must be 5–1000 characters");

            if (!Enum.TryParse(signalReport.Language,ignoreCase: true, out Language _))
                return ValidationResult.Failure($"Language must be: {string.Join(", ", Enum.GetNames<Language>())}");

            if (signalReport.SignalStrength < -120 || signalReport.SignalStrength > 0)
                return ValidationResult.Failure("Signal Strength must be between -120-0");

            return ValidationResult.Success();
        }

    }
}