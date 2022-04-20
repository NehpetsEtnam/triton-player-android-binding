﻿using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using AWidget = Android.Widget;
using Com.Tritondigital.Player;
using Android.Media;

namespace TritonAndroidSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TritonPlayer player = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            
            AWidget.Button startButton = FindViewById<AWidget.Button>(Resource.Id.StartButton);
            AWidget.Button pauseButton = FindViewById<AWidget.Button>(Resource.Id.PauseButton);
            AWidget.Button stopButton = FindViewById<AWidget.Button>(Resource.Id.StopButton);
            startButton.Click += StartButton_Click;
            pauseButton.Click += PauseButton_Click;
            stopButton.Click += StopButton_Click;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            player?.Stop();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            player?.Pause();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (player == null)
            {
                Bundle settings = new Bundle();
                //settings.PutString(TritonPlayer.SettingsStreamUrl, "http://storage.googleapis.com/automotive-media/Jazz_In_Paris.mp3");
                settings.PutString(TritonPlayer.SettingsStationBroadcaster, "Triton Digital");
                settings.PutString(TritonPlayer.SettingsStationName, "MOBILEFM");
                settings.PutString(TritonPlayer.SettingsStationMount, "MOBILEFM_AACV2");
                settings.PutString(TritonPlayer.SettingsPlayerServicesRegion, "AP");

                player = new TritonPlayer(this, settings);
            }

            player?.Play();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}