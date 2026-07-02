using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline
{
    class Try
    {
        static void Main()
        {
            DroneReport rp = new DroneReport(12, DateTime.Now, 12.1, 12.1, "dfgdfg", 2343, 234234);
            Console.WriteLine(rp.GetType);
            int i = rp.ReportId;
            Console.WriteLine(i);

        }
    }
}