#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Threading;

namespace HandyTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Global Variables

        private readonly DispatcherTimer? _timer;

        #endregion

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer{Interval = TimeSpan.FromSeconds(1)};
            _timer.Tick += TimerOnTick;
        }

        private int _disp = 0;

        private void TimerOnTick(object? sender, EventArgs e)
        {
            _disp++;
            TbcTimer.Text = _disp.ToString();
        }

        private void BtnStartStop_OnChecked(object sender, RoutedEventArgs e)
        {
            _timer?.Start();
            BtnStartStop.Content = "Stop";
        }

        private void BtnStartStop_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
            BtnStartStop.Content = "Start";
        }

        private void BtnReset_OnClick(object sender, RoutedEventArgs e)
        {
            BtnStartStop.IsChecked = false;
            // BtnStartStop_OnUnchecked(sender, e);
            _disp = 0;
            TbcTimer.Text = "00:00:00";
        }
    }
}