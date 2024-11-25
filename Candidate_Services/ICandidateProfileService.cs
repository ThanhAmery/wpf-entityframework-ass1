using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidate();

        public CandidateProfile GetCandidateProfile(string id);

        public bool AddCandidateProflie(CandidateProfile profile);

        public bool DeleteCandidateProflie(string candidateID);

        public bool UpdateCandidateProflie(CandidateProfile candidateProfile);
    }
}
