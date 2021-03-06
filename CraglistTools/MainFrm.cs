﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CraigslistTools
{
    public partial class MainFrm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UI.AdFlager_ProxyUC docAdFlagerProxyCtr = new UI.AdFlager_ProxyUC();
        UI.AdFlager_HMAUC docAdFlagerHMACtr = new UI.AdFlager_HMAUC();
        UI.ProxyUC docProxyCtr = new UI.ProxyUC();
        UI.CityUC docCityCtr = new UI.CityUC();
        UI.CategoryUC docCategoryCtr = new UI.CategoryUC();
        UI.UserAgentUC docUserAgentCtr = new UI.UserAgentUC();
        UI.TestProxyUC docTestProxyCtr = new UI.TestProxyUC();
        UI.LoginInfoUC docLoginInfoCtr = new UI.LoginInfoUC();
        UI.ActivityUC docActivityCtr = new UI.ActivityUC();
        UI.ActivityCategoryUC docActivityCategoryCtr = new UI.ActivityCategoryUC();
        public MainFrm()
        {
            InitializeComponent();
        }
        private void ActivateDoc(string controlName, string caption, Image img)
        {
            try
            {
                foreach (var doc in tabbedViewMain.Documents)
                {
                    if (doc.ControlName == controlName)
                        return;
                }
                DevExpress.XtraBars.Docking2010.Views.Tabbed.Document nDoc = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
                nDoc.Caption = caption;
                nDoc.Image = img;
                nDoc.ControlName = controlName;
                tabbedViewMain.Documents.Add(nDoc);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void bbiAddFlager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docAdFlagerProxyCtr =new UI.AdFlager_ProxyUC();
            ActivateDoc(docAdFlagerProxyCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiFlagAddFlagerHMA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docAdFlagerHMACtr = new UI.AdFlager_HMAUC();
            ActivateDoc(docAdFlagerHMACtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiProxyEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docProxyCtr = new UI.ProxyUC();
            ActivateDoc(docProxyCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiCityEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docCityCtr = new UI.CityUC();
            ActivateDoc(docCityCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiFlagCategoryEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docCategoryCtr = new UI.CategoryUC();
            ActivateDoc(docCategoryCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiUserAgentEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docUserAgentCtr = new UI.UserAgentUC();
            ActivateDoc(docUserAgentCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiTestProxy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docTestProxyCtr = new UI.TestProxyUC();
            ActivateDoc(docTestProxyCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiFlagLoginInfoEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docLoginInfoCtr = new UI.LoginInfoUC();
            ActivateDoc(docLoginInfoCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiFlagAddFlagerActivity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docActivityCtr = new UI.ActivityUC();
            ActivateDoc(docActivityCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void bbiFlagActivityCategoryEditor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            docActivityCategoryCtr = new UI.ActivityCategoryUC();
            ActivateDoc(docActivityCategoryCtr.Name, e.Item.Caption, e.Item.Glyph);
        }
        private void tabbedViewMain_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            if (e.Control != null)
                return;
            if (e.Document.ControlName == "AdFlager_ProxyUC")
            {
                e.Control = docAdFlagerProxyCtr;
            }
            if (e.Document.ControlName == "AdFlager_HMAUC")
            {
                e.Control = docAdFlagerHMACtr;
            }
            else if (e.Document.ControlName == "ProxyUC")
            {
                e.Control = docProxyCtr;
            }
            else if (e.Document.ControlName == "CityUC")
            {
                e.Control = docCityCtr;
            }
            else if (e.Document.ControlName == "CategoryUC")
            {
                e.Control = docCategoryCtr;
            }
            else if (e.Document.ControlName == "TestProxyUC")
            {
                e.Control = docTestProxyCtr;
            }
            else if (e.Document.ControlName == "UserAgentUC")
            {
                e.Control = docUserAgentCtr;
            }
            else if (e.Document.ControlName == "LoginInfoUC")
            {
                e.Control = docLoginInfoCtr;
            }
            else if (e.Document.ControlName == "ActivityUC")
            {
                e.Control = docActivityCtr;
            }
            else if (e.Document.ControlName == "ActivityCategoryUC")
            {
                e.Control = docActivityCategoryCtr;
            }
        }

                
    }
}
