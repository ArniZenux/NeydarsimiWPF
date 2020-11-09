using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Neydarsimi.Helper;
using Neydarsimi.View;
using Neydarsimi.Model;

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

        private DataContextSingleton context = DataContextSingleton.Instance;

        #endregion

        #region "Svæði"
        public string _TulkurListi;
        public string TulkurListi
        {
            get
            {
                return _TulkurListi;
            }
            set
            {
                if(_TulkurListi != value)
                {
                    _TulkurListi = value;
                    NotifyPropertyChanged("TulkurListi");
                }
            }
        }
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

        private ObservableCollection<Tulkur> _tulkslisti;
        public ObservableCollection<Tulkur> Tulkslisti
        {
            get
            {
                return _tulkslisti;
            }
            set
            {
                _tulkslisti = value;
                NotifyPropertyChanged("TulkurListi");
            }
        }

        public ObservableCollection<clsNeydarsimi> _neydarsimiData;
        public ObservableCollection<clsNeydarsimi> NeydarsimiData
        {
            get
            {
                return _neydarsimiData;
            }
            set
            {
                _neydarsimiData = value;
                NotifyPropertyChanged("NeydarsimiData");
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
            var query = from d1 in context.Context.Tulkurs
                        from d2 in context.Context.Vinnas
                        from d3 in context.Context.Neydarsimi1
                        where d1.kt == d2.kt && d2.nr == d3.nr
                        select new
                        {
                            d3.nr,
                            d1.nafn,
                            d3.timi_byrja,
                            d3.timi_endir,
                            d3.byrja,
                            d3.endir,
                            d3.tegund
                        };
            foreach (var str in query)
            {
                _neydarsimiData.Add(new clsNeydarsimi()
                {
                    nr = str.nr,
                    nafn = str.nafn,
                    byrja = str.byrja,
                    endir = str.endir,
                    timi_byrja = str.timi_byrja,
                    timi_endir = str.timi_endir,
                    tegund = str.tegund
                });
            }
        }
                
        //Hlaða list af túlkum. 
        public void LoadTulkur()
        {
            var query = from d1 in context.Context.Tulkurs
                        select d1;
            _tulkslisti = new ObservableCollection<Tulkur>(query);
        }
        #endregion
    }
}
