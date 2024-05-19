using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;
using ISS_Wildcats.Backend.Repos;
using ISS_Wildcats.Backend.Service;
using Moq;
using Xunit;

namespace ISS_Wildcats.Backend.UnitTests
{
    public class SongRepoTests
    {
		[Fact]
		public void AddSong_ValidSong_ShouldRetrieveSameSongByTitle()
		{
			// Arrange
			var mockRepo = new Mock<ISongRepo>();
			var song = new Song("Billie Jean", "http://example.com/song5.mp3", 200, 3);

			mockRepo.Setup(repo => repo.GetSongByTitle("Billie Jean")).Returns(song);
			var songService = new SongRepoService(mockRepo.Object);

			// Act
			songService.AddSong(song);
			var retrievedSong = songService.GetSongByTitle("Billie Jean");

			// Assert
			Assert.Equal("Billie Jean", retrievedSong.Title);
			Assert.Equal(200, retrievedSong.Length);
			Assert.Equal(3, retrievedSong.AlbumId);
		}

		[Fact]
		public void GetSongById_ValidId_ShouldReturnExpectedSong()
		{
			// Arrange
			var mockRepo = new Mock<ISongRepo>();
			var expectedSong = new Song("Event Horizon", "http://example.com/song4.mp3", 305, 3);

			mockRepo.Setup(repo => repo.GetSongById(28)).Returns(expectedSong);
			var songService = new SongRepoService(mockRepo.Object);

			// Act
			var actualSong = songService.GetSongById(28);

			// Assert
			Assert.Equal("Event Horizon", actualSong.Title);
			Assert.Equal("http://example.com/song4.mp3", actualSong.SongUrl);
			Assert.Equal(305, actualSong.Length);
			Assert.Equal(3, actualSong.AlbumId);
		}

		[Fact]
		public void GetSongByUrl_ValidUrl_ShouldReturnExpectedSong()
		{
			// Arrange
			var mockRepo = new Mock<ISongRepo>();
			var song = new Song("Event Horizon", "http://example.com/song4.mp3", 305, 3);

			mockRepo.Setup(repo => repo.GetSongByUrl("http://example.com/song4.mp3")).Returns(song);
			var songService = new SongRepoService(mockRepo.Object);

			// Act
			var retrievedSong = songService.GetSongByUrl("http://example.com/song4.mp3");

			// Assert
			Assert.Equal("Event Horizon", retrievedSong.Title);
			Assert.Equal("http://example.com/song4.mp3", retrievedSong.SongUrl);
			Assert.Equal(305, retrievedSong.Length);
			Assert.Equal(3, retrievedSong.AlbumId);
		}

		[Fact]
		public void DeleteSong_ValidSong_ShouldNotFindSongAfterDeletion()
		{
			// Arrange
			var mockRepo = new Mock<ISongRepo>();
			var song = new Song("Event Horizon", "http://example.com/song4.mp3", 305, 3);

			mockRepo.Setup(repo => repo.GetSongById(4)).Returns(song);
			mockRepo.Setup(repo => repo.DeleteSong(song)).Callback(() => mockRepo.Setup(repo => repo.GetSongById(4)).Returns((Song)null));
			var songService = new SongRepoService(mockRepo.Object);

			// Act
			songService.DeleteSong(song);
			var resultSong = songService.GetSongById(4);

			// Assert
			Assert.Null(resultSong);
		}

		[Fact]
		public void GetSongsByCreator_ValidCreator_ShouldReturnSongs()
		{
			// Arrange
			var mockRepo = new Mock<ISongRepo>();
			var songs = new List<Song> { new Song("Event Horizon", "http://example.com/song4.mp3", 305, 3) };

			mockRepo.Setup(repo => repo.GetSongsByCreator(2)).Returns(songs);
			var songService = new SongRepoService(mockRepo.Object);

			// Act
			var songsByCreator = songService.GetSongsByCreator(2);

			// Assert
			Assert.NotNull(songsByCreator);
			Assert.NotEmpty(songsByCreator);
		}

		[Fact]
        public void TestSongRepoAddGet()
        {
            // arrange
            var songRepo = new SongRepo();

            string title = "Billie Jean";
            string songUrl = "http://example.com/song5.mp3";
            int id = 200;
            int len = 200;
            int albumId = 3;

            var song = new Song(title, songUrl, len, albumId);

            // act
            songRepo.AddSong(song);

            // assert
            Assert.Equal(songRepo.GetSongByTitle(title).Title, title);
            Assert.Equal(songRepo.GetSongByTitle(title).Length, len);
            Assert.Equal(songRepo.GetSongByTitle(title).AlbumId, albumId);
        }

        [Fact]
        public void TestGetById()
        {
            // arrange
            var songrepo = new SongRepo();

            string title = "Event Horizon";
            string songUrl = "http://example.com/song4.mp3";
            int id = 28;
            int len = 305;
            int albumId = 3;

            songrepo.AddSong(new Song(title, songUrl, len, albumId));

            // act
            var songFromMethod = songrepo.GetSongById(id);

            // assert
            Assert.Equal(title, songFromMethod.Title);
            Assert.Equal(songUrl, songFromMethod.SongUrl);
            Assert.Equal(len, songFromMethod.Length);
            Assert.Equal(albumId, songFromMethod.AlbumId);
        }

        [Fact]
        public void TestGetByUrl()
        {
            // arrange
            var songrepo = new SongRepo();

            string title = "Event Horizon";
            string songUrl = "http://example.com/song4.mp3";
            int id = 28;
            int len = 305;
            int albumId = 3;

			songrepo.AddSong(new Song(title, songUrl, len, albumId));
			var songFromMethod = songrepo.GetSongByUrl(songUrl);

            // assert
            Assert.Equal(title, songFromMethod.Title);
            Assert.Equal(songUrl, songFromMethod.SongUrl);
            Assert.Equal(len, songFromMethod.Length);
            Assert.Equal(albumId, songFromMethod.AlbumId);
        }

        [Fact]
        public void TestSongRepoDelete()
        {
            // arrange
            var album = new SongRepo();

            string title = "Event Horizon";
            string songUrl = "http://example.com/song4.mp3";
            int id = 4;
            int len = 305;
            int albumId = 3;

            var song = new Song(title, songUrl, len, albumId);

            // act
            album.DeleteSong(song);

            // assert
            Assert.Null(album.GetSongById(4));
        }

        [Fact]
        public void TestGetLists()
        {
            // arrange
            var album = new SongRepo();

            int creatorId = 2;
            int albumId = 3;

            // act
            var songsByCreator = album.GetSongsByCreator(creatorId);
            var albumSongsById = album.GetSongsFromAlbum(albumId);

            // assert
            Assert.NotNull(songsByCreator);
            Assert.NotNull(albumSongsById);
        }
    }
}
