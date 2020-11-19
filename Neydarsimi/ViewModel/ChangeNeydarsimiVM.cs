using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Neydarsimi.Helper;
using Neydarsimi.Model;

namespace Neydarsimi.ViewModel
{
    class ChangeNeydarsimiVM : ViewModelBase
    {
        #region "Variable"
        public string _TulkurBox;
        public string _Byrja_dagur;
        public string _Endir_dagur;
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurComboBox;
        public string _VettvangurBox;
        public int _kennitala;
        public RelayCommand ChangeNeydarsimi_CMD { get; set; }
        private DataContextSingleton context = DataContextSingleton.Instance;
        #endregion

        #region "Svæði"
        public int Kennitala
        {
            get
            {
                return _kennitala;
            }
            set
            {
                if (_kennitala != value)
                {
                    _kennitala = value;
                    NotifyPropertyChanged("Kennitala");
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
                    NotifyPropertyChanged("Fra_dagssetningur");
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
                    NotifyPropertyChanged("Til_dagssetningur");
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

        public string VettvangurComboBox
        {
            get
            {
                return _VettvangurComboBox; 
            }
            set
            {
                if (_VettvangurComboBox != value)
                {
                    VettvangurBox = VettvangurComboBox;
                    _VettvangurComboBox = value;
                    NotifyPropertyChanged("VettvangurComboBox");
                }
            }
        }

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

        #endregion
        public ChangeNeydarsimiVM()
        {
            ChangeNeydarsimi_CMD = new RelayCommand(ChangeNeydarsimi_Fall);

            _neydarsimiData = new ObservableCollection<clsNeydarsimi>();
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

        public void NullStilla()
        {
            Kennitala = 0;
            Byrja_dagur = "";
            Endir_dagur = "";
            KlukkInnBox = "";
            KlukkUtBox = "";
        }

        public void ChangeNeydarsimi_Fall(object obj)
        {
            if (TulkurBox != string.Empty && Byrja_dagur != string.Empty && Endir_dagur != string.Empty && KlukkInnBox != string.Empty && KlukkUtBox != string.Empty && VettvangurBox != string.Empty)
            {
                try
                {
              

                    context.Context.SaveChanges();

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
        }
    }
}
