﻿namespace CraigslistTools
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiFlagAddFlager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFlagProxyEditor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFlagCityEditor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFlagUserAgentEditor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFlagCategoryEditor = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageFlag = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupCraigslistCode = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupCraigslistData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedViewMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiFlagAddFlager,
            this.bbiFlagProxyEditor,
            this.bbiFlagCityEditor,
            this.bbiFlagUserAgentEditor,
            this.bbiFlagCategoryEditor});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 6;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageFlag});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(758, 146);
            // 
            // bbiFlagAddFlager
            // 
            this.bbiFlagAddFlager.Caption = "Flagging";
            this.bbiFlagAddFlager.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFlagAddFlager.Glyph = global::CraigslistTools.Properties.Resources.status_16x16;
            this.bbiFlagAddFlager.Id = 1;
            this.bbiFlagAddFlager.LargeGlyph = global::CraigslistTools.Properties.Resources.status_32x32;
            this.bbiFlagAddFlager.Name = "bbiFlagAddFlager";
            this.bbiFlagAddFlager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddFlager_ItemClick);
            // 
            // bbiFlagProxyEditor
            // 
            this.bbiFlagProxyEditor.Caption = "Proxy Editor";
            this.bbiFlagProxyEditor.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFlagProxyEditor.Glyph = global::CraigslistTools.Properties.Resources.Proxy16;
            this.bbiFlagProxyEditor.Id = 2;
            this.bbiFlagProxyEditor.LargeGlyph = global::CraigslistTools.Properties.Resources.Proxy32;
            this.bbiFlagProxyEditor.Name = "bbiFlagProxyEditor";
            this.bbiFlagProxyEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiProxyEditor_ItemClick);
            // 
            // bbiFlagCityEditor
            // 
            this.bbiFlagCityEditor.Caption = "City Editor";
            this.bbiFlagCityEditor.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFlagCityEditor.Glyph = global::CraigslistTools.Properties.Resources.country_16x16;
            this.bbiFlagCityEditor.GlyphDisabled = global::CraigslistTools.Properties.Resources.country_16x16;
            this.bbiFlagCityEditor.Id = 3;
            this.bbiFlagCityEditor.LargeGlyph = global::CraigslistTools.Properties.Resources.country_32x32;
            this.bbiFlagCityEditor.LargeGlyphDisabled = global::CraigslistTools.Properties.Resources.country_32x32;
            this.bbiFlagCityEditor.Name = "bbiFlagCityEditor";
            this.bbiFlagCityEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCityEditor_ItemClick);
            // 
            // bbiFlagUserAgentEditor
            // 
            this.bbiFlagUserAgentEditor.Caption = "User Agent Editor";
            this.bbiFlagUserAgentEditor.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFlagUserAgentEditor.Glyph = global::CraigslistTools.Properties.Resources.UserAgent16;
            this.bbiFlagUserAgentEditor.Id = 4;
            this.bbiFlagUserAgentEditor.LargeGlyph = global::CraigslistTools.Properties.Resources.UserAgent32;
            this.bbiFlagUserAgentEditor.Name = "bbiFlagUserAgentEditor";
            this.bbiFlagUserAgentEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserAgentEditor_ItemClick);
            // 
            // bbiFlagCategoryEditor
            // 
            this.bbiFlagCategoryEditor.Caption = "Categoy Editor";
            this.bbiFlagCategoryEditor.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFlagCategoryEditor.Glyph = global::CraigslistTools.Properties.Resources.Category16;
            this.bbiFlagCategoryEditor.Id = 5;
            this.bbiFlagCategoryEditor.LargeGlyph = global::CraigslistTools.Properties.Resources.Category32;
            this.bbiFlagCategoryEditor.Name = "bbiFlagCategoryEditor";
            this.bbiFlagCategoryEditor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFlagCategoryEditor_ItemClick);
            // 
            // ribbonPageFlag
            // 
            this.ribbonPageFlag.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupCraigslistCode,
            this.ribbonPageGroupCraigslistData});
            this.ribbonPageFlag.Image = global::CraigslistTools.Properties.Resources.status_16x16;
            this.ribbonPageFlag.Name = "ribbonPageFlag";
            this.ribbonPageFlag.Text = "Flag";
            // 
            // ribbonPageGroupCraigslistCode
            // 
            this.ribbonPageGroupCraigslistCode.ItemLinks.Add(this.bbiFlagCityEditor);
            this.ribbonPageGroupCraigslistCode.ItemLinks.Add(this.bbiFlagCategoryEditor);
            this.ribbonPageGroupCraigslistCode.ItemLinks.Add(this.bbiFlagProxyEditor);
            this.ribbonPageGroupCraigslistCode.ItemLinks.Add(this.bbiFlagUserAgentEditor);
            this.ribbonPageGroupCraigslistCode.Name = "ribbonPageGroupCraigslistCode";
            this.ribbonPageGroupCraigslistCode.Text = "Codes";
            // 
            // ribbonPageGroupCraigslistData
            // 
            this.ribbonPageGroupCraigslistData.ItemLinks.Add(this.bbiFlagAddFlager);
            this.ribbonPageGroupCraigslistData.Name = "ribbonPageGroupCraigslistData";
            this.ribbonPageGroupCraigslistData.Text = "Data";
            // 
            // documentManagerMain
            // 
            this.documentManagerMain.ContainerControl = this;
            this.documentManagerMain.MenuManager = this.ribbonControl1;
            this.documentManagerMain.View = this.tabbedViewMain;
            this.documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedViewMain});
            // 
            // tabbedViewMain
            // 
            this.tabbedViewMain.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.tabbedViewMain_QueryControl);
            // 
            // MainFrm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Center;
            this.BackgroundImageStore = global::CraigslistTools.Properties.Resources.craigslist_logo;
            this.ClientSize = new System.Drawing.Size(758, 363);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Craigslist Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManagerMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageFlag;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCraigslistCode;
        private DevExpress.XtraBars.BarButtonItem bbiFlagAddFlager;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedViewMain;
        private DevExpress.XtraBars.BarButtonItem bbiFlagProxyEditor;
        private DevExpress.XtraBars.BarButtonItem bbiFlagCityEditor;
        private DevExpress.XtraBars.BarButtonItem bbiFlagUserAgentEditor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCraigslistData;
        private DevExpress.XtraBars.BarButtonItem bbiFlagCategoryEditor;
    }
}
