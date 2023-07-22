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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public DateTime containDate;
        public void UpdateLytoPage()
        {
            nemez.Text = "";
            foreach (int gg in checked_values)
            {
                nemez.Text += gg.ToString() + ", ";
            }
        }
        public List<CheckedElem> elements = new List<CheckedElem>() {
            new CheckedElem("Капибара на расслабоне", "/img/capy_chill.jpg"),
            new CheckedElem("Капибара рыбак", "/img/capy_fish.jpg"),
            new CheckedElem("Капибара сонный", "/img/capy_sleep.jpg"),
            new CheckedElem("Капибара финский снайпер", "/img/capy_snipe.jpg")
        };
        public List<int> checked_values = new List<int>();
        public Page2(DateTime date)
        {
            containDate = date;
            this.checked_values = checked_values;
            InitializeComponent();
            spisok_avdeevyh.Children.Clear();
            int LL = 0;
            List<int> eauueu = new List<int>();
            foreach (var idk in JsonWorking.Deserializing<List<CheckedElems>>("saved_days.json"))
            {
                if (idk.date == date)
                {
                    eauueu = idk.indexes;
                }
            }
            foreach (CheckedElem checkedElem in elements)
            {
                gadam_capybara gg = new gadam_capybara("pack://application:,,," + checkedElem.path, checkedElem.name, checkedElem.ch_, LL);
                spisok_avdeevyh.Children.Add(gg);
                if (eauueu.Contains(LL))
                {
                    (spisok_avdeevyh.Children[^1] as gadam_capybara).boxxx.IsChecked = true;
                }
                LL++;
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("PageFrame") as Frame;
            frame.Navigate(new Page1(containDate.Month, containDate.Year));
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<CheckedElem> gg = new List<CheckedElem>();
            foreach (int i in checked_values)
            {
                CheckedElem checkedElem = elements[i];
                gg.Add(checkedElem);
            }
            CheckedElems checkedElems = new CheckedElems(containDate, gg, checked_values);
            var window = Window.GetWindow(this);
            var frame = window.FindName("PageFrame") as Frame;
            List<CheckedElems> pamparampam = JsonWorking.Deserializing<List<CheckedElems>>("saved_days.json");
            for (int i = 0; i < pamparampam.Count(); i++)
            {
                CheckedElems tururu = pamparampam[i];
                if (tururu.date == containDate)
                {
                    pamparampam.RemoveAt(i);
                    break;
                }
            }
            pamparampam.Add(checkedElems);
            JsonWorking.Serializing<List<CheckedElems>>("saved_days.json", pamparampam);

            frame.Navigate(new Page1(containDate.Month, containDate.Year));
        }
    }
}
