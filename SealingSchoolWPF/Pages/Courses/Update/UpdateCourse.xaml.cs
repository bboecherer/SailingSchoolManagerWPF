﻿using FirstFloor.ModernUI.Windows.Controls;
using SailingSchoolWPF.Model;
using SailingSchoolWPF.ViewModel.Course;
using SailingSchoolWPF.ViewModel.StudentViewModel;
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

namespace SailingSchoolWPF.Pages.Courses.Update
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class UpdateCourse : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateCourseViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCourse"/> class.
        /// </summary>
        /// <param name="course">The course.</param>
        public UpdateCourse(SailingSchoolWPF.ViewModel.Course.CourseViewModel course)
        {
            InitializeComponent();
            viewModel = new UpdateCourseViewModel(GetCourseDataFromModel(course));
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Gets the course data from model.
        /// </summary>
        /// <param name="course">The course.</param>
        /// <returns></returns>
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
            c.CourseMaterialTyps = course.CourseMaterialTyps;

            return c;
        }

        /// <summary>
        /// Handles the Closing event of the ModernWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            viewModel.Close();
        }

    }
}
