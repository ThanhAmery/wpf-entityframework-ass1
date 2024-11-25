using Candidate_BusinessObjects;
using Candidate_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo profileRepo;

        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProflie(CandidateProfile profile)
        {
            return profileRepo.AddCandidateProflie(profile);
        }

        public bool DeleteCandidateProflie(string candidateID)
        {
            return profileRepo.DeleteCandidateProflie(candidateID);
        }

        public List<CandidateProfile> GetCandidate()
        {
            return profileRepo.GetCandidate();
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return profileRepo.GetCandidateProfile(id);
        }

        public bool UpdateCandidateProflie(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProflie(candidateProfile);
        }
    }
}
