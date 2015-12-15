using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Gecko;

namespace CraigslistTools
{
    public partial class Test : DevExpress.XtraEditors.XtraForm
    {
        public Test()
        {
            InitializeComponent();
            Gecko.Xpcom.Initialize(Application.StartupPath +  @"\xulrunner\");
            geckoWebBrowser1.DocumentCompleted += geckoWebBrowser1_DocumentCompleted;
            //Gecko.Xpcom.Initialize(@"d:\Sysbase\Internet\Mozilla Firefox\");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(tbURL.Text);
        }

        void geckoWebBrowser1_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            GeckoHtmlElement element = null;
            var geckoDomElement = geckoWebBrowser1.Document.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                var innerHtml = element.InnerHtml;
            }
        }
        private void btnclearcookie_Click(object sender, EventArgs e)
        {
            nsICookieManager CookieMan;
            CookieMan = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
            CookieMan = Xpcom.QueryInterface<nsICookieManager>(CookieMan);
            CookieMan.RemoveAll();
        }
        private void btnuseragent_Click(object sender, EventArgs e)
        {
            string sUserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; pl; rv:1.9.1) Gecko/20090624 Firefox/3.5 (.NET CLR 3.5.30729)";
            Gecko.GeckoPreferences.User["general.useragent.override"] = sUserAgent;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GeckoHtmlElement ele_user = (GeckoHtmlElement)geckoWebBrowser1.Document.GetElementById("inputEmailHandle");
            ele_user.SetAttribute("value", "damarisethen52@gmail.com");
            GeckoHtmlElement ele_pass = (GeckoHtmlElement)geckoWebBrowser1.Document.GetElementById("inputPassword");
            ele_pass.SetAttribute("value", "4Z37DUmW4321");
            GeckoHtmlElement ele_btnLogin = null;
            GeckoElementCollection col = (GeckoElementCollection)geckoWebBrowser1.Document.GetElementsByTagName("button");
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

        private void btnSpam_Click(object sender, EventArgs e)
        {
            GeckoNodeCollection ele_user = (GeckoNodeCollection)geckoWebBrowser1.Document.GetElementsByClassName("flaglink");
            ((GeckoHtmlElement)ele_user[0]).Click();

        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeProxy_Click(object sender, EventArgs e)
        {
            GeckoPreferences.Default["network.proxy.type"] = 1;
            GeckoPreferences.Default["network.proxy.http"] = "89.40.196.45";
            GeckoPreferences.Default["network.proxy.http_port"] = 8080;
            MessageBox.Show("Done ... 89.40.196.45");
            
            //GeckoPreferences.Default["network.proxy.ssl"] = proxyAddress.Host;
            //GeckoPreferences.Default["network.proxy.ssl_port"] = proxyAddress.Port;

        }

        private void btnproxy2_Click(object sender, EventArgs e)
        {
            GeckoPreferences.Default["network.proxy.type"] = 1;
            GeckoPreferences.Default["network.proxy.http"] = "185.46.85.111";
            GeckoPreferences.Default["network.proxy.http_port"] = 8085;
            MessageBox.Show("Done ...185.46.85.111");
        }
    }
}