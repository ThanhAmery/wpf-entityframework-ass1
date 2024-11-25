using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        

        public List<JobPosting> GetJobPostings() => JostPostingDAO.Instance.GetJobPostings();

        public JobPosting GetJobPosting(string id) => JostPostingDAO.Instance.GetJobPosting(id);
        


        public bool CreateJobPosting(JobPosting jobPosting) => JostPostingDAO.Instance.CreateJobPosting(jobPosting);
         


        public bool UpdateJobPosting(JobPosting jobPosting) => JostPostingDAO.Instance.UpdateJobPosting(jobPosting);
        


        public bool DeleteJobPosting(string id) => JostPostingDAO.Instance.DeleteJobPosting(id);
        
    }
}
