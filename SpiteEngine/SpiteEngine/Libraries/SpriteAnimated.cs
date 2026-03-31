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
        Bitmap[]? frames;
        int currentFrame = 0;
        int[] xs = [0];
        int[] ys = [0];
        int animationIndex = 0;
        bool animating = false;

        public override void Start()
        {
            frames = new Bitmap[framesX * framesY];
            System.Diagnostics.Debug.WriteLine("frames:" + frames.Length);
            for (int y = 0; y < framesY; y++)
            {
                for (int x = 0; x < framesX; x++)
                {
                    Rectangle rectangel = new(x * (image_.Width / framesX), y * (image_.Height / framesY), image_.Width / framesX, image.Height / framesY);
                    Bitmap crop = new(rectangel.Width, rectangel.Height);
                    using (Graphics g = Graphics.FromImage(crop))
                    {
                        g.DrawImage(image_, new Rectangle(0, 0, crop.Width, crop.Height), rectangel, GraphicsUnit.Pixel);
                    }
                    frames[(y * framesX) + x] = crop;
                    System.Diagnostics.Debug.WriteLine((y * framesX) + x);
                }
            }
            pBox = new()
            {
                Image = frames[0],
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
            if (!animating) return;
            animationIndex = (animationIndex + 1) % xs.Length;
            try
            {
                pBox.Image = frames[(ys[animationIndex] * framesX) + xs[animationIndex]];
            }
            catch { }
        }
        public void Animate(int speed, int[] iX, int[] iY)
        {
            xs = iX;
            ys = iY;
            animationIndex = 0;
            t.Interval = speed;
            animating = true;
        }
        public void NextFrame()
        {
            currentFrame = (currentFrame + 1) % frames.Length;
            System.Diagnostics.Debug.WriteLine("we on frame: " + currentFrame);
            pBox.Image = frames[currentFrame];
        }
        public void PauseAnimation()
        {
            animating = false;
        }
        public override void OnDestroy()
        {
            pBox?.Dispose();
            t?.Dispose();
        }
    }
}