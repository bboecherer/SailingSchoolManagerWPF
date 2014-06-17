using SealingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.BoatAdministrationViewModel
{
    class BoatAdministrationListViewModel : ViewModel
    {

        static BoatAdministrationListViewModel instance = null;
        static readonly object padlock = new object();

        public static BoatAdministrationListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BoatAdministrationListViewModel();
                    }
                    return instance;
                }
            }
        }


        private BoatMgr boatMgr = new BoatMgr();

        private ObservableCollection<BoatAdministrationViewModel> boat;

        public ObservableCollection<BoatAdministrationViewModel> Boats
        {
            get
            {
                return boat;
            }
            set
            {
                if (Boats != value)
                {
                    boat = value;
                    this.OnPropertyChanged("Boats");
                }
            }
        }

        public BoatAdministrationListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Boat> boats = boatMgr.GetAll();
            boat = new ObservableCollection<BoatAdministrationViewModel>(boats.Select(p => new BoatAdministrationViewModel(p)));
            
        }

        
    }
}