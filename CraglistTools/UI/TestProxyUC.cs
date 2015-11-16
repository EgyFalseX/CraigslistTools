using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using CraigslistTools.Datasource;

namespace CraigslistTools.UI
{
    public partial class TestProxyUC : DevExpress.XtraEditors.XtraUserControl
    {
        Queue<string> QueProxy = new Queue<string>();
        WebBrowser wb = new WebBrowser();
        Timer tmr = new Timer() { Interval = 1000 * 15 };
        string TestUrl = "https://accounts.craigslist.org/login";
        //string TestUrl = "www.google.com";
        string MSG_Blocked = "This IP has been automatically blocked.";
        string MSG_NotFound = "Server not found";
        string MSG_PageProblem1 = "Internet Explorer cannot display the webpage";
        string MSG_PageProblem2 = "The website cannot display the page";
        string MSG_OK = "Log in to your craigslist account";

        string Cookie_P1 = "cl_b=1p-SbbOK5RGYgMf7MiKlagFFMrk";
        string Cookie_P2 = "cl_tocmode=sss%3Agrid";
        int CookieId = 1;
        Datasource.dsDataTableAdapters.ProxyTableAdapter adp = new Datasource.dsDataTableAdapters.ProxyTableAdapter();
        
        List<FlagUnit> _data = new List<FlagUnit>();

        public TestProxyUC()
        {
            InitializeComponent();
            gridControlMain.DataSource = _data;
        }
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (tbPIDs.EditValue == null || tbPIDs.EditValue.ToString().Trim() == string.Empty)
                return;
            btnStartTest.Enabled = false;
            wb.DocumentCompleted += Wb_DocumentCompleted;
            tmr.Tick += Tmr_Tick;
            string[] proxies = tbPIDs.EditValue.ToString().Split('\n');
            _data.Clear();
            foreach (string proxy in proxies)
            {
                if (proxy.Trim() == string.Empty)
                    continue;
                QueProxy.Enqueue(proxy.Trim());
            }
            ExeTest();
        }
        private void ExeTest()
        {
            if (QueProxy.Count == 0)
            {
                btnStartTest.Enabled = true;
                return;
            }
            string proxy = QueProxy.Dequeue();
            Cookie coki = new Cookie(CookieId.ToString(), Cookie_P1 + CookieId + "; " + Cookie_P2 + CookieId, Application.StartupPath + "\\Cookie", "/");
            Core.Core.InternetSetCookie(TestUrl, null, coki.ToString() + "; expires = Sun, 01-Jan-2017 00:00:00 GMT");
            Core.Core.RefreshIESettings(proxy);
            wb.Tag = proxy;
            wb.Navigate(TestUrl);
            tmr.Start();
        }
        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tmr.Stop();
            WebBrowser webbro = (WebBrowser)sender;
            FlagUnit item = new FlagUnit(webbro.Tag.ToString(), -1, "", "", "", "");
            if (webbro.DocumentText.Contains(MSG_OK))
            {
                item.Status = "Working";
                try { adp.InsertNewProxy(item.Proxy); } catch {}
            }
            else
            {
                item.Status = "Not Working";
            }
            _data.Add(item);
            gridControlMain.RefreshDataSource();

            string[] Cookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            foreach (string CookieFile in Cookies)
            {
                try { System.IO.File.Delete(CookieFile); } catch { }
            }
            if (wb.Document.Cookie != null)
            {
                wb.Document.Cookie.Remove(0, wb.Document.Cookie.Length);
                wb.Document.Cookie = string.Empty;
            }

            if (QueProxy.Count == 0)
            {
                btnStartTest.Enabled = true;
                return;
            }
            else
                ExeTest();
        }
        private void Tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            wb.Stop();
            FlagUnit item = new FlagUnit(wb.Tag.ToString(), -1, "", "", "", "");
            item.Status = "Not Working - Timeout";
            _data.Add(item);
            gridControlMain.RefreshDataSource();
            if (QueProxy.Count == 0)
            {
                btnStartTest.Enabled = true;
                return;
            }
            else
                ExeTest();
        }
    }
}
