using SpiteEngine.Libraries;
using SpiteEngine.Properties;


namespace SpiteEngine
{
    internal class SampleScene : Scene
    {
        public override void Setup()
        {
            Add(new("sprite^2", new(25, 25), new(50, 50), new Sprite(Resources.WoodenBox)));
            Add(new("PAC-MAN", new Point(150, 225), new Size(100, 100), new SpriteAnimated(Resources.PACMAN, 2, 2), new TestComponent(10), new AudioPlayer("test", 1, true)));
            Add(new("Sprite Test", new(100, 100), new(100, 100), new Sprite(Resources.Player)));
        }
    }
}