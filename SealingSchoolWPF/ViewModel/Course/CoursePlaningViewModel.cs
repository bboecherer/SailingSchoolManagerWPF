using SailingSchoolWPF.Data;
using SailingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.Course
{
    /// <summary>
    /// ViewModel for course planning
    /// @Author Benjamin Böcherer
    /// </summary>
    public class CoursePlaningViewModel : ViewModel<SailingSchoolWPF.Model.CoursePlaning>
    {
        #region ctor
        public CoursePlaningViewModel(SailingSchoolWPF.Model.CoursePlaning model)
            : base(model)
        {
        }

        static CoursePlaningViewModel instance = null;
        static readonly object padlock = new object();

        public static CoursePlaningViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CoursePlaningViewModel(new SailingSchoolWPF.Model.CoursePlaning());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties
        public int Id
        {
            get
            {
                return Model.CoursePlaningId;
            }
            set
            {
                if (Id != value)
                {
                    Model.CoursePlaningId = value;
                    this.OnPropertyChanged("CoursePlaningId");
                }
            }
        }

        private ObservableCollection<CoursePlaning> coursePlanings;
        public ObservableCollection<CoursePlaning> CoursePlanings
        {
            get
            {
                return this.GetCoursePlanings();
            }
            set
            {
                if (coursePlanings != value)
                {
                    coursePlanings = value;
                    this.OnPropertyChanged("CoursePlanings");
                }
            }
        }

        public string Label
        {
            get
            {
                return Model.Label;
            }
            set
            {
                if (Label != value)
                {
                    Model.Label = value;
                    this.OnPropertyChanged("Label");
                }
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return Model.StartDate;
            }
            set
            {
                if (StartDate != value)
                {
                    Model.StartDate = value;
                    this.OnPropertyChanged("StartDate");
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                return Model.EndDate;
            }
            set
            {
                if (EndDate != value)
                {
                    Model.EndDate = value;
                    this.OnPropertyChanged("EndDate");
                }
            }
        }

        public String EndDateColumn
        {
            get
            {
                return Model.EndDate.Value.ToShortDateString();
            }
        }


        #endregion

        #region commands
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(p => ExecuteAddCommand());
                }
                return addCommand;
            }
        }

        private void ExecuteAddCommand()
        {
            //TODO: SAVE TO DB
        }
        #endregion

        #region helpers
        private ObservableCollection<SailingSchoolWPF.Model.CoursePlaning> GetCoursePlanings()
        {
            IList<SailingSchoolWPF.Model.CoursePlaning> courseList = coursePlaningMgr.GetAll();
            coursePlanings = new ObservableCollection<CoursePlaning>(courseList);
            return coursePlanings;
        }

        #endregion
    }
}
