using SpiteEngine.Libraries;
using SpiteEngine.Properties;
using NAudio.Wave;


namespace SpiteEngine
{
    internal class SceneLoseScreen : Scene
    {
        public override void Setup()
        {
            windowColor = ColorTranslator.FromHtml("#051f39");
            windowSize = new Size(550, 450);

            Add(new("Enemy", new(39, 175), new(472, 80), new Sprite(Resources.TextYouLose)));
        }
    }
}
