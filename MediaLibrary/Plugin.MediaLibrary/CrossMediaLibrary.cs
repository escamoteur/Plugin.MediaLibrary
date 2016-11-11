using Plugin.MediaLibrary.Abstractions;
using System;

namespace Plugin.MediaLibrary
{
  /// <summary>
  /// Cross platform MediaLibrary implemenations
  /// </summary>
  public class CrossMediaLibrary
  {
    static Lazy<IMediaLibrary> Implementation = new Lazy<IMediaLibrary>(() => CreateMediaLibrary(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IMediaLibrary Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IMediaLibrary CreateMediaLibrary()
    {
#if PORTABLE
        return null;
#else
        return new MediaLibraryImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
