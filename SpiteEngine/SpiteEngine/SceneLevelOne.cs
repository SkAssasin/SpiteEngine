using SpiteEngine.Libraries;
using SpiteEngine.Properties;
using NAudio.Wave;


namespace SpiteEngine
{
    internal class SceneLevelOne : Scene
    {
        string vfxPath = "C:\\Users\\Assasin\\Documents\\GitHub\\SpiteEngine\\SpiteEngine\\SpiteEngine\\Sounds\\";

        public override void Setup()
        {
            windowColor = ColorTranslator.FromHtml("#051f39");
            windowSize = new Size(300, 600);

            Add(new("Player", new(125, 475), new(50, 50), new SpriteAnimated(Resources.SpriteSheet, 3, 3), new AudioPlayer(vfxPath+"laserShoot.wav", 1, false), new Player([25, 125, 225])));
            Add(new("EnemySpawner", new(0, 0), new(1, 1), new EnemySpawner([25, 125, 225], 1500)));
        }
    }
}