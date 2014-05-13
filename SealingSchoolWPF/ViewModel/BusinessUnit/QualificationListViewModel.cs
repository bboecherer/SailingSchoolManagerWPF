using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.BusinessUnit
{
    public class QualificationListViewModel : ViewModel
    {
        private QualificationMgr qualificationMgr = new QualificationMgr();

        static QualificationListViewModel instance = null;
        static readonly object padlock = new object();

        public static QualificationListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new QualificationListViewModel();
                    }
                    return instance;
                }
            }
        }

        private ObservableCollection<QualificationViewModel> qualifications;

        public ObservableCollection<QualificationViewModel> Qualifications
        {
            get
            {
                return qualifications;
            }
            set
            {
                if (Qualifications != value)
                {
                    qualifications = value;
                    this.OnPropertyChanged("Qualifications");
                }
            }
        }

        public QualificationListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Qualification> qualificationsList = qualificationMgr.GetAll();
            qualifications = new ObservableCollection<QualificationViewModel>(qualificationsList.Select(q => new QualificationViewModel(q)));
        }
    }
}