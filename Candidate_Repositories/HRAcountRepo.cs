using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public class HRAcountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAcountDAO.Instance.GetHracountByEmail(email);
        

        public List<Hraccount> GetHraccounts() => HRAcountDAO.Instance.GetHraccounts();
        
    }
}
