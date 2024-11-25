using Candidate_BusinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_DoanCongThanh
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private readonly ICandidateProfileService profileService;
        private readonly IJobPostingService jobService;
        private readonly int? RoleID;

        public CandidateProfileWindow()
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
        }

        public CandidateProfileWindow(int? roleID)
        {
            InitializeComponent();
            this.profileService = new CandidateProfileService();
            this.jobService = new JobPostingService();
            this.RoleID = roleID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (RoleID)
            {
                case 1:
                    break;
                case 2:
                    //Manager
                    this.btnAdd.IsEnabled = false;
                    break;
                case 3:
                    // Staff can only read data
                    this.btnAdd.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                    btnDelete.IsEnabled = false;
                    break;
                default:
                    break;

            }
            this.loadDataInit();
        }

        private void loadDataInit()
        {
            this.dtgCandidateProflie.ItemsSource = profileService.GetCandidate().Select(a => new { a.CandidateId, a.Fullname, a.Posting.JobPostingTitle });
            this.cmbPostID.ItemsSource = jobService.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(cmbPostID.SelectedValue.ToString());
            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.Birthday = DateTime.Parse(dateBrithDay.Text);
            candidateProfile.ProfileUrl = txtImageURL.Text;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();
            if (profileService.AddCandidateProflie(candidateProfile))
            {
                MessageBox.Show("Add Successful!");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something is wrong!!!");
            }
        }

        private void dtgCandidateProflie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);

            if(row != null)
            {
                DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                if(RowColumn != null)
                {
                    string id = ((TextBlock)RowColumn.Content).Text;
                    CandidateProfile candidate = profileService.GetCandidateProfile(id);

                    txtCandidateID.Text = candidate.CandidateId.ToString();
                    txtFullName.Text = candidate.Fullname.ToString();
                    txtImageURL.Text = candidate.ProfileUrl.ToString();
                    dateBrithDay.Text = candidate.Birthday.ToString();
                    txtDescription.Text = candidate.ProfileShortDescription.ToString();
                    cmbPostID.SelectedValue = candidate.PostingId;
                } 
            } 

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {


            CandidateProfile candidateProfile = new CandidateProfile();
            candidateProfile.CandidateId = txtCandidateID.Text;
            candidateProfile.Fullname = txtFullName.Text;
            candidateProfile.Birthday = DateTime.Parse(dateBrithDay.Text);
            candidateProfile.ProfileUrl = txtImageURL.Text;
            candidateProfile.ProfileShortDescription = txtDescription.Text;
            candidateProfile.PostingId = cmbPostID.SelectedValue.ToString();

            if (profileService.UpdateCandidateProflie(candidateProfile))
            {
                MessageBox.Show("Updated Successful!");

                // Xóa dữ liệu DataGrid trước khi nạp lại dữ liệu
                this.dtgCandidateProflie.ItemsSource = null;


                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something is wrong!!!");
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtCandidateID.Text.Length > 0)
            {

                string candidateID = txtCandidateID.Text;


                var result = MessageBox.Show("Are you sure you want to delete this candidate profile?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (profileService.DeleteCandidateProflie(candidateID))
                    {
                        MessageBox.Show("Delete Successful!");
                        ClearInputFields();
                        this.loadDataInit();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the candidate profile.");
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a Candidate!!!");
            }
        }


        private void ClearInputFields()
        {
            txtCandidateID.Text = string.Empty;
            txtFullName.Text = string.Empty;
            dateBrithDay.Text = string.Empty;
            txtImageURL.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbPostID.SelectedValue = string.Empty; // Bỏ chọn trong ComboBox
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            JobPostingWindow jobPostingWindow = new JobPostingWindow(RoleID);
            jobPostingWindow.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
