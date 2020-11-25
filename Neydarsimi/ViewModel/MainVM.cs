using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
        public string _VettvangurComboBox_old;
        public int _kennitala;

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
                    //GetKennitala(_TulkurListi);
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

        public string VettvangurComboBox_old
        {
            get
            {
                return _VettvangurComboBox_old;
            }
            set
            {
                if(_VettvangurComboBox_old != value)
                {
                    _VettvangurComboBox_old = value;
                    NotifyPropertyChanged("VettvangurComboBox");
                }
            }
        }

        public int Kennitala
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
                    //GetKennitala(_selectUser); 
                    NotifyPropertyChanged("SelectUser");
                }
            }
        }

        private ObservableCollection<clsTulkur> _tulkslisti;
        public ObservableCollection<clsTulkur> Tulkslisti
        {
            get
            {
                return _tulkslisti;
            }
            set
            {
                if (_tulkslisti != value)
                {
                    _tulkslisti = value;
                    NotifyPropertyChanged("Tulkslisti");
                }
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

        public ObservableCollection<clsVettvangur> _vettvangur;
        public ObservableCollection<clsVettvangur> VettvangurComboBox
        {
            get
            {
                return _vettvangur;
            }
            set
            {
                if(_vettvangur != value)
                {
                    _vettvangur = value;
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
            SelectItemListbox_CMD = new RelayCommand(GetKt);
            
            _neydarsimiData = new ObservableCollection<clsNeydarsimi>();
            _tulkslisti = new ObservableCollection<clsTulkur>();

            EventSystem.Subscribe<BasicChange>(UpdateNeydarsimi);
            EventSystem.Subscribe<NewUserAdd>(NewUserAdd_Fall);
            EventSystem.Subscribe<UpdateUser>(UpdateUser_Fall);

            LoadNeydarsimi();
            LoadTulkur();
            LoadVettvangur();
            NullStilla();
        }
        #endregion

        #region "Functions"

        public void NullStilla()
        {
            Kennitala = 0;
            Byrja_dagur = "";
            Endir_dagur = "";
            KlukkInnBox = "";
            KlukkUtBox = ""; 
        }
    
        public void GetKt(object obj)
        {
            try
            {
                var item = (Tulkur)obj;
                if(item != null)
                {
                    Kennitala = item.kt;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
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

        public void UpdateNeydarsimi(BasicChange msg)
        {
            LoadNeydarsimi();
        }

        public void NewUserAdd_Fall(NewUserAdd msg)
        {
            LoadTulkur();
        }

        public void UpdateUser_Fall(UpdateUser msg)
        {
            LoadTulkur();
            LoadNeydarsimi();
        }

        public void BookingProject_Fall(object obj)
        {
            if (Kennitala != 0)
            {
                //MessageBox.Show(Kennitala.ToString()); 

                if(Byrja_dagur != string.Empty && Endir_dagur != string.Empty && KlukkInnBox != string.Empty && KlukkUtBox != string.Empty && VettvangurComboBox_old != string.Empty)
                {
                    try
                    {
                        tblNeydarsimi _neydarsimi = new tblNeydarsimi
                        {
                            byrja = Byrja_dagur,
                            endir = Endir_dagur,
                            timi_byrja = KlukkInnBox,
                            timi_endir = KlukkUtBox,
                            tegund = VettvangurComboBox_old,
                            kt_fk = Kennitala
                        };

                        context.Context.tblNeydarsimis.Add(_neydarsimi);
                        context.Context.SaveChanges();
                        
                        MessageBox.Show("Neydarsími hafa vistaður", "Tilkynning");

                        LoadNeydarsimi();
                        
                        NullStilla();

                        //bæta við eventSystem.publish seinna 

                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        MessageBox.Show("Gagnavilla : " + message, "Tilkynning");
                    }
                }
                else
                {
                    MessageBox.Show("Innsetningarbox eru tómar", "Tilkynning");
                }
            }
            else
            {
                MessageBox.Show("Vinsamlegt að velja túlk", "Tilkynning"); 
            }
        }

        //Hlaða lista af neyðarsíma túlka
        public void LoadNeydarsimi()
        {
            _neydarsimiData.Clear(); 

            var query = from d1 in context.Context.Tulkurs
                        from d2 in context.Context.tblNeydarsimis
                        where d1.kt == d2.kt_fk
                        select new
                        {
                            d2.nr,
                            d1.nafn,
                            d2.timi_byrja,
                            d2.timi_endir,
                            d2.byrja,
                            d2.endir,
                            d2.tegund
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
            _tulkslisti.Clear(); 

            var query = from d1 in context.Context.Tulkurs
                        select d1;
            
            foreach(var str in query)
            {
                _tulkslisti.Add(new clsTulkur()
                {
                    kt = str.kt,
                    nafn = str.nafn
                });
            }
        }

        public void LoadVettvangur()
        {
            _vettvangur = new ObservableCollection<clsVettvangur>()
            {
                new clsVettvangur { tegund = "Venjuleg vakt"  },
                new clsVettvangur { tegund = "Helgarvakt" },
                new clsVettvangur { tegund = "Helgarvakt" },
                new clsVettvangur { tegund = "Páskar" },
                new clsVettvangur { tegund = "Sumardagurinn fyrsti" },
                new clsVettvangur { tegund = "Verkalýðsdagurinn" },
                new clsVettvangur { tegund = "Uppstigningardagur" },
                new clsVettvangur { tegund = "Hvítasunnudagur og Annar í hvítasunnu" },
                new clsVettvangur { tegund = "Íslenski þjóðhátíðardagurinn" },
                new clsVettvangur { tegund = "Verslunarmannahelgi" },
                new clsVettvangur { tegund = "Jól" }
            };
        }
        #endregion
    }
}
