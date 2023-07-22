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
    /// Логика взаимодействия для gadam_capybara.xaml
    /// </summary>
    public partial class gadam_capybara : UserControl
    {
        public int index = 0;
        public bool started = false;
        public gadam_capybara(string path, string name, bool marked, int LL)
        {
            InitializeComponent();
            shish_capy.Source = new BitmapImage(new Uri(path));
            boxxx.Content = name;
            boxxx.IsChecked= marked;
            index = LL;
            started= true;
        }

        private void boxxx_Checked(object sender, RoutedEventArgs e)
        {
            Page2 page_i_need;
            page_i_need = (((this.Parent as StackPanel).Parent as ScrollViewer).Parent as Grid).Parent as Page2;
            page_i_need.elements[index].ch_ = true;
            if (!page_i_need.checked_values.Contains(index))
            {
                page_i_need.checked_values.Add(index);
            }
            page_i_need.UpdateLytoPage();
        }

        private void boxxx_Unchecked(object sender, RoutedEventArgs e)
        {
            var page_i_need = (((this.Parent as StackPanel).Parent as ScrollViewer).Parent as Grid).Parent as Page2;
            page_i_need.elements[index].ch_ = false;
            if (page_i_need.checked_values.Contains(index))
            {
                page_i_need.checked_values.Remove(index);
            }
            page_i_need.UpdateLytoPage();
        }
    }
}
