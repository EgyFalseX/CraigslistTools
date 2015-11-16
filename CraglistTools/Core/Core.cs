using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CraigslistTools.Core
{
    public static class Core
    {
        #region Win API
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        public static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        public const int URLMON_OPTION_USERAGENT = 0x10000001;
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        };
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lpszCookieName, string lpszCookieData);
        public static void RefreshIESettings(string strProxy)
        {
            const int INTERNET_OPTION_PROXY = 38;
            const int INTERNET_OPEN_TYPE_PROXY = 3;

            Struct_INTERNET_PROXY_INFO struct_IPI;

            // Filling in structure 
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");

            // Allocating memory 
            IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));

            // Converting structure to IntPtr 
            Marshal.StructureToPtr(struct_IPI, intptrStruct, true);

            bool iReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
        }
        #endregion
    }
}
