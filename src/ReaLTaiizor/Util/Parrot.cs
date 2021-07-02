﻿#region Imports

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ReaLTaiizor.Util
{
    #region ParrotUtil

    #region Percantage

    public static class Percentage
    {
        public static int IntToPercent(int number, int total)
        {
            return Convert.ToInt32(Math.Round((double)(100 * number) / (double)total));
        }

        public static int PercentToInt(int number, int total)
        {
            return Convert.ToInt32(Math.Round((double)(total / 100) * (double)number));
        }
    }

    #endregion

    #region StripeRemoval

    public class StripeRemoval : ToolStripSystemRenderer
    {
        public StripeRemoval(Color borderColor)
        {
            BorderColor = borderColor;
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(BorderColor, 1f), new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1));
        }

        public Color BorderColor;
    }

    #endregion

    #region Widget

    public class Widget
    {
        public void SetWidget(Control C)
        {
            C.MouseDown += WidgetDown;
            C.MouseUp += WidgetUp;
            C.MouseMove += WidgetMove;
        }

        private void WidgetDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void WidgetUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void WidgetMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ((Control)sender).Location = new Point(e.X, e.Y);
            }
        }

        private bool isDragging;
    }

    #endregion

    #region KitMenuStripRenderer

    public class KitMenuStripRenderer : System.Windows.Forms.ToolStripRenderer
    {
        public KitMenuStripRenderer(Color hc, Color bc, Color sbc, Color hbc, Color tc, Color htc, Color stc, Color sc)
        {
            headerColor = hc;
            backColor = bc;
            selectedBackColor = sbc;
            hoverBackColor = hbc;
            textColor = tc;
            hoverTextColor = htc;
            selectedTextColor = stc;
            seperatorColor = sc;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);
            if (e.Item.Enabled)
            {
                if (!e.Item.IsOnDropDown && e.Item.Selected)
                {
                    Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
                    e.Graphics.FillRectangle(new SolidBrush(hoverBackColor), rect);
                    e.Item.ForeColor = hoverTextColor;
                }
                else
                {
                    e.Item.ForeColor = textColor;
                }
                if (e.Item.IsOnDropDown && e.Item.Selected)
                {
                    Rectangle rect2 = new Rectangle(1, -4, e.Item.Width + 5, e.Item.Height + 4);
                    e.Graphics.FillRectangle(new SolidBrush(hoverBackColor), rect2);
                    e.Item.ForeColor = textColor;
                }
                if ((e.Item as ToolStripMenuItem).DropDown.Visible && !e.Item.IsOnDropDown)
                {
                    Rectangle rect3 = new Rectangle(0, 0, e.Item.Width + 3, e.Item.Height);
                    e.Graphics.FillRectangle(new SolidBrush(selectedBackColor), rect3);
                    e.Item.ForeColor = selectedTextColor;
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            SolidBrush brush = new SolidBrush(seperatorColor);
            Rectangle rect = new Rectangle(1, 3, e.Item.Width, 1);
            e.Graphics.FillRectangle(brush, rect);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);
            if (e.Item.Selected)
            {
                Rectangle rect = new Rectangle(4, 2, 18, 18);
                Rectangle rect2 = new Rectangle(5, 3, 16, 16);
                SolidBrush brush = new SolidBrush(selectedTextColor);
                SolidBrush brush2 = new SolidBrush(selectedBackColor);
                e.Graphics.FillRectangle(brush, rect);
                e.Graphics.FillRectangle(brush2, rect2);
                e.Graphics.DrawImage(e.Image, new Point(5, 3));
                return;
            }
            Rectangle rect3 = new Rectangle(4, 2, 18, 18);
            Rectangle rect4 = new Rectangle(5, 3, 16, 16);
            SolidBrush brush3 = new SolidBrush(textColor);
            SolidBrush brush4 = new SolidBrush(backColor);
            e.Graphics.FillRectangle(brush3, rect3);
            e.Graphics.FillRectangle(brush4, rect4);
            e.Graphics.DrawImage(e.Image, new Point(5, 3));
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);
            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);
            e.Graphics.FillRectangle(new SolidBrush(backColor), rect);
            SolidBrush brush = new SolidBrush(backColor);
            Rectangle rect2 = new Rectangle(0, 0, 26, e.AffectedBounds.Height);
            e.Graphics.FillRectangle(brush, rect2);
            e.Graphics.DrawLine(new Pen(new SolidBrush(backColor)), 28, 0, 28, e.AffectedBounds.Height);
        }

        public Color headerColor;

        public Color backColor;

        public Color selectedBackColor;

        public Color hoverBackColor;

        public Color textColor;

        public Color hoverTextColor;

        public Color selectedTextColor;

        public Color seperatorColor;
    }

    #endregion

    #endregion
}