using Client.bll;
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
using System.Xml.Linq;

namespace DesktopAssistant
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        XmlHelper xmlHelper ;
        Brush brush;
        public LoginWindow()
        {
            xmlHelper = new XmlHelper();
            InitializeComponent();
            InitControlText();
           
            //Head.Text = "Login";
            brush = txt_UserName.BorderBrush;

        }
        /// <summary>
        /// 初始化控件文本
        /// </summary>
        private void InitControlText()
        {

            Head.Text = xmlHelper.GetElementValue("LoginTitle");
            tbl_UserName.Text = xmlHelper.GetElementValue("LoginNameLabel");
            tbl_PassWord.Text = xmlHelper.GetElementValue("PassWordLabel");
            Btn_Login.Content = xmlHelper.GetElementValue("LoginButton");
            
        }
        ////界面可以拖动 
        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            #region 测试用
            MainWindow l = new MainWindow();
            l.Show(); 
            #endregion
            //验证登陆
            CheckLogin();

        }
        /// <summary>
        /// 验证登陆表单,验证成功则调用bll层登陆方法
        /// </summary>
        void CheckLogin()
        {
            
            //每次验证初始化边框颜色
            txt_UserName.BorderBrush = brush;
            txt_PassWord.BorderBrush = brush;
            //判断输入是否合法，并提示。
            if (txt_UserName.Text.Trim() == "")
            {
                tbl_Prompt.Text = xmlHelper.GetElementValue("UserNameEmpty"); ;
                txt_UserName.BorderBrush =Brushes.Red;
                txt_UserName.Focus();
                return;
            }
            if (txt_PassWord.Password.Trim() == "")
            {
                tbl_Prompt.Text = xmlHelper.GetElementValue("PassWordEmpty"); ;
                txt_PassWord.BorderBrush = Brushes.Red;
                txt_PassWord.Focus();
                return;
            }

            //调用bll层 登陆
            LoginBLL loginbll = new LoginBLL();
            loginbll.Login(txt_UserName.Text.Trim(), txt_PassWord.Password.Trim());
            MainWindow main = new MainWindow();
            main.Top = this.Top;
            main.Left = this.Left;
            this.Close();
            main.Show();
        }

        //切换语言为简体中文
        private void Zh_Click(object sender, RoutedEventArgs e)
        {
            xmlHelper.SetLanguage("Zh");

            xmlHelper = new XmlHelper();
            InitializeComponent();
            InitControlText();
            zh_btn.Foreground = Brushes.Black;
            en_btn.Foreground = Brushes.Gray;
        }
        //切换语言为英文
        private void En_Click(object sender, RoutedEventArgs e)
        {
            xmlHelper.SetLanguage("En");

            xmlHelper = new XmlHelper();
            InitializeComponent();
            InitControlText();
            en_btn.Foreground = Brushes.Black;
            zh_btn.Foreground = Brushes.Gray;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }





    }
}
