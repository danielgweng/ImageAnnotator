using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageAnnotator
{
    public partial class FormImageAnnotator : Form
    {
        DataSetAzureTableAdapters.RegionsTableAdapter regionsTableAdapter = new DataSetAzureTableAdapters.RegionsTableAdapter();
        DataSetAzureTableAdapters.ImagesTableAdapter imagesTableAdapter = new DataSetAzureTableAdapters.ImagesTableAdapter();

        private List<Region> Regions = new List<Region>();

        // The ellipses to draw.
        private List<Rectangle> Ellipses = new List<Rectangle>();

        // The points for the new ellipse we are drawing.
        private Point StartPoint, EndPoint;

        private bool DrawingNew = false;
        private bool CircleMode = false;
        private bool RectangleMode = false;
        private int regionCount = 0;
        private Image chartImage;
        private ImageAnnotation chartImageAnnotation;

        public FormImageAnnotator()
        {
            InitializeComponent();
        }

        private void FormImageAnnotator_Load(object sender, EventArgs e)
        {
            CircleMode = true;
            RectangleMode = false;
            buttonCircle.BackColor = Color.LightYellow;
        }

        private void chartAnnotate_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string fileName = files[0];
            if (fileName.ToLower().Contains(".jpg") || files[0].ToLower().Contains(".png"))
            {
                Image img = Bitmap.FromFile(fileName);
                chartImage = img;
                img = ResizeImage(img, chartAnnotate.Width, chartAnnotate.Height);
                if(chartAnnotate.Images.Count>0)
                {
                    chartAnnotate.Images[0]=new NamedImage("Image", img);
                }
                else
                {
                    chartAnnotate.Images.Add(new NamedImage("Image", img));
                }
                chartImageAnnotation = new ImageAnnotation();
                chartImageAnnotation.Image = "Image";
                chartImageAnnotation.Name = "Image";
                chartImageAnnotation.X = 0;
                chartImageAnnotation.Y = 0;
                if(chartAnnotate.Annotations.Count>0)
                {
                    chartAnnotate.Annotations[0] = chartImageAnnotation;
                }
                else
                {
                    chartAnnotate.Annotations.Add(chartImageAnnotation);
                }
            }
            else
            {
                MessageBox.Show("Picture format must be .jpg or .png");
            }
        }

        private void chartAnnotate_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        // Start selecting an ellipse.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(chartImageAnnotation==null)
            {
                MessageBox.Show("You must first select an image before you can draw regions.");
                return;
            }
            DrawingNew = true;
            StartPoint = e.Location;
            EndPoint = e.Location;
        }

        // Continue drawing the new ellipse.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DrawingNew) return;
            EndPoint = e.Location;
        }

        // Finish drawing the new ellipse.
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!DrawingNew) return;
            DrawingNew = false;

            string shape = "";

            // If the start and end points are different,
            // save the new ellipse.
            if (StartPoint.X != EndPoint.X &&
                StartPoint.Y != EndPoint.Y)
            {
                Rectangle rect = new Rectangle(
                    Math.Min(StartPoint.X, EndPoint.X),
                    Math.Min(StartPoint.Y, EndPoint.Y),
                    Math.Abs(StartPoint.X - EndPoint.X),
                    Math.Abs(StartPoint.Y - EndPoint.Y));
                Image img = new Bitmap(chartAnnotate.Width,chartAnnotate.Height);
                using (Graphics g = Graphics.FromImage(img))
                {
                    if (CircleMode)
                    {
                        g.DrawEllipse(Pens.Red, rect);
                        shape = "Ellipse";
                    }
                    else if (RectangleMode)
                    {
                        g.DrawRectangle(Pens.Red, rect);
                        shape = "Rectangle";
                    }
                    g.DrawString("Label" + regionCount, new Font("Arial",10), Brushes.Red, rect.X, rect.Y + rect.Height);
                }
                    

                chartAnnotate.Images.Add(new NamedImage("Label" + regionCount, img));
                ImageAnnotation ia = new ImageAnnotation();
                ia.Image = "Label" + regionCount;
                ia.Name = ia.Image;
                ia.ToolTip = ia.Name;
                ia.X = 0;
                ia.Y = 0;
                chartAnnotate.Annotations.Add(ia);
                regionCount++;
                Regions.Add(new Region(ia.Name, shape, rect.X, rect.Y, rect.Width, rect.Height));
            }
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            CircleMode = true;
            RectangleMode = false;
            buttonCircle.BackColor = Color.LightYellow;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            CircleMode = false;
            RectangleMode = true;
            buttonRectangle.BackColor = Color.LightYellow;
        }

        private void buttonSaveCloud_Click(object sender, EventArgs e)
        {
            int? imageIDnullable = -1;
            int imageID = -1;
            if(chartImage!=null)
            {
                using (var ms = new MemoryStream())
                {
                    chartImage.Save(ms, chartImage.RawFormat);
                    try
                    {
                        imagesTableAdapter.InsertGetIndex(ms.ToArray(), ref imageIDnullable);
                        imageID = Convert.ToInt32(imageIDnullable);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Uploading image to cloud failed. Please contact engineer for support." + Environment.NewLine + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("No image selected!");
                return;
            }

            try
            {
                foreach (Region region in Regions)
                {
                    regionsTableAdapter.Insert(imageID, region.Name, region.Shape, region.X, region.Y, region.Width, region.Height);
                }
                MessageBox.Show("Successfully uploaded your annotated image to the cloud!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uploading regions to cloud failed. Please contact engineer for support." + Environment.NewLine + ex.Message);
                return;
            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

    class Region
    {

        public string Name { get; set; }
        public string Shape { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Region()
        {
        }

        public Region(string name, string shape, int x, int y, int width, int height)
        {
            this.Name = name;
            this.Shape = shape;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
