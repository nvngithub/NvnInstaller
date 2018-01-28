using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller {
    public partial class SummaryControl : UserControl {
        public event EventHandler ControlSizeChanged;
        bool collapsed = false, expandToContainer = false;
        DataTable data;
        Size controlSize;

        [Browsable(true)]
        public string Title {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Browsable(true)]
        public bool Collapsed {
            get { return collapsed; }
            set { if (value) Collapse(); else ExpandComplete(); }
        }

        [Browsable(true)]
        public bool ExpandDridToContainer {
            get { return expandToContainer; }
            set { expandToContainer = value; }
        }

        public DataTable Data {
            get { return data; }
            set { data = value; UpdateGridData(); }
        }

        public DataGridView DataGrid {
            get { return dgrSummaryData; }
        }

        public SummaryControl() {
            InitializeComponent();
            controlSize = this.Size;
        }

        public SummaryControl(bool collapsed)
            : this() {
            this.collapsed = collapsed;
            if (collapsed) {
                Collapse();
            } else {
                ExpandComplete();
            }
        }

        private void SummaryControl_Load(object sender, EventArgs e) {
            if (collapsed) {
                Collapse();
            } else {
                ExpandComplete();
            }
        }

        private void lblCollapse_Click(object sender, EventArgs e) {
            if (collapsed) {
                if (expandToContainer) ExpandToContainer();
                else ExpandComplete();
            } else {
                Collapse();
            }
        }

        private void UpdateGridData() {
            dgrSummaryData.DataSource = data;
            if (collapsed == false) {
                ExpandComplete();
            }
        }

        public void Collapse() {
            collapsed = true;
            this.Height = lblCollapse.Location.Y + lblCollapse.Height + lblCollapse.Margin.Bottom;
            lblCollapse.Text = "+";
            lblLine.Visible = true;
            if (ControlSizeChanged != null) {
                ControlSizeChanged(this, null);
            }
        }

        private void Expand() {
            collapsed = false;
            lblCollapse.Text = "-";
            lblLine.Visible = false;
            if (ControlSizeChanged != null) {
                ControlSizeChanged(this, null);
            }
        }

        public void ExpandComplete() {
            dgrSummaryData.Height = dgrSummaryData.ColumnHeadersHeight + (dgrSummaryData.RowCount * dgrSummaryData.RowTemplate.Height);
            this.Height = dgrSummaryData.Location.Y + dgrSummaryData.Height + dgrSummaryData.Margin.Bottom;

            Expand();
        }

        public void ExpandToContainer() {
            dgrSummaryData.Height = controlSize.Height + this.Margin.Top + this.Margin.Bottom;
            this.Height = controlSize.Height;
            this.Refresh();

            Expand();
        }
    }
}
