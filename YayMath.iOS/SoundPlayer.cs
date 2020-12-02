using System;
using AVFoundation;
using Foundation;

[assembly: Xamarin.Forms.Dependency (typeof (YayMath.iOS.SoundPlayer))]

namespace YayMath.iOS
{
    public class SoundPlayer : ISoundPlayer
    {
        AVPlayer player;
        AVPlayerItem booItem;
        AVPlayerItem yayItem;

        public SoundPlayer ()
        {
            player = new AVPlayer ();
            booItem = new AVPlayerItem (NSUrl.FromFilename ("Boo.m4a"));
            yayItem = new AVPlayerItem (NSUrl.FromFilename ("Yay.m4a"));
            player.ReplaceCurrentItemWithPlayerItem (yayItem);
        }

        public void PlayBoo ()
        {
            player.ReplaceCurrentItemWithPlayerItem (booItem);
            player.Seek ( new CoreMedia.CMTime ( 0, player.CurrentItem.Asset.Duration.TimeScale));
            player.Play ();
        }

        public void PlayYay ()
        {
            player.ReplaceCurrentItemWithPlayerItem (yayItem);
            player.Seek (new CoreMedia.CMTime (0, player.CurrentItem.Asset.Duration.TimeScale));
            player.Play ();
        }
    }
}

