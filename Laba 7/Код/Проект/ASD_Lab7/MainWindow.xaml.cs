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

namespace ASD_Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Hashtable hashtable = Hashtable.InitHashtable(50);
        public static Hashtable secHashtable = Hashtable.InitHashtable(15);

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StartPage();
        }

        public class Hashtable
        {
            public Entry[] Table;
            public int Loadness;
            public int Size;
            private Hashtable() { }

            public static Hashtable InitHashtable(int size)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Table = new Entry[size];
                hashtable.Loadness = 0;
                hashtable.Size = size;
                return hashtable;
            }
        }

        public class Entry
        {
            public Key MyKey;
            public object MyValue;
            public Entry(Key inputKey, object inputValue)
            {
                MyKey = inputKey;
                MyValue = inputValue;
            }
        }

        public class Key
        {
            public string MyKey;
            public Key(string stringKey)
            {
                MyKey = stringKey;
            }
            public Key(int intKey)
            {
                MyKey = intKey.ToString();
            }
        }

        public class Value1
        {
            public string ObjectType;
            public string CourierName;
            public Address AddressOfDelivery;
            public Date DateOfDelivery;
            public Value1(string objectType, string courierName, Address addressOfDelivery, Date dateOfDelivery)
            {
                ObjectType = objectType;
                CourierName = courierName;
                AddressOfDelivery = addressOfDelivery;
                DateOfDelivery = dateOfDelivery;
            }

            public string GetValue1String()
            {
                string textToOutput = "";
                textToOutput += "Об'єкт: " + ObjectType + "\n";
                textToOutput += "Ім'я кур'єра: " + CourierName + "\n";
                textToOutput += "Адреса: " + AddressOfDelivery.GetStringToOutput() + "\n";
                textToOutput += "Дата: " + DateOfDelivery.GetStringToOutput() + "\n";
                return textToOutput;
            }
        }

        public class Value2
        {
            public List<int> DeliveryIDs = new List<int>();
            public int differentDeliveries = 0; 

            public Value2(int deliveryID)
            {
                DeliveryIDs.Add(deliveryID);
                differentDeliveries++;
            }
            public string GetValue2String()
            {
                string res = "";
                for (int i = 0; i < DeliveryIDs.Count; i++)
                {
                    res += "ID замовлення №" + (i + 1) + ":\t" + DeliveryIDs[i] + "\n";
                    if (FindDate(DeliveryIDs[i]) != null)
                    {
                        res += "Дата замовлення:\t" + FindDate(DeliveryIDs[i]).GetStringToOutput() + "\n";
                        res += "Адреса:\t" + FindAddress(DeliveryIDs[i]).GetStringToOutput() + "\n\n";
                    }
                    else
                    {
                        res += "Дату замовлення ВИДАЛЕНО\nАдресу ВИДАЛЕНОn\n\n";
                    }
                }
                return res;
            }
        }

        public class Address
        {
            public string Street;
            public int HouseNumber;
            public int Appartment;
            public Address(string street, int houseNum, int appartment)
            {
                Street = street;
                HouseNumber = houseNum;
                Appartment = appartment;
            }
            public string GetStringToOutput()
            {
                string output = "";
                output += Street + HouseNumber.ToString() + "/" + Appartment.ToString();
                return output;
            }
        }

        public class Date
        {
            public int Year;
            public string Month;
            public int Day;
            public Date(int year, string month, int day)
            {
                Year = year;
                Month = month;
                Day = day;
            }
            public string GetStringToOutput()
            {
                string output = "";
                output += $"{Day}-{Month}-{Year}";
                return output;
            }
        }

        // Interface
        private void Button1_Click_Page1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page1();
        }

        private void Button2_Click_Page2(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page2();
        }

        private void Button3_Click_Page3(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Page3();
        }

        private void Button3_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Service
        public static int GetHash(Hashtable hashtable, Key key)
        {
            return getHashCode(key) % hashtable.Size;
        }

        public static void InsertEntry(ref Hashtable hashtable, Key key, object value)
        {
            int index = GetHash(hashtable, key);
            Entry newEntry = new Entry(key, value);
            if (hashtable.Table[index] == null)
            {
                hashtable.Table[index] = newEntry;
            }
            else
            {
                for (int i = 0; i < hashtable.Size; i++)
                {
                    if (hashtable.Table[(index + 1) % hashtable.Size] != null)
                    {
                        index++;
                    }
                    else
                    {
                        index = (index + 1) % hashtable.Size;
                        hashtable.Table[index] = newEntry;
                        break;
                    }
                }
            }
            hashtable.Loadness++;
            if (1.0 * hashtable.Loadness / hashtable.Size > 0.75)
            {
                Rehashing(ref hashtable);
            }
        }

        public static Value1 FindValue1(Hashtable hashtable, Key key)
        {
            if (hashtable != null)
            {
                int index = GetHash(hashtable, key);
                for (int i = 0; i < hashtable.Size; i++)
                {
                    if (hashtable.Table[index] != null)
                    {
                        if (getHashCode(key) == getHashCode(hashtable.Table[index].MyKey))
                        {
                            return (Value1)hashtable.Table[index].MyValue;
                        }
                        else
                        {
                            index++;
                        }
                    }
                }
            }
            return null;
        }

        public static Value2 FindValue2(Hashtable hashtable, Key key)
        {
            if (hashtable != null)
            {
                int index = GetHash(hashtable, key);
                for (int i = 0; i < hashtable.Size; i++)
                {
                    if (hashtable.Table[index] != null)
                    {
                        if (getHashCode(key) == getHashCode(hashtable.Table[index].MyKey))
                        {
                            return (Value2)hashtable.Table[index % hashtable.Size].MyValue;
                        }
                        else
                        {
                            index++;
                        }
                    }
                }
            }
            return null;
        }

        public static int getHashCode(Key key)
        {
            try
            {
                int res = int.Parse(key.MyKey);
                return res;
            }
            catch
            {
                int sum = 0;
                for (int i = 0; i < key.MyKey.Length; i++)
                {
                    sum += (int)key.MyKey[i];
                }
                return sum;
            }
        }

        public static void RemoveEntry1(Hashtable hashtable, Key key)
        {
            int index = GetHash(hashtable, key);
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[index] != null)
                {
                    if (key.MyKey == hashtable.Table[index].MyKey.MyKey)
                    {
                        hashtable.Table[index].MyKey = new Key("DELETED");
                        return;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
        }

        public static void RemoveEntry2(Key key, int delID)
        {
            Value2 value2 = FindValue2(secHashtable, key);
            for (int i = 0; i < value2.DeliveryIDs.Count; i++)
            {
                if (value2.DeliveryIDs[i] == delID)
                {
                    value2.DeliveryIDs[i] = -212;
                    break;  
                }
            }
            if (NeedToDeleteKey2(key))
            {
                key.MyKey = null;
            }
        }

        private static bool NeedToDeleteKey2(Key key)
        {
            Value2 value2 = FindValue2(secHashtable, key);
            int counter = 0;
            for (int i = 0; i < value2.DeliveryIDs.Count; i++)
            {
                if (value2.DeliveryIDs[i] == -212)
                {
                    counter++;
                }
            }
            if (counter == value2.DeliveryIDs.Count)
            {
                return true;
            }
            return false;
        }

        private static void Rehashing(ref Hashtable hashtable)
        {
            Hashtable newHashtable = Hashtable.InitHashtable(hashtable.Size * 2);
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    Key key = hashtable.Table[i].MyKey;
                    object value = hashtable.Table[i].MyValue;
                    InsertEntry(ref newHashtable, key, value);
                }
            }
            hashtable = newHashtable;
            MessageBox.Show("Перегешування таблиці");
        }

        public static int GetKeyIndex(Hashtable hashtable, Key key)
        {
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    if (hashtable.Table[i].MyKey.MyKey == key.MyKey)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static int FindHashtableIndex(List<Hashtable> hashtables, string name)
        {
            for (int i = 0; i < hashtables.Count; i++)
            {
                Hashtable currentHashtable = hashtables[i];
                for (int j = 0; j < currentHashtable.Size; j++)
                {
                    if (currentHashtable.Table[j] != null)
                    {
                        if (currentHashtable.Table[j].MyKey.MyKey == name)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        public static Address FindAddress(int delID)
        {
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    if (hashtable.Table[i].MyKey.MyKey == delID.ToString())
                    {
                        return ((Value1)hashtable.Table[i].MyValue).AddressOfDelivery;
                    }
                }
            }
            return null;
        }

        public static Date FindDate(int delID)
        {
            for (int i = 0; i < hashtable.Size; i++)
            {
                if (hashtable.Table[i] != null)
                {
                    if (hashtable.Table[i].MyKey.MyKey == delID.ToString())
                    {
                        return ((Value1)hashtable.Table[i].MyValue).DateOfDelivery;
                    }
                }
            }
            return null;
        }
    }
}

