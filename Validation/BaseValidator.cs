using IntelligencePipeline.Models.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IntelligencePipeline.Validation
{
    abstract class BaseValidator : IValidator

    {
        /* - Validates common fields shared by all reports (Timestamp, Latitude, Longitude, Description)
    - Defines template method pattern for validation workflow
    - Delegates specific field validation to derived classes
        */

        //public ValidationResult Validate(Report report)
        //{

        //}
    }
}
