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

namespace WpfScheduler
{
    /// <summary>
    /// Interaction logic for DayScheduler.xaml
    /// </summary>
    public partial class DayScheduler : UserControl
    {
        private Scheduler _scheduler;

        internal event EventHandler<Event> OnEventDoubleClick;
        internal event EventHandler<DateTime> OnScheduleDoubleClick;

        #region CurrentDay

        private DateTime _currentDay;
        internal DateTime CurrentDay
        {
            get { return _currentDay; }
            set {
                _currentDay = value;
                AdjustCurrentDay(value);
            }
        }

        private void AdjustCurrentDay(DateTime currentDay)
        {
            dayLabel.Content = currentDay.ToString("dddd dd/MM");

            PaintAllEvents();
            PaintAllDayEvents();
        }
        #endregion

        public DayScheduler()
        {
            InitializeComponent();

            column.MouseDown += Canvas_MouseDown;
            column.Background = Brushes.Transparent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs ea)
        {
            DependencyObject ucParent = (sender as DayScheduler).Parent;
            while (!(ucParent is Scheduler))
            {
                ucParent = LogicalTreeHelper.GetParent(ucParent);
            }

            _scheduler = ucParent as Scheduler;

            _scheduler.OnEventAdded += ((object s, Event e) =>
            {
                if (e.Start.Date == e.End.Date)
                    PaintAllEvents();
                else
                    PaintAllDayEvents();
            });

            _scheduler.OnEventDeleted += ((object s, Event e) =>
            {
                if (e.Start.Date == e.End.Date)
                    PaintAllEvents();
                else
                    PaintAllDayEvents();
            });

            _scheduler.OnEventsModified += ((object s, EventArgs e) =>
            {
                PaintAllEvents();
                PaintAllDayEvents();
            });

            _scheduler.OnStartJourneyChanged += ((object s, TimeSpan t) =>
            {
                if (_scheduler.StartJourney.Hours == 0)
                    startJourney.Visibility = System.Windows.Visibility.Hidden;
                else
                    Grid.SetRowSpan(startJourney, (int)t.TotalHours * 2);
            });

            _scheduler.OnEndJourneyChanged += ((object s, TimeSpan t) =>
            {
                if (_scheduler.EndJourney.Hours == 0)
                    endJourney.Visibility = System.Windows.Visibility.Hidden;
                else
                {
                    Grid.SetRow(endJourney, (int)t.Hours);
                    Grid.SetRowSpan(endJourney, 48 - (int)t.Hours * 2);
                }
            });

            (sender as DayScheduler).SizeChanged += DayScheduler_SizeChanged;

            ResizeGrids(new Size(this.ActualWidth, this.ActualHeight));
            PaintAllEvents();
            PaintAllDayEvents();
            if (_scheduler.StartJourney.Hours != 0)
            {
                double hourHeight = EventsGrid.ActualHeight / 22;
                ScrollEventsViewer.ScrollToVerticalOffset(hourHeight * (_scheduler.StartJourney.Hours - 1));
            }

            if (_scheduler.StartJourney.Hours == 0)
                startJourney.Visibility = System.Windows.Visibility.Hidden;
            else
                Grid.SetRowSpan(startJourney, _scheduler.StartJourney.Hours * 2);

            if (_scheduler.EndJourney.Hours == 0)
                endJourney.Visibility = System.Windows.Visibility.Hidden;
            else
            {
                Grid.SetRow(endJourney, _scheduler.EndJourney.Hours * 2);
                Grid.SetRowSpan(endJourney, 48 - _scheduler.EndJourney.Hours * 2);
            }
        }

        private void DayScheduler_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeGrids(e.NewSize);
            PaintAllEvents();
            PaintAllDayEvents();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                OnScheduleDoubleClick(sender, new DateTime(CurrentDay.Year, CurrentDay.Month, CurrentDay.Day));
            }
        }

        private IEnumerable<Event> TodayEvents
        {
            get
            {
                return _scheduler.Events.Where(ev => ev.Start.Date <= CurrentDay.Date && ev.End.Date >= CurrentDay.Date);
            }
        }

        private void PaintAllEvents()
        {
            if (_scheduler == null || _scheduler.Events == null) return;

            IEnumerable<Event> eventList = TodayEvents.Where(ev => ev.Start.Date == ev.End.Date && !ev.AllDay).OrderBy(ev => ev.Start);

            column.Children.Clear();

            double columnWidth = EventsGrid.ColumnDefinitions[1].Width.Value;

            foreach (Event e in eventList)
            {
                //column.Width = columnWidth;

                double oneHourHeight = 50;// column.ActualHeight / 46;

                var concurrentEvents = TodayEvents.Where(e1 => ((e1.Start <= e.Start && e1.End > e.Start) ||
                                                                (e1.Start > e.Start && e1.Start < e.End)) &&
                                                                e1.End.Date == e1.Start.Date).OrderBy(ev => ev.Start);

                double marginTop = oneHourHeight * (e.Start.Hour + (e.Start.Minute / 60.0));
                double width = columnWidth / (concurrentEvents.Count());
                double marginLeft = width * getIndex(e, concurrentEvents.ToList());

                EventUserControl wEvent = new EventUserControl(e, true);
                wEvent.Width = width;
                wEvent.Height = e.End.Subtract(e.Start).TotalHours * oneHourHeight;
                wEvent.Margin = new Thickness(marginLeft, marginTop, 0, 0);
                wEvent.MouseDoubleClick += ((object sender, MouseButtonEventArgs ea) =>
                {
                    ea.Handled = true;
                    OnEventDoubleClick(sender, wEvent.Event);
                });

                column.Children.Add(wEvent);
            }
        }

        private int getIndex(Event e, List<Event> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (e.Id == list[i].Id) return i;
            }
            return -1;
        }

        private void PaintAllDayEvents()
        {
            if (_scheduler == null || _scheduler.Events == null) return;

            allDayEvents.Children.Clear();

            double columnWidth = EventsGrid.ColumnDefinitions[1].Width.Value;

            foreach (Event e in TodayEvents.Where(ev => ev.End.Date > ev.Start.Date || ev.AllDay))
            {
                EventUserControl wEvent = new EventUserControl(e, false);
                wEvent.Width = columnWidth;
                wEvent.Margin = new Thickness(0, 0, 0, 0);
                wEvent.MouseDoubleClick += ((object sender, MouseButtonEventArgs ea) =>
                {
                    ea.Handled = true;
                    OnEventDoubleClick(sender, wEvent.Event);
                });
                allDayEvents.Children.Add(wEvent);
            }
        }

        private void ResizeGrids(Size newSize)
        {
            EventsGrid.Width = newSize.Width;
            EventsHeaderGrid.Width = newSize.Width;

            double columnWidth = (this.ActualWidth - EventsGrid.ColumnDefinitions[0].ActualWidth);
            for (int i = 1; i < EventsGrid.ColumnDefinitions.Count; i++)
            {
                EventsGrid.ColumnDefinitions[i].Width = new GridLength(columnWidth);
                EventsHeaderGrid.ColumnDefinitions[i].Width = new GridLength(columnWidth);
            }
        }
    }
}
