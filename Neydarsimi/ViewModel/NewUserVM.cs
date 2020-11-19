using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Neydarsimi.Helper;
using Neydarsimi.Model;

namespace Neydarsimi.ViewModel
{
    class NewUserVM : ViewModelBase
    {
        #region "Variable"
        public int _KennitalaBox;
        public string _FulltNafnBox;
        private DataContextSingleton context = DataContextSingleton.Instance;

        public RelayCommand Vista_New_User_CMD { get; set; }
        #endregion

        #region "Svæði" 
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
                if(_FulltNafnBox != value)
                {
                    _FulltNafnBox = value;
                    NotifyPropertyChanged("FulltNafnBox");
                }
            }
        }
        #endregion 

        #region "NewUser VM"
        public NewUserVM()
        {
            Vista_New_User_CMD = new RelayCommand(Vista_New_User_Fall);
            NullStilla();
        }
        #endregion

        #region "Functions"
        public void NullStilla()
        {
            KennitalaBox = 0;
            FulltNafnBox = ""; 
        }
        public void Vista_New_User_Fall(object obj)
        {
            if(KennitalaBox != null)
            {
                try
                {
                    Tulkur _tulkur = new Tulkur
                    {
                        kt = KennitalaBox,
                        nafn = FulltNafnBox
                    };

                    context.Context.Tulkurs.Add(_tulkur);
                    context.Context.SaveChanges();

                    MessageBox.Show("Nýr tulkur vistaður.", "Tilkynning");

                    //bæta við eventSystem.publish seinna 

                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    MessageBox.Show("Gagnavilla : " + message , "Tilkynning");
                }

            }
            else
            {
                MessageBox.Show("Innsetningarbox eru tómar","Tilkynning");
            }
        }
        #endregion
    }
}
