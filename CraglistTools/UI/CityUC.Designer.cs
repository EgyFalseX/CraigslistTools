namespace CraigslistTools.UI
{
    partial class CityUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlMain = new DevExpress.XtraGrid.GridControl();
            this.dsData = new CraigslistTools.Datasource.dsData();
            this.gridViewMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cityBindingSource = new System.Windows.Forms.BindingSource();
            this.cityTableAdapter = new CraigslistTools.Datasource.dsDataTableAdapters.CityTableAdapter();
            this.colCityId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlMain
            // 
            this.gridControlMain.DataSource = this.cityBindingSource;
            this.gridControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMain.Location = new System.Drawing.Point(0, 0);
            this.gridControlMain.MainView = this.gridViewMain;
            this.gridControlMain.Name = "gridControlMain";
            this.gridControlMain.Size = new System.Drawing.Size(536, 373);
            this.gridControlMain.TabIndex = 0;
            this.gridControlMain.UseEmbeddedNavigator = true;
            this.gridControlMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMain});
            // 
            // dsData
            // 
            this.dsData.DataSetName = "dsData";
            this.dsData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridViewMain
            // 
            this.gridViewMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCityId});
            this.gridViewMain.GridControl = this.gridControlMain;
            this.gridViewMain.Name = "gridViewMain";
            this.gridViewMain.NewItemRowText = "Click to add new";
            this.gridViewMain.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade;
            this.gridViewMain.OptionsImageLoad.AsyncLoad = true;
            this.gridViewMain.OptionsSelection.MultiSelect = true;
            this.gridViewMain.OptionsView.ColumnAutoWidth = false;
            this.gridViewMain.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewMain.OptionsView.ShowAutoFilterRow = true;
            this.gridViewMain.OptionsView.ShowGroupPanel = false;
            this.gridViewMain.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.gridViewMain_RowDeleted);
            this.gridViewMain.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewMain_RowUpdated);
            // 
            // cityBindingSource
            // 
            this.cityBindingSource.DataMember = "City";
            this.cityBindingSource.DataSource = this.dsData;
            // 
            // cityTableAdapter
            // 
            this.cityTableAdapter.ClearBeforeFill = true;
            // 
            // colCityId
            // 
            this.colCityId.AppearanceCell.Options.UseTextOptions = true;
            this.colCityId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCityId.AppearanceHeader.Options.UseTextOptions = true;
            this.colCityId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCityId.Caption = "City";
            this.colCityId.FieldName = "CityId";
            this.colCityId.Name = "colCityId";
            this.colCityId.Visible = true;
            this.colCityId.VisibleIndex = 0;
            this.colCityId.Width = 172;
            // 
            // CityUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlMain);
            this.Name = "CityUC";
            this.Size = new System.Drawing.Size(536, 373);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMain;
        private Datasource.dsData dsData;
        private System.Windows.Forms.BindingSource cityBindingSource;
        private Datasource.dsDataTableAdapters.CityTableAdapter cityTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colCityId;
    }
}
