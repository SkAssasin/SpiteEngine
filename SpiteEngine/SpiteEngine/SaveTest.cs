using SpiteEngine.Libraries;
using SpiteEngine.Properties;


namespace SpiteEngine
{
	internal class SaveTest : Scene
	{
		public override void Setup()
		{
			Add(new("sprite^2", new(25, 25), new(50, 50), new SpiteEngine.Libraries.Sprite()));
			Add(new("PAC-MAN", new(150, 225), new(100, 100), new SpiteEngine.Libraries.SpriteAnimated(), new SpiteEngine.TestComponent(), new SpiteEngine.Libraries.AudioPlayer()));
		}
	}
}
