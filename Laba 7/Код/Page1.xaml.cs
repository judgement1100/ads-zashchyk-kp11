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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static string objectType;
        public static string courierName;
        public static string street;
        public static int houseNumber;
        public static int appartmentNumber;
        public static int year;
        public static string month;
        public static int day;
        public static List<string> names = new List<string>();
        public static int numOfMaxDeliver = 10;

        public Page1()
        {
            InitializeComponent();
            ClearValues();
        }

        private new void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                try
                {
                    objectType = TB_object.Text;
                    courierName = TB_name.Text;
                    street = TB_street.Text;
                    houseNumber = int.Parse(TB_houseNum.Text);
                    appartmentNumber = int.Parse(TB_appartmentNum.Text);
                    year = int.Parse(TB_year.Text);
                    month = TB_month.Text;
                    day = int.Parse(TB_day.Text);
                    AddHashtableInfo();
                    MessageBox.Show("Дані занесено успішно");
                    ClearTextBoxes();
                    ClearValues();
                }
                catch
                {
                    SetDafaultValues();
                    AddHashtableInfo();
                    MessageBox.Show("Дані було виправлено та занесено");
                    ClearTextBoxes();
                    ClearValues();
                }
            }
        }

        private void ClearValues()
        {
            objectType = default;
            courierName = default;
            street = default;
            houseNumber = default;
            appartmentNumber = default;
            year = default;
            month = default;
            day = default;
        }

        private void ClearTextBoxes()
        {
            TB_object.Text = "";
            TB_name.Text = "";
            TB_street.Text = "";
            TB_houseNum.Text = "";
            TB_appartmentNum.Text = "";
            TB_year.Text = "";
            TB_month.Text = "";
            TB_day.Text = "";
        }

        private void SetDafaultValues()
        {
            if (TB_name.Text.Length < 1)
            {
                courierName = "Віктор";
                TB_name.Text = courierName;
            }
            if (TB_object.Text.Length < 1)
            {
                objectType = "Кавун";
                TB_object.Text = objectType;
            }
            if (TB_street.Text.Length < 1)
            {
                street = "Вишнева";
                TB_street.Text = street;
            }
            if (houseNumber < 1)
            {
                houseNumber = 1;
                TB_houseNum.Text = houseNumber.ToString();
            }
            if (appartmentNumber < 1)
            {
                appartmentNumber = 1;
                TB_appartmentNum.Text = appartmentNumber.ToString();
            }
            if (year < DateTime.Now.Year)
            {
                year = DateTime.Now.Year;
                TB_year.Text = year.ToString();
            }
            if (TB_month.Text.Length < 1)
            {
                month = "січень";
                TB_month.Text = month;
            }
            if (day < 1)
            {
                day = 1;
                TB_day.Text = day.ToString();
            }
        }

        private new void LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((TextBox)sender).Name == TB_object.Name)
                {
                    if (TB_object.Text.Length < 1)
                    {
                        TB_object.Text = "Кавун";
                    }
                }
                else if (((TextBox)sender).Name == TB_name.Name)
                {
                    if (TB_name.Text.Length < 1)
                    {
                        TB_name.Text = "Віктор";
                    }
                }
                else if (((TextBox)sender).Name == TB_street.Name)
                {
                    if (TB_street.Text.Length < 1)
                    {
                        TB_street.Text = "Вишнева";
                    }
                }
                else if (((TextBox)sender).Name == TB_houseNum.Name)
                {
                    if (TB_houseNum.Text.Length < 1)
                    {
                        TB_houseNum.Text = 1.ToString();
                    }
                }
                else if (((TextBox)sender).Name == TB_appartmentNum.Name)
                {
                    if (TB_appartmentNum.Text.Length < 1)
                    {
                        TB_appartmentNum.Text = 1.ToString();
                    }
                }
                else if (((TextBox)sender).Name == TB_year.Name)
                {
                    if (TB_year.Text.Length < 1)
                    {
                        TB_year.Text = DateTime.Now.Year.ToString();
                    }
                    else if (int.Parse(TB_year.Text) < DateTime.Now.Year)
                    {
                        TB_year.Text = DateTime.Now.Year.ToString();
                    }
                }
                else if (((TextBox)sender).Name == TB_month.Name)
                {
                    if (TB_month.Text.Length < 1)
                    {
                        TB_month.Text = "січень";
                    }
                }
                else if (((TextBox)sender).Name == TB_day.Name)
                {
                    if (day < 1)
                    {
                        TB_day.Text = 1.ToString();
                    }
                }
            }
            catch
            {
                SetDafaultValues();
                AddHashtableInfo();
            }
        }

        private int GetRandomNum()
        {
            Random rnd = new Random();
            int res = rnd.Next(100000,999999);
            MainWindow.Key key = new MainWindow.Key(res);
            while (FindValue1(hashtable, key) != null)
            {
                res = rnd.Next(100000, 999999);
                key = new MainWindow.Key(res);
            }
            return res;
        }
        private bool CourierIsOld(Hashtable hashtable, string name)
        {
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    if (((Value1)hashtable.Table[i].MyValue).CourierName == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string FindStreet(int delID)
        {
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    if (hashtable.Table[i].MyKey.MyKey == delID.ToString())
                    {
                        return ((Value1)hashtable.Table[i].MyValue).AddressOfDelivery.Street;
                    }
                }
            }
            return null;
        }

        private bool StreetIsNew(List<int> IDs)
        {
            for (int i = 0; i < IDs.Count; i++)
            {
                if (FindStreet(IDs[i]) == street)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsCourierAvailable(string _courierName, string _street)
        {
            if (secHashtable.Table[GetHash(secHashtable, new MainWindow.Key(_courierName))] != null)
            {
                if (StreetIsNew(((Value2)secHashtable.Table[GetHash(secHashtable, new MainWindow.Key(_courierName))].MyValue).DeliveryIDs))
                {
                    if (((Value2)secHashtable.Table[GetHash(secHashtable, new MainWindow.Key(_courierName))].MyValue).differentDeliveries == numOfMaxDeliver)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void AddHashtableInfo()
        {
            int deliveryID = GetRandomNum();
            MainWindow.Key key1 = new MainWindow.Key(deliveryID);
            Value1 value1 = new Value1(objectType, courierName, new Address(street, houseNumber, appartmentNumber), new Date(year, month, day));
            if (CourierIsOld(hashtable, courierName))
            {
                if (IsCourierAvailable(courierName, street))
                {
                    if (FindValue2(secHashtable, new MainWindow.Key(courierName)) != null)
                    {
                        Value2 value2 = FindValue2(secHashtable, new MainWindow.Key(courierName));
                        if (StreetIsNew(value2.DeliveryIDs))
                        {
                            value2.differentDeliveries++;
                        }
                        value2.DeliveryIDs.Add(deliveryID);
                    }
                }
                else
                {
                    bool isCourierRedirected = false;
                    for (int i = 0; i < secHashtable.Size; i++)
                    {
                        if (secHashtable.Table[i] != null)
                        {
                            string tmpName = secHashtable.Table[i].MyKey.MyKey;
                            int j;
                            for (j = 0; j < ((Value2)secHashtable.Table[i].MyValue).DeliveryIDs.Count; j++)
                            {
                                string tmpStreet = FindStreet(((Value2)secHashtable.Table[i].MyValue).DeliveryIDs[j]);
                                if (IsCourierAvailable(tmpName, tmpStreet))
                                {
                                    break;
                                }
                            }
                            if (j >= numOfMaxDeliver)
                            {
                                j = 0;
                                continue;
                            }
                            else if (IsCourierAvailable(tmpName, FindStreet(((Value2)secHashtable.Table[i].MyValue).DeliveryIDs[j])))
                            {
                                if (FindValue2(secHashtable, new MainWindow.Key(tmpName)).ToString() != null)
                                {
                                    Value2 value2 = (Value2)FindValue2(secHashtable, new MainWindow.Key(tmpName));
                                    value2.DeliveryIDs.Add(deliveryID);
                                    isCourierRedirected = true;
                                    MessageBox.Show($"Перепризначаємо кур'єра. Новий кур'єр - {tmpName}");
                                    break;
                                }
                            }
                        }
                    }
                    if (!isCourierRedirected)
                    {
                        MessageBox.Show("Введіть інше ім'я кур'єра. Усі наявні кур'єри зайняті");
                    }
                }
            }
            else
            {
                InsertEntry(ref secHashtable, new MainWindow.Key(courierName), new Value2(deliveryID));
            }

            InsertEntry(ref hashtable, key1, value1);

            if (names.IndexOf(courierName) == -1)
            {
                names.Add(courierName);
            }
        }
    }
}
