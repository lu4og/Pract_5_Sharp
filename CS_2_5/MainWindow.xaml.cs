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
using System.IO;
namespace CS_2_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists("saved_days.json"))
            {
                File.WriteAllText("saved_days.json", "[]");
            }
            int yy = 0;
            int mm = 0;
            DateTime super_data = DateTime.Now;
            yy = super_data.Year;
            mm = super_data.Month;
            // yep
            PageFrame.Content = new Page1(mm, yy);
        }
    }
}
