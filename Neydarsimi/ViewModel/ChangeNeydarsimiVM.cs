using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using Neydarsimi.Helpers;
using Neydarsimi.Data;

namespace Neydarsimi.ViewModel
{
    class ChangeNeydarsimiVM
    {
        public string _TulkurBox;
        public string _Fra_dagssetningur;
        public string _Til_dagssetningur;
        public string _KlukkInnBox;
        public string _KlukkUtBox;
        public string _VettvangurBox;

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
                    
                }
            }
        }
        public RelayCommand ChangeNeydarsimi_CMD { get; set; }
        public ChangeNeydarsimiVM()
        {
            ChangeNeydarsimi_CMD = new RelayCommand(ChangeNeydarsimi_Fall);
        }

        public void ChangeNeydarsimi_Fall(object obj)
        {
            MessageBox.Show("Breyta");
        }
    }
}
