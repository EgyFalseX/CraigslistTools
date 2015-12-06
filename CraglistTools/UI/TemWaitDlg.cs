using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CraigslistTools.UI
{
    public partial class TemWaitDlg : DevExpress.XtraEditors.XtraForm
    {
        public int Sec = 0;
        public TemWaitDlg()
        {
            InitializeComponent();
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbSecond.EditValue == null || tbSecond.EditValue.ToString() == string.Empty)
                return;
            Sec = Convert.ToInt32(tbSecond.EditValue) * 1000;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}