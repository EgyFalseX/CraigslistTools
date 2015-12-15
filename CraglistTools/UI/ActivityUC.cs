using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Gecko;

namespace CraigslistTools.UI
{
    public partial class ActivityUC : DevExpress.XtraEditors.XtraUserControl
    {

        #region  - Vars -
        List<Datasource.Act_Item> _pidSpam = new List<Datasource.Act_Item>();
        List<Datasource.Act_Item> _linkView = new List<Datasource.Act_Item>();
        List<Datasource.Act_Item> _pidBest = new List<Datasource.Act_Item>();
        List<Datasource.FlagTemplate> _template = new List<Datasource.FlagTemplate>();
        int _pidSpam_Off = 0; int _linkView_Off = 0; int _pidBest_Off = 0;
        int Login_Off = 0;
        List<Datasource.Exe_Activity> Ex_Data = new List<Datasource.Exe_Activity>();
        int _ex_Off = 0;
        int _pxy_Off = 0;
        #endregion
        #region  - Func -
        public ActivityUC()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(Application.StartupPath + @"\xulrunner\");
            gridControlSpamPID.DataSource = _pidSpam; gridViewSpamPID.PopulateColumns();
            gridControlViewLinks.DataSource = _linkView; gridViewViewLinks.PopulateColumns();
            gridControlBestOf.DataSource = _pidBest; gridViewBestOf.PopulateColumns();
            gridControlTemplate.DataSource = _template; gridViewTemplate.PopulateColumns();

            activityCategoryTableAdapter.Fill(dsData.ActivityCategory);
            loginInfoTableAdapter.FillByActive(dsData.LoginInfo);
            userAgentTableAdapter.Fill(dsData.UserAgent);
            proxyTableAdapter.Fill(dsData.Proxy);
            Core.HMA.Init();

            //Test();
        }
        private void Test()
        {
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://wichitafalls.craigslist.org/lab/5326171074.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/lab/5328594450.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/tfr/5328517020.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/trd/5328602130.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/etc/5328591338.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/tfr/5328599658.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/spa/5328604063.html?lang=es&cc=mx"));
            _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, "http://abilene.craigslist.org/lab/5328507160.html?lang=es&cc=mx"));

            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://spokane.craigslist.org/tfr/5333139045.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://skagit.craigslist.org/tfr/5333272503.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://yakima.craigslist.org/tfr/5317568109.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://kpr.craigslist.org/tfr/5317573671.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://boise.craigslist.org/tfr/5317578597.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://eastidaho.craigslist.org/tfr/5317583857.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://bellingham.craigslist.org/tfr/5317605126.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://spokane.craigslist.org/med/5333141799.html?lang=en&cc=us"));
            _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://eastidaho.craigslist.org/med/5317584820.html?lang=en&cc=us"));

            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://spokane.craigslist.org/tfr/5333139045.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://skagit.craigslist.org/tfr/5333272503.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://yakima.craigslist.org/tfr/5317568109.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://kpr.craigslist.org/tfr/5317573671.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://boise.craigslist.org/tfr/5317578597.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://eastidaho.craigslist.org/tfr/5317583857.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://bellingham.craigslist.org/tfr/5317605126.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://spokane.craigslist.org/med/5333141799.html?lang=en&cc=us"));
            _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, "http://eastidaho.craigslist.org/med/5317584820.html?lang=en&cc=us"));

            btnTemLogin_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavCL_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavCat_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavView_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavView_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavSpam_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavView_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnTemNavView_Click(btnTemLogin, EventArgs.Empty);
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, 3000));
            btnNavBest_Click(btnTemLogin, EventArgs.Empty);
            Core.HMA.KMAPath = @"c:\Program Files (x86)\HMA! Pro VPN\bin\HMA! Pro VPN.exe";

        }
        private void CL_Login(GeckoWebBrowser browser, string username, string password)
        {
            GeckoHtmlElement ele_user = (GeckoHtmlElement)browser.Document.GetElementById("inputEmailHandle");
            ele_user.SetAttribute("value", username);
            GeckoHtmlElement ele_pass = (GeckoHtmlElement)browser.Document.GetElementById("inputPassword");
            ele_pass.SetAttribute("value", password);
            GeckoHtmlElement ele_btnLogin = null;
            GeckoElementCollection col = (GeckoElementCollection)browser.Document.GetElementsByTagName("button");
            foreach (GeckoHtmlElement node in col)
            {
                if (node.TextContent == "Log In")
                {
                    ele_btnLogin = (GeckoHtmlElement)node;
                    break;
                }
            }
            ele_btnLogin.Click();
        }
        private void AddLog(string msg, bool error)
        {
            recLog.Invoke(new MethodInvoker(() => 
            {
                recLog.Document.AppendText(Environment.NewLine + msg);
                recLog.Document.CaretPosition = recLog.Document.Range.End;
                recLog.ScrollToCaret();
            }));
        }
        private void ChangeProxy(string ip, int port)
        {
            geckoWB.Invoke(new MethodInvoker(() => 
            {
                GeckoPreferences.Default["network.proxy.type"] = 1;
                GeckoPreferences.Default["network.proxy.http"] = ip;
                GeckoPreferences.Default["network.proxy.http_port"] = port;
            }));
        }
        public bool PromptAuth(nsIChannel aChannel, uint level, nsIAuthInformation authInfo)
        {
            nsString.Set(authInfo.SetUsernameAttribute, "USERNAME");
            nsString.Set(authInfo.SetPasswordAttribute, "PASSWORD");
            return true;
        }

        #endregion
        #region  - Events -
        private void btnAddSpamPID_Click(object sender, EventArgs e)
        {
            AddListDlg dlg = new AddListDlg();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (string item in dlg.ItemList)
                _pidSpam.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_HaveProblem_28, item));
            gridControlSpamPID.RefreshDataSource();
        }
        private void btnClearSpamPID_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            _pidSpam.Clear();
            gridControlSpamPID.RefreshDataSource();
        }
        private void btnAddView_Click(object sender, EventArgs e)
        {
            AddListDlg dlg = new AddListDlg();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (string item in dlg.ItemList)
                _linkView.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_View_0, item));
            gridControlViewLinks.RefreshDataSource();
        }
        private void btnClearView_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            _linkView.Clear();
            gridControlViewLinks.RefreshDataSource();
        }
        private void btnAddBestOfPIDs_Click(object sender, EventArgs e)
        {
            AddListDlg dlg = new AddListDlg();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (string item in dlg.ItemList)
                _pidBest.Add(new Datasource.Act_Item(Core.Core.FlagType.Flag_BestOf_9, item));
            gridControlBestOf.RefreshDataSource();
        }
        private void btnClearBestOfPIDs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            _pidBest.Clear();
            gridControlBestOf.RefreshDataSource();
        }
        private void btnTemLogin_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Login));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemNavCL_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Nav_CL));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemCleanAgent_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Clean_Agent));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemProxy_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Proxy));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemNavCat_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Nav_Cat));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemNavView_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Nav_View));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemNavSpam_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Nav_Spam));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnNavBest_Click(object sender, EventArgs e)
        {
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Nav_Best));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemWait_Click(object sender, EventArgs e)
        {
            TemWaitDlg dlg = new TemWaitDlg();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            _template.Add(new Datasource.FlagTemplate(Core.Core.TemplateType.Wait, dlg.Sec));
            gridControlTemplate.RefreshDataSource();
        }
        private void btnTemClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                return;
            gridControlTemplate.RefreshDataSource();
            _template.Clear();
        }
        private void beHMAPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            beHMAPath.EditValue = dlg.FileName;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((beHMAPath.EditValue == null || beHMAPath.EditValue.ToString() == string.Empty) && (bool)tsPorxy.EditValue == false)
            {
                MessageBox.Show("Please Select HMA Path ...", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((bool)tsPorxy.EditValue == false)
                Core.HMA.KMAPath = beHMAPath.EditValue.ToString();
            
            Ex_Data.Clear(); _ex_Off = 0; _pxy_Off = 0;
            
            Random rnd_Cat = new Random();
            Random rnd_Agent = new Random();

            foreach (Datasource.dsData.LoginInfoRow login in dsData.LoginInfo)
            {
                foreach (Datasource.FlagTemplate tem in _template)
                {
                    Datasource.Exe_Activity act = new Datasource.Exe_Activity(tem.TemType);

                    switch (tem.TemType)
                    {
                        case CraigslistTools.Core.Core.TemplateType.Login:
                            act.Username = login.UserName;act.Password = login.Password;
                           break;
                        case CraigslistTools.Core.Core.TemplateType.Nav_CL:
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Nav_Cat:
                            act.ActivityCategory = dsData.ActivityCategory[rnd_Cat.Next(0, dsData.ActivityCategory.Count - 1)].ActivityCategory;
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Nav_View:
                            if (_linkView_Off == _linkView.Count - 1)
                                _linkView_Off = 0;
                            act.Link = _linkView[_linkView_Off].Link;
                            _linkView_Off++;
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Nav_Spam:
                            if (_pidSpam_Off == _pidSpam.Count)
                                _pidSpam_Off = 0;
                            act.Link = _pidSpam[_pidSpam_Off].Link;
                            _pidSpam_Off++;
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Nav_Best:
                            if (_pidBest_Off == _pidBest.Count - 1)
                                _pidBest_Off = 0;
                            act.Link = _pidBest[_pidBest_Off].Link;
                            _pidBest_Off++;
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Wait:
                            act.Wait = Convert.ToInt32(tem.Parameter);
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Clean_Agent:
                            act.Agent = dsData.UserAgent[rnd_Agent.Next(0, dsData.UserAgent.Count - 1)].UserAgentName;
                            break;
                        case CraigslistTools.Core.Core.TemplateType.Proxy:
                            break;
                        default:
                            break;
                    
                    }
                    Ex_Data.Add(act);
                }
            }
            pbc.Properties.Maximum = Ex_Data.Count;
            pbc.EditValue = 0;
            Ex_Start();
        }
        private void Ex_Start()
        {
            if (_ex_Off == Ex_Data.Count)
            {
                MessageBox.Show("All complete ...", "done message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;//stop all
            }
            Datasource.Exe_Activity actv = Ex_Data[_ex_Off];
            _ex_Off++;
            AddLog("Start Act:" + actv.TemType.ToString(), false);
            System.Threading.ThreadPool.QueueUserWorkItem((o) => 
            {
                switch (actv.TemType)
                {
                    case CraigslistTools.Core.Core.TemplateType.Login:
                        OpCode_Login(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Nav_CL:
                        OpCode_Nav_CL(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Nav_Cat:
                        OpCode_Nav_Cat(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Nav_View:
                        OpCode_Nav_View(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Nav_Spam:
                        OpCode_Nav_Spam(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Nav_Best:
                        OpCode_Nav_Best(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Wait:
                        OpCode_Wait(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Clean_Agent:
                        OpCode_Clean_Agent(actv);
                        break;
                    case CraigslistTools.Core.Core.TemplateType.Proxy:
                        OpCode_Proxy(actv);
                        break;
                    default:
                        break;
                }
                pbc.Invoke(new MethodInvoker(() => { pbc.EditValue = Convert.ToInt32(pbc.EditValue) + 1; }));
            });
            
        }

        private void OpCode_Login(Datasource.Exe_Activity actv)
        {
            geckoWB.Invoke(new MethodInvoker(() => 
            {
                geckoWB.DocumentCompleted += geckoWB_OpCode_Login_DocumentCompleted;
                geckoWB.Tag = actv; actv.OpCode_Status = "NavToLogin";
                AddLog("Navigate To Login...", false);
                geckoWB.Invoke(new MethodInvoker(() =>
                { geckoWB.Navigate(actv.Cl_lOGIN); }));
            }));
            
        }
        void geckoWB_OpCode_Login_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Datasource.Exe_Activity actv = (Datasource.Exe_Activity)geckoWB.Tag;
            if (actv.OpCode_Status == "NavToLogin")
            {
                AddLog("Login ...", false);
                actv.OpCode_Status = "LoginComplete";
                GeckoHtmlElement ele_user = (GeckoHtmlElement)geckoWB.Document.GetElementById("inputEmailHandle");
                ele_user.SetAttribute("value", actv.Username);
                GeckoHtmlElement ele_pass = (GeckoHtmlElement)geckoWB.Document.GetElementById("inputPassword");
                ele_pass.SetAttribute("value", actv.Password);
                GeckoHtmlElement ele_btnLogin = null;
                GeckoElementCollection col = (GeckoElementCollection)geckoWB.Document.GetElementsByTagName("button");
                foreach (GeckoHtmlElement node in col)
                {
                    if (node.TextContent == "Log In")
                    {
                        ele_btnLogin = (GeckoHtmlElement)node;
                        break;
                    }
                }
                ele_btnLogin.Click();
            }
            else
            {
                AddLog("Login Complete", false);
                geckoWB.DocumentCompleted -= geckoWB_OpCode_Login_DocumentCompleted;
                Ex_Start();
            }
            
        }

        private void OpCode_Nav_CL(Datasource.Exe_Activity actv)
        {
            geckoWB.DocumentCompleted += geckoWB_OpCode_Nav_CL_DocumentCompleted;
            geckoWB.Tag = actv;
            AddLog("Navigate to CL", false);
            geckoWB.Invoke(new MethodInvoker(() =>
            { geckoWB.Navigate(actv.Cl_URL); }));
            
        }
        void geckoWB_OpCode_Nav_CL_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            AddLog("Navigate Complete", false);
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Nav_CL_DocumentCompleted;
            Ex_Start();
        }

        private void OpCode_Nav_Cat(Datasource.Exe_Activity actv)
        {
            geckoWB.DocumentCompleted += geckoWB_OpCode_Nav_Cat_DocumentCompleted;
            geckoWB.Tag = actv;
            AddLog("Navigate To Cat: " + actv.ActivityCategory, false);
            geckoWB.Invoke(new MethodInvoker(() =>
            { geckoWB.Navigate(actv.ActivityCategory); }));
        }
        void geckoWB_OpCode_Nav_Cat_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            AddLog("Navigate Complete", false);
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Nav_Cat_DocumentCompleted;
            Ex_Start();
        }

        private void OpCode_Nav_View(Datasource.Exe_Activity actv)
        {
            geckoWB.DocumentCompleted += geckoWB_OpCode_Nav_View_DocumentCompleted;
            geckoWB.Tag = actv;
            AddLog("Navigate To View: " + actv.Link, false);
            geckoWB.Invoke(new MethodInvoker(() =>
            { geckoWB.Navigate(actv.Link); }));
        }
        void geckoWB_OpCode_Nav_View_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            AddLog("Navigate Complete", false);
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Nav_View_DocumentCompleted;
            Ex_Start();
        }

        private void OpCode_Nav_Spam(Datasource.Exe_Activity actv)
        {
            geckoWB.DocumentCompleted += geckoWB_OpCode_Nav_Spam_DocumentCompleted;
            geckoWB.Tag = actv;
            AddLog("Navigate To Spam: " + actv.Link, false);
            geckoWB.Invoke(new MethodInvoker(() =>
            { geckoWB.Navigate(actv.Link); }));
        }
        void geckoWB_OpCode_Nav_Spam_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Datasource.Exe_Activity actv = (Datasource.Exe_Activity)geckoWB.Tag;
            System.Threading.Thread.Sleep(actv.WAITSEC);
            GeckoNodeCollection ele_user = (GeckoNodeCollection)geckoWB.Document.GetElementsByClassName("flaglink");
            ((GeckoHtmlElement)ele_user[0]).Click();
            System.Threading.Thread.Sleep(2000);
            AddLog("Spam Complete", false);
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Nav_Spam_DocumentCompleted;
            Ex_Start();
        }

        private void OpCode_Nav_Best(Datasource.Exe_Activity actv)
        {
            geckoWB.DocumentCompleted += geckoWB_OpCode_Nav_Best_DocumentCompleted;
            geckoWB.Tag = actv;
            AddLog("Navigate To Best: " + actv.Link, false);
            geckoWB.Invoke(new MethodInvoker(() =>
            { geckoWB.Navigate(actv.Link); }));
        }
        void geckoWB_OpCode_Nav_Best_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            Datasource.Exe_Activity actv = (Datasource.Exe_Activity)geckoWB.Tag;
            System.Threading.Thread.Sleep(actv.WAITSEC);
            GeckoNodeCollection ele_user = (GeckoNodeCollection)geckoWB.Document.GetElementsByClassName("bestof-link");
            ((GeckoHtmlElement)ele_user[0]).Click();
            System.Threading.Thread.Sleep(5000);
            AddLog("Best Complete", false);
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Nav_Best_DocumentCompleted;
            Ex_Start();
        }

        private void OpCode_Wait(Datasource.Exe_Activity actv)
        {
            AddLog("Wait" + actv.Wait, false);
            geckoWB.Tag = actv;
            System.Threading.Thread.Sleep(actv.Wait);

            Ex_Start();
        }
        
        private void OpCode_Clean_Agent(Datasource.Exe_Activity actv)
        {
            //Delete All Cookies
            this.Invoke(new MethodInvoker(() =>
            {
                nsICookieManager CookieMan;
                CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
                CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
                CookieMan.RemoveAll();
                AddLog("Cookie Cleared", false);
                //Change User Agent
                Gecko.GeckoPreferences.User["general.useragent.override"] = actv.Agent;
            }));
            AddLog("Agent Changed", false);
            Ex_Start();
        }

        private void OpCode_Proxy(Datasource.Exe_Activity actv)
        {
            if ((bool)tsPorxy.EditValue == false)
            {
                Core.HMA.ChangeIP();
                AddLog("Changing IP ...", false);
                System.Threading.Thread.Sleep(10000);
                while (Core.HMA.Status() == Core.HMA.HMA_State.Not_Connected)
                {
                    AddLog("Waiting Get New IP", false);
                    System.Threading.Thread.Sleep(5000);
                    Application.DoEvents();
                }
            }
            else
            {
                if (_pxy_Off > dsData.Proxy.Count)
                    _pxy_Off = 0;
                string[] proxy = dsData.Proxy[_pxy_Off].IP.Split(':');
                ChangeProxy(proxy[0], Convert.ToInt32(proxy[1]));
                _pxy_Off++;
            }
            
            AddLog("Test New IP", false);
            geckoWB.Tag = actv;
            geckoWB.DocumentCompleted += geckoWB_OpCode_Proxy_DocumentCompleted;

            geckoWB.Invoke(new MethodInvoker(() => { geckoWB.Navigate(actv.Cl_URL); }));

        }
        void geckoWB_OpCode_Proxy_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            geckoWB.DocumentCompleted -= geckoWB_OpCode_Proxy_DocumentCompleted;
            Datasource.Exe_Activity actv = (Datasource.Exe_Activity)geckoWB.Tag;
            GeckoHtmlElement element = null;
            var geckoDomElement = geckoWB.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                if (element.InnerHtml.ToLower().Contains("this ip has been automatically blocked"))
                {
                    OpCode_Proxy(actv);
                    AddLog("IP Blocked", true);
                }
                else
                {
                    AddLog("IP Changed", false);
                    Ex_Start();
                }
            }

        }

        #endregion

    }
}
