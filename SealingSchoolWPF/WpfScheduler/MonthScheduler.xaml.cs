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
    /// Interaction logic for MonthScheduler.xaml
    /// </summary>
    public partial class MonthScheduler : UserControl
    {
        private Scheduler _scheduler;
        private DateTime firstDay;
        private DateTime lastDay;

        internal event EventHandler<Event> OnEventDoubleClick;
        internal event EventHandler<DateTime> OnScheduleDoubleClick;

        #region CurrentMonth

        private DateTime _currentMonth;
        internal DateTime CurrentMonth
        {
            get { return _currentMonth; }
            set {
                _currentMonth = new DateTime(value.Year, value.Month, 1);
                PaintMonth();
                PaintAllEvents();
                PaintAllDayEvents();
            }
        }

        #endregion

        private Dictionary<DateTime, MonthDay> controls = new Dictionary<DateTime,MonthDay>();

        private void PaintMonth()
        {
            DateTime dt = CurrentMonth;
            int currentMonth = dt.Month;
            while (dt.DayOfWeek != DayOfWeek.Monday) dt = dt.AddDays(-1);

            EventsGrid.Children.Clear();
            EventsGrid.RowDefinitions.Clear();
            controls.Clear();

            // Start painting
            int currentRow = -1;
            firstDay = dt;
            while ((dt.Month <= currentMonth && dt.Year == CurrentMonth.Year) ||
                (dt.Year < CurrentMonth.Year) ||
                dt.DayOfWeek != DayOfWeek.Monday)
            {
                if (dt.DayOfWeek == DayOfWeek.Monday)
                {
                    RowDefinition rd = new RowDefinition();
                    EventsGrid.RowDefinitions.Add(rd);
                    currentRow++;
                }
                MonthDay uc = new MonthDay(dt, currentMonth == dt.Month);
                Grid.SetRow(uc, currentRow);
                Grid.SetColumn(uc, DayOfWeekToInt(dt.DayOfWeek));
                EventsGrid.Children.Add(uc);

                uc.OnScheduleDoubleClick += ((object sender, DateTime e) =>
                {
                    OnScheduleDoubleClick(sender, e);
                });

                uc.OnEventDoubleClick += ((object sender, Event e) =>
                {
                    OnEventDoubleClick(sender, e);
                });

                controls.Add(dt.Date, uc);
                dt = dt.AddDays(1);
            }
            lastDay = dt;
        }

        private static int DayOfWeekToInt(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return 0;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 3;
                case DayOfWeek.Friday:
                    return 4;
                case DayOfWeek.Saturday:
                    return 5;
                default:
                    return 6;
            }
        }

        public MonthScheduler()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs ea)
        {
            DependencyObject ucParent = (sender as MonthScheduler).Parent;
            while (!(ucParent is Scheduler))
            {
                ucParent = LogicalTreeHelper.GetParent(ucParent);
            }
            _scheduler = ucParent as Scheduler;

            _scheduler.OnEventAdded += ((object s, Event e) =>
            {
                if (e.Start.Date == e.End.Date)
                    PaintAllEvents(e.Start);
                else
                    PaintAllDayEvents();
            });

            _scheduler.OnEventDeleted += ((object s, Event e) =>
            {
                if (e.Start.Date == e.End.Date)
                    PaintAllEvents(e.Start);
                else
                    PaintAllDayEvents();
            });

            _scheduler.OnEventsModified += ((object s, EventArgs e) =>
            {
                PaintAllEvents();
            });

            PaintMonth();
            PaintAllEvents();
            PaintAllDayEvents();
        }


        private IEnumerable<Event> EventsToShow
        {
            get
            {
                if (_scheduler == null || _scheduler.Events == null) return new List<Event>();

                return _scheduler.Events.Where(e => (e.Start.Date >= firstDay && e.Start.Date <= lastDay) ||
                                                    (e.End.Date >= firstDay && e.End.Date <= lastDay));
            }
        }

        private void PaintAllEvents(DateTime dt)
        {
            if (controls.ContainsKey(dt.Date))
            {
                MonthDay mD = controls[dt.Date];
                mD.Events = EventsToShow.Where(e => e.Start.Date == dt.Date).ToList();
            }
        }

        private void PaintAllEvents()
        {
            foreach (DateTime dt in EventsToShow.Where(e => e.Start.Date == e.End.Date).Select(e => e.Start).Distinct())
            {
                PaintAllEvents(dt);
            }
        }

        private void PaintAllDayEvents()
        {
            foreach(DateTime dt in controls.Keys) {
                if (controls.ContainsKey(dt.Date))
                {
                    MonthDay mD = controls[dt.Date];
                    mD.Events = EventsToShow.Where(e => e.Start.Date <= dt.Date && e.End.Date >= dt.Date).ToList();
                }
            }
        }
    }
}
