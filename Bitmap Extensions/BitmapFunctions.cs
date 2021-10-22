using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Bitmap_Extensions
{
    public static class BitmapFunctions
    {
        #region Extensions

        public static GraphicsPath Rounded_Rectangle(Int16 x0, Int16 y0, Int16 w, Int16 h, Int16 radius) {
            Rectangle corner = new Rectangle(x0, y0, radius, radius);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(corner, 180, 90);
            corner.X = x0 + w - radius;
            path.AddArc(corner, 270, 90);
            corner.Y = y0 + h - radius;
            path.AddArc(corner, 0, 90);
            corner.X = x0;
            path.AddArc(corner, 90, 90);
            path.CloseFigure();

            return path;
        }

        private static Font FindFont(Graphics g,string longString, Size Room, Font PreferedFont)
        {
            SizeF RealSize = g.MeasureString(longString, PreferedFont);
            float HeightScaleRatio = Room.Height / RealSize.Height;
            float WidthScaleRatio = Room.Width / RealSize.Width;

            float ScaleRatio = (HeightScaleRatio < WidthScaleRatio)
               ? HeightScaleRatio
               : WidthScaleRatio;

            float ScaleFontSize = PreferedFont.Size * ScaleRatio;

            return new Font(PreferedFont.FontFamily, ScaleFontSize);
        }

        #endregion Extensions

        #region Clear_Commands

        public static void ClearDisplay(ref Graphics canva, Color color)
        {
            canva.Clear(color);
        }

        #endregion Clear_Commands

        #region Draw_Commands

        public static void Draw_Pixel(ref Graphics canva, Int16 x0, Int16 y0, Color color)
        {
            canva.FillRectangle(new SolidBrush(color), x0, y0, 1, 1);
        }

        public static void Draw_Line(ref Graphics canva, Int16 x0, Int16 y0, Int16 x1, Int16 y1, Color color)
        {
            canva.DrawLine(new Pen(color), x0, y0, x1, y1);
        }

        public static void Draw_Rectangle(ref Graphics canva, Int16 x0, Int16 y0, Int16 w, Int16 h, Color color)
        {
            canva.DrawRectangle(new Pen(color), x0, y0, w, h);
        }

        public static void Draw_Circle(ref Graphics canva, Int16 x0, Int16 y0, Int16 radius, Color color)
        {
            canva.DrawEllipse(new Pen(color), x0 - radius, y0 - radius,
                      radius + radius, radius + radius);
        }

        public static void Draw_Rounded_Rectangle(ref Graphics canva, Int16 x0, Int16 y0, Int16 w, Int16 h, Int16 radius, Color color)
        {
            canva.DrawPath(new Pen(color), Rounded_Rectangle(x0, y0, w, h, radius));
        }

        public static void Draw_Image(ref Graphics canva, Int16 x0, Int16 y0, Int16 w, Int16 h, Image data)
        {
            canva.DrawImage(data, x0, y0, w, h);
        }

        public static void Draw_Text(ref Graphics canva, Int16 x0, Int16 y0, Int16 font_number, Int16 length, Color color, String text)
        {
            using (Font font1 = new Font(SystemFonts.DefaultFont.FontFamily, font_number, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                Rectangle rect1 = new Rectangle(0, 0, length, font_number);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                canva.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                Font goodFont = FindFont(canva, text, rect1.Size, font1);

                canva.DrawString(text, goodFont, Brushes.Red, rect1, stringFormat);
            }
        }

        public static void Draw_Ellipse(ref Graphics canva, Int16 x0, Int16 y0, Int16 radius_x, Int16 radius_y, Color color)
        {
            canva.DrawEllipse(new Pen(color), x0, y0, radius_x * 2, radius_y * 2);
        }
        #endregion Draw_Commands

        #region Fill_Commands

        public static void Fill_Rectangle(ref Graphics canva, Int16 x0, Int16 y0, Int16 w, Int16 h, Color color)
        {
            canva.FillRectangle(new SolidBrush(color), x0, y0, w, h);
        }

        public static void Fill_Circle(ref Graphics canva, Int16 x0, Int16 y0, Int16 radius, Color color)
        {
            canva.FillEllipse(new SolidBrush(color), x0 - radius, y0 - radius,
          radius + radius, radius + radius);
        }

        public static void Fill_Rounded_Rectangle(ref Graphics canva, Int16 x0, Int16 y0, Int16 w, Int16 h, Int16 radius, Color color)
        {
            canva.FillPath(new SolidBrush(color), Rounded_Rectangle(x0, y0, w, h, radius));
        }

        public static void Fill_Ellipse(ref Graphics canva, Int16 x0, Int16 y0, Int16 radius_x, Int16 radius_y, Color color)
        {
            canva.FillEllipse(new SolidBrush(color), x0, y0, radius_x * 2, radius_y * 2);
        }
        #endregion Fill_Commands
    }
}
