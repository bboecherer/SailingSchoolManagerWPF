using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfScheduler
{
    /// <summary>
    /// Interaction logic for EventUserControl.xaml
    /// </summary>
    public partial class EventUserControl : UserControl
    {
        Event _e;

        public EventUserControl(Event e, bool showTime)
        {
            InitializeComponent();

            _e = e;

            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.Subject = e.Subject;
            this.BorderElement.Background = e.Color;
            if (!showTime || e.AllDay)
            {
                this.DisplayDateText.Visibility = System.Windows.Visibility.Hidden;
                this.DisplayDateText.Height = 0;
                this.DisplayDateText.Text = String.Format("{0} - {1}", e.Start.ToShortDateString(), e.End.ToShortDateString());
            }
            else
            {
                this.DisplayDateText.Text = String.Format("{0} - {1}", e.Start.ToString("HH:mm"), e.End.ToString("HH:mm"));
            }
            this.BorderElement.ToolTip = this.DisplayDateText.Text + System.Environment.NewLine + this.DisplayText.Text;
        }

        public Event Event {
            get { return _e; }
        }

        #region Subject
        public static readonly DependencyProperty SubjectProperty = 
            DependencyProperty.Register("Subject", typeof(string), typeof(EventUserControl),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(AdjustSubject)));

        public string Subject
        {
            get { return (string)GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }

        private static void AdjustSubject(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            (source as EventUserControl).DisplayText.Text = (string)e.NewValue;
        }
        #endregion
    }


    
}
