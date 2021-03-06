﻿using System;
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

        private ObservableCollection<clsTulkur> _tulkslisti; 
        public ObservableCollection<clsTulkur> Tulkslisti
        {
            get
            {
                return _tulkslisti;
            }
            set
            {
                if(_tulkslisti != value)
                {
                    _tulkslisti = value;
                    NotifyPropertyChanged("Tulkslisti");
                }
            }
        }
        #endregion 

        #region "NewUser VM"
        public ChangeUserVM()
        {
            Change_user_CMD = new RelayCommand(Change_user_Fall);
            SelectItemListbox_CMD = new RelayCommand(SelectItemListbox_Fall);
            
            _tulkslisti = new ObservableCollection<clsTulkur>();

            LoadTulkur();
            KennitalaBox = 0;
            FulltNafnBox = ""; 
        }
        #endregion

        #region "Functions"
        //Hlaða list af túlkum. 
        public void LoadTulkur()
        {
            Tulkslisti.Clear();

            var query = from d1 in context.Context.Tulkurs
                        select new
                        {
                            d1.kt,
                            d1.nafn
                        };
            foreach( var str in query)
            {
                _tulkslisti.Add(new clsTulkur()
                {
                    kt = str.kt,
                    nafn = str.nafn
                });
            }

            //_tulkslisti = new ObservableCollection<clsTulkur>(query); 
        }

        public void NullStilla()
        {
            KennitalaBox = 0;
            FulltNafnBox = ""; 
        }

        public void Change_user_Fall(object obj)
        {
            if (KennitalaBox != 0 && FulltNafnBox != string.Empty)
            {
                try
                {
                    Tulkur _tulkurUpdate = (from d1 in context.Context.Tulkurs
                                            where d1.kt == KennitalaBox
                                            select d1).First();
                    _tulkurUpdate.kt = KennitalaBox;
                    _tulkurUpdate.nafn = FulltNafnBox;

                    context.Context.SaveChanges();

                    MessageBox.Show("Túlkur endurbreytaður.", "Tilkynning");

                    LoadTulkur();

                    NullStilla();

                    EventSystem.Publish<UpdateUser>(new UpdateUser
                    {
                       basicData = BasicTulkur.update_tulkur
                    });
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

        public void SelectItemListbox_Fall(object obj)
        {
            try
            {
                var item = (clsTulkur)obj;
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
