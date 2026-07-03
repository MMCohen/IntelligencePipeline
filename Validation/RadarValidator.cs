using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class RadarValidator : BaseValidator, IValidator
    {

        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not RadarReport radarReport)
                return ValidationResult.Failure("report is not Radar report");

            if (radarReport.Speed < 0 || radarReport.Speed > 2000)
                return ValidationResult.Failure("speed must be between 0-2,000");

            if (radarReport.Direction < 0 || radarReport.Direction > 359)
                return ValidationResult.Failure("Direction must be between 0-359");

            if (radarReport.Distance < 100 || radarReport.Distance > 100000)
                return ValidationResult.Failure("Distance must be between 100-100,000");

            return ValidationResult.Success();
        }


    }
}