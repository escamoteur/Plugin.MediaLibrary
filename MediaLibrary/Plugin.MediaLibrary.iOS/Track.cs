namespace Plugin.MediaLibrary.Abstractions
{
    class Track : ITrack
    {
        public string Title { get; set; }
        public string ContentUrl { get; set; }
        public int AlbumTrackNumber { get; set; }
        public int Duration { get; set; }
    }
}