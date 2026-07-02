using IntelligencePipeline.Models.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IntelligencePipeline.Validation
{

    abstract class BaseValidator : IValidator

    {
        static DateTime MIN_REPORT_DATE = new DateTime(2020, 01, 01);


        public ValidationResult Validate(Report report)
        {
            ValidationResult x = ValidateCommonFields(report);
            if (x.IsValid == false)
                return x;


            ValidationResult y = ValidateSpecificFields(report);
            if (y.IsValid == false)
                return y;

            else return ValidationResult.Success();

        }


        /// <summary>
        /// Validates common fields for all report types
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        protected ValidationResult ValidateCommonFields(Report report)
        {
            if (report.Timestamp < MIN_REPORT_DATE || report.Timestamp > DateTime.Now)
                return ValidationResult.Failure("Timestamp: Cannot be in the future, cannot be before 2020-01-01");
            
            if (report.Latitude < 29.5000 || report.Latitude > 33.5000)
                return ValidationResult.Failure("Latitude: Must be between 29.5000 and 33.5000");
            
            if (report.Longitude < 34.0 || report.Longitude > 36.0)
                return ValidationResult.Failure("Longitude: Must be between 34.0000 and 36.0000");
            
            if (report.Description.Length < 10 || report.Description.Length > 500)
                return ValidationResult.Failure("Description: Cannot be null/empty, must be 10-500 characters");

            return ValidationResult.Success();
        }


        /// <summary>
        /// Abstract method that derived validators must
        /// implement to validate type-specific fields.
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        protected abstract ValidationResult ValidateSpecificFields(Report report);


    }
}
