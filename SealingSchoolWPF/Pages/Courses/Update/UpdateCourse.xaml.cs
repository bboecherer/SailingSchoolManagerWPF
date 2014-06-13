using FirstFloor.ModernUI.Windows.Controls;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.ViewModel.Course;
using SealingSchoolWPF.ViewModel.StudentViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SealingSchoolWPF.Pages.Courses.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateCourse : ModernWindow
    {
        UpdateCourseViewModel viewModel;

        public UpdateCourse(SealingSchoolWPF.ViewModel.Course.CourseViewModel course)
        {
            InitializeComponent();
            viewModel = new UpdateCourseViewModel(GetCourseDataFromModel(course));
            this.DataContext = viewModel;
        }

        private Model.Course GetCourseDataFromModel(CourseViewModel course)
        {
            Model.Course c = new Model.Course();

            c.CourseId = Convert.ToInt32(course.Id);
            c.Label = course.Label;
            c.Description = course.Description;
            c.Duration = course.Duration;
            c.Capacity = course.Capacity;
            c.NetPrice = course.NetPrice;
            c.GrossPrice = course.GrossPrice;
            c.NetAmount = course.NetAmount;
            c.Title = course.Title;
            c.AdditionalInfo = course.AdditionalInfo;
            c.NeededInstructors = course.NeededInstructors;
            c.Qualifications = course.Qualifications;
            c.RatingValue = course.RatingValue;

            return c;
        }

        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
