using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProflie(CandidateProfile profile) => CandidateProfileDAO.Instance.AddCandidateProflie(profile);
        

        public bool DeleteCandidateProflie(string candidateID) => CandidateProfileDAO.Instance.DeleteCandidateProflie(candidateID);
        

        public List<CandidateProfile> GetCandidate() => CandidateProfileDAO.Instance.GetCandidates();
        

        public CandidateProfile GetCandidateProfile(string id) => CandidateProfileDAO.Instance.GetCandidateProfile(id);
        

        public bool UpdateCandidateProflie(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProflie(candidateProfile);
        
    }
}
