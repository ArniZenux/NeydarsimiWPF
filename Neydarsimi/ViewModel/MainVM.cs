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
        public string _Byrja_dagur;
        public string _Endir_dagur; 
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurComboBox;
        public string _kennitala;

        public RelayCommand AddUser_CMD { get; set; }
        public RelayCommand ChangeUser_CMD { get; set; }
        public RelayCommand ChangeGSM_CMD { get; set; }
        public RelayCommand BookingProject_CMD { get; set; }
        public RelayCommand SelectItemListbox_CMD { get; set; }

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
                    GetKennitala(_TulkurListi);
                    NotifyPropertyChanged("TulkurListi");
                }
            }
        }

        public string Byrja_dagur
        {
            get
            {
                return _Byrja_dagur;
            }
            set
            {
                if(_Byrja_dagur != value)
                {
                    _Byrja_dagur = value;
                    NotifyPropertyChanged("Byrja_dagur");
                }
            }
        }

        public string Endir_dagur
        {
            get
            {
                return _Endir_dagur;
            }
            set
            {
                if (_Endir_dagur != value)
                { 
                    _Endir_dagur = value;
                    NotifyPropertyChanged("Endir_dagur");
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

        public string Kennitala
        {
            get
            {
                return _kennitala;
            }
            set
            {
                if(_kennitala != value)
                {
                    _kennitala = value;
                    NotifyPropertyChanged("Kennitala");
                }
            }
        }

        public string _selectUser;
        public string SelectUser
        {
            get
            {
                return _selectUser;
            }
            set
            {
                if (_selectUser != value)
                {
                    _selectUser = value;
                    GetKennitala(_selectUser); 
                    NotifyPropertyChanged("SelectUser");
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
            SelectItemListbox_CMD = new RelayCommand(GetKt);

            LoadNeydarsimi();
            LoadTulkur();
            NullStilla();
        }
        #endregion

        #region "Functions"
        public void NullStilla()
        {
            Kennitala = ""; 
        }
        public void GetKennitala(string _kennitala)
        {
            var query = from item in context.Context.Tulkurs
                        where item.kt == _kennitala
                        select item;

            foreach(var str in query)
            {
                Kennitala = str.kt;
            }
        }

        public void GetKt(object obj)
        {
            try
            {
                var item = (clsTulkur)obj;
                if(item != null)
                {
                    Kennitala = item.kt;
                    MessageBox.Show(Kennitala.ToString()); 
                }
            }
            catch (Exception ex)
            {

            }
        }
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
            if (Kennitala != string.Empty)
            {
                MessageBox.Show(Kennitala);

                /*
                if (Byrja_dagur != string.Empty && Endir_dagur != string.Empty && KlukkInnBox != string.Empty && KlukkUtBox != string.Empty && VettvangurComboBox != string.Empty)
                {
                    try
                    {
                        Vinna _vinna = new Vinna
                        {
                            kt = Kennitala,
                            turn_off = 1
                        };
                        context.Context.Vinnas.Add(_vinna);
                        context.Context.SaveChanges();

                        Neydarsimi1 _neydarsimi = new Neydarsimi1
                        {
                            byrja = Byrja_dagur,
                            endir = Endir_dagur,
                            timi_byrja = KlukkInnBox,
                            timi_endir = KlukkUtBox,
                            tegund = VettvangurComboBox,

                        };
                        context.Context.Neydarsimi1.Add(_neydarsimi);
                        context.Context.SaveChanges();

                        MessageBox.Show("Neydarsími hafa vistaður.", "Tilkynning");

                        //bæta við eventSystem.publish seinna 

                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        MessageBox.Show("Gagnavilla: ", ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Innsetningarbox eru tómar", "Tilkynning");
                }
                */
            }
            else
            {
                MessageBox.Show("Veldu túlkur", "Tilkynning"); 
            }
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
