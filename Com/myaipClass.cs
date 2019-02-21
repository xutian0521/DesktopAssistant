using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using System.Drawing;
using System.Windows;

namespace xutian.win32
{
    /// <summary>
    /// 原C++ RECT结构体，兼容c++ rect
    /// </summary>
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    /// <summary>
    /// 原C++ POINT结构体，兼容c++ POINT
    /// </summary>
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    /// <summary>
    /// 一个win32Message 消息类
    /// </summary>
    public static class Win32Message
    {
        public const int WM_NULL = 0x0000;
        /// <summary>
        /// //创建一个窗口
        /// </summary>
        public const int WM_CREATE = 0x0001;
        /// <summary>
        /// 当一个窗口被破坏时发送
        /// </summary>
        public const int WM_DESTROY = 0x0002;
        /// <summary>
        /// 移动一个窗口
        /// </summary>
        public const int WM_MOVE = 0x0003;
        /// <summary>
        /// 改变一个窗口的大小
        /// </summary>
        public const int WM_SIZE = 0x0005;
        /// <summary>
        /// 一个窗口被激活或失去激活状态
        /// </summary>
        public const int WM_ACTIVATE = 0x0006;
        /// <summary>
        /// 一个窗口获得焦点
        /// </summary>
        public const int WM_SETFOCUS = 0x0007; 
        /// <summary>
        /// 一个窗口失去焦点
        /// </summary>
        public const int WM_KILLFOCUS = 0x0008;
        /// <summary>
        /// 一个窗口改变成Enable状态
        /// </summary>
        public const int WM_ENABLE = 0x000A; 
        /// <summary>
        /// 设置窗口是否能重画
        /// </summary>
        public const int WM_SETREDRAW = 0x000B;
        /// <summary>
        /// 应用程序发送此消息来设置一个窗口的文本
        /// </summary>
        public const int WM_SETTEXT = 0x000C;
        /// <summary>
        /// 应用程序发送此消息来复制对应窗口的文本到缓冲区
        /// </summary>
        public const int WM_GETTEXT = 0x000D;
        /// <summary>
        /// 得到与一个窗口有关的文本的长度（不包含空字符）
        /// </summary>
        public const int WM_GETTEXTLENGTH = 0x000E;
        /// <summary>
        /// 要求一个窗口重画自己
        /// </summary>
        public const int WM_PAINT = 0x000F; 
        /// <summary>
        /// 当一个窗口或应用程序要关闭时发送一个信号
        /// </summary>
        public const int WM_CLOSE = 0x0010;
        /// <summary>
        /// 当用户选择结束对话框或程序自己调用ExitWindows函数
        /// </summary>
        public const int WM_QUERYENDSESSION = 0x0011; 
        /// <summary>
        /// 用来结束程序运行
        /// </summary>
        public const int WM_QUIT = 0x0012;
        /// <summary>
        /// 当用户窗口恢复以前的大小位置时，把此消息发送给某个图标
        /// </summary>
        public const int WM_QUERYOPEN = 0x0013;
        /// <summary>
        /// 当窗口背景必须被擦除时（例在窗口改变大小时）
        /// </summary>
        public const int WM_ERASEBKGND = 0x0014; 
        /// <summary>
        /// 当系统颜色改变时，发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_SYSCOLORCHANGE = 0x0015;
        /// <summary>
        /// 当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束
        /// </summary>
        public const int WM_ENDSESSION = 0x0016;
        /// <summary>
        /// 当隐藏或显示窗口是发送此消息给这个窗口
        /// </summary>
        public const int WM_SHOWWINDOW = 0x0018;

        public const int WM_WININICHANGE = 0x001A;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_DEVMODECHANGE = 0x001B;
        /// <summary>
        /// 发此消息给应用程序哪个窗口是激活的，哪个是非激活的
        /// </summary>
        public const int WM_ACTIVATEAPP = 0x001C;
        /// <summary>
        /// 当系统的字体资源库变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_FONTCHANGE = 0x001D;
        /// <summary>
        /// /当系统的时间变化时发送此消息给所有顶级窗口
        /// </summary>
        public const int WM_TIMECHANGE = 0x001E;
        /// <summary>
        /// 发送此消息来取消某种正在进行的摸态（操作）
        /// </summary>
        public const int WM_CANCELMODE = 0x001F;
        /// <summary>
        /// 如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口
        /// </summary>
        public const int WM_SETCURSOR = 0x0020;
        /// <summary>
        /// 当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口
        /// </summary>
        public const int WM_MOUSEACTIVATE = 0x0021;
        /// <summary>
        /// 发送此消息给MDI子窗口当用户点击此窗口的标题栏，或当窗口被激活，移动，改变大小
        /// </summary>
        public const int WM_CHILDACTIVATE = 0x0022;
        /// <summary>
        /// 此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息
        /// </summary>
        public const int WM_QUEUESYNC = 0x0023;
        /// <summary>
        /// 此消息发送给窗口当它将要改变大小或位置
        /// </summary>
        public const int WM_GETMINMAXINFO = 0x0024;
        /// <summary>
        /// 发送给最小化窗口当它图标将要被重画
        /// </summary>
        public const int WM_PAINTICON = 0x0026;
        /// <summary>
        /// 此消息发送给某个最小化窗口，仅当它在画图标前它的背景必须被重画
        /// </summary>
        public const int WM_ICONERASEBKGND = 0x0027;
        /// <summary>
        /// 发送此消息给一个对话框程序去更改焦点位置
        /// </summary>
        public const int WM_NEXTDLGCTL = 0x0028;
        /// <summary>
        /// 每当打印管理列队增加或减少一条作业时发出此消息
        /// </summary>
        public const int WM_SPOOLERSTATUS = 0x002A;
        /// <summary>
        /// 当button，combobox，listbox，menu的可视外观改变时发送
        /// </summary>
        public const int WM_DRAWITEM = 0x002B;
        /// <summary>
        /// 当button, combo box, list box, list view control, or menu item 被创建时
        /// </summary>
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DELETEITEM = 0x002D;
        /// <summary>
        /// 此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息
        /// </summary>
        public const int WM_VKEYTOITEM = 0x002E;
        /// <summary>
        /// 此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息
        /// </summary>
        public const int WM_CHARTOITEM = 0x002F;
        /// <summary>
        /// 当绘制文本时程序发送此消息得到控件要用的颜色
        /// </summary>
        public const int WM_SETFONT = 0x0030;
        /// <summary>
        /// 应用程序发送此消息得到当前控件绘制文本的字体
        /// </summary>
        public const int WM_GETFONT = 0x0031;
        /// <summary>
        /// 应用程序发送此消息让一个窗口与一个热键相关连
        /// </summary>
        public const int WM_SETHOTKEY = 0x0032;
        /// <summary>
        /// 应用程序发送此消息来判断热键与某个窗口是否有关联
        /// </summary>
        public const int WM_GETHOTKEY = 0x0033;
        /// <summary>
        /// 此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标
        /// </summary>
        public const int WM_QUERYDRAGICON = 0x0037;
        /// <summary>
        /// 发送此消息来判定combobox或listbox新增加的项的相对位置
        /// </summary>
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_GETOBJECT = 0x003D;
        /// <summary>
        /// 显示内存已经很少了
        /// </summary>
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMMNOTIFY = 0x0044;
        /// <summary>
        /// 发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        /// <summary>
        /// 发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数
        /// </summary>
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        /// <summary>
        /// 当系统将要进入暂停状态时发送此消息
        /// </summary>
        public const int WM_POWER = 0x0048;
        /// <summary>
        /// 当一个应用程序传递数据给另一个应用程序时发送此消息
        /// </summary>
        public const int WM_COPYDATA = 0x004A;
        /// <summary>
        /// 当某个用户取消程序日志激活状态，提交此消息给程序
        /// </summary>
        public const int WM_CANCELJOURNAL = 0x004B;
        /// <summary>
        /// 当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口
        /// </summary>
        public const int WM_NOTIFY = 0x004E;
        /// <summary>
        /// //当用户选择某种输入语言，或输入语言的热键改变
        /// </summary>
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        /// <summary>
        /// 当平台现场已经被改变后发送此消息给受影响的最顶级窗口
        /// </summary>
        public const int WM_INPUTLANGCHANGE = 0x0051;
        /// <summary>
        /// 当程序已经初始化windows帮助例程时发送此消息给应用程序
        /// </summary>
        public const int WM_TCARD = 0x0052;
        /// <summary>
        /// 此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果当前都没有焦点，就把此消息发送给当前激活的窗口
        /// </summary>
        public const int WM_HELP = 0x0053;
        /// <summary>
        /// //当用户已经登入或退出后发送此消息给所有的窗口，当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息
        /// </summary>
        public const int WM_USERCHANGED = 0x0054;
        /// <summary>
        /// 公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构
        /// </summary>
        public const int WM_NOTIFYFORMAT = 0x0055;
        /// <summary>
        /// 当用户某个窗口中点击了一下右键就发送此消息给这个窗口
        /// </summary>
        public const int WM_CONTEXTMENU = 0x007B;
        /// <summary>
        /// 当调用SETWINDOWLONG函数将要改变一个或多个 窗口的风格时发送此消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGING = 0x007C;
        /// <summary>
        /// 当调用SETWINDOWLONG函数一个或多个 窗口的风格后发送此消息给那个窗口
        /// </summary>
        public const int WM_STYLECHANGED = 0x007D;
        /// <summary>
        /// 当显示器的分辨率改变后发送此消息给所有的窗口
        /// </summary>
        public const int WM_DISPLAYCHANGE = 0x007E;
        /// <summary>
        /// 此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄
        /// </summary>
        public const int WM_GETICON = 0x007F;
        /// <summary>
        /// 程序发送此消息让一个新的大图标或小图标与某个窗口关联
        /// </summary>
        public const int WM_SETICON = 0x0080;
        /// <summary>
        /// 当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送
        /// </summary>
        public const int WM_NCCREATE = 0x0081;
        /// <summary>
        /// 此消息通知某个窗口，非客户区正在销毁
        /// </summary>
        public const int WM_NCDESTROY = 0x0082;
        /// <summary>
        /// 当某个窗口的客户区域必须被核算时发送此消息
        /// </summary>
        public const int WM_NCCALCSIZE = 0x0083;
        /// <summary>
        /// 移动鼠标，按住或释放鼠标时发生
        /// </summary>
        public const int WM_NCHITTEST = 0x0084;
        /// <summary>
        /// 程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时
        /// </summary>
        public const int WM_NCPAINT = 0x0085;
        /// <summary>
        /// 此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态
        /// </summary>
        public const int WM_NCACTIVATE = 0x0086;
        /// <summary>
        /// 发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过应
        /// </summary>
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_SYNCPAINT = 0x0088;
        /// <summary>
        /// 当光标在一个窗口的非客户区内移动时发送此消息给这个窗口 非客户区为：窗体的标题栏及窗 的边框体
        /// </summary>
        public const int WM_NCMOUSEMOVE = 0x00A0;
        /// <summary>
        /// //当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        /// <summary>
        /// 当用户释放鼠标左键同时光标某个窗口在非客户区时发送此消息
        /// </summary>
        public const int WM_NCLBUTTONUP = 0x00A2;
        /// <summary>
        /// 当用户双击鼠标左键同时光标某个窗口在非客户区时发送此
        /// </summary>
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        /// <summary>
        /// 当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        /// <summary>
        /// 当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCRBUTTONUP = 0x00A5;
        /// <summary>
        /// 当用户双击鼠标右键同时光标某个窗口在非客户区时发送此
        /// </summary>
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        /// <summary>
        /// 当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        /// <summary>
        /// 当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息
        /// </summary>
        public const int WM_NCMBUTTONUP = 0x00A8;
        /// <summary>
        /// 当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息#DeFine WM_KEYFIRST 0x100
        /// </summary>
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        /// <summary>
        /// 按下一个键
        /// </summary>
        public const int WM_KEYDOWN = 0x0100;
        /// <summary>
        /// 释放一个键
        /// </summary>
        public const int WM_KEYUP = 0x0101;
        /// <summary>
        /// 按下某键，并已发出WM_KEYDOWN， WM_KEYUP消息
        /// </summary>
        public const int WM_CHAR = 0x0102;
        /// <summary>
        /// 当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_DEADCHAR = 0x0103;
        /// <summary>
        /// 当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSKEYDOWN = 0x0104;
        /// <summary>
        /// 当用户释放一个键同时ALT 键还按着时提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSKEYUP = 0x0105;
        /// <summary>
        /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSCHAR = 0x0106;
        /// <summary>
        /// 当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口
        /// </summary>
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_KEYLAST = 0x010F;
        /// <summary>
        /// 在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务
        /// </summary>
        public const int WM_INITDIALOG = 0x0110;
        /// <summary>
        /// 当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译
        /// </summary>
        public const int WM_COMMAND = 0x0111;
        /// <summary>
        /// 当用户选择窗口菜单的一条命令或当用户选择最大化或最小化时那个窗口会收到此消息
        /// </summary>
        public const int WM_SYSCOMMAND = 0x0112;
        /// <summary>
        /// 发生了定时器事件
        /// </summary>
        public const int WM_TIMER = 0x0113;
        /// <summary>
        /// 当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件
        /// </summary>
        public const int WM_HSCROLL = 0x0114;
        /// <summary>
        /// 当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件
        /// </summary>
        public const int WM_VSCROLL = 0x0115;
        /// <summary>
        /// 当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单
        /// </summary>
        public const int WM_INITMENU = 0x0116;
        /// <summary>
        /// 当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部
        /// </summary>
        public const int WM_INITMENUPOPUP = 0x0117;
        /// <summary>
        /// 当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）
        /// </summary>
        public const int WM_MENUSELECT = 0x011F;
        /// <summary>
        /// 当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜
        /// </summary>
        public const int WM_MENUCHAR = 0x0120;
        /// <summary>
        /// 当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待
        /// </summary>
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_MENUCOMMAND = 0x0126;
        /// <summary>
        /// 在windows绘制消息框前发送此消息给消息框的所有者窗口，通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置消息框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        /// <summary>
        /// 当一个编辑型控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLOREDIT = 0x0133;
        /// <summary>
        /// 当一个列表框控件将要被绘制前发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置列表框的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        /// <summary>
        /// 当一个按钮控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置按纽的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORBTN = 0x0135;
        /// <summary>
        /// 当一个对话框控件将要被绘制前发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置对话框的文本背景颜色
        /// </summary>
        public const int WM_CTLCOLORDLG = 0x0136;
        /// <summary>
        /// 当一个滚动条控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置滚动条的背景颜色
        /// </summary>
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        /// <summary>
        /// 当一个静态控件将要被绘制时发送此消息给它的父窗口 通过响应这条消息，所有者窗口可以 通过使用给定的相关显示设备的句柄来设置静态控件的文本和背景颜色
        /// </summary>
        public const int WM_CTLCOLORSTATIC = 0x0138;
        /// <summary>
        /// 移动鼠标时发生
        /// </summary>
        public const int WM_MOUSEMOVE = 0x0200;
        /// <summary>
        /// 按下鼠标左键
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x0201;
        /// <summary>
        /// 释放鼠标左键
        /// </summary>
        public const int WM_LBUTTONUP = 0x0202;
        /// <summary>
        /// 双击鼠标左键
        /// </summary>
        public const int WM_LBUTTONDBLCLK = 0x0203;
        /// <summary>
        /// 按下鼠标右键
        /// </summary>
        public const int WM_RBUTTONDOWN = 0x0204;
        /// <summary>
        /// 释放鼠标右键
        /// </summary>
        public const int WM_RBUTTONUP = 0x0205;
        /// <summary>
        /// 双击鼠标右键
        /// </summary>
        public const int WM_RBUTTONDBLCLK = 0x0206;
        /// <summary>
        /// 按下鼠标中键
        /// </summary>
        public const int WM_MBUTTONDOWN = 0x0207;
        /// <summary>
        /// 释放鼠标中键
        /// </summary>
        public const int WM_MBUTTONUP = 0x0208;
        /// <summary>
        /// 双击鼠标中键
        /// </summary>
        public const int WM_MBUTTONDBLCLK = 0x0209;
        /// <summary>
        /// 当鼠标轮子转动时发送此消息个当前有焦点的控件 Buttons
        /// </summary>
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_SIZING = 0x0214;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_MOVING = 0x0216;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
        public const int WM_PASTE = 0x0302;
        public const int WM_CLEAR = 0x0303;
        public const int WM_UNDO = 0x0304;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;

