using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PaintMock
{
    public class ShapeDrawHandler
    {
        Point lastPoint = Point.Empty;
        bool isMouseDown = new Boolean();
        private readonly PictureBox pictureBox;
        Rectangle SelectRect = new Rectangle();
        Point pointStart = new Point();
        Point pointEnd = new Point();

        public EventHandler<Point> OnStartPoint;
        public EventHandler<Rectangle> OnRectangleUpdated;
        protected ShapeTypeEnum ActiveShape { get; set; }
        protected Color ActiveColor { get; set; }



        public ShapeDrawHandler(PictureBox pictureBox)
        {
            ActiveShape = ShapeTypeEnum.Draw;

            this.pictureBox = pictureBox;
            this.pictureBox.MouseDown += clsLineRectangle_OnMouseDown;
            this.pictureBox.MouseUp += clsLineRectangle_OnMouseUp;
            this.pictureBox.MouseMove += clsLineRectangle_OnMouseMove;
        }
        public void SetShape(ShapeTypeEnum shapeType) => ActiveShape = shapeType;
        public void clsLineRectangle_OnMouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            lastPoint = e.Location;

            pointStart = new Point(e.X, e.Y);
            SelectRect = new Rectangle(pointStart.X, pointStart.Y, 0, 0);
            pointEnd = pointStart;

            OnStartPoint?.Invoke(this, pointStart);
        }
        public void clsLineRectangle_OnMouseMove(object sender, MouseEventArgs e)
        {

            if (isMouseDown != true) return;

            if (ActiveShape == ShapeTypeEnum.Line)
                LineMove(sender, e);
            else if (ActiveShape == ShapeTypeEnum.Rectangle)
                RectangleMove(sender, e);
            else
                DrawMove(sender, e);
        }
        public void clsLineRectangle_OnMouseUp(object sender, MouseEventArgs e)
        {
            if (ActiveShape == ShapeTypeEnum.Line)
                LineMouseUp(sender);
            else if (ActiveShape == ShapeTypeEnum.Rectangle)
                RectangleMouseUp(sender);

            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void DrawMove(object sender, MouseEventArgs e)
        {
            if (lastPoint == null)
                return;
            if (!(sender is PictureBox picBox)) 
                return;

            if (picBox.Image == null)
            {
                Bitmap bmp = new Bitmap(picBox.Width, picBox.Height);
                picBox.Image = bmp;
            }

            using (Graphics g = Graphics.FromImage(picBox.Image))
            {
                g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }

            picBox.Invalidate();
            lastPoint = e.Location;
        }
        private void RectangleMove(object sender, MouseEventArgs e)
        {
            // First DrawReversible to toggle to the background color
            // Second DrawReversible to toggle to the specified color
            Control drawControl = ((Control)sender);
            ControlPaint.DrawReversibleFrame(drawControl.RectangleToScreen(SelectRect), Color.Black, FrameStyle.Dashed);
            SelectRect.Width = e.X - SelectRect.X;
            SelectRect.Height = e.Y - SelectRect.Y;
            ControlPaint.DrawReversibleFrame(drawControl.RectangleToScreen(SelectRect), Color.Black, FrameStyle.Dashed);

            OnRectangleUpdated?.Invoke(this, SelectRect);
        }
        private void LineMove(object sender, MouseEventArgs e)
        {
            // First DrawReversible to toggle to the background color
            // Second DrawReversible to toggle to the specified color
            Control drawControl = ((Control)sender);
            ControlPaint.DrawReversibleLine(drawControl.PointToScreen(pointStart), drawControl.PointToScreen(pointEnd), Color.Black);
            pointEnd = new Point(e.X, e.Y);
            ControlPaint.DrawReversibleLine(drawControl.PointToScreen(pointStart), drawControl.PointToScreen(pointEnd), Color.Black);

        }
        private void LineMouseUp(object sender)
        {
            Pen p = new Pen(Color.Blue, 2);
            PictureBox picBox = sender as PictureBox;
            if (picBox.Image == null)
            {
                Bitmap bmp = new Bitmap(picBox.Width, picBox.Height);
                picBox.Image = bmp;
            }

            ControlPaint.DrawReversibleLine(picBox.PointToScreen(pointStart), picBox.PointToScreen(pointEnd), Color.Black);
            using (Graphics g = Graphics.FromImage(picBox.Image))
                g.DrawLine(p, pointStart, pointEnd);

            picBox.Invalidate();
        }
        private void RectangleMouseUp(object sender)
        {
            Pen p = new Pen(Color.DeepPink, 2);
            PictureBox picBox = sender as PictureBox;
            if (picBox.Image == null)
            {
                Bitmap bmp = new Bitmap(picBox.Width, picBox.Height);
                picBox.Image = bmp;
            }


            ControlPaint.DrawReversibleFrame(picBox.RectangleToScreen(SelectRect), Color.Black, FrameStyle.Dashed);
            using (Graphics g = Graphics.FromImage(picBox.Image))
                g.DrawRectangle(p, SelectRect);

            picBox.Invalidate();
        }
    }
}
