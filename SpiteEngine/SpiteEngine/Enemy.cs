using SpiteEngine.Properties;
using SpiteEngine.Libraries;
using System.Diagnostics;
using SpiteEngine;

namespace SpiteEngine
{
    internal class Enemy : Script
    {
        int speed = 2;

        public override void Start()
        {
            SpriteAnimated? a = object_.GetComponent<SpriteAnimated>() as SpriteAnimated;
            if (a != null) a.Animate(300, [0, 1], [1, 1]);
        }

        public override void Update()
        {
            object_.position = new(object_.position.X, object_.position.Y + speed);
            if (object_.position.Y >= 500)
                game.ChangeScene(new SceneLoseScreen());
        }
    }
}
