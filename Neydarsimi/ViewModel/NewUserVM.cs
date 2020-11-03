using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Neydarsimi.Helper;
using Neydarsimi.Data; 

namespace Neydarsimi.ViewModel
{
    class NewUserVM : ViewModelBase
    {
        #region "Variable"
        public int _KennitalaBox;
        public string _FulltNafnBox; 
        
        public RelayCommand Vista_New_User_CMD { get; set; }
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
        }
        #endregion

        #region "Functions"
        public void Vista_New_User_Fall(object obj)
        {
            if(KennitalaBox != 0)
            {
                MessageBox.Show("Vista Vista");
            }
            else
            {
                MessageBox.Show("EKKI VISTA");
            }
        }
        #endregion
    }
}
