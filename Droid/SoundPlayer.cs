using System;
using Android.Media;

[assembly: Xamarin.Forms.Dependency (typeof (YayMath.Droid.SoundPlayer))]

namespace YayMath.Droid
{
    public class SoundPlayer : ISoundPlayer
    {
        MediaPlayer mediaPlayer;

        public SoundPlayer ()
        {
            mediaPlayer = MediaPlayer.Create (Xamarin.Forms.Forms.Context, Resource.Raw.Yay);
        }

        public void PlayBoo ()
        {
            mediaPlayer.Reset ();

            mediaPlayer.SetDataSource (
                Xamarin.Forms.Forms.Context, 
                Android.Net.Uri.Parse (
                    string .Format(
                        "android.resource://{0}/{1}", 
                        Xamarin.Forms.Forms.Context.PackageName, 
                        Resource.Raw.Boo)));
            
            mediaPlayer.Prepare ();
            mediaPlayer.Start ();
        }

        public void PlayYay ()
        {
            mediaPlayer.Reset ();

            mediaPlayer.SetDataSource (
                Xamarin.Forms.Forms.Context,
                Android.Net.Uri.Parse (
                    string.Format (
                        "android.resource://{0}/{1}", 
                        Xamarin.Forms.Forms.Context.PackageName, 
                        Resource.Raw.Yay)));

            mediaPlayer.Prepare ();
            mediaPlayer.Start ();
        }
    }
}

