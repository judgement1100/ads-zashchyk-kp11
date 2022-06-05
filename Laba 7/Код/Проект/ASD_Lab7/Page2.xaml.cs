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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            PrintCommonHashtable(hashtable);
            UpdateCombobox();
        }

        // Interface
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintCommonHashtable(hashtable);
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            PrintChosenCourier();
        }

        private void UpdateCombobox()
        {
            CB1.SelectedIndex = 0;
            for (int i = 0; i < Page1.names.Count; i++)
            {
                CB1.Items.Add(Page1.names[i]);
            }
        }

        // Service
        public void PrintCommonHashtable(Hashtable tableToOutput)
        {
            string textToOutput = "Loadness = " + tableToOutput.Loadness.ToString() + "\n";
            textToOutput += "Size = " + tableToOutput.Size.ToString() + "\n\n";
            for (int i = 0; i < tableToOutput.Size; i++)
            {
                if (tableToOutput.Table[i] != null)
                {
                    textToOutput += "Номер замовлення: " + tableToOutput.Table[i].MyKey.MyKey + "\n";
                    textToOutput += ((Value1)tableToOutput.Table[i].MyValue).GetValue1String();
                    textToOutput += "\n";
                }
            }
            TB_output.Text = textToOutput;
        }

        private void PrintChosenCourier()
        {
            if (CB1.SelectedValue != null)
            {
                string name = CB1.SelectedValue.ToString();

                if (FindValue2(secHashtable, new MainWindow.Key(name)) != null)
                {
                    Value2 value2 = FindValue2(secHashtable, new MainWindow.Key(name));
                    string textToOutput = "Кількість різних замовлень = " + value2.differentDeliveries + "\n";
                    textToOutput += "Ім'я кур'єра: " + name + "\n\n";
                    textToOutput += value2.GetValue2String() + "\n";
                    TB_output.Text = textToOutput;
                }
            }
        }
    }
}
