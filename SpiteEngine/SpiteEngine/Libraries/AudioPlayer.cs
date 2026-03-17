using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace SpiteEngine.Libraries
{
    internal class AudioPlayer : Script
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;


        public override void Start()
        {
            
        }
        public void GoPlay()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                //audioFile = new AudioFileReader(@"C:\Users\simon\Documents\VS Projects\VS\SpiteEngine\SpiteEngine\SpiteEngine\Libraries\OHMYGODITSDANIELFUCIK.wav");
                audioFile = new AudioFileReader(@"C:\Libraries\OHMYGODITSDANIELFUCIK.wav");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }
        public void Stop() 
        {
            outputDevice?.Stop();
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
    }
}
