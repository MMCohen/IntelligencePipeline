using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator, IValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SoldierReport soldier)
                return ValidationResult.Failure("report is not soldier report");

            else if (soldier.SoldierName.Length < 2 || soldier.SoldierName.Length > 50)
                return ValidationResult.Failure("Soldier Name must be 2–50 characters");

            else if (soldier.SoldierID.Length != 7 || !int.TryParse(soldier.SoldierID, out int _))
                return ValidationResult.Failure("Soldier ID must be exactly 7 digits");

            else if (soldier.Unit.Length < 2 || soldier.Unit.Length > 50)
                return ValidationResult.Failure("Unit must be 2–50 characters");

            else if (soldier.ConfidenceLevel < 1 || soldier.ConfidenceLevel > 5)
                return ValidationResult.Failure("Confidence Level must be between 1-5");

            return ValidationResult.Success();
        }

    }
}