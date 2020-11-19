using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Neydarsimi.ViewModel;

namespace Neydarsimi.View
{
    /// <summary>
    /// Interaction logic for ChangeNeydarsimi.xaml
    /// </summary>
    public partial class ChangeNeydarsimi : Window
    {
        public ChangeNeydarsimi()
        {
            InitializeComponent();
            DataContext = new ChangeNeydarsimiVM(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
