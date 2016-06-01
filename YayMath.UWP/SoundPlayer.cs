using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(YayMath.UWP.SoundPlayer))]

namespace YayMath.UWP
{
    public class SoundPlayer : ISoundPlayer
    {
        MediaElement booSound;
        MediaElement yaySound;

        public SoundPlayer ()
        {
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync (CoreDispatcherPriority.Normal, () =>
            {
                booSound = new MediaElement { Source = new Uri ("ms-appx:///Assets/Boo.m4a") };
                yaySound = new MediaElement { Source = new Uri ("ms-appx:///Assets/Yay.m4a") };
            }).AsTask ();
        }

        public void PlayBoo ()
        {
            booSound?.Play ();
        }

        public void PlayYay ()
        {
            yaySound?.Play ();
        }
    }
}

