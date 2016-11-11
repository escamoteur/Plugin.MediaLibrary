using Plugin.MediaLibrary.Abstractions;
using System;
using System.Collections.Generic;


namespace Plugin.MediaLibrary
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class MediaLibraryImplementation : IMediaLibrary
  {
      public IEnumerable<Album> GetAllAlbums()
      {
          throw new NotImplementedException();
      }
  }
}