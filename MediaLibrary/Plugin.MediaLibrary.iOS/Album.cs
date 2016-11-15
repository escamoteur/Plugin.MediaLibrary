using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CoreGraphics;
using Foundation;
using MediaPlayer;

namespace Plugin.MediaLibrary.Abstractions
{
    public class Album : IAlbum
    {
        private UInt64 PersistentID { get; set; }
        private MPMediaItemArtwork CoverImage { get; set; }

        public Album(UInt64 persistentID, MPMediaItemArtwork coverImage)
        {
            PersistentID = persistentID;
            CoverImage = coverImage;
        }

    public string Title { get; set; }
        public string Artist { get; set; }
        public string ContentUrl { get; set; }
        public int    TrackCount { get; set; }

        public Stream GetCoverImageAsStream(int width, int height)
        {
            if (CoverImage != null)
            {
                return CoverImage.ImageWithSize(new CGSize(width, height)).AsJPEG().AsStream();
            }
            return null;
        }

        public IEnumerable<ITrack> GetTracks()
        {
            MPMediaQuery mq = new MPMediaQuery();
            var value = NSObject.FromObject(PersistentID);
            var type = MPMediaItem.AlbumPersistentIDProperty;
            var predicate = MPMediaPropertyPredicate.PredicateWithValue(value, type);
            mq.AddFilterPredicate(predicate);

            return mq.Items.Select(source => new Track()
            {
                Title = source.Title,
                AlbumTrackNumber = source.AlbumTrackNumber,
                ContentUrl = source.AssetURL.AbsoluteString,
                Duration =  (int) source.PlaybackDuration
            });
        }
    }
}