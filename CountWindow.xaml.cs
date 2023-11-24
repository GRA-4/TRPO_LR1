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
    /// Логика взаимодействия для Count.xaml
    /// </summary>
    public partial class CountWindow : Window
    {
        public States States;
        public CountWindow(States states)
        {
            InitializeComponent();
            States = states;
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(CountTextBox.Text, out int count))
                {
                    if ((count>=0)&&(count<=5000))
                    {
                        States.CurrentCount = States.CurrentCount + count;
                        MessageBox.Show("Добаволено "+count.ToString()+" денег");
                    }
                }
            }
            catch { }
            
        }
    }
}
