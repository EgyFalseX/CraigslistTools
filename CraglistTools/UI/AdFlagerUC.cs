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
using System.Runtime.InteropServices;
using System.Net;

namespace CraigslistTools.UI
{
    public partial class AdFlagerUC : DevExpress.XtraEditors.XtraUserControl
    {
        WebBrowser _searchBrowser = new WebBrowser();
        //WebBrowser _flagBrowser = new WebBrowser();
        Queue<Datasource.SearchUnit> _searchList = new Queue<Datasource.SearchUnit>();
        Queue<Datasource.FlagUnit> _flagQue = new Queue<Datasource.FlagUnit>();
        List<Datasource.FlagUnit> _flagList = new List<Datasource.FlagUnit>();
        Timer _tmr_flag = new Timer();
        string _craigslist = "craigslist.org";
        string _postpid = "data-pid=\"";
        string _flagMSG = "thanks for flagging!";
        
        public AdFlagerUC()
        {
            InitializeComponent();
            _searchBrowser.DocumentCompleted += _searchBrowser_DocumentCompleted;
            //_flagBrowser.DocumentCompleted += _flagBrowser_DocumentCompleted;
            cityTableAdapter.Fill(dsData.City);
            userAgentTableAdapter.Fill(dsData.UserAgent);
            proxyTableAdapter.Fill(dsData.Proxy);
            categoryTableAdapter.Fill(dsData.Category);

            flagUnitBindingSource.DataSource = _flagList;
            //gridControlPID.DataSource = _flagList;

            _tmr_flag.Interval = 1000 * 10;
            _tmr_flag.Tick += _tmr_flag_Tick;
        }
        
        public void ChangeUserAgent(string Agent)
        {
            Core.Core.UrlMkSetSessionOption(Core.Core.URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }
        private string GetSearchUrl(string city, string craigslist, string category, string keyword)
        {
            string output = string.Empty;
            output = string.Format("http://" + city + "." + craigslist + "/search/" + category + "?query=" + keyword);
            return output;
        }
        private List<string> ParseSearchResult(string result)
        {
            List<string> output = new List<string>();
            int off = 0;
            while (true)
            {
                int inx = result.IndexOf(_postpid, off);
                if (inx == -1)
                    break;
                string pid = result.Substring(inx + _postpid.Length, 10); off = inx + _postpid.Length + 10;
                Int64 isnumber = 0;
                if (!Int64.TryParse(pid, out isnumber))
                    continue;

                bool alreadyadded = false;
                foreach (string item in output)
                {
                    if (pid == item)
                    {
                        alreadyadded = true;
                        break;
                    }
                }

                if (!alreadyadded)
                    output.Add(pid);
            }
            return output;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!dxvp.Validate())
                return;
            _searchList.Clear(); _flagQue.Clear(); _flagList.Clear();
            btnSearch.Enabled = btnStartFlag.Enabled = btnAddPID.Enabled = false; Application.DoEvents();

            string[] cities = ccbCity.EditValue.ToString().Split(',');
            string[] categories = ccbCategory.EditValue.ToString().Split(',');
            
            foreach (string city in cities)
            {
                foreach (string category in categories)
                    _searchList.Enqueue(new Datasource.SearchUnit(city.Trim(), _craigslist, category.Trim(), tbSearchKeyword.EditValue.ToString()));
            }
            pbcSearch.Properties.Maximum = _searchList.Count; pbcSearch.EditValue = 0;
            ExeSearch();
        }
        private void ExeSearch()
        {
            if (_searchList.Count == 0)
                return;
            Datasource.SearchUnit item = _searchList.Dequeue();
            _searchBrowser.Tag = item;
            _searchBrowser.Navigate(item.Url);
            pbcSearch.EditValue = (int)pbcSearch.EditValue + 1;
        }
        private void _searchBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Datasource.SearchUnit item = (Datasource.SearchUnit)((WebBrowser)sender).Tag;
            List<string> PIDs = ParseSearchResult(_searchBrowser.DocumentText);
            string[] proxies = ccbProxy.EditValue.ToString().Split(',');
            Random rnd = new Random(0);
            foreach (string pid in PIDs)
            {
                _flagList.Add(new Datasource.FlagUnit("", 0, "", pid, item.City, item.Category));
                foreach (string proxy in proxies)
                {
                    int id = rnd.Next(0, dsData.UserAgent.Count);
                    Datasource.FlagUnit data = new Datasource.FlagUnit(proxy, dsData.UserAgent[id].UserAgentId, dsData.UserAgent[id].UserAgentName, pid, item.City, item.Category);
                    _flagQue.Enqueue(data);
                }
            }
            if (_searchList.Count > 0)
                ExeSearch();
            else
            {
                gridControlPID.RefreshDataSource();
                btnSearch.Enabled = btnStartFlag.Enabled = btnAddPID.Enabled = true; Application.DoEvents();
            }
        }
        private void btnAddPID_Click(object sender, EventArgs e)
        {
            if (tbPID.EditValue == null || tbPID.EditValue.ToString().Trim() == string.Empty)
            {
                return;
            }
            string[] PIDs = tbPID.EditValue.ToString().Split('\n');
            string[] proxies = ccbProxy.EditValue.ToString().Split(',');
            foreach (string pid in PIDs)
            {
                if (pid.Trim() == string.Empty)
                   continue;
                foreach (string proxy in proxies)
                {
                    int id = new Random(0).Next(0, dsData.UserAgent.Count);
                    Datasource.FlagUnit data = new Datasource.FlagUnit(proxy, dsData.UserAgent[id].UserAgentId, dsData.UserAgent[id].UserAgentName, pid.Trim(), "Unknown", "Unknown");
                    _flagQue.Enqueue(data); _flagList.Add(new Datasource.FlagUnit("", 0, "", pid.Trim(), "Unknown", "Unknown"));
                    //gridControlPID.DataSource = _flagList;
                    gridControlPID.RefreshDataSource();
                }
            }

            tbPID.EditValue = null;
        }
        private void repositoryItemCheckEditExe_CheckedChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit check = (DevExpress.XtraEditors.CheckEdit)sender;
            Datasource.FlagUnit flg = (Datasource.FlagUnit)gridViewPID.GetRow(gridViewPID.FocusedRowHandle);
            if (flg == null)
                return;
            Datasource.FlagUnit[] lst = _flagQue.ToArray<Datasource.FlagUnit>();

            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i].PID == flg.PID)
                    lst[i].Exe = check.Checked;
            }
        }
        private void ExeFlag()
        {
            if (_flagQue.Count == 0) return;
                Datasource.FlagUnit flag = _flagQue.Dequeue();
            while (!flag.Exe)
                flag = _flagQue.Dequeue();
            WebBrowser _flagBrowser = new WebBrowser();
            _flagBrowser.DocumentCompleted += _flagBrowser_DocumentCompleted;
            Cookie coki = new Cookie(flag.Proxy + flag.AgentId + flag.PID, flag.Proxy + flag.AgentId + flag.PID, Application.StartupPath + "/Cookie", "/");
            Core.Core.InternetSetCookie(flag.Url, null, coki.ToString() + "; expires = Sun, 01-Jan-2017 00:00:00 GMT");

            ChangeUserAgent(flag.Agent);
            Core.Core.RefreshIESettings(flag.Proxy);
            _flagBrowser.Tag = flag;
            _tmr_flag.Tag = _flagBrowser;
            _tmr_flag.Start();
            System.Threading.Thread.Sleep(1000 * 3);
            _flagBrowser.Navigate(flag.Url);
        }
        private void _flagBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser _flagBrowser = (WebBrowser)sender;
            _tmr_flag.Stop();
            pbcFlag.EditValue = (int)pbcFlag.EditValue + 1;
            Datasource.FlagUnit flg = (Datasource.FlagUnit)_flagBrowser.Tag;
            if (_flagBrowser.DocumentText.Contains(_flagMSG))
                flg.Status = "Flagged :)";
            else
                flg.Status = "Can't Flag ...!!" + Environment.NewLine + _flagBrowser.DocumentText;

            //Clear Cookies
            string[] Cookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            foreach (string CookieFile in Cookies)
            {
                try { System.IO.File.Delete(CookieFile); } catch { }
            }
            if (_flagBrowser.Document.Cookie != null)
            {
                _flagBrowser.Document.Cookie.Remove(0, _flagBrowser.Document.Cookie.Length);
                _flagBrowser.Document.Cookie = string.Empty;
            }
            //Add Row
            Datasource.dsData.FlagLogRow row = dsData.FlagLog.NewFlagLogRow();
            row.FlagDate = DateTime.Now;
            row.ProxyIP = flg.Proxy; row.PostPID = Convert.ToDouble(flg.PID); row.UserAgentId = flg.AgentId; row.Status = flg.Status;
            dsData.FlagLog.AddFlagLogRow(row); row.EndEdit();
            flagLogTableAdapter.Update(row);

            if (_flagQue.Count > 0) ExeFlag();
            else
            {
                btnSearch.Enabled = btnStartFlag.Enabled = btnAddPID.Enabled = true; Application.DoEvents();
            }
        }
        private void btnExportPIDs_Click(object sender, EventArgs e)
        {
            gridViewPID.ShowRibbonPrintPreview();
        }
        private void _tmr_flag_Tick(object sender, EventArgs e)
        {
            WebBrowser _flagBrowser = (WebBrowser)((Timer)sender).Tag;
            Datasource.FlagUnit flg = (Datasource.FlagUnit)_flagBrowser.Tag;
            flg.Status = "Can't Flag ...!! - Timeout";
            //Add Row
            Datasource.dsData.FlagLogRow row = dsData.FlagLog.NewFlagLogRow();
            row.FlagDate = DateTime.Now;
            row.ProxyIP = flg.Proxy; row.PostPID = Convert.ToDouble(flg.PID); row.UserAgentId = flg.AgentId; row.Status = flg.Status;
            dsData.FlagLog.AddFlagLogRow(row); row.EndEdit();
            flagLogTableAdapter.Update(row);

            if (_flagQue.Count > 0) ExeFlag();
            else
            {
                btnSearch.Enabled = btnStartFlag.Enabled = btnAddPID.Enabled = true; Application.DoEvents();
            }
        }
        private void btnStartFlag_Click(object sender, EventArgs e)
        {
            if (!dxvp.Validate())
                return;
            dsData.FlagLog.Clear();
            btnSearch.Enabled = btnStartFlag.Enabled = btnAddPID.Enabled = false; Application.DoEvents();

            string[] proxies = ccbProxy.EditValue.ToString().Split(',');

            pbcFlag.Properties.Maximum = _flagQue.Count * proxies.Length; pbcFlag.EditValue = 0;
            MessageBox.Show(pbcFlag.Properties.Maximum.ToString());
            ExeFlag();
        }

    }
}
