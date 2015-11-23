using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using System.Net.NetworkInformation.NetworkInterface;

namespace CraigslistTools.Core
{
    public static class HMA
    {
        static string MainWindowTitle = "HMA! Pro VPN";
        static IntPtr MainWindowHandle = IntPtr.Zero;
        static IntPtr StatusHandle = IntPtr.Zero;
        static IntPtr BtnChangeIPHandle = IntPtr.Zero;
        static IntPtr BtnConnectHandle = IntPtr.Zero;
        public static string KMAPath = string.Empty;
        public enum HMA_State
        {
            Connected = 1,
            Not_Connected
        }
        private static IntPtr FindMainWindowInProcess(string compareTitle, Process _process)
        {
            IntPtr windowHandle = IntPtr.Zero;
            try
            {
                foreach (ProcessThread t in _process.Threads)
                {
                    windowHandle = FindMainWindowInThread(t.Id, compareTitle);
                    if (windowHandle != IntPtr.Zero)
                        break;
                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.Message);}
            return windowHandle;
        }
        private static IntPtr FindMainWindowInThread(int threadId, string compareTitle)
        {
            IntPtr windowHandle = IntPtr.Zero;
            try
            {
                Win32.EnumThreadWindows(threadId, (hWnd, lParam) =>
                {
                    StringBuilder text = new StringBuilder(200);
                    Win32.GetWindowText(hWnd, text, 200);
                    if (text.ToString().Contains(compareTitle))
                    {
                        windowHandle = hWnd;
                        return false;
                    }
                    else
                        return true;
                }, IntPtr.Zero);
            }
            catch { }
            return windowHandle;
        }
        public static void MainWindowStyle(Win32.WindowShowStyle style)
        {
            try
            {
                Win32.ShowWindowAsync(MainWindowHandle, style);
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.Message);}
        }
        private static void PerformClick(IntPtr hwnd)
        {
            try
            {
                Win32.SendMessage(hwnd, Win32.WM_SETFOCUS, 0, 0);
                Win32.SendMessage(hwnd, Win32.BM_CLICK, 0, 0);
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.Message); }
        }
        public static bool Init()
        {
            bool output = false;
            foreach (Process pro in System.Diagnostics.Process.GetProcesses())
            {
                if (pro.ProcessName == "HMA! Pro VPN")
                {
                    MainWindowHandle = FindMainWindowInProcess("HMA! Pro VPN", pro);
                    //MainWindowHandle = pro.MainWindowHandle;
                    if (MainWindowHandle != IntPtr.Zero)
                    {
                        output = true;
                        break;
                    }
                }
            }
            if (output == false)//Found process and main window
                return false;
            //elementHost1
            
            IntPtr Ptr1 = Win32.GetWindow(MainWindowHandle, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr2 = Win32.GetWindow(Ptr1, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr3 = Win32.GetWindow(Ptr2, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr4 = Win32.GetWindow(Ptr3, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr5 = Win32.GetWindow(Ptr4, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr6 = Win32.GetWindow(Ptr5, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr7 = Win32.GetWindow(Ptr6, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr8 = Win32.GetWindow(Ptr7, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr9 = Win32.GetWindow(Ptr8, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr10 = Win32.GetWindow(Ptr9, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr11 = Win32.GetWindow(Ptr10, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            IntPtr Ptr12 = Win32.GetWindow(Ptr11, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr13 = Win32.GetWindow(Ptr12, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr14 = Win32.GetWindow(Ptr13, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr15 = Win32.GetWindow(Ptr14, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            IntPtr Ptr16 = Win32.GetWindow(Ptr15, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr17 = Win32.GetWindow(Ptr16, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr18 = Win32.GetWindow(Ptr17, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr19 = Win32.GetWindow(Ptr18, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            IntPtr Ptr20 = Win32.GetWindow(Ptr19, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            IntPtr Ptr21 = Win32.GetWindow(Ptr20, Win32.GetWindow_Cmd.GW_CHILD);
            IntPtr Ptr22 = Win32.GetWindow(Ptr21, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            StatusHandle = Win32.GetWindow(Ptr22, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            BtnConnectHandle = Win32.GetWindow(StatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            //IntPtr Ptr22 = Win32.GetWindow(StatusHandle, Win32.GetWindow_Cmd.GW_HWNDNEXT);
            //IntPtr BtnChangeIPHandle = Win32.GetWindow(Ptr22, Win32.GetWindow_Cmd.GW_HWNDNEXT);

            if (StatusHandle != IntPtr.Zero)
                output = true;
            else
                output = false;
            return output;
        }
        public static HMA_State Status()
        {
            try
            {
                Init();
                Int32 size = Win32.SendMessage((int)StatusHandle, Win32.WM_GETTEXTLENGTH, 0, 0).ToInt32();
                StringBuilder data = new StringBuilder(size + 1);
                Win32.SendMessage(StatusHandle, Win32.WM_GETTEXT, data.Capacity, data);
                Console.WriteLine(data.ToString());
                if (data.ToString() == "Connected")
                    return HMA_State.Connected;
                else
                    return HMA_State.Not_Connected;
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.Message); }

            return HMA_State.Not_Connected;
        }
        public static void ChangeIP()
        {
            //PerformClick(BtnChangeIPHandle);
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(KMAPath, "-changeip");
            System.Diagnostics.Process.Start(info);
            //00030570
        }
    }

}
