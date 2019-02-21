using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xutian.win32;

namespace Com
{

    /// <summary>
    /// 包含win视觉动画效果的类
    /// </summary>
    public static class VisualEffectHelper
    {
        /// <summary>
        /// 窗体靠顶自动收缩
        /// </summary>
        /// <param name="window">需要wpf Window类</param>
        /// <param name="px">动画每次移动多少像素</param>
        public static void WindowShrinkEffect(Window window, int px)
        {
            POINT point = new POINT();
            bool b = Win32Api.GetCursorPos(out point);



            //判断窗体顶部距离屏幕顶端距离是否为0，并且鼠标不在窗体上面。收缩窗口。
            if (window.Top == 0 && !(point.Y <= (window.Height + window.Top) && point.Y >= window.Top && point.X >= window.Left && point.X <= (window.Left + window.Width)))
            {
                // 窗体收缩动画 
                int s = (int)window.Height;
                for (int i = 0; i < (s - 5) / px; i++)
                {
                    window.Top = window.Top - px;
                    //Thread.Sleep(0);
                }
            }
            //判断窗体顶部距离屏幕的是否是否小于-30，并且鼠标在窗体上。展开窗口。
            if (window.Top < -30 && b && (point.Y <= (window.Height + window.Top) && point.Y > window.Top && point.X >= window.Left && point.X <= (window.Left + window.Width)))
            {

                if (point.Y <= 0 && point.X > window.Left && point.X < (window.Left + window.Width))
                {
                    // 窗体展开动画 
                    int s = (int)window.Height;
                    for (int i = 0; i < (s - 5) / px; i++)
                    {
                        window.Top = window.Top + px;
                        //Thread.Sleep(0);
                    }
                }
            }
        }
        #region 窗体UI动画相关

        #endregion
    }
}
