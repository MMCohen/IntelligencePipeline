using IntelligencePipeline.Models.Enums;
using IntelligencePipeline.Models.Reports;
using System.Net.NetworkInformation;

namespace IntelligencePipeline.Storage
{
    class ReportRepository
    {
        private List<Report> _reports;

        public ReportRepository()
        {
            _reports = new List<Report>();
        }

        public void Add(Report report) { _reports.Add(report); }


        public List<Report> GetAll() { return _reports; }
        

        public List<Report> GetByStatus(ReportStatus status)
        {
            List<Report> tempList = new() ;

            foreach (Report report in _reports)
            {
                if (report.Status == status) { tempList.Add(report); }
            }

            return tempList;
        }


        public List<Report> GetByPriority(Priority priority)
            {
            List<Report> tempList = new();

            foreach (Report report in _reports)
            {
                if (report.Priority == priority) { tempList.Add(report); }
            }

            return tempList;
        }


        public List<Report> Search(string keyword)
            {
            List<Report> tempList = new();

            foreach (Report report in _reports)
            {
                if (report.Description.Contains(keyword)) { tempList.Add(report); }
            }

            return tempList;
            }


        public Report? GetById(int reportId)
            {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    return report;
                }
            }
            return null;
            }


        public void UpdateStatus(int reportId, ReportStatus newStatus)
        {
            foreach (Report report in _reports)
            {
                if (report.ReportId == reportId)
                {
                    report.Status = newStatus;
                }
            }
        }
        public int GetTotalCount() { return _reports.Count(); }


        public int GetCountByStatus(ReportStatus status)
        {
            int cnt = 0;
            foreach (Report report in _reports)
            {
                if (report.Status == status)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}