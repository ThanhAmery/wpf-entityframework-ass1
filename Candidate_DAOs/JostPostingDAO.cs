using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JostPostingDAO
    {
        private CandidateManagementContext dbContext;
        private static JostPostingDAO instance;

        public static JostPostingDAO Instance 
        { 
             get
             {
                if (instance == null)
                {
                    instance = new JostPostingDAO();
                }
                return instance;
             }

        }

        public JostPostingDAO()
        {
            dbContext = new CandidateManagementContext();
        }

        public List<JobPosting> GetJobPostings()
        {
            return dbContext.JobPostings.ToList();
        }

        public JobPosting GetJobPosting(string id)
        {
            return dbContext.JobPostings.SingleOrDefault(jp => jp.PostingId.Equals(id));
        }

        public bool CreateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            var jp = GetJobPosting(jobPosting.PostingId);
            if (jp == null)
            {
                dbContext.JobPostings.Add(jobPosting);
                dbContext.SaveChanges();

                isSuccess = true;
            }
            return isSuccess;
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool isSuccess = false;
            var jp = GetJobPosting(jobPosting.PostingId);
            if(jp != null)
            {
                jp.JobPostingTitle = jobPosting.JobPostingTitle;
                jp.Description = jobPosting.Description;
                jp.PostedDate = jobPosting.PostedDate;
                jp.PostingId = jobPosting.PostingId;

                dbContext.JobPostings.Update(jp);

                isSuccess = true;
            }
            return isSuccess;
        }


        public bool DeleteJobPosting(string id)
        {
            bool isSuccess = false;
            var jp = GetJobPosting(id);
            if( jp != null )
            {
                dbContext.JobPostings.Remove(jp);
                dbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

    }
}
