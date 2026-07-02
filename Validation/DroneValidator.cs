using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class DroneValidator : BaseValidator, IValidator
    {

        //TODO: fix the var names
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not DroneReport drone)
                return ValidationResult.Failure("source type is not Drone");

            else if (drone.Altitude < 100 || drone.Altitude > 10000)
                return ValidationResult.Failure("Altitude is under 100 or above 10000");
            
            else if (drone.ImageQuality < 1 || drone.ImageQuality > 100)
                return ValidationResult.Failure("ImageQuality is not in the legit range");

            return ValidationResult.Success();

        }

    }
}