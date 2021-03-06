﻿using SailingSchoolWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SailingSchoolWPF.ViewModel.BoatAdministrationViewModel
{
    /// <summary>
    /// ViewModel for boat administration list
    /// @Author Stefan Müller
    /// </summary>
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


        private ObservableCollection<BoatAdministrationViewModel> boats;

        public ObservableCollection<BoatAdministrationViewModel> Boats
        {
            get
            {
                return boats;
            }
            set
            {
                if (Boats != value)
                {
                    boats = value;
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
            IList<SailingSchoolWPF.Model.Boat> boat = boatMgr.GetAll();
            boats = new ObservableCollection<BoatAdministrationViewModel>(boat.Select(p => new BoatAdministrationViewModel(p)));

        }


    }
}