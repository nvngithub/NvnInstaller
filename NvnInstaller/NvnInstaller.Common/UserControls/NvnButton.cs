using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NvnInstaller {
    public class NvnButton : Button {
        bool isSelected = false;

        public bool IsSelected {
            get { return isSelected; }
            set { isSelected = value; }
        }

        protected override void OnPaint(PaintEventArgs p) {
            base.OnPaint(p);
            SizeF size = p.Graphics.MeasureString(Text, Font);
            PointF pt = new PointF((Width - size.Width) / 2, (Height - size.Height) / 2);
            Rectangle r = this.ClientRectangle;
            Brush foreBrush = new SolidBrush(ForeColor);

            if (isSelected) {
                ControlPaint.DrawBorder3D(p.Graphics, r, Border3DStyle.Sunken);
                p.Graphics.FillRectangle(Brushes.WhiteSmoke, r.X + 2, r.Y + 2, r.Width - 3, r.Height - 3);
                p.Graphics.DrawString(this.Text, this.Font, foreBrush, pt);
            } else {
                ControlPaint.DrawBorder3D(p.Graphics, r, Border3DStyle.Adjust);
            }
        }
    }
}