        public const int WM_APP = 0x8000;
        public const int WM_USER = 0x0400;
    }  
    public static class Win32Api //我自己定义的aip
    {
        #region OpenProcess的权限常量
        public const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        public const int PROCESS_VM_READ = 0x0010;
        public const int PROCESS_VM_WRITE = 0x0020;
        #endregion

        #region mouse_event 函数鼠标操作的常量
        /// <summary>
        /// 移动鼠标 
        /// </summary>
        public const int MOUSEEVENTF_MOVE = 0x0001;
        /// <summary>
        /// 模拟鼠标左键按下 
        /// </summary>
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        /// <summary>
        /// 模拟鼠标左键抬起 
        /// </summary>
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        /// <summary>
        /// 模拟鼠标右键按下 
        /// </summary>
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        /// <summary>
        /// 模拟鼠标右键抬起
        /// </summary>
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        /// <summary>
        /// 模拟鼠标中键按下
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        /// <summary>
        /// 模拟鼠标中键抬起 
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        /// <summary>
        /// 标示是否采用绝对坐标
        /// </summary>
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;  
        #endregion

        #region Win32的api

        /// <summary>
        /// 函数检索处理顶级窗口的类名和窗口名称匹配指定的字符串。这个函数不搜索子窗口
        /// </summary>
        /// <param name="lpClassName">指向窗口类名字符串指针</param>
        /// <param name="lpWindowName">指向窗口标题字符串的指针</param>
        /// <returns>窗口句柄</returns>
        [DllImport("User32.dll", EntryPoint = "FindWindow", SetLastError = true)] //声明findwindow api
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口。此函数为指定的窗口调用窗口程序，直到窗口程序处理完消息再返回
        /// </summary>
        /// <param name="hwnd">要接收消息的窗口的句柄</param>
        /// <param name="wMsg">要发送的消息</param>
        /// <param name="wParam">要附加的消息特定信息</param>
        /// <param name="lParam">要附加的消息特定信息</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessageA", SetLastError = true)]//声明sendmessage api
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        /// <summary>
        /// 找出某个窗口的创建者（线程或进程），返回创建者的标志符。
        /// </summary>
        /// <param name="hWnd">被查找窗口的句柄</param>
        /// <param name="lpdwProcessId">要接收进程标识PId</param>
        /// <returns>创建窗口的线程标识ID</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        /// <summary>
        /// 该函数用来打开一个已存在的进程对象,并返回进程的句柄
        /// </summary>
        /// <param name="dwDesiredAccess">访问权限</param>
        /// <param name="bInheritHandle">继承标志</param>
        /// <param name="dwProcessId">进程PID</param>
        /// <returns>进程句柄</returns>
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        /// <summary>
        /// 该函数从指定的进程中读入内存信息,被读取的区域必须具有访问权限。
        /// </summary>
        /// <param name="hProcess">被读取进程的句柄</param>
        /// <param name="lpBaseAddress">读的起始地址</param>
        /// <param name="buffer">存放读取数据缓冲区</param>
        /// <param name="size">一次读取的字节数</param>
        /// <param name="lpNumberOfBytesRead">实际读取的字节数</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
        /// <summary>
        /// 此函数能写入某一进程的内存区域。入口区必须可以访问，否则操作将失败。 
        /// </summary>
        /// <param name="hProcess">要写入的进程句柄</param>
        /// <param name="lpBaseAddress">要写的内存首地址</param>
        /// <param name="lpBuffer">存放写入数据缓冲区</param>
        /// <param name="nSize">要写入的字节数。</param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        #region 键盘鼠标模拟

