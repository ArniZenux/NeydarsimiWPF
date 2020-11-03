using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Neydarsimi.Helper;
using Neydarsimi.Data;
using Neydarsimi.Model;

namespace Neydarsimi.ViewModel
{
    class ChangeUserVM : ViewModelBase
    {
        #region "Variable"
        public int _KennitalaBox;
        public string _FulltNafnBox;
        public RelayCommand Change_user_CMD { get; set; }
        public RelayCommand SelectItemListbox_CMD { get; set; }

        private DataContextSingleton context = DataContextSingleton.Instance;

        #endregion

        #region "svæði" 
        public int KennitalaBox
        {
            get
            {
                return _KennitalaBox;
            }
            set
            {
                if (_KennitalaBox != value)
                {
                    _KennitalaBox = value;
                    NotifyPropertyChanged("KennitalaBox");
                }
            }
        }

        public string FulltNafnBox
        {
            get
            {
                return _FulltNafnBox;
            }
            set
            {
                if (_FulltNafnBox != value)
                {
                    _FulltNafnBox = value;
                    NotifyPropertyChanged("FulltNafnBox");
                }
            }
        }

        private ObservableCollection<tulkur> _tulkslisti; 
        public ObservableCollection<tulkur> Tulkslisti
        {
            get
            {
                return _tulkslisti;
            }
            set
            {
                _tulkslisti = value; 
            }
        }
        #endregion 

        #region "NewUser VM"
        public ChangeUserVM()
        {
            Change_user_CMD = new RelayCommand(Change_user_Fall);
            SelectItemListbox_CMD = new RelayCommand(SelectItemListbox_Fall);
            LoadTulkur();
            KennitalaBox = 0;
            FulltNafnBox = ""; 
        }
        #endregion

        #region "Functions"
        //Hlaða list af túlkum. 
        public void LoadTulkur()
        {
            var query = from d1 in context.Context.Tulkurs
                        select d1;
            _tulkslisti = new ObservableCollection<tulkur>(); 

            /*_tulkslisti = new ObservableCollection<tulkur>()
            {
                new tulkur() { kt = 123, nafn = "Arni" },
                new tulkur() { kt = 321, nafn = "Ingi" },
            };*/
        }

        public void Change_user_Fall(object obj)
        {
            if (KennitalaBox != 0)
            {
                try
                {
                    MessageBox.Show("Vista Vista");

                }
                catch (Exception ex)
                {
                    string text = ex.Message;
                    MessageBox.Show("Gagnavilla..");
                }

            }
            else
            {
                MessageBox.Show("EKKI VISTA");
            }
        }

        public void SelectItemListbox_Fall(object obj)
        {
            try
            {
                var item = (tulkur)obj;
                if(item != null)
                {
                    KennitalaBox = item.kt;
                    FulltNafnBox = item.nafn;
                }
            }
            catch 
            {
            }
        }
        #endregion
    }
}
