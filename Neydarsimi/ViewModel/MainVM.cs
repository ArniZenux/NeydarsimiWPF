using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Neydarsimi.Helpers;
using Neydarsimi.View;

namespace Neydarsimi.ViewModel
{
    class MainVM : ViewModelBase
    {
        #region "Variable" 
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurComboBox;
        public RelayCommand AddUser_CMD { get; set; }
        public RelayCommand ChangeUser_CMD { get; set; }
        public RelayCommand ChangeGSM_CMD { get; set; }
        public RelayCommand BookingProject_CMD { get; set; }
        #endregion

        #region "Svæði"
        public string KlukkInnBox
        {
            get
            {
                return _KlukkInnBox;
            }
            set
            {
                if(_KlukkInnBox != value)
                {
                    _KlukkInnBox = value;
                    NotifyPropertyChanged("KlukkInnBox");
                }
            }
        }

        public string KlukkUtBox
        {
            get
            {
                return _KlukkUtBox;
            }
            set
            {
                if (_KlukkUtBox != value)
                {
                    _KlukkUtBox = value;
                    NotifyPropertyChanged("KlukkInnBox");
                }
            }
        }

        public string VettvangurComboBox
        {
            get
            {
                return _VettvangurComboBox;
            }
            set
            {
                if(_VettvangurComboBox != value)
                {
                    _VettvangurComboBox = value;

                    NotifyPropertyChanged("VettvangurComboBox");
                }
            }
        }

        #endregion

        #region "Main VM"
        public MainVM()
        {
            AddUser_CMD = new RelayCommand(AddUser_Fall);
            ChangeUser_CMD = new RelayCommand(ChangeUser_Fall);
            ChangeGSM_CMD = new RelayCommand(ChangeGSM_Fall); 
            BookingProject_CMD = new RelayCommand(BookingProject_Fall);

            LoadNeydarsimi();
            LoadTulkur(); 
        }
        #endregion

        #region "Functions"
        public void AddUser_Fall(object obj)
        {
            NewUser new_user = new NewUser(); 
            new_user.Show(); 
        }

        public void ChangeUser_Fall(object obj)
        {
            ChangeUser change_user = new ChangeUser();
            change_user.Show(); 
        }

        public void ChangeGSM_Fall(object obj)
        {
            ChangeNeydarsimi change_gsm = new ChangeNeydarsimi();
            change_gsm.Show(); 
        }

        public void BookingProject_Fall(object obj)
        {
            MessageBox.Show("Skrá");
            KlukkInnBox = "";
            KlukkUtBox = "";
        }

        //Hlaða lista af neyðarsíma túlka
        public void LoadNeydarsimi()
        {

        }

        
        //Hlaða list af túlkum. 
        public void LoadTulkur()
        {

        }
        #endregion
    }
}