        /// <summary>
        /// 该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。系统给创建前台窗口的线程分配的权限稍高于其他线程。
        /// </summary>
        /// <param name="hWnd">指定的窗口的窗口句柄</param>
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零。</returns>
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 该函数返回指定窗口的边框矩形的尺寸。该尺寸以相对于屏幕坐标左上角的屏幕坐标给出。
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lpRect">指向一个RECT结构的指针，该结构接收窗口的左上角和右下角的屏幕坐标</param>
        /// <returns>如果函数成功，返回值为非零：如果函数失败，返回值为零。</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out  RECT lpRect);

        /// <summary>   
        /// 获取鼠标的坐标   
        /// </summary>   
        /// <param name="lpPoint">传址参数，坐标point类型</param>   
        /// <returns>获取成功返回真</returns>   
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
        /// <summary>
        /// 该函数把光标移到屏幕的指定位置。如果新位置不在由 ClipCursor函数设置的屏幕矩形区域之内，则系统自动调整坐标，使得光标在矩形之内。
        /// </summary>
        /// <param name="x">指定光标的新的X坐标</param>
        /// <param name="y">指定光标的新的Y坐标</param>
        /// <returns>如果成功，返回非零值；如果失败，返回值是零</returns>
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 该函数模拟鼠标击键和鼠标动作
        /// </summary>
        /// <param name="dwFlags"> 要调用鼠标事件的常量,可组合</param>
        /// <param name="dx">指定鼠标沿x轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际X坐标；给出的相对数据作为移动的mickeys数。一个mickey表示鼠标移动的数量，表明鼠标已经移动。</param>
        /// <param name="dy">指定鼠标沿y轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOUSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际y坐标，给出的相对数据作为移动的mickeys数。</param>
        /// <param name="dwData">如果dwFlags为MOUSEEVENTF_WHEEL，则dwData指定鼠标轮移动的数量。正值表明鼠标轮向前转动，即远离用户的方向；负值表明鼠标轮向后转动，即朝向用户。一个轮击定义为WHEEL_DELTA，即120。</param>
        /// <param name="dwExtraInfo">指定与鼠标事件相关的附加32位值。应用程序调用函数GetMessageExtraInfo来获得此附加信息。</param>
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("User32.dll")]
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo); 

        #endregion

        
        #endregion

        public static void CloseWindow(string WindowName)//发送关闭消息关闭一个指定窗口
        {
            //WindowName 指定要关闭窗口的名字 
            IntPtr hwnd; //定义句柄变量

            hwnd = FindWindow(null, WindowName);//findwindow 获取窗口句柄

            //MessageBox.Show("句柄" + hwnd.ToString() + "窗口" + WindowName + "即将关闭，点击确定关闭", "提示");

            SendMessage(hwnd, Win32Message.WM_CLOSE, IntPtr.Zero, null);//sendmessage 发送关闭消息。
        }
        
    }
}
