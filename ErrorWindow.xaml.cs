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

namespace TRPO_LR1
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(int error)
        {
            InitializeComponent();
            switch (error)
            {
                case 1:
                    MonkeyImage.Visibility = Visibility.Visible;
                    break;
                    case 2:
                    AngryImage.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
