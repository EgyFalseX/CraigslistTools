using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraigslistTools.UI
{
    public partial class CityUC : DevExpress.XtraEditors.XtraUserControl
    {
        public CityUC()
        {
            InitializeComponent();
            cityTableAdapter.Fill(dsData.City);
        }
        private void UpdateRow(Datasource.dsData.CityRow row)
        {
            try
            {
                gridViewMain.ShowLoadingPanel();
                row.EndEdit();
                int effected = cityTableAdapter.Update(row);
                if (effected == 0)
                {
                    MessageBox.Show("No data saved ...", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (gridViewMain.LoadingPanelVisible)
                gridViewMain.HideLoadingPanel();
        }
        private void gridViewMain_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            UpdateRow((Datasource.dsData.CityRow)((DataRowView)e.Row).Row);

        }
        private void gridViewMain_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            UpdateRow((Datasource.dsData.CityRow)((DataRowView)e.Row).Row);
        }
    }
}
