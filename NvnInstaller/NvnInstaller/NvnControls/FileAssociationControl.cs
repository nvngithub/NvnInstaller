using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NvnInstaller {
    public partial class FileAssociationControl : UserControl {
        public FileAssociationControl() {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            int index = dgrExtensions.Rows.Add();
            dgrExtensions[indexColumn.Name, index].Value = index + 1;
            dgrExtensions[BrowseColumn.Name, index].Value = "...";
            dgrExtensions[deleteColumn.Name, index].Value = "Delete";
            dgrExtensions[applicationColumn.Name, index].ReadOnly = true;
        }

        private void dgrExtensions_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == deleteColumn.Index) {
                dgrExtensions.Rows.RemoveAt(e.RowIndex);
                // update row index(Display) values
                for (int i = 0; i < dgrExtensions.Rows.Count; i++) {
                    dgrExtensions[indexColumn.Name, i].Value = i + 1;
                }
            } else if (e.ColumnIndex == BrowseColumn.Index) {
                // show dialog to select files and folders in Components tree
                ComponentsForm componentsForm = new ComponentsForm(true);
                Point pointToScreen = PointToScreen(dgrExtensions.Location);
                int x = pointToScreen.X + dgrExtensions.Columns[0].Width + dgrExtensions.Columns[1].Width + dgrExtensions.Columns[2].Width + dgrExtensions.Columns[3].Width - componentsForm.Width;
                int y = pointToScreen.Y + dgrExtensions.ColumnHeadersHeight + dgrExtensions.Rows[e.RowIndex].Height * e.RowIndex;
                componentsForm.Location = new Point(x, y);
                if (componentsForm.ShowDialog() == DialogResult.OK) {
                    if (componentsForm.SelectedComponentNode != null) {
                        ComponentNode componentNode = (ComponentNode)componentsForm.SelectedComponentNode.Tag;
                        dgrExtensions[applicationColumn.Name, e.RowIndex].Value = (new FileInfo(componentNode.Property.SourcePath)).Name;
                        dgrExtensions.Rows[e.RowIndex].Tag = componentsForm.SelectedComponentNode;
                    }
                }
            } else {
                dgrExtensions.BeginEdit(true);
            }
        }
    }
}
