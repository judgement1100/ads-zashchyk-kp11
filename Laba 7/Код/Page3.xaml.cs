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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ASD_Lab7.MainWindow;

namespace ASD_Lab7
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputKey = TB1.Text;
            MainWindow.Key key1 = new MainWindow.Key(inputKey);
            if (FindValue1(hashtable, key1) != null)
            {
                Value1 value1 = FindValue1(hashtable, key1);
                string name = value1.CourierName;
                MainWindow.Key key2 = new MainWindow.Key(name);

                RemoveEntry1(hashtable, key1);
                RemoveEntry2(key2, int.Parse(key1.MyKey));
            }
            TB1.Text = "";
        }
    }
}
