using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace TuxLife
{
    class Music
    {
        private static MediaElement PlayMusic = new MediaElement();
        private static bool flag = false;
        public void Stop()
        {
            PlayMusic.Stop();
        }
        public async static         Task
playMusic()
        {
            if (!flag)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Assets");
                StorageFile sf = await Folder.GetFileAsync("bajo_el_mar.mp3");
                PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
                PlayMusic.Play();
                PlayMusic.IsLooping = true;
                flag = true;
            }
        }
    }
}
