using SealingSchoolWPF.Data;
using SealingSchoolWPF.Pages.Boat.Create;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SealingSchoolWPF.ViewModel.Boat
{
    class BoatListViewModel : ViewModel
    {

        static BoatListViewModel instance = null;
        static readonly object padlock = new object();

        public static BoatListViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BoatListViewModel();
                    }
                    return instance;
                }
            }
        }


        private MaterialMgr matMgr = new MaterialMgr();

        private ObservableCollection<BoatViewModel> boat;

        public ObservableCollection<BoatViewModel> Boats
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

        public BoatListViewModel()
        {
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            IList<SealingSchoolWPF.Model.Boat> mats = matMgr.GetAll();
            boat = new ObservableCollection<BoatViewModel>(mats.Select(p => new BoatViewModel(p)));
        }

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
            CreateBoat window = new CreateBoat();
            window.ShowDialog();
        }


    }
}