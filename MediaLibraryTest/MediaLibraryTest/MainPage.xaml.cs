using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.MediaLibrary;
using Plugin.MediaManager;

using Xamarin.Forms;



namespace MediaLibraryTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var albums = Plugin.MediaLibrary.CrossMediaLibrary.Current.GetAllAlbums();
            if (albums != null)
            {
                if (albums.Count() != 0)
                {
                    var album = albums.First();
                    var tracks = album.GetTracks();
                    var firstTrack = tracks.FirstOrDefault();
                    if (firstTrack != null)
                    {
                        await CrossMediaManager.Current.Play(firstTrack.ContentUrl);
                    }

                }
            }
        }
    }
}
