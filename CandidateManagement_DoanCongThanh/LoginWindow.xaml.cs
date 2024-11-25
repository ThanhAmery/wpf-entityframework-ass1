using Candidate_BusinessObjects;
using Candidate_Repositories;
using Candidate_Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_DoanCongThanh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountService  = new HRAccountService();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = iAccountService.GetHraccountByEmail(txtEmail.Text.Trim()); //Gọi xuống tầng Service 
            
            if(hraccount != null &&  txtPassword.Password.Equals(hraccount.Password))
            {
                int? roleID = hraccount.MemberRole;  //? là optinal 
                switch (roleID)
                {
                    case 1:
                        this.Hide();
                        CandidateProfileWindow canForm = new CandidateProfileWindow(roleID);
                        canForm.Show();
                        break;
                    case 2:
                        this.Hide();
                        CandidateProfileWindow managerCandidate = new CandidateProfileWindow(roleID);
                        managerCandidate.Show(); 
                        break;
                    case 3:
                        this.Hide();
                        CandidateProfileWindow staffCandidate = new CandidateProfileWindow(roleID);
                        staffCandidate.Show();
                        break;
                    default:
                        break;
                }
                //this.Hide();
                //JobPostingWindow jobForm = new JobPostingWindow();
                //CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow();
                //candidateProfileWindow.Show();
                ////jobForm.Show();
                //this.Close();
                
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password!!!");

            }
        }       

        
    }
}