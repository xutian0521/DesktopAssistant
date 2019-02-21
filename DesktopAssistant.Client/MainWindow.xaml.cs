using Com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using xutian.win32;

namespace DesktopAssistant
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        
        private void Button_Click_ShutDwon_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            #region 测试用
            Thread t = new Thread(closeShowDialog);
            t.Start(); 
            #endregion

            #region 开启timer监听窗体是否满足收缩和展开条件
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0);   //间隔1毫秒秒
            timer.Tick += timer_Tick;
            timer.Start(); 
            #endregion
            
        }

        #region 窗体UI动画相关
        /// <summary>
        /// timer 要执行的检查窗体是否符合要求，展开或收缩窗体
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            VisualEffectHelper.WindowShrinkEffect(this, 3);
        }
        #endregion


        #region 测试用
        void closeShowDialog()
        {
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(new Action(this.Close));
        } 
        #endregion

    }
}
