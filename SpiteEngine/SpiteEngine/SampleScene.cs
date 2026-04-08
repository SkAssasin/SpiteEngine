using SpiteEngine.Libraries;
using SpiteEngine.Properties;


namespace SpiteEngine
{
    internal class SampleScene : Scene
    {
        public override void Setup()
        {
            //Add(new("LilTestFella", new(100, 158), new(100, 100), 0, new Sprite(Resources.Player), new TestComponent(10), new AudioPlayer("jack shit")));
            Add(new("sprite^2", new(25, 25), new(50, 50), new Sprite(Resources.WoodenBox))/*, new Sprite(Resources.Player)*/);
            Add(new("PAC-MAN", new Point(150, 225), new Size(100, 100), new SpriteAnimated(Resources.PACMAN, 2, 2), new TestComponent(10), new AudioPlayer(@"C:\Users\Assasin\Documents\GitHub\SpiteEngine\SpiteEngine\SpiteEngine\Libraries\OHMYGODITSDANIELFUCIK.wav", 1, false)));

            //Add(new("negate", new(100, 100), new(50, 50), 0, new Sprite(Properties.Resources.WoodenBox), new TestComponent(-10)));
            //Add(new("Sprite Test", new(100, 100), new(100, 100), 0, new Sprite(Image.FromFile("Images/Player.png"))));
        }
    }
}
