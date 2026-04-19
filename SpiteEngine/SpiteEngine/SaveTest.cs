using SpiteEngine.Libraries;
using SpiteEngine.Properties;


namespace SpiteEngine
{
	internal class SaveTest : Scene
	{
		public override void Setup()
		{
			Add(new("sprite^2", new(25, 25), new(50, 50), new SpiteEngine.Libraries.Sprite(Resources.Player)));
			Add(new("PAC-MAN", new(150, 225), new(100, 100), new SpiteEngine.Libraries.SpriteAnimated(Resources.Player, 999, 999), new SpiteEngine.TestComponent(999), new SpiteEngine.Libraries.AudioPlayer("text ig?", 999, true)));
			Add(new("Sprite Test", new(100, 100), new(100, 100), new SpiteEngine.Libraries.Sprite(Resources.Player)));
		}
	}
}
