using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SealingSchoolWPF.PDF;

namespace SealingSchoolWPF.ViewModel.Invoicing
{
    public class CreateCreditNoteViewModel : ViewModel<SealingSchoolWPF.Model.CreditNote>
    {
        #region ctor
        public CreateCreditNoteViewModel(SealingSchoolWPF.Model.CreditNote model)
            : base(model)
        {
            GetTrainingActivityTypNames();
        }

        static CreateCreditNoteViewModel instance = null;
        static readonly object padlock = new object();

        public static CreateCreditNoteViewModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CreateCreditNoteViewModel(new SealingSchoolWPF.Model.CreditNote());
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region properties

        private ObservableCollection<CreditNote> creditNotes;
        public ObservableCollection<CreditNote> CreditNotes
        {
            get
            {
                return this.GetCreditNotes();
            }
            set
            {
                if (creditNotes != value)
                {
                    creditNotes = value;
                    this.OnPropertyChanged("CreditNotes");
                }
            }
        }


        private IList<SealingSchoolWPF.Model.TrainingActivity> GetTrainingActivityTypNames()
        {
            CourseTypNames = new List<SealingSchoolWPF.Model.TrainingActivity>();

            foreach (SealingSchoolWPF.Model.TrainingActivity course in trainingActivityMgr.GetByStatus(TrainingActivityStatus.BEENDET))
            {
                CourseTypNames.Add(course);
                coursesList.Add(course);
            }

            TrainingActivityValues = coursesList;

            return CourseTypNames;
        }

        private IList<SealingSchoolWPF.Model.TrainingActivity> CourseTypNames;

        private IEnumerable<SealingSchoolWPF.Model.TrainingActivity> _trainingActivityValues;
        public IEnumerable<SealingSchoolWPF.Model.TrainingActivity> TrainingActivityValues
        {
            get
            {
                return coursesList;
            }
            set
            {
                _trainingActivityValues = value;
                this.OnPropertyChanged("TrainingActivityValues");
            }
        }

        private SealingSchoolWPF.Model.TrainingActivity _trainingActivityTyp;
        public SealingSchoolWPF.Model.TrainingActivity TrainingActivityTyp
        {
            get
            {
                return _trainingActivityTyp;
            }
            set
            {
                _trainingActivityTyp = value;
                this.OnPropertyChanged("TrainingActivityTyp");
            }
        }

        private bool _isComboBoxEnabled = true;
        public bool IsComboBoxEnabled
        {
            get
            {
                return _isComboBoxEnabled;
            }
            set
            {
                _isComboBoxEnabled = value;
                this.OnPropertyChanged("IsComboBoxEnabled");
            }
        }

        private bool _isComboBoxReadOnly = false;
        public bool IsComboBoxReadOnly
        {
            get
            {
                return _isComboBoxReadOnly;
            }
            set
            {
                _isComboBoxReadOnly = value;
                this.OnPropertyChanged("IsComboBoxReadOnly");
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

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get
            {
                return _isButtonEnabled;
            }
            set
            {
                _isButtonEnabled = value;
                this.OnPropertyChanged("IsButtonEnabled");
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

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(p => ExecuteClearCommand());
                }
                return clearCommand;
            }
        }

        private void ExecuteClearCommand()
        {
            this.ErrorLabel = string.Empty;
            //TODO: Felder leeren
            this.ReBindDataGrid();
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
            InvoiceItem item = new InvoiceItem();
            item.GrossPrice = this.TrainingActivityTyp.Course.GrossPrice;
            item.NetPrice = this.TrainingActivityTyp.Course.NetPrice;
            item.VatAmount = this.TrainingActivityTyp.Course.NetAmount;
            item.Amount = 1;
            item.ServiceLocation = "Italien";
            item.ServiceEndDate = DateTime.Now;
            item.ServiceStartDate = DateTime.Now;
            //Model.InvoiceItems = new List<InvoiceItem>();
            //Model.InvoiceItems.Add(item);

            //Model.CreatedOn = DateTime.Now;
            //Model.Printed = false;
            Model.GrossPrice = this.TrainingActivityTyp.Course.GrossPrice;
            Model.NetPrice = this.TrainingActivityTyp.Course.NetPrice;
            Model.VatAmount = this.TrainingActivityTyp.Course.NetAmount;
            //Model.PaymentStatus = PaymentStatus.NICHT_GEZAHLT;
            //Model.InvoiceStatus = InvoiceStatus.RECHNUNG;
            //Model.PaymentTargetDate = DateTime.Now.Add(new TimeSpan(14, 0, 0, 0));
            //Model.PaidDate = DateTime.Now;
            //Model.ModifiedOn = DateTime.Now;
            //Model.Label = this.TrainingActivityTyp.Student.Label + " / " + this.TrainingActivityTyp.Course.Label;

            try
            {
                this.creditNoteMgr.Create(Model);
                TrainingActivity ta = this.trainingActivityMgr.GetById(this.TrainingActivityTyp.TrainingActivityId);
                ta.TrainingActivityStatus = TrainingActivityStatus.RECHNUNG_GESTELLT;
                this.trainingActivityMgr.Update(ta);

                PDFTest createInvoicePDF = new PDFTest();
                string name = DateTime.Now.ToString().Replace(".", "_").Replace(":", string.Empty).Replace(" ", "_");
                //createInvoicePDF.createPDF(name.Trim(), ta, Model.InvoiceId);
            }
            catch (Exception e)
            {

            }
        }

        private void ReBindDataGrid()
        {
            this.ErrorLabel = String.Empty;
        }

        private ObservableCollection<SealingSchoolWPF.Model.CreditNote> GetCreditNotes()
        {
            IList<SealingSchoolWPF.Model.CreditNote> invs = this.creditNoteMgr.GetAll();
            creditNotes = new ObservableCollection<CreditNote>(invs);
            return creditNotes;
        }

        public IList<TrainingActivity> coursesList = new List<TrainingActivity>();
        #endregion
    }
}