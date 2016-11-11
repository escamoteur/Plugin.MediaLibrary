using Plugin.MediaLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MediaPlayer;
using Plugin.MediaLibrary.Abstractions;


namespace Plugin.MediaLibrary
{
  /// <summary>
  /// Implementation for MediaLibrary
  /// </summary>
  public class MediaLibraryImplementation : IMediaLibrary
  {
      public IEnumerable<Album> GetAllAlbums()
      {
            MPMediaQuery mq = new MPMediaQuery();
            var value = NSObject.FromObject(MPMediaType.Music);
            var type = MPMediaItem.MediaTypeProperty;
            var predicate = MPMediaPropertyPredicate.PredicateWithValue(value, type);
            mq.AddFilterPredicate(predicate);
          return mq.Items.Select(mediaItem => { return new Album() {Name = mediaItem.AlbumTitle} ; }); 
      }

  }
}