using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace NvnInstaller {
    public partial class GridItemsControl : UserControl {

        public event EventHandler<GridItemEventArgs> ItemDeleted;
        public event EventHandler<GridItemEventArgs> ItemSelectionChanged;

        public GridItemsControl() {
            InitializeComponent();
        }

        [Browsable(true)]
        public DataGridViewColumn GridHeader {
            get { return dgItems.Columns[0]; }
        }

        [Browsable(true)]
        public ContextMenuStrip GridContextMenu {
            get { return dgItems.ContextMenuStrip; }
            set { dgItems.ContextMenuStrip = value; }
        }

        public ArrayList Items {
            get {
                ArrayList items = new ArrayList();
                foreach (DataGridViewRow row in dgItems.Rows) {
                    items.Add(row.Tag);
                }
                return items;
            }
            set {
                dgItems.Rows.Clear();
                foreach (object o in value) {
                    int index = dgItems.Rows.Add(o.ToString());
                    dgItems.Rows[index].Tag = o;
                }
            }
        }

        #region Button Events
        private void btnDelete_Click(object sender, EventArgs e) {
            DeleteSelectedItem();
        }

        private void btnUp_Click(object sender, EventArgs e) {
            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count > 0 && dgItems.SelectedRows[0].Index > 0) {
                DataGridViewRow selectedRow = dgItems.SelectedRows[0];
                int index = dgItems.SelectedRows[0].Index;
                dgItems.Rows.Remove(selectedRow);
                dgItems.Rows.Insert(index - 1, selectedRow);
                selectedRow.Selected = true;
            }              
        }

        private void btnDown_Click(object sender, EventArgs e) {
            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count > 0 && dgItems.SelectedRows[0].Index < dgItems.Rows.Count - 1) {
                DataGridViewRow selectedRow = dgItems.SelectedRows[0];
                int index = dgItems.SelectedRows[0].Index;
                dgItems.Rows.Remove(selectedRow);
                dgItems.Rows.Insert(index + 1, selectedRow);
                selectedRow.Selected = true;
            }
        }
        #endregion

        #region Grid Event Handlers
        private void dgItems_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (ItemDeleted != null) { ItemDeleted(this, new GridItemEventArgs(e.Row.Tag)); }
        }

        private void dgItems_SelectionChanged(object sender, EventArgs e) {
            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count > 0) {
                if (ItemSelectionChanged != null) { ItemSelectionChanged(this, new GridItemEventArgs(dgItems.SelectedRows[0].Tag)); };
            }
        }
        #endregion

        public void AddNewItem(object o) {
            int index = dgItems.Rows.Add(o.ToString());
            dgItems.Rows[index].Tag = o;

            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count == 1 && ItemSelectionChanged != null) {
                ItemSelectionChanged(this, new GridItemEventArgs(dgItems.SelectedRows[0].Tag));
            }
        }

        public void ClearItems() {
            while(dgItems.Rows.Count != 0) {
                dgItems.Rows[0].Selected = true;
                DeleteSelectedItem();
            }
        }

        public void DeleteSelectedItem() {
            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count > 0) {
                if (ItemDeleted != null) ItemDeleted(this, new GridItemEventArgs(dgItems.SelectedRows[0].Tag));
                dgItems.Rows.Remove(dgItems.SelectedRows[0]);
            }
        }

        public void UpdateSelectedItemText(string text) {
            if (dgItems.SelectedRows != null && dgItems.SelectedRows.Count > 0) {
                dgItems.SelectedRows[0].Cells[0].Value = text;
            }
        }
    }

    public class GridItemEventArgs : EventArgs {
        private object item;

        public object SelectedItem {
            get { return item; }
        }

        public GridItemEventArgs(object item) {
            this.item = item;
        }
    }
}
