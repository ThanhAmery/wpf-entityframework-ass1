using Candidate_BusinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;

        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }

        public JobPosting GetJobPosting(string id)
        {
            return jobPostingRepo.GetJobPosting(id);
        }

        public bool CreateJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.CreateJobPosting(jobPosting);
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.UpdateJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(string id)
        {
            return jobPostingRepo.DeleteJobPosting(id);
        }
    }
}
