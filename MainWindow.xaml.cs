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

namespace TRPO_LR1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> TextureList = new List<string>() { "file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Small.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Small_Full.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Medium.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Medium_1.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Medium_Full.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Large.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Large_1.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Large_2.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Large_3.png",
"file:///C:\\Users\\Zhekunia\\source\\repos\\TRPO_LR1\\Bottle_Large_Fulll.png"
        };



        public States States { get; set; }
        public List<string> MessageList { get; set; }
        public int SelectedVolume = 0;
        public int SmallBottle = 0;
        public int MediumBottle = 0;
        public int LargeBottle = 0;
        public bool IsCardPut = false;
        public MainWindow()
        {
            InitializeComponent();

            

            States = new States();
            DataContext = States;
            MessageList = new List<string>() {"Введите карту или выберите объем",
                "Вставьте карту", "Выберите объем", "Налито, заберите карту",
                "Денег мало, заберите карту", };
                    SelectedVolume = 0;
    }

    private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if((SelectedVolume != 0)&&(IsCardPut))
            {
                if (SelectedVolume != 0)
                {
                    switch (SelectedVolume)
                    {
                        case 1:
                            if (States.CurrentCount >= 25)
                            {
                                switch (States.SelectedBottle)
                                {
                                    case 0:
                                        MonkeyMessage(); break;
                                    case 1:
                                        AddToSmallBottle(SelectedVolume); break;
                                    case 2:
                                        AddToMediumBottle(SelectedVolume); break;
                                    case 3:
                                        AddToLargeBottle(SelectedVolume); break;
                                }
                                States.CurrentCount = States.CurrentCount - 25;
                            }
                            else
                            {
                                DisplayTextBox.Text = "\n"+MessageList[4];
                            }
                            break;
                        case 2:
                            if (States.CurrentCount >= 50)
                            {
                                switch (States.SelectedBottle)
                                {
                                    case 0:
                                        MonkeyMessage(); break;
                                    case 1:
                                        AddToSmallBottle(SelectedVolume); break;
                                    case 2:
                                        AddToMediumBottle(SelectedVolume); break;
                                    case 3:
                                        AddToLargeBottle(SelectedVolume); break;

                                }
                                States.CurrentCount = States.CurrentCount - 50;

                            }
                            else
                            {
                                DisplayTextBox.Text= "\n"+MessageList[4];
                            }
                            break;
                        case 3:
                            if (States.CurrentCount >= 100)
                            {
                                switch (States.SelectedBottle)
                                {
                                    case 0:
                                        MonkeyMessage(); break;
                                    case 1:
                                        AddToSmallBottle(SelectedVolume); break;
                                    case 2:
                                        AddToMediumBottle(SelectedVolume); break;
                                    case 3:
                                        AddToLargeBottle(SelectedVolume); break;
                                }
                                States.CurrentCount = States.CurrentCount - 100;

                            }
                            else
                            {
                                DisplayTextBox.Text = "\n"+MessageList[4];
                            }
                            break;

                    }
                }
                else
                {
                    DisplayTextBox.Text += "\n"+MessageList[2];
                }

            }
            SelectedVolume = 0;
            DisplayTextBox.Text = MessageList[0];
        }

        private void LargeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedVolume = 3;
            DisplayTextBox.Text = "Выбрано\n20 литров на сумму 100";
        }

        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedVolume = 2;
            DisplayTextBox.Text = "Выбрано\n10 литров на сумму 50";

        }

        private void SmallButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedVolume = 1;
            DisplayTextBox.Text = "Выбрано\n5 литров на сумму 25";

        }

        private void LargeBottleRectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch(States.SelectedBottle)
            {
                case 0:
                    LargeBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Visible;
                    States.SelectedBottle = 3;
                    break;
                    case 1:
                    LargeBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Visible;
                    SmallBottleRectangle.Visibility = Visibility.Visible;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 3;
                    break;
                    case 2:
                    LargeBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Visible;
                    MediumBottleRectangle.Visibility = Visibility.Visible;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 3;
                    break;
                    case 3:
                    LargeBottleRectangle.Visibility = Visibility.Visible;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 0;
                    break;
            }
        }

        private void MediumBottleRectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (States.SelectedBottle)
            {
                case 0:
                    MediumBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Visible;
                    States.SelectedBottle = 2;
                    break;
                case 1:
                    MediumBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Visible;
                    SmallBottleRectangle.Visibility = Visibility.Visible;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 2;
                    break;
                case 3:
                    MediumBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Visible;
                    LargeBottleRectangle.Visibility = Visibility.Visible;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 2;
                    break;
                case 2:
                    MediumBottleRectangle.Visibility = Visibility.Visible;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 0;
                    break;
            }
        }

        private void SmallBottleRectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (States.SelectedBottle)
            {
                case 0:
                    SmallBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Visible;
                    States.SelectedBottle = 1;
                    break;
                case 2:
                    SmallBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Visible;
                    MediumBottleRectangle.Visibility = Visibility.Visible;
                    SelectedMediumBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 1;
                    break;
                case 3:
                    SmallBottleRectangle.Visibility = Visibility.Collapsed;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Visible;
                    LargeBottleRectangle.Visibility = Visibility.Visible;
                    SelectedLargeBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 1;
                    break;
                case 1:
                    SmallBottleRectangle.Visibility = Visibility.Visible;
                    SelectedSmallBottleRectangle.Visibility = Visibility.Collapsed;
                    States.SelectedBottle = 0;
                    break;
            }
        }

        private void CardRectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CountWindow countWindow = new CountWindow(States);
            countWindow.Show();
        }

        private void CardRecieverButton_Click(object sender, RoutedEventArgs e)
        {
            if(!IsCardPut)
            {
                DisplayTextBox.Text = "На счету " + States.CurrentCount.ToString()  +" денег";
                CardRectangle.Visibility = Visibility.Hidden;
                IsCardPut = true;


            }
            else
            {
                DisplayTextBox.Text = MessageList[0];
                SelectedVolume = 0;
                CardRectangle.Visibility = Visibility.Visible;
                IsCardPut = false;
            }
        }


        public void MonkeyMessage()
        {
            ErrorWindow errorWindow = new ErrorWindow(1);
            errorWindow.Show();
        }
        public void AddToSmallBottle(int volume)
        {
            switch (SmallBottle)
            {
                case 0:
                    SmallBottle = 1;
                    ChangeTexture(1, 1);
                    if(volume >1)
                    {
                        MonkeyMessage();
                    }
                    break;
                    case 1:
                    
                        MonkeyMessage();
                    break;
            }
        }

        public void AddToMediumBottle(int volume)
        {
            switch (volume)
            {
                case 1:
                    switch (SmallBottle)
                    {
                        case 0:
                            SmallBottle = 1;
                            ChangeTexture(2, 1);
                            break;
                            case 1:
                            SmallBottle = 2;
                            ChangeTexture(2, 2);
                            break;
                        case 2:
                            MonkeyMessage();
                            break;
                    }
                    break;
                case 2:
                    switch(SmallBottle)
                    {
                        case 0:
                            SmallBottle = 2;
                            ChangeTexture(2, 2);
                            break;
                            case 1:
                            SmallBottle = 2;
                            ChangeTexture(2, 2);
                            break;
                            case 2:
                            MonkeyMessage();
                            break;

                    }
                    break;
                case 3:
                    SmallBottle = 2;
                    ChangeTexture(2, 2);
                    MonkeyMessage();
                    break;
            }
        }

        public void AddToLargeBottle(int volume)
        {
            switch(volume)
            {
                case 1:
                    switch(LargeBottle)
                    {
                        case 0:
                            LargeBottle = 1;
                            ChangeTexture(3, 1);
                            break;
                            case 1:
                            LargeBottle = 2;
                            ChangeTexture(3, 2);
                            break;
                            case 2:
                            LargeBottle = 3;
                            ChangeTexture(3, 3);
                            break;
                            case 3:
                            SmallBottle = 4;
                            ChangeTexture(3, 4);
                            break;
                            case 4:
                            MonkeyMessage();
                            break;

                    }
                    break;
                    case 2:
                    switch(LargeBottle)
                    {
                        case 0:
                            LargeBottle = 2;
                            ChangeTexture(3, 2);
                            break;
                            case 1:
                            LargeBottle = 3;
                            ChangeTexture(3, 3);
                            break;
                            case 2:
                            SmallBottle = 4;
                            ChangeTexture(3, 4);
                            break;
                            case 3:
                            SmallBottle = 4;
                            ChangeTexture(3, 4);
                            MonkeyMessage();
                            break;
                        case 4:
                            MonkeyMessage();
                            break;
                    }
                    break;
                    case 3:
                    switch (LargeBottle)
                    {
                        case 0:
                            LargeBottle = 4;
                            ChangeTexture(3, 4);
                            break;
                            case 1:
                            LargeBottle = 4;
                            ChangeTexture(3, 4);
                            break;
                            case 2:
                            SmallBottle = 4;
                            ChangeTexture(3, 4);
                            break;
                            case 3:
                            SmallBottle = 4;
                            ChangeTexture(3, 4);
                            MonkeyMessage();
                            break;
                            case 4:
                            MonkeyMessage();
                            break;

                    }
                    break;
            }
        }

        public void ChangeTexture(int bottle, int volume)
        {
            switch (bottle)
            {
                case 1:
                    switch (volume)
                    {
                        case 0:
                            SmallBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[0] )));
                            SelectedSmallBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[0] )));
                            break;
                        case 1:
                            SmallBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[1] )));
                            SelectedSmallBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[1] )));
                            break;
                    }
                    break;
                case 2:
                    switch(volume)
                    {
                        case 0:
                            MediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[2] )));
                            SelectedMediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[2] )));
                            break;
                        case 1:
                            MediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[3] )));
                            SelectedMediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[3] )));
                            break;
                        case 2:
                            MediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[4] )));
                            SelectedMediumBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[4] )));
                            break;
                    }
                    break;
                    case 3:
                    switch(volume)
                    {
                        case 0:
                            LargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[5] )));
                            SelectedLargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[5] )));
                            break;
                        case 1:
                            LargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[6] )));
                            SelectedLargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[6] )));
                            break;
                        case 2:
                            LargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[7] )));
                            SelectedLargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[7] )));
                            break;
                        case 3:
                            LargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[8] )));
                            SelectedLargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[8] )));
                            break;
                        case 4:
                            LargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[9] )));
                            SelectedLargeBottleRectangle.Fill = new ImageBrush(new BitmapImage(new Uri(TextureList[9] )));
                            break;

                    }
                    break;
            }
        }
    }
}
