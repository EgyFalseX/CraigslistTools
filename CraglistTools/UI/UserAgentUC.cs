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
    public partial class UserAgentUC : DevExpress.XtraEditors.XtraUserControl
    {
        public UserAgentUC()
        {
            InitializeComponent();
            userAgentTableAdapter.Fill(dsData.UserAgent);
        }
        private void UpdateRow(Datasource.dsData.UserAgentRow row)
        {
            try
            {
                gridViewMain.ShowLoadingPanel();
                row.EndEdit();
                int effected = userAgentTableAdapter.Update(row);
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
            UpdateRow((Datasource.dsData.UserAgentRow)((DataRowView)e.Row).Row);

        }
        private void gridViewMain_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            UpdateRow((Datasource.dsData.UserAgentRow)((DataRowView)e.Row).Row);
        }
    }
}
