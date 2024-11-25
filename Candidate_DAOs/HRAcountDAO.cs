using Candidate_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAcountDAO
    {
        private CandidateManagementContext context;

        private static HRAcountDAO instance = null;  //static chấm ko cần new

        public HRAcountDAO()
        {
            context = new CandidateManagementContext();
        }

        public static HRAcountDAO Instance
        { //Ctrl + K + D: format lại cho đẹp 
            //kĩ thuật singleton Pattern 
            get
            {
                if (instance == null)
                {
                    instance = new HRAcountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHracountByEmail(string email)
        {   //lấy đối tượng nào đó: context . cái bảng 
            //context là đẩy hết đối tượng lên r 
            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }

        public List<Hraccount> GetHraccounts()
        {
            return context.Hraccounts.ToList();
        }
    }
}
