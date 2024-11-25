using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repositories
{
    public interface IHRAccountRepo  //interface ra đời để giải quyết đa kế thừa 
    {
        public Hraccount GetHraccountByEmail(string email);

        public List<Hraccount> GetHraccounts();
    }
}
