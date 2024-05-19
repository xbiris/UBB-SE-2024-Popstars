using System.Collections.Generic;
using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;

namespace ISS_Wildcats.Backend.Service
{
	public class SongRepoService : ISongRepoService
	{
		private readonly ISongRepo songRepo;

		public SongRepoService(ISongRepo songRepo)
		{
			this.songRepo = songRepo;
		}

		public void AddSong(Song song)
		{
			songRepo.AddSong(song);
		}

		public Song GetSongById(int songId)
		{
			return songRepo.GetSongById(songId);
		}

		public Song GetSongByTitle(string title)
		{
			return songRepo.GetSongByTitle(title);
		}

		public Song GetSongByUrl(string songUrl)
		{
			return songRepo.GetSongByUrl(songUrl);
		}

		public void DeleteSong(Song song)
		{
			songRepo.DeleteSong(song);
		}

		public List<Song> GetSongsByCreator(int creatorId)
		{
			return songRepo.GetSongsByCreator(creatorId);
		}

		public List<Song> GetSongsFromAlbum(int albumId)
		{
			return songRepo.GetSongsFromAlbum(albumId);
		}
	}
}
