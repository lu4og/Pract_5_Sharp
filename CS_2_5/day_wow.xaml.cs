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
    /// Логика взаимодействия для day_wow.xaml
    /// </summary>
    public partial class day_wow : UserControl
    {
        public DateTime date;
        public day_wow(DateTime ch, string imgSource = "pack://application:,,,/img/default.png")
        {
            InitializeComponent();
            blIcon.Source = new BitmapImage(new Uri(imgSource));
            dateDay.Text = ch.Day.ToString();
            date = ch;
        }

        public void UserControl_MouseDown(object sender, MouseEventArgs e)
        {
            // кастыль
            var page = ((this.Parent as WrapPanel).Parent as Grid).Parent as Page;
            var window = Window.GetWindow(page);
            var frame = window.FindName("PageFrame") as Frame;
            frame.Navigate(new Page2(date));
        }
    }
}
