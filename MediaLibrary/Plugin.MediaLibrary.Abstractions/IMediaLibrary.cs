using System;
using System.Collections;
using System.Collections.Generic;

namespace Plugin.MediaLibrary.Abstractions
{
  /// <summary>
  /// Interface for MediaLibrary
  /// </summary>
  public interface IMediaLibrary
  {
      IEnumerable<Album> GetAllAlbums();
  }
}
