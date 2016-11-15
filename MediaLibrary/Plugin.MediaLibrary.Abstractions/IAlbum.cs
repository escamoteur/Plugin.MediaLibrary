using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Plugin.MediaLibrary.Abstractions
{
    public interface IAlbum
    {
        string Title { get; set; }
        string Artist { get; set; }
        int TrackCount { get; set; }

        Stream GetCoverImageAsStream(int width, int height);
        IEnumerable<ITrack> GetTracks();
    }
}