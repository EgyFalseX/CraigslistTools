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
    public partial class AddListDlg : DevExpress.XtraEditors.XtraForm
    {
        public List<string> ItemList = new List<string>();
        //public Core.Core.FlagType FlgType = new Core.Core.FlagType();
        public AddListDlg()
        {
            InitializeComponent();
            //cbe.Properties.Items.Add(Core.Core.FlagType.Flag_HaveProblem_28.ToString());
            //cbe.Properties.Items.Add(Core.Core.FlagType.Flag_Repeted_15.ToString());
            //cbe.Properties.Items.Add(Core.Core.FlagType.Flag_BestOf_9.ToString());
            //cbe.Properties.Items.Add(Core.Core.FlagType.Flag_View_0.ToString());
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (cbe.EditValue == null || cbe.EditValue.ToString() == string.Empty
            //    || tbPID.EditValue == null || tbPID.EditValue.ToString() == string.Empty)
            //    return;
            //if (cbe.EditValue.ToString() == Core.Core.FlagType.Flag_BestOf_9.ToString())
            //    FlgType = Core.Core.FlagType.Flag_BestOf_9;
            //else if (cbe.EditValue.ToString() == Core.Core.FlagType.Flag_HaveProblem_28.ToString())
            //    FlgType = Core.Core.FlagType.Flag_HaveProblem_28;
            //else if (cbe.EditValue.ToString() == Core.Core.FlagType.Flag_Repeted_15.ToString())
            //    FlgType = Core.Core.FlagType.Flag_Repeted_15;
            string[] pids = tbPID.EditValue.ToString().Split('\n');
            foreach (string pid in pids)
            {
                if (pid.Trim() == string.Empty)
                    continue;
                ItemList.Add(pid.Trim());
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            return;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            return;
        }
    }
}