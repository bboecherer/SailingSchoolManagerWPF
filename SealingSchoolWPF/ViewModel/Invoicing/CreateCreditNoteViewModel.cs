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
            GetInvoiceTypNames();
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


        private IList<SealingSchoolWPF.Model.Invoice> GetInvoiceTypNames()
        {
            InvoiceTypNames = new List<SealingSchoolWPF.Model.Invoice>();

            foreach (SealingSchoolWPF.Model.Invoice inv in invoiceMgr.GetByStatus(PaymentStatus.GEZAHLT))
            {
                InvoiceTypNames.Add(inv);
                invoiceList.Add(inv);
            }

            InvoiceValues = invoiceList;

            return InvoiceTypNames;
        }

        private IList<SealingSchoolWPF.Model.Invoice> InvoiceTypNames;

        private IEnumerable<SealingSchoolWPF.Model.Invoice> _invoiceValues;
        public IEnumerable<SealingSchoolWPF.Model.Invoice> InvoiceValues
        {
            get
            {
                return invoiceList;
            }
            set
            {
                _invoiceValues = value;
                this.OnPropertyChanged("InvoiceValues");
            }
        }

        private SealingSchoolWPF.Model.Invoice _invoiceTyp;
        public SealingSchoolWPF.Model.Invoice InvoiceTyp
        {
            get
            {
                return _invoiceTyp;
            }
            set
            {
                _invoiceTyp = value;
                this.OnPropertyChanged("InvoiceTyp");
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
            CreditNoteItem item = new CreditNoteItem();
            item.GrossPrice = this.InvoiceTyp.GrossPrice;
            item.NetPrice = this.InvoiceTyp.NetPrice;
            item.VatAmount = this.InvoiceTyp.VatAmount;
            item.Amount = 1;
            item.ServiceLocation = "Italien";
            item.ServiceEndDate = DateTime.Now;
            item.ServiceStartDate = DateTime.Now;
            Model.CreditNoteItems = new List<CreditNoteItem>();
            Model.CreditNoteItems.Add(item);

            Model.CreatedOn = DateTime.Now;
            Model.GrossPrice = this.InvoiceTyp.GrossPrice;
            Model.NetPrice = this.InvoiceTyp.NetPrice;
            Model.VatAmount = this.InvoiceTyp.VatAmount;
            Model.ModifiedOn = DateTime.Now;
            Model.Label = "GS_" + this.InvoiceTyp.Label;
            Model.CreditDate = DateTime.Now;

            try
            {
                this.creditNoteMgr.Create(Model);
                this.InvoiceTyp.InvoiceStatus = InvoiceStatus.GUTSCHRIFT;
                this.InvoiceTyp.PaymentStatus = PaymentStatus.GUTGESCHRIEBEN;
                this.invoiceMgr.Update(this.InvoiceTyp);

                PDFTest createCreditNotePDF = new PDFTest();
                string name = DateTime.Now.ToString().Replace(".", "_").Replace(":", string.Empty).Replace(" ", "_");
                createCreditNotePDF.createCreditNotePDF(name.Trim(), Model);
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

        public IList<Invoice> invoiceList = new List<Invoice>();
        #endregion
    }
}