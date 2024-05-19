using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;

namespace ISS_Wildcats.Backend.Repos
{
    public interface ISongRepo
    {
        void AddSong(Song song);
        void DeleteSong(Song song);
        List<Song> GetSongsByCreator(int creatorId);
        Song GetSongById(int songId);
        Song GetSongByTitle(string title);
        Song GetSongByUrl(string songUrl);
        List<Song> GetSongsFromAlbum(int albumId);
    }
}
