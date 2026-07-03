using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Validation;

namespace IntelligencePipeline
{
    class Try
    {
        static void Main()
        {
            DroneReport rp = new DroneReport(12, DateTime.Parse("01/01/2020"), 30, 35, "hello world how", 5000, 87);
            //Console.WriteLine(rp.GetType);

            SoldierReport sr = new SoldierReport(13, DateTime.Parse("01/01/2020"), 30, 35,
                "hello world how", "Moshe", "1234567", "99", 4);

            //SoldierValidator x = new SoldierValidator();
            //ValidationResult y = x.Validate(sr);
            //Console.WriteLine(y.ErrorMessage);
            //Console.WriteLine(x.Validate(rp));

            // radar testing
            RadarReport radarReport = new RadarReport(12, DateTime.Parse("01/01/2020"), 30, 35, "hello world how",
                2000, 359, 200);

            RadarValidator radarValidator = new RadarValidator();
            ValidationResult radarResult = radarValidator.Validate(radarReport);

            Console.WriteLine(radarResult.ErrorMessage);

            //




        }
    }
}