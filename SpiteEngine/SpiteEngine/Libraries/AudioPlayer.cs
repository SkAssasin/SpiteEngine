using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SpiteEngine.Libraries
{
    public class AudioPlayer(string audioFilePath) : Script
    {
        private WaveOutEvent outputDevice = new WaveOutEvent();
        private AudioFileReader audioFile = new AudioFileReader(audioFilePath);
        private bool closing = false;

        public override void Start()
        {
            if(audioFile == null) audioFile = new AudioFileReader(@"C:\Users\simon\Documents\VS Projects\VS\SpiteEngine\SpiteEngine\SpiteEngine\Libraries\OHMYGODITSDANIELFUCIK.wav");

            outputDevice.PlaybackStopped += (s, a) => { if (closing) { outputDevice.Dispose(); audioFile.Dispose(); } };
            outputDevice.Init(audioFile);
            game.FormClosing += (s, a) => { closing = true; outputDevice.Stop(); };
        }
        public void Play()
        {
            audioFile.Position = 0;
            if(outputDevice.PlaybackState != PlaybackState.Playing)
                outputDevice.Play();
        }
        public void Stop() 
        {
            outputDevice?.Stop();
        }
    }
}
