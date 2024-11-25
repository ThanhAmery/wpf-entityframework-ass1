using Candidate_BusinessObjects;
using Candidate_Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for JobPostingWindow.xaml
    /// </summary>
    public partial class JobPostingWindow : Window
    {

        
        private readonly IJobPostingService jobService;
        private readonly int? RoleID;

        public JobPostingWindow()
        {
            InitializeComponent();
            this.jobService = new JobPostingService();
        }


        public JobPostingWindow(int? roleID)
        {
            InitializeComponent();
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
                    this.btnCreate.IsEnabled = false;
                    break;
                case 3:
                    // Staff can only read data
                    this.btnCreate.IsEnabled = false;
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
            this.dtgJobPosting.ItemsSource = jobService.GetJobPostings().Select(jp => new { jp.PostingId,
                jp.JobPostingTitle,
                jp.PostedDate,
            });
            
        }

        private void dtgJobPosting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);

            if(row != null)
            {
                DataGridCell RowColumn =
                dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                if (RowColumn != null)
                {
                    string id = ((TextBlock)RowColumn.Content).Text;
                    JobPosting jobPosting = jobService.GetJobPosting(id);

                    txtPostingID.Text = jobPosting.PostingId.ToString();
                    txtTitle.Text = jobPosting.JobPostingTitle.ToString();
                    dpDate.SelectedDate = jobPosting.PostedDate;
                    txtDescription.Text = jobPosting.Description.ToString();
                }
                
            }
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtTitle.Text;
            jobPosting.PostedDate = dpDate.SelectedDate;
            jobPosting.Description = txtDescription.Text;

            if (jobService.CreateJobPosting(jobPosting))
            {
                MessageBox.Show("Created Successfully!");
                this.loadDataInit();
            }
            else
            {
                MessageBox.Show("Something is wrong!!!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            JobPosting jobPosting = new JobPosting();
            jobPosting.PostingId = txtPostingID.Text;
            jobPosting.JobPostingTitle = txtTitle.Text;
            jobPosting.PostedDate = dpDate.SelectedDate;
            jobPosting.Description= txtDescription.Text;

            if (jobService.UpdateJobPosting(jobPosting))
            {
                MessageBox.Show("Updated Successful!");
                this.loadDataInit();

            }
            else
            {
                MessageBox.Show("Something is wrong!!!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (txtPostingID.Text.Length > 0)
            {

                string postingID = txtPostingID.Text;


                var result = MessageBox.Show("Are you sure you want to delete this postingID?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {

                    if (jobService.DeleteJobPosting(postingID))
                    {
                        MessageBox.Show("Delete Successful!");
                        ClearData();
                        this.loadDataInit();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the posting!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a JobPosting!!!");
            }
        }

        private void ClearData()
        {
            txtPostingID.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            dpDate.SelectedDate = null;

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfileWindow candidateProfileWindow = new CandidateProfileWindow();
            candidateProfileWindow.Show();
            this.Close();
        }
    }
}
