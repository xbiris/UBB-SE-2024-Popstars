namespace ISS_Wildcats.Backend.Models;

using Microsoft.Data.SqlClient;
using System;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Length { get; set; }
    public string SongUrl { get; set; }
    public int AlbumId { get; set; }

    public Song(string title, string songUrl, int length, int albumId)
    {
        this.Title = title;
        this.SongUrl = songUrl;
        this.Length = length;
        this.AlbumId = albumId;
    }
}
