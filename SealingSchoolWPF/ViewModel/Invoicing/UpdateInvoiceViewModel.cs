using SealingSchoolWPF.Data;
using SealingSchoolWPF.Model;
using SealingSchoolWPF.Pages.Student.Create;
using SealingSchoolWPF.ViewModel.BusinessUnit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SealingSchoolWPF.ViewModel.Course
{
    public class UpdateInvoiceViewModel : ViewModel<SealingSchoolWPF.Model.Invoice>
    {
        static SealingSchoolWPF.Model.Invoice modelDummy = new SealingSchoolWPF.Model.Invoice();

        #region ctor
        public UpdateInvoiceViewModel(SealingSchoolWPF.Model.Invoice model)
            : base(model)
        {
            modelDummy.InvoiceId = model.InvoiceId;
            modelDummy.CreatedOn = model.CreatedOn;
            modelDummy.PaymentStatus = model.PaymentStatus;
            modelDummy.Label = model.Label;
        }

        static UpdateInvoiceViewModel instance = null;
        static readonly object padlock = new object();

        public static UpdateInvoiceViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UpdateInvoiceViewModel(modelDummy);
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties

        public string Label
        {
            get
            {
                return modelDummy.Label;
            }
        }

        public IEnumerable<PaymentStatus> InvoiceStatusTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(PaymentStatus))
                    .Cast<PaymentStatus>();
            }
        }

        private PaymentStatus _invoiceStatus;
        public PaymentStatus InvoiceStatus
        {
            get
            {
                return modelDummy.PaymentStatus;
            }
            set
            {
                _invoiceStatus = value;
                this.OnPropertyChanged("InvoiceStatus");
            }
        }

        private string _errorLabel;
        public string ErrorLabel
        {
            get
            {
                return _errorLabel;
            }
            set
            {
                _errorLabel = value;
                this.OnPropertyChanged("ErrorLabel");
            }
        }

        private string _imageSourceSave = "/Resources/Images/save_16xLG.png";
        public string ImageSourceSave
        {
            get
            {
                return _imageSourceSave;
            }
            set
            {
                _imageSourceSave = value;
                this.OnPropertyChanged("ImageSourceSave");
            }
        }

        private string _imageSourceNext = "/Resources/Images/arrow_Next_16xLG.png";
        public string ImageSourceNext
        {
            get
            {
                return _imageSourceNext;
            }
            set
            {
                _imageSourceNext = value;
                this.OnPropertyChanged("ImageSourceNext");
            }
        }

        private string _imageSourceClear = "/Resources/Images/Undo_16x.png";
        public string ImageSourceClear
        {
            get
            {
                return _imageSourceClear;
            }
            set
            {
                _imageSourceClear = value;
                this.OnPropertyChanged("ImageSourceClear");
            }
        }

        public string InvoiceDate
        {
            get
            {
                return modelDummy.CreatedOn.ToString();
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
            SaveModelToDatabase();
            Application.Current.Windows[1].Close();
        }

        #endregion

        #region helpers

        public void Close()
        {
            instance = null;
        }

        private void SaveModelToDatabase()
        {
            Model.PaymentStatus = this._invoiceStatus;
            invoiceMgr.Update(Model);
        }

        #endregion

    }
}