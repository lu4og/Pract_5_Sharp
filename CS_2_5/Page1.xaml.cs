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

namespace CS_2_5
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static DateTime bruhdate;
        public Page1(int mm, int yy)
        {
            InitializeComponent();
            int dd = 1;
            bruhdate = new DateTime(yy, mm, dd);
            CalGen();
        }
        private void CalGen()
        {
            int count = DateTime.DaysInMonth(bruhdate.Year, bruhdate.Month);
            string month_name = "";
            switch (bruhdate.Month)
            {
                case 1:
                    month_name = "Январь";
                    break;
                case 2:
                    month_name = "Февраль";
                    break;
                case 3:
                    month_name = "Март";
                    break;
                case 4:
                    month_name = "Апрель";
                    break;
                case 5:
                    month_name = "Май";
                    break;
                case 6:
                    month_name = "Июнь";
                    break;
                case 7:
                    month_name = "Июль";
                    break;
                case 8:
                    month_name = "Август";
                    break;
                case 9:
                    month_name = "Сентябрь";
                    break;
                case 10:
                    month_name = "Октябрь";
                    break;
                case 11:
                    month_name = "Ноябрь";
                    break;
                case 12:
                    month_name = "Декабрь";
                    break;
            }
            selectedMonth.Text = $"{month_name}, {bruhdate.Year}";
            dateContainer.Children.Clear();
            for (int i = 1 ; i <= count; i++)
            {
                string imgSource = "pack://application:,,,/img/default.png";
                foreach (var bruh in JsonWorking.Deserializing<List<CheckedElems>>("saved_days.json"))
                {
                    if (bruh.date == new DateTime(bruhdate.Year, bruhdate.Month, i))
                    {
                        imgSource = "pack://application:,,," + bruh.elements[0].path;
                        break;
                    }
                }
                dateContainer.Children.Add(new day_wow(new DateTime(bruhdate.Year, bruhdate.Month, i), imgSource));
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bruhdate = bruhdate.AddMonths(-1);
            CalGen();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bruhdate = bruhdate.AddMonths(1);
            CalGen();
        }
    }
}
