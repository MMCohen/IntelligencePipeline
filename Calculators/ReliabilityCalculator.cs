using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Calculators
{

    class ReliabilityCalculator
    {
        const int MIN_RELIABILITY_SCORE = 1;
        const int MAX_RELIABILITY_SCORE = 10;

        /// <summary>
        /// Calls report.CalculateReliabilityScore() and ensures result is 1–10
        /// </summary>
        /// <param name="report"> a Report instance of any type </param>
        /// <returns> int Reliability Score clamps to 1-10</returns>
        public int Calculate(Report report)
        {
            int reliabilityScore = report.CalculateReliabilityScore();

            int reliabilityScoreClamp = Math.Clamp(reliabilityScore, MIN_RELIABILITY_SCORE, MAX_RELIABILITY_SCORE);

            return reliabilityScoreClamp;
        }
    }

}