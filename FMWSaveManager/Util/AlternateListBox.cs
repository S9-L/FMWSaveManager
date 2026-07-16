using System.Drawing;
using System.Windows.Forms;

namespace FMWSaveManager.Util
{
    /*
     * The MIT License (MIT)
     * 
     * Copyright (c) 2015 xdaniel (Daniel R.) / DigitalZero Domain
     * 
     * Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
     * and associated documentation files (the "Software"), to deal in the Software without restriction, 
     * including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
     * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
     * subject to the following conditions:
     * 
     * The above copyright notice and this permission notice shall be included 
     * in all copies or substantial portions of the Software.
     * 
     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
     * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE 
     * AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
     * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
     * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
     */

    public partial class AlternateListBox : ListBox
    {
        [System.ComponentModel.DefaultValue(false)]
        public bool AlternateBackColorOnDraw { get; set; }
        [System.ComponentModel.DefaultValue(typeof(Color), "ButtonFace")]
        public Color AltBackColor { get; set; }
        public AlternateListBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.DrawMode = DrawMode.OwnerDrawFixed;

            this.AlternateBackColorOnDraw = false;
            this.AltBackColor = SystemColors.ButtonFace;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1 && e.Index < Items.Count)
            {
                Color backColor = ((e.State & DrawItemState.Selected) == DrawItemState.Selected && this.Enabled ? SystemColors.Highlight : (AlternateBackColorOnDraw && e.Index % 2 != 0 ? AltBackColor : BackColor));
                using (SolidBrush backgroundBrush = new SolidBrush(backColor)) e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), e.Font, e.Bounds.Location, (this.Enabled ? e.ForeColor : SystemColors.ControlDark), TextFormatFlags.Left);
            }
            e.DrawFocusRectangle();
        }

        /* Based on http://yacsharpblog.blogspot.de/2008/07/listbox-flicker.html */
        protected override void OnPaint(PaintEventArgs e)
        {
            Region region = new Region(e.ClipRectangle);
            e.Graphics.FillRegion(new SolidBrush(BackColor), region);

            if (Items.Count > 0)
            {
                for (int i = 0; i < Items.Count; ++i)
                {
                    Rectangle rect = GetItemRectangle(i);

                    if (e.ClipRectangle.IntersectsWith(rect))
                    {
                        DrawItemState itemState = (((SelectionMode == SelectionMode.One && SelectedIndex == i) ||
                            (SelectionMode == SelectionMode.MultiSimple && SelectedIndices.Contains(i)) ||
                            (SelectionMode == SelectionMode.MultiExtended && SelectedIndices.Contains(i))) ? DrawItemState.Selected : DrawItemState.Default);

                        OnDrawItem(new DrawItemEventArgs(e.Graphics, Font, rect, i, itemState, ForeColor, BackColor));

                        region.Complement(rect);
                    }
                }
            }
            base.OnPaint(e);
        }
    }
}