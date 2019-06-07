using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Hooks
{
    public static class MouseHook
    {
        #region Declarations
        public static event MouseEventHandler MouseDown;
        public static event MouseEventHandler MouseUp;
        public static event MouseEventHandler MouseMove;

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEHOOKSTRUCT
        {
            public POINT pt;
            public IntPtr hwnd;
            public int wHitTestCode;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator Point(POINT p)
            {
                return new Point(p.X, p.Y);
            }

            public static implicit operator POINT(Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_MBUTTONUP = 0x208;
        const int WM_MBUTTONDOWN = 0x207;
        const int WM_XBUTTONDOWN = 0x20B;
        const int WM_XBUTTONUP = 0x20C;

        static IntPtr hHook = IntPtr.Zero;
        static IntPtr hModule = IntPtr.Zero;
        static bool hookInstall = false;
        static bool localHook = true;
        static API.HookProc hookDel;
        #endregion

        /// <summary>
        /// Hook install method.
        /// </summary>
        public static void InstallHook()
        {
            if (IsHookInstalled) return;

            hModule = Marshal.GetHINSTANCE(AppDomain.CurrentDomain.GetAssemblies()[0].GetModules()[0]);
            hookDel = new API.HookProc(HookProcFunction);

            if (localHook)
                hHook = API.SetWindowsHookEx(API.HookType.WH_MOUSE, hookDel, IntPtr.Zero, AppDomain.GetCurrentThreadId()); // Если подчеркивает необращай внимание, так надо.
            else
                hHook = API.SetWindowsHookEx(API.HookType.WH_MOUSE_LL, hookDel, hModule, 0);

            if (hHook != IntPtr.Zero)
                hookInstall = true;
            else
                throw new Win32Exception("Can't install low level keyboard hook!");
        }
        /// <summary>
        /// If hook installed return true, either false.
        /// </summary>
        public static bool IsHookInstalled
        {
            get { return hookInstall && hHook != IntPtr.Zero; }
        }
        /// <summary>
        /// Module handle in which hook was installed.
        /// </summary>
        public static IntPtr ModuleHandle
        {
            get { return hModule; }
        }
        /// <summary>
        /// If true local hook will installed, either global.
        /// </summary>
        public static bool LocalHook
        {
            get { return localHook; }
            set
            {
                if (value != localHook)
                {
                    if (IsHookInstalled)
                        throw new Win32Exception("Can't change type of hook than it install!");
                    localHook = value;
                }
            }
        }
        /// <summary>
        /// Uninstall hook method.
        /// </summary>
        public static void UnInstallHook()
        {
            if (IsHookInstalled)
            {
                if (!API.UnhookWindowsHookEx(hHook))
                    throw new Win32Exception("Can't uninstall low level keyboard hook!");
                hHook = IntPtr.Zero;
                hModule = IntPtr.Zero;
                hookInstall = false;
            }
        }
        /// <summary>
        /// Hook process messages.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        static IntPtr HookProcFunction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == 0) {
                MSLLHOOKSTRUCT mhs = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                switch (wParam.ToInt32()) {
                    case WM_LBUTTONDOWN:
                        MouseDown?.Invoke(null, new MouseEventArgs(MouseButtons.Left, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_LBUTTONUP:
                        MouseUp?.Invoke(null, new MouseEventArgs(MouseButtons.Left, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_MBUTTONDOWN:
                        MouseDown?.Invoke(null, new MouseEventArgs(MouseButtons.Middle, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_MBUTTONUP:
                        MouseUp?.Invoke(null, new MouseEventArgs(MouseButtons.Middle, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_MOUSEMOVE:
                        MouseMove?.Invoke(null, new MouseEventArgs(MouseButtons.None, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_MOUSEWHEEL:
                        if (!localHook) {
                            MouseMove?.Invoke(null, new MouseEventArgs(MouseButtons.None, mhs.time, mhs.pt.X, mhs.pt.Y, mhs.mouseData >> 16));
                        }
                        break;
                    case WM_RBUTTONDOWN:
                        MouseDown?.Invoke(null,new MouseEventArgs(MouseButtons.Right, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_RBUTTONUP:
                        MouseUp?.Invoke(null, new MouseEventArgs(MouseButtons.Right, 1, mhs.pt.X,mhs.pt.Y, 0));
                        break;
                    case WM_XBUTTONDOWN:
                        MouseDown?.Invoke(null, new MouseEventArgs(API.HIWORD(mhs.mouseData) == 1 ? MouseButtons.XButton1 : MouseButtons.XButton2, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    case WM_XBUTTONUP:
                        MouseUp?.Invoke(null, new MouseEventArgs(API.HIWORD(mhs.mouseData) == 1 ? MouseButtons.XButton1 : MouseButtons.XButton2, 1, mhs.pt.X, mhs.pt.Y, 0));
                        break;
                    default:

                        break;
                }
            }

            return API.CallNextHookEx(hHook, nCode, wParam, lParam);
        }
    }

    public static class KeyboardHook
    {
        #region Declarations
        public static event KeyEventHandler KeyboardPressed;
        public static event KeyEventHandler KeyboardUp;
        public static event KeyEventHandler KeyboardDown;

        [StructLayout(LayoutKind.Sequential)]
        struct KBLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x0101;

        static IntPtr hHook = IntPtr.Zero;
        static IntPtr hModule = IntPtr.Zero;
        static bool hookInstall = false;
        static bool localHook = true;
        static API.HookProc hookDel;
        #endregion

        /// <summary>
        /// Hook install method.
        /// </summary>
        public static void InstallHook()
        {
            if (IsHookInstalled) return;

            hModule = Marshal.GetHINSTANCE(AppDomain.CurrentDomain.GetAssemblies()[0].GetModules()[0]);
            hookDel = new API.HookProc(HookProcFunction);

            if (localHook)
                hHook = API.SetWindowsHookEx(API.HookType.WH_KEYBOARD, hookDel, IntPtr.Zero, AppDomain.GetCurrentThreadId()); // Если подчеркивает необращай внимание, так надо.
            else
                hHook = API.SetWindowsHookEx(API.HookType.WH_KEYBOARD_LL, hookDel, hModule, 0);

            if (hHook != IntPtr.Zero)
                hookInstall = true;
            else
                throw new Win32Exception("Can't install low level keyboard hook!");
        }
        /// <summary>
        /// If hook installed return true, either false.
        /// </summary>
        public static bool IsHookInstalled
        {
            get { return hookInstall && hHook != IntPtr.Zero; }
        }
        /// <summary>
        /// Module handle in which hook was installed.
        /// </summary>
        public static IntPtr ModuleHandle
        {
            get { return hModule; }
        }
        /// <summary>
        /// If true local hook will installed, either global.
        /// </summary>
        public static bool LocalHook
        {
            get { return localHook; }
            set
            {
                if (value != localHook)
                {
                    if (IsHookInstalled)
                        throw new Win32Exception("Can't change type of hook than it install!");
                    localHook = value;
                }
            }
        }
        /// <summary>
        /// Uninstall hook method.
        /// </summary>
        public static void UnInstallHook()
        {
            if (IsHookInstalled)
            {
                if (!API.UnhookWindowsHookEx(hHook))
                    throw new Win32Exception("Can't uninstall low level keyboard hook!");
                hHook = IntPtr.Zero;
                hModule = IntPtr.Zero;
                hookInstall = false;
            }
        }
        /// <summary>
        /// Hook process messages.
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        static IntPtr HookProcFunction(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == 0)
            {
                KBLLHOOKSTRUCT pKBLLHOOKSTRUCT = (KBLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBLLHOOKSTRUCT));
                switch (wParam.ToInt32())
                {
                    case WM_KEYDOWN:
                        KeyboardDown?.Invoke(null, new KeyEventArgs((Keys)pKBLLHOOKSTRUCT.vkCode));
                        //MessageBox.Show("OKAY, " + pKBLLHOOKSTRUCT.vkCode); // <--- DEBUG
                        break;
                    case WM_KEYUP:
                        KeyboardUp?.Invoke(null, new KeyEventArgs((Keys)pKBLLHOOKSTRUCT.vkCode));
                        break;
                    
                    default:
                        break;
                }
            }

            return API.CallNextHookEx(hHook, nCode, wParam, lParam);
        }
    }

    static class API
    {
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, [In] IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, [In] IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public delegate int SUBCLASSPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, uint dwRefData);

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern int DefSubclassProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        public static int LOWORD ( int x ) {
            return x & 0xffff;
        }

        public static int HIWORD ( int x ) {
            return (x >> 16) & 0xffff;
        }
    }
}
