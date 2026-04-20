using SpiteEngine.Properties;
using SpiteEngine.Libraries;
using System.Diagnostics;
using SpiteEngine;

namespace SpiteEngine
{
    internal class Projectile(int speed_) : Script
    {
        int speed = speed_;
        bool kaboom = false;
        SpriteAnimated? a;

        public override void Start()
        {
            a = object_.GetComponent<SpriteAnimated>() as SpriteAnimated;
            if (a != null) a.SetFrame(2, 0);
            if (a != null) a.Animate(300, [3, 3], [0, 0]);
        }
        public override void Update()
        {
            if (kaboom) return;

            object_.position = new(object_.position.X, object_.position.Y - speed);
            foreach (Control c in game.Controls)
                if (c is PictureBox pb && pb != a.pBox && a.pBox.Bounds.IntersectsWith(pb.Bounds) && pb.Tag == "enemeny")
                {
                    Debug.WriteLine("Name: {0}; Tag: {1}", pb.Name, pb.Tag);
                    game.Nuke(game.currentSceneObjs.Find(t => t.name == pb.Name));
                    game.Nuke(object_);
                    kaboom = true;
                }
        }
    }
}
