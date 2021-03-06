﻿using FirstFloor.ModernUI.Windows.Controls;
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
using SailingSchoolWPF.ViewModel.Course;

namespace SailingSchoolWPF.Pages.Courses.Planing
{
    /// <summary>
    /// Interaction logic for CreateStudent.xaml
    /// </summary>
    public partial class PlaningCourse : ModernWindow
    {
        /// <summary>
        /// The view model
        /// </summary>
        UpdateCoursePlaningViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaningCourse"/> class.
        /// </summary>
        /// <param name="course">The course.</param>
        public PlaningCourse(SailingSchoolWPF.Model.CoursePlaning course)
        {
            InitializeComponent();
            viewModel = new UpdateCoursePlaningViewModel(course);
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Handles the 1 event of the ModernWindow_Closed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ModernWindow_Closed_1(object sender, EventArgs e)
        {
            viewModel.Close();
        }
    }
}
