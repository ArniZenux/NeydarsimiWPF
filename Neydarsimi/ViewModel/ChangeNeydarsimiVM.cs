using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Neydarsimi.Helper;
using Neydarsimi.Model;

namespace Neydarsimi.ViewModel
{
    class ChangeNeydarsimiVM : ViewModelBase
    {
        #region "Variable"
        public int _number;
        public string _TulkurBox;
        public string _Byrja_dagur;
        public string _Endir_dagur;
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurComboBox_old;
       
        //public string _VettvangurComboBox;
        public string _VettvangurBox;
        public int _KennitalaBox;
        public RelayCommand ChangeNeydarsimi_CMD { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }
        public RelayCommand SelectTulkur { get; set; }

        private DataContextSingleton context = DataContextSingleton.Instance;
        #endregion

        #region "Svæði"

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if(_number != value)
                {
                    _number = value;
                    NotifyPropertyChanged("Number");
                }
            }
        }

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

        public string TulkurBox
        {
            get
            {
                return _TulkurBox;
            }
            set
            {
                if(_TulkurBox != value)
                {
                    _TulkurBox = value;
                    NotifyPropertyChanged("TulkurBox");
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
                if (_KlukkInnBox != value)
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
                    NotifyPropertyChanged("KlukkUtBox");
                }
            }
        }

        //select of combobox and so can save/update it. 
        public string VettvangurComboBox_old
        {
            get
            {
                return _VettvangurComboBox_old; 
            }
            set
            {
                if (_VettvangurComboBox_old != value)
                {
                    _VettvangurComboBox_old = value;
                    NotifyPropertyChanged("VettvangurComboBox_old");
                }
            }
        }

        //normal print í textbox
        public string VettvangurBox
        {
            get
            {
                return _VettvangurBox;
            }
            set
            {
                if(_VettvangurBox != value)
                {
                    _VettvangurBox = value;
                    NotifyPropertyChanged("VettvangurBox");
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

        //print vettvangur í combobox
        public ObservableCollection<clsVettvangur> _vettvangur;
        public ObservableCollection<clsVettvangur> VettvangurComboBox
        {
            get
            {
                return _vettvangur;
            }
            set
            {
                if (_vettvangur != value)
                {
                    _vettvangur = value;
                    NotifyPropertyChanged("VettvangurComboBox");
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

        #endregion
        public ChangeNeydarsimiVM()
        {
            ChangeNeydarsimi_CMD = new RelayCommand(ChangeNeydarsimi_Fall);
            SelectionChangedCommand = new RelayCommand(SelectionChangedCommand_Fall);
            SelectTulkur = new RelayCommand(SelectTulkur_Fall);

            _neydarsimiData = new ObservableCollection<clsNeydarsimi>();
            _tulkslisti = new ObservableCollection<clsTulkur>();

            LoadNeydarsimi();
            LoadVettvangur();
            LoadTulkur(); 
            NullStilla(); 
        }

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
                            d2.tegund,
                            d2.kt_fk
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
                    tegund = str.tegund,
                    kt_fk = str.kt_fk                    
                });
            }
        }

        public void LoadTulkur()
        {
            Tulkslisti.Clear();

            var query = from d1 in context.Context.Tulkurs
                        select new
                        {
                            d1.kt,
                            d1.nafn
                        };
            foreach (var str in query)
            {
                _tulkslisti.Add(new clsTulkur()
                {
                    kt = str.kt,
                    nafn = str.nafn
                });
            }
        }

        public void NullStilla()
        {
            Number = 0; 
            KennitalaBox = 0;
            TulkurBox = ""; 
            Byrja_dagur = "";
            Endir_dagur = "";
            KlukkInnBox = "";
            KlukkUtBox = "";
            VettvangurBox = "";
        }
        public void LoadVettvangur()
        {
            _vettvangur = new ObservableCollection<clsVettvangur>()
            {
                new clsVettvangur { tegund = "Þjóðarhátíð"  },
                new clsVettvangur { tegund = "Aðdangsdagur" }
            };
        }

        public void SelectionChangedCommand_Fall(object obj)
        {
            try
            {
                var item = (clsNeydarsimi)obj;
                
                if (item != null)
                {
                    Number = item.nr;
                    TulkurBox = item.nafn;
                    Byrja_dagur = item.byrja;
                    Endir_dagur = item.endir;
                    KlukkInnBox = item.timi_byrja;
                    KlukkUtBox = item.timi_endir;
                    VettvangurBox = item.tegund;
                    KennitalaBox = item.kt_fk;

                   // GetTulkur();
                }
            }
            catch
            {
            }
        }

        /*public void GetTulkur()
        {
            var query = from d1 in context.Context.Tulkurs
                        where d1.nafn == TulkurBox
                        select new
                        {
                            KennitalaBox = d1.kt
                        };                    
        }*/

        public void SelectTulkur_Fall(object obj)
        {
            try
            {
                var item = (clsTulkur)obj;
                if (item != null)
                {
                    KennitalaBox = item.kt;
                }
            }
            catch
            {
            }
        }

        public void ChangeNeydarsimi_Fall(object obj)
        {
            string message = "Túlkur: " + TulkurBox + "\n" + "Byrja: " + Byrja_dagur + "\n" + "Endir: " + Endir_dagur + "\n" + "Inn: " + KlukkInnBox + "\n" + "Út: " + KlukkUtBox + "\n" + "Vettvangur: " + VettvangurBox + "\n";

            DialogResult dialogResult = MessageBox.Show(message, "Er rétt upplýsingar?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Já");
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Nei");
            }


            /*
            if (Number != 0 && KennitalaBox != 0 && TulkurBox != string.Empty && Byrja_dagur != string.Empty && Endir_dagur != string.Empty && KlukkInnBox != string.Empty && KlukkUtBox != string.Empty && VettvangurBox != string.Empty)
            {
                try
                {
                    tblNeydarsimi _neydarsimiUpdate = ( from d1 in context.Context.tblNeydarsimis
                                                        where d1.nr == Number
                                                        select d1).First();

                    _neydarsimiUpdate.byrja = Byrja_dagur;
                    _neydarsimiUpdate.endir = Endir_dagur;
                    _neydarsimiUpdate.timi_byrja = KlukkInnBox;
                    _neydarsimiUpdate.timi_endir = KlukkUtBox;
                    _neydarsimiUpdate.tegund = VettvangurBox;
                    _neydarsimiUpdate.kt_fk = KennitalaBox;
                                      
                    context.Context.SaveChanges();

                    MessageBox.Show("Neyðarsími túlks endurbreytaður.", "Tilkynning");

                    LoadNeydarsimi();
                    NullStilla();
                }
                catch (Exception ex)
                {
                    string text = ex.Message;
                    MessageBox.Show("Gagnavilla..");
                }
            }
            else
            {
                MessageBox.Show("Innsetningarbox eru tómar", "Tilkynning");
            }
            */
        }
    }
}
