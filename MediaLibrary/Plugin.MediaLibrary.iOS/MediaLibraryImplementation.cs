using Plugin.MediaLibrary.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CloudKit;
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
      private bool PermissionGranted = false;

      public MediaLibraryImplementation()
      {
          PermissionGranted = RequestPermission();
      }

      private static bool RequestPermission()
      {
          bool granted = false;

          var permissionStatus = MPMediaLibrary.AuthorizationStatus;
          switch (permissionStatus)
          {
              case MPMediaLibraryAuthorizationStatus.NotDetermined:
                  MPMediaLibrary.RequestAuthorization(status =>
                  {
                      granted = status == MPMediaLibraryAuthorizationStatus.Authorized;
                  } );
                  return granted;
                  break;
              case MPMediaLibraryAuthorizationStatus.Denied:
                  return false;
                  break;
              case MPMediaLibraryAuthorizationStatus.Restricted:
                  return false;
                  break;
              case MPMediaLibraryAuthorizationStatus.Authorized:
                  return true;
                  break;
              default:
                  throw new ArgumentOutOfRangeException();
          }
      }


      public IEnumerable<IAlbum> GetAllAlbums()
      {
          if (PermissionGranted)
          {
                MPMediaQuery mq = MPMediaQuery.AlbumsQuery;


                foreach (var mediaItem in mq.Items)
                {
                    if (mediaItem.AlbumTitle != null)
                    {
                        Debug.WriteLine(mediaItem.AlbumTitle);
                    }
                    if (mediaItem.PersistentID != null)
                    {
                        Debug.WriteLine(mediaItem.PersistentID);
                    }

                    if (mediaItem.AlbumPersistentID != null)
                    {
                        Debug.WriteLine(mediaItem.AlbumPersistentID);
                    }


                    if (mediaItem.Title != null)
                    {
                        Debug.WriteLine(mediaItem.Title);
                    }
                    Debug.WriteLine(mediaItem.AssetURL);
                    Debug.WriteLine(mediaItem.MediaType.ToString());
                }


                return
                    mq.Items.Select(
                        mediaItem => new Album(mediaItem.AlbumPersistentID,mediaItem.Artwork)
                        {
                                
                            Title = mediaItem.AlbumTitle,
                            Artist = mediaItem.Artist,
                            TrackCount = mediaItem.AlbumTrackCount,
                        });

            }
            return null;
      }

  }
}