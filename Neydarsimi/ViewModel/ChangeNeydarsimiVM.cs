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
        public string _Fra_dagssetningur;
        public string _Til_dagssetningur;
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurComboBox;
        public string _VettvangurBox;
        public RelayCommand ChangeNeydarsimi_CMD { get; set; }
        private DataContextSingleton context = DataContextSingleton.Instance;
        #endregion

        #region "Svæði"
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

        public string Fra_dagssetningur
        {
            get
            {
                return _Fra_dagssetningur;
            }
            set
            {
                if(_Fra_dagssetningur != value)
                {
                    _Fra_dagssetningur = value;
                    NotifyPropertyChanged("Fra_dagssetningur");
                }   
            }
        }

        public string Til_dagssetningur
        {
            get
            {
                return _Til_dagssetningur;
            }
            set
            {
                if (_Til_dagssetningur != value)
                {
                    _Til_dagssetningur = value;
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
        #endregion
        public ChangeNeydarsimiVM()
        {
            ChangeNeydarsimi_CMD = new RelayCommand(ChangeNeydarsimi_Fall);
        }

        public void LoadNeydarsimi()
        {

        }

        public void NullStilla()
        {

        }

        public void ChangeNeydarsimi_Fall(object obj)
        {
            if (TulkurBox != string.Empty && Fra_dagssetningur != string.Empty && Til_dagssetningur != string.Empty && KlukkInnBox != string.Empty && KlukkUtBox != string.Empty && VettvangurBox != string.Empty)
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
