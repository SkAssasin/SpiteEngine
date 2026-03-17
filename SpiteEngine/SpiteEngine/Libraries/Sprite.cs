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
    public class Sprite(Image image_) : Script
    {
        private PictureBox? pBox = null; 
        public Image image = image_;
        Bitmap bp = new (image_);

        public override void Start()
        {
            pBox = new()
            {
                Image = image,
                Name = object_.name,
                Location = new Point(object_.position.X, object_.position.Y),
                Size = new Size(object_.scale.Width, object_.scale.Height),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            game.Controls.Add(pBox);
        }
        public override void Update()
        {
            if (pBox == null) return;
            pBox.Location = new Point(object_.position.X, object_.position.Y);
            pBox.Size = new Size(object_.scale.Width, object_.scale.Height);
        }
        public override void OnDestroy()
        {
            pBox?.Dispose();
        }
    }
}
