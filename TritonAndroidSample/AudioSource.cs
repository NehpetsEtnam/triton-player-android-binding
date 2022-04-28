using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Com.Tritondigital.Player;

namespace TritonAndroidSample
{
    [Service]
    public class AudioSource : Service, AudioManager.IOnAudioFocusChangeListener
    {
        Bundle settings = null;
        TritonPlayer tritonPlayer = null;

        public AudioSource()
        {
            settings = new Bundle();
            //settings.PutString(TritonPlayer.SettingsStationBroadcaster, "Triton Digital");
            //settings.PutString(TritonPlayer.SettingsStationName, "MOBILEFM");
            //settings.PutString(TritonPlayer.SettingsStationMount, "MOBILEFM_AACV2");

            tritonPlayer = new TritonPlayer(this, settings);
        }

        public void OnAudioFocusChange([GeneratedEnum] AudioFocus focusChange)
        {
            
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        internal void Play()
        {
            tritonPlayer?.Play();
        }

        internal void Pause()
        {
            tritonPlayer?.Pause();
        }

        internal void Stop()
        {
            tritonPlayer?.Stop();
        }
    }
}
