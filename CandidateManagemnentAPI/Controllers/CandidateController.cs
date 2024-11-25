using Candidate_Services;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagemnentAPI.Controllers
{
    public class CandidateController : Controller
    {
        private ICandidateProfileService profileServices;
        public CandidateController()
        {
            profileServices = new CandidateProfileService();
        }

        [HttpGet(Name = "GetCandidates")]
        public IActionResult GetAllCadidate()
        {
            return Ok(profileServices.GetCandidate().ToList());
        }
    }
}
