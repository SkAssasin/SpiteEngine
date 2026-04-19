using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiteEngine.Libraries;
using SpiteEngine.Properties;


namespace SpiteEngine
{
    internal class SampleSceneVTwo : Scene
    {
        public override void Setup()
        {
            Add(new("sprite^2", new(25, 25), new(100, 100), new Sprite(Resources.Enemy)));
            Add(new("sprite^2", new(125, 125), new(100, 100), new SpriteAnimated(Resources.PACMAN, 2, 2)));
            Add(new("sprite^2", new(225, 225), new(100, 100), new AudioPlayer("file path", 1, true)));
        }
    }
}
