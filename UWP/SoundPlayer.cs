using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
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
            LoadStream ("Boo.m4a").ContinueWith (task => booSound = task.Result);
            LoadStream ("Yay.m4a").ContinueWith (task => yaySound = task.Result);
        }

        private async Task<MediaElement> LoadStream (string name)
        {
            var assets = await Package.Current.InstalledLocation.GetFolderAsync ("Assets");
            var file = await assets.GetFileAsync (name);
            var stream = await file.OpenReadAsync ();

            MediaElement sound = null;
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync (CoreDispatcherPriority.Normal, () =>
            {
                sound = new MediaElement ();
                sound.AutoPlay = false;
                sound.SetSource (stream, file.ContentType);
            });
            return sound;
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

