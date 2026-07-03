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

        public override int CalculateReliabilityScore()
        {
            int BaseReliability = 5;
            //- SignalStrength >= -40: +3
            //- SignalStrength >= -70: +2
            //- Content contains attack / target / border / vehicle: +1
            //- SignalStrength< -100: -2
            //- Result clamped to 1–10
            return BaseReliability;
        }



    }
}