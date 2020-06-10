using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintMock
{
    public partial class Form1 : Form
    {
        private readonly ShapeDrawHandler drawHandler;
        public Form1()
        {
            InitializeComponent();

            drawHandler = new ShapeDrawHandler(picBox);

            btnClear.Click += btnClear_Click;
            rdDraw.CheckedChanged += ShapeStyle_CheckedChanged;
            rdLine.CheckedChanged += ShapeStyle_CheckedChanged;
            rdRectangle.CheckedChanged += ShapeStyle_CheckedChanged;

            drawHandler.OnStartPoint += (s, e) => StartPointUpdated(e);
            drawHandler.OnRectangleUpdated += (s, e) => ShapeUpdated(e);
            picBox.MouseMove += Coordinates_MouseMove;
            MouseMove += Coordinates_MouseMove;
        }

        private void Coordinates_MouseMove(object sender, MouseEventArgs e)
            => toolStripStatusLabel1.Text = $"X: {e.X}, Y: {e.Y}";
        private void StartPointUpdated(Point point)
            => toolStripStatusLabel3.Text = $"Start Point: ({point.X},{point.Y})";
        private void ShapeUpdated(Rectangle rect)
            => toolStripStatusLabel2.Text = $"Shape Data: {rect.Width}x{rect.Height}, ({rect.X},{rect.Y})";
        private void ShapeStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdShape = sender as RadioButton;
            if (rdShape == null || !rdShape.Checked) return;

            if (!int.TryParse((string)rdShape.Tag, out int tag)) 
                return;

            ShapeTypeEnum shapeType = (ShapeTypeEnum)tag;
            drawHandler.SetShape(shapeType);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (picBox.Image == null)
                return;

            picBox.Image = null;
            Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "imagenes (*.jpeg)|*.jpeg";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    string imagePath = saveFileDialog1.FileName;
                    picBox.Image.Save(imagePath, ImageFormat.Jpeg);
                    myStream.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        public class NoSabeException : Exception
        {
            public NoSabeException() : base("Pos no sabe") { }
        }
    }
}
