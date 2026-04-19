using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SpiteEngine.Libraries
{
    public class AudioPlayer : Script
    {
        public string audioPath;
        public int volume;
        public bool loop;

        private WaveOutEvent outputDevice = new WaveOutEvent();
        private AudioFileReader audioFile;
        private bool closing = false;

        public AudioPlayer(string audioFilePath, int volume_, bool loop_)
        {
            audioPath = audioFilePath;
            volume = volume_;
            loop = loop_;
        }

        public override void Start()
        {
            try
            {
                audioFile = new AudioFileReader(audioPath);
            }
            catch
            {
                audioFile = new AudioFileReader(@"C:\Users\simon\Documents\VS Projects\VS\SpiteEngine\SpiteEngine\SpiteEngine\Libraries\OHMYGODITSDANIELFUCIK.wav");
            }
            outputDevice.Volume = volume;
            outputDevice.PlaybackStopped += (s, a) => { if (closing) { outputDevice.Dispose(); audioFile.Dispose(); } if (loop) Play(); };
            outputDevice.Init(audioFile);
            game.FormClosing += (s, a) => { loop = false; closing = true; outputDevice.Stop(); };
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
