using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpiteEngine.Libraries;
using SpiteEngine;

namespace SpiteEngine
{
    public class TestComponent(int speed_) : Script
    {
        private readonly int speed = speed_;

        public override void Start()
        {

        }
        public override void Update()
        {
            int x = Input.GetAxis("Horizontal");
            int y = Input.GetAxis("Vertical");
            System.Diagnostics.Debug.WriteLine("x: " + object_.position.X + "; y: " + object_.position.Y);
            Move(x, y);

            if (Input.GetButtonDown("Jump"))
                DoBullshit();
        }

        void Move(int x, int y)
        {
            object_.position = new Point(object_.position.X + x * speed, object_.position.Y - y * speed);
            //pic.Left += (int)x * speed;
            //pic.Top += (int)y * speed;
        }

        public void DoBullshit()
        {
            //object_.components.Find(c => c.GetType() == new AudioPlayer().GetType()).Play();
            game.ChangeScene(new SampleSceneVTwo()); 
        }
    }
}
