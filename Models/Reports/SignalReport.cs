using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Validation;
using System.Collections;
using System.Reflection;
using System.Reflection.Metadata;

namespace IntelligencePipeline.Models.Reports
{
    class SignalReport : Report
    {

        private double _frequency;
        private string _content;
        private string _language; // I change it from enum to string so the validation will be outside
        private int _signalStrength;


        public double Frequency { get => _frequency; protected set => _frequency = value; }
        public string Content { get => _content; protected set => _content = value; }
        public string Language { get => _language; protected set => _language = value; }
        public int SignalStrength { get => _signalStrength; protected set => _signalStrength = value; }


        public SignalReport(int reportId, DateTime timestamp, double latitude,
            double longitude, string description,
            double frequency, string content, string language,
            int signalStrength)
                : base(reportId, timestamp, latitude, longitude, description)
        {
            Frequency = frequency;
            Content = content;
            Language = language;
            SignalStrength = signalStrength;
        }
        public override string GetSourceType()
            => "Signal";

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

        public override int CalculateReliabilityScore()
        {
            int BaseReliability = 5;

            if (SignalStrength >= -40) BaseReliability += 3;
            else if(SignalStrength >= -70) BaseReliability += 2;
            else if(SignalStrength < -100) BaseReliability -= 2;
            if (IsContains(Content, ["attack", "target", "border", "vehicle"]))
                BaseReliability += 1;
             
            return Math.Clamp(BaseReliability, 1, 10);
        }



    }
}