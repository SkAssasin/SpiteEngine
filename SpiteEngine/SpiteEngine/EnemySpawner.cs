using SpiteEngine.Properties;
using SpiteEngine.Libraries;
using System.Diagnostics;
using SpiteEngine;

namespace SpiteEngine
{
    internal class EnemySpawner(int[] spawnPoss_, int spawnInterval_) : Script
    {
        int[] spawnPoss = spawnPoss_;
        int spawnInterval = spawnInterval_;
        System.Windows.Forms.Timer t = null;
        int enemyTag = 0;

        public override void Start()
        {
            t = new();
            t.Interval = spawnInterval;
            t.Tick += SpawnEnemeny;
            t.Enabled = true;
        }

        private void SpawnEnemeny(object sender, EventArgs e)
        {
            Random r = new Random();
            game.CreateObject(new("Enemy" + enemyTag, new(spawnPoss[r.Next(0, spawnPoss.Length)], 25), new(50, 50), new SpriteAnimated(Resources.SpriteSheet, 3, 3, "enemeny"), new Enemy()));
            enemyTag++;
        }

        public override void OnDestroy()
        {
            t?.Dispose();
        }
    }
}
