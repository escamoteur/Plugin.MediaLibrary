namespace Plugin.MediaLibrary.Abstractions
{
    public interface ITrack
    {
        string Title { get; set; }
        string ContentUrl { get; set; }
        int AlbumTrackNumber { get; set; }
        int Duration { get; set; }
    }
}