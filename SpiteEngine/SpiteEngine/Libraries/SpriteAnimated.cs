using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SpiteEngine.Libraries
{
    public class SpriteAnimated(Image image_, int framesX, int framesY) : Script
    {
        private PictureBox? pBox = null;
        private System.Windows.Forms.Timer? t = null;
        public Image image = image_;
        int[] xs = [0];
        int[] ys = [0];
        int i = 0;

        public override void Start()
        {
            Rectangle rectangel = new(0, 0, image_.Width / framesX, image.Height / framesY);
            Bitmap crop = new(rectangel.Width, rectangel.Height);
            using (Graphics g = Graphics.FromImage(crop))
            {
                g.DrawImage(image_, new Rectangle(0, 0, crop.Width, crop.Height), rectangel, GraphicsUnit.Pixel);
            }
            pBox = new()
            {
                Image = crop,
                Name = object_.name,
                Location = new Point(object_.position.X, object_.position.Y),
                Size = new Size(object_.scale.Width, object_.scale.Height),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            game.Controls.Add(pBox);
            
            t = new();
            t.Enabled = true;
            t.Interval = 250;
            t.Tick += NewFrame;
        }
        public override void Update()
        {
            if (pBox == null) return;
            pBox.Location = new Point(object_.position.X, object_.position.Y);
            pBox.Size = new Size(object_.scale.Width, object_.scale.Height);
        }
        private void NewFrame(object sender, EventArgs e)
        {
            i = (i + 1) % xs.Length;
            Rectangle rectangel = new(xs[i] * (image_.Width / framesX), ys[i] * (image_.Height / framesY), image_.Width / framesX, image.Height / framesY);
            Bitmap crop = new(rectangel.Width, rectangel.Height);
            using (Graphics g = Graphics.FromImage(crop))
            {
                g.DrawImage(image_, new Rectangle(0, 0, crop.Width, crop.Height), rectangel, GraphicsUnit.Pixel);
            }
            pBox.Image = crop;
        }
        public void Animate(int speed, int[] iX, int[] iY)
        {
            xs = iX;
            ys = iY;
            i = 0;
            t.Interval = speed;
        }
        public override void OnDestroy()
        {
            pBox?.Dispose();
            t?.Dispose();
        }
    }
}