using SpiteEngine.Properties;
using SpiteEngine.Libraries;
using System.Diagnostics;
using SpiteEngine;

namespace SpiteEngine
{
    internal class Player(int[] lanes_) : Script
    {
        int[] lanes = lanes_;
        int lane = 0;

        public override void Start()
        {
            SpriteAnimated? a = object_.GetComponent<SpriteAnimated>() as SpriteAnimated;
            if (a != null) a.Animate(300, [0, 1], [0, 0]);
        }
        public override void Update()
        {
            Move();
            if (Input.GetButtonDown("Shoot"))
                Shoot();
        }

        void Move()
        {
            if (Input.GetButtonDown("Left"))
            {
                if (lane <= 0)
                    return;
                lane--;
                object_.position = new Point(lanes[lane], object_.position.Y);
            }
            else if (Input.GetButtonDown("Right"))
            {
                if (lane >= lanes.Length - 1)
                    return;
                lane++;
                object_.position = new Point(lanes[lane], object_.position.Y);
            }
        }

        public void Shoot()
        {
            AudioPlayer? p = object_.GetComponent<AudioPlayer>() as AudioPlayer;
            if (p != null) p.Play();
            game.CreateObject(new("Projectile", new(object_.position.X + 14, 475), new(40, 40), new SpriteAnimated(Resources.SpriteSheet, 4, 4), new Projectile(5)));
        }
    }
}
