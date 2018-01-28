using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NvnInstaller
{
    public partial class UIControl : UserControl
    {
        string tableName;
        bool isCurrentControl;
        LabelProperty currentValue;
        LabelProperty? oldValue;
        bool undoRedo = false;
        LabelController labelController = new LabelController();

        public UIControl()
        {
            InitializeComponent();
            labelController.LabelClicked += new EventHandler(labelController_LabelClicked);
            labelController.LabelMoved += new EventHandler(labelController_LabelMoved);
            Globals.KeyDown += new EventHandler<KeyEventArgs>(Globals_KeyDown);
        }

        public UIControl(DataTable table) : this()
        {
            tableName = table.TableName;
            foreach (DataRow row in table.Rows)
            {
                // create label on the image 
                Label lbl = labelController.CreateLabel(row);
                lbl.Location = new Point(lbl.Location.X + pbDialog.Location.X, lbl.Location.Y + pbDialog.Location.Y);
                pnlDialog.Controls.Add(lbl);
            }
            pbBanner.SendToBack();
            pbDialog.SendToBack();
        }

        public bool IsCurrentControl
        {
            get
            {
                return isCurrentControl;
            }
            set
            {
                isCurrentControl = value;
            }
        }

        public string BannerImg
        {
            set
            {
                if (value != null)
                    pbBanner.Load(value);
            }
        }

        public string DialogImg
        {
            set
            {
                if (value != null)
                    pbDialog.Load(value);
            }
        }

        //public Size DialogSize
        //{
        //    get
        //    {
        //        return pnlDialog.Size;
        //    }
        //    set
        //    {
        //        pnlDialog.Size = value;
        //    }
        //}

        void labelController_LabelClicked(object sender, EventArgs e)
        {
            currentValue = new LabelProperty((Label)sender);
            oldValue = null;
            pgLabelProperty.SelectedObject = currentValue;
        }

        void labelController_LabelMoved(object sender, EventArgs e)
        {
            oldValue = currentValue;
            currentValue.UpdateProperty();
            pgLabelProperty.SelectedObject = currentValue;

            LabelPropertyChanged();         
        }

        private void pgLabelProperty_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //Update label properties
            oldValue = currentValue;
            currentValue = (LabelProperty)pgLabelProperty.SelectedObject;
            currentValue.UpdateLabelObject();

            LabelPropertyChanged();
        }

        private void LabelPropertyChanged()
        {
            if (undoRedo == false)
            {
                UndoRedoItem undoRedoItem = new UndoRedoItem();
                undoRedoItem.dlgName = tableName;
                undoRedoItem.undoRedoStatus = UndoRedoStatus.New;
                undoRedoItem.newValue = currentValue;
                undoRedoItem.oldValue = oldValue;
                UndoRedo.AddItem(undoRedoItem);
            }
        }

        void Globals_KeyDown(object sender, KeyEventArgs e)
        {
            if (((ControlType)sender) == ControlType.UserInterface && isCurrentControl)// PITFALL
            {
                if (e.Control && e.KeyCode == Keys.Z)// Ctrl + Z
                {
                    undoRedo = true;
                    UndoRedoItem undoRedoItem = UndoRedo.Undo(tableName);
                    if (undoRedoItem != null)
                    {
                        LabelProperty labelProp = (LabelProperty)undoRedoItem.oldValue;
                        labelProp.UpdateLabelObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.Y) // Ctrl + Y
                {
                    undoRedo = true;
                    UndoRedoItem undoRedoItem = UndoRedo.Redo(tableName);
                    if (undoRedoItem != null)
                    {
                        LabelProperty labelProp = (LabelProperty)undoRedoItem.newValue;
                        labelProp.UpdateLabelObject();
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                }
            }
            undoRedo = false;
        }

        private void UpdateLabel(Label label)
        {
            DataRow data = (DataRow)label.Tag;
            label.Location = new Point (int.Parse((string)data["x"]), int.Parse((string)data["y"]));
            label.Width = int.Parse((string)data["width"]);
            label.Height = int.Parse((string)data["height"]);
            label.Text = (string)data["text"];
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            labelController.UnselectCotrols();
        }
    }

    class LabelController
    {
        public event EventHandler LabelClicked;
        public event EventHandler LabelMoved;
        private Dictionary<string, Label> lables = new Dictionary<string, Label>();
        private Label selectedLabel;
        private Point labelLocation;
        private int xOffset = 164;
        private int yOffset = 52;

        public Label CreateLabel(DataRow data)
        {
            Label lblElement = new Label();
            //lblElement.AutoSize = true;
            lblElement.Top = int.Parse((string)data["y"]);
            lblElement.Left =  int.Parse((string)data["x"]);
            lblElement.Width = int.Parse((string)data["width"]);
            lblElement.Height = int.Parse((string)data["height"]);
            lblElement.Tag = data;
            lblElement.Text = (string)data["text"];
            switch ((UIFontSize)Enum.Parse(typeof(UIFontSize), (string)data["fontsize"]))
            {
                case UIFontSize.Normal:
                    lblElement.Font = new Font(lblElement.Font.FontFamily, Globals.normalFontSize, FontStyle.Regular);
                    lblElement.BringToFront();
                    break;
                case UIFontSize.Bigger:
                    lblElement.Font = new Font(lblElement.Font.FontFamily, Globals.biggerFontSize, FontStyle.Regular);
                    lblElement.SendToBack();
                    break;
                case UIFontSize.Title:
                    lblElement.Font = new Font(lblElement.Font.FontFamily, Globals.titleFontSize, FontStyle.Bold);
                    break;
            }
            lblElement.Cursor = Cursors.Default;
            lblElement.BackColor = Color.Transparent;
            lblElement.FlatStyle = FlatStyle.Standard;
            lblElement.MouseClick += new MouseEventHandler(lblElement_MouseClick);
            lblElement.MouseDown += new MouseEventHandler(Label_MouseDown);
            lblElement.MouseUp += new MouseEventHandler(lblElement_MouseUp);
            lblElement.MouseMove += new MouseEventHandler(Label_MouseMove);
            
            lables.Add((string)data["id"], lblElement);

            return lblElement;
        }

        internal void UnselectCotrols()
        {
            if (selectedLabel != null)
            {
                selectedLabel.BorderStyle = BorderStyle.None;
                selectedLabel = null;
            }
        }

        void lblElement_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectedLabel != null)
            {
                selectedLabel.BorderStyle = BorderStyle.None;
            }
            selectedLabel = (Label)sender;
            selectedLabel.BringToFront();
            selectedLabel.BorderStyle = BorderStyle.FixedSingle;

            if (LabelClicked != null)
            {
                LabelClicked(selectedLabel, null);
            }
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            labelLocation = e.Location;
        }

        void lblElement_MouseUp(object sender, MouseEventArgs e)
        {
            if (LabelMoved != null && ((Label)sender).Location != labelLocation)
            {
                LabelMoved(sender, null);
            }
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Label)sender).Left += e.X - labelLocation.X;
                ((Label)sender).Top += e.Y - labelLocation.Y;
            }
        }
    }

    struct LabelProperty
    {
        private Label label;
        private Size size;
        private Point location;
        private string text;
        private UIFontSize fontsize;

        public LabelProperty(Label label)
        {
            this.label = label;

            DataRow data = (DataRow)this.label.Tag;
            location = new Point (int.Parse((string)data["x"]),int.Parse((string)data["y"]));
            size = new Size(int.Parse((string)data["width"]), int.Parse((string)data["height"]));
            text = (string)data["text"];
            fontsize = (UIFontSize)Enum.Parse(typeof(UIFontSize),(string)data["fontsize"]);
        }

        public void UpdateProperty()
        {
            //TODO: No other property can be changed... need improvement
            location = this.label.Location;
        }

        public void UpdateLabelObject()
        {
            // just label is reference variable... rest of the properties are value types
            this.label.Size = size;
            this.label.Location = location;
            this.label.Text = text;
            // update DataRow >> DataTable
            DataRow data = (DataRow)this.label.Tag;
            data["x"] = location.X;
            data["y"] = location.Y;
            data["width"] = size.Width;
            data["height"] = size.Height;
            data["fontsize"] = fontsize;
            switch (fontsize)
            {
                case UIFontSize.Normal:
                    this.label.Font = new Font (this.label.Font.FontFamily,Globals.normalFontSize,FontStyle.Regular);
                    break;
                case UIFontSize.Bigger:
                    this.label.Font = new Font(this.label.Font.FontFamily, Globals.biggerFontSize, FontStyle.Regular);
                    break;
                case UIFontSize.Title:
                    this.label.Font = new Font(this.label.Font.FontFamily, Globals.titleFontSize, FontStyle.Bold);
                    break;
            }
            data["text"] = text;
        }

        public Point Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        public Size Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public UIFontSize FontSize
        {
            get
            {
                return fontsize;
            }
            set
            {
                fontsize = value;
            }
        }
    }
}
