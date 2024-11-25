using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        //private CandidateManagementContext dbContext;

        //private static CandidateProfileDAO instance;

        public static CandidateProfileDAO instance;

        private static GenericDao<CandidateProfile> genericDao;

        public CandidateProfileDAO()
        {
            genericDao = new GenericDao<CandidateProfile>(new CandidateManagementContext());
        }

        public static CandidateProfileDAO Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }

        }


        //public CandidateProfileDAO()
        //{
        //    dbContext = new CandidateManagementContext();
        //}

        //public List<CandidateProfile> GetCandidates()
        //{
        //    return dbContext.CandidateProfiles.ToList();
        //}

        //THÊM NGÀY 26/09/2024
        public List<CandidateProfile> GetCandidates()
        {
            return genericDao.GetAllWithInclude(c => c.Posting);
            //return dbContext.CandidateProfiles.Include(u => u.Posting).ToList();
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return genericDao.GetById(id);
            //return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProflie(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = genericDao.GetById(candidateProfile.CandidateId);
            if(candidate == null)
            {
                //dbContext.CandidateProfiles.Add(candidateProfile);
                //dbContext.SaveChanges();
                genericDao.Add(candidateProfile);
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool DeleteCandidateProflie(string candidateID)
        {
            bool isSuccess = false;
            CandidateProfile candidate = genericDao.GetById(candidateID);
            if (candidate != null)
            {
                //dbContext.CandidateProfiles.Remove(candidate);
                //dbContext.SaveChanges();
                genericDao.Delete(candidateID);
                isSuccess = true;
            }
            return isSuccess;
        }


        public bool UpdateCandidateProflie(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            CandidateProfile candidate = genericDao.GetById(candidateProfile.CandidateId);
            if (candidate != null)
            {
                //tự động quét, tự check, ko cập nhật ID 
                //dbContext.Entry<CandidateProfile> (candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                //dbContext.SaveChanges();

                candidate.Fullname = candidateProfile.Fullname;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                candidate.PostingId = candidateProfile.PostingId;
                genericDao.Update(candidate);
                isSuccess = true;
            }
            return isSuccess;
        }


    }
}
