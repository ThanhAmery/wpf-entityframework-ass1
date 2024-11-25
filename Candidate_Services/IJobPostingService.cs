using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IJobPostingService
    {
        public List<JobPosting> GetJobPostings();

        public JobPosting GetJobPosting(string id);

        public bool CreateJobPosting(JobPosting jobPosting);

        public bool UpdateJobPosting(JobPosting jobPosting);

        public bool DeleteJobPosting(string id);
    }
}
