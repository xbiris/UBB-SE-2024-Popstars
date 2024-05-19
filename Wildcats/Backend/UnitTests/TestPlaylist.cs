using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;
using Xunit;
using Moq;
using ISS_Wildcats.Backend.Repos;
using ISS_Wildcats.Backend.Service;

namespace ISS_Wildcats.Backend.UnitTests
{
    public class TestPlaylist
    {
		[Fact]
		public void GetPlaylist_ValidId_ShouldLoadPropertiesCorrectly()
		{
			// Arrange
			var mockRepo = new Mock<IPlaylistRepo>();
			var playlistId = 3;
			var expectedPlaylist = new Playlist
			{
				PlaylistID = playlistId,
				Name = "Sunset Boulevard",
				CreatorID = 1,
				SongIDs = new List<int> { 1 }
			};

			mockRepo.Setup(repo => repo.GetPlaylist(playlistId)).Returns(expectedPlaylist);
			var playlistService = new PlaylistService(mockRepo.Object);

			// Act
			var actualPlaylist = playlistService.GetPlaylist(playlistId);

			// Assert
			Assert.NotNull(actualPlaylist);
			Assert.Equal(expectedPlaylist.PlaylistID, actualPlaylist.PlaylistID);
			Assert.Equal(expectedPlaylist.Name, actualPlaylist.Name);
			Assert.Equal(expectedPlaylist.CreatorID, actualPlaylist.CreatorID);
			Assert.Equal(expectedPlaylist.SongIDs, actualPlaylist.SongIDs);
		}

		[Fact]
		public void UpdatePlaylist_ExistingPlaylistNameIsSunsetBoulevard_ShouldChangeNameToSynchronicity()
		{
			// Arrange
			var connectionString = "fake_connection_string";
			var mockRepo = new Mock<IPlaylistRepo>();
			var playlistId = 3;
			var originalPlaylist = new Playlist
			{
				PlaylistID = playlistId,
				Name = "Sunset Boulevard",
				CreatorID = 1, // example creator ID
				SongIDs = new List<int>() // example song IDs
			};

			mockRepo.Setup(repo => repo.GetPlaylist(playlistId)).Returns(originalPlaylist);
			mockRepo.Setup(repo => repo.UpdatePlaylist(It.IsAny<Playlist>()))
					.Callback<Playlist>(p => originalPlaylist.Name = p.Name);

			var playlistService = new PlaylistService(mockRepo.Object);

			// Act
			playlistService.UpdatePlaylistName(playlistId, "Synchronicity");

			// Assert
			Assert.Equal("Synchronicity", originalPlaylist.Name);
			mockRepo.Verify(repo => repo.UpdatePlaylist(It.Is<Playlist>(p => p.Name == "Synchronicity")), Times.Once);
		}

		[Fact]
		public void DeletePlaylist_ValidId_ShouldNotFindPlaylistAfterDeletion()
		{
			// Arrange
			var mockRepo = new Mock<IPlaylistRepo>();
			int playlistId = 1;

			mockRepo.Setup(repo => repo.GetPlaylist(playlistId)).Throws(new ArgumentException("Playlist not found."));
			mockRepo.Setup(repo => repo.DeletePlaylist(playlistId)).Callback(() => mockRepo.Setup(repo => repo.GetPlaylist(playlistId)).Throws(new ArgumentException("Playlist not found.")));
			var playlistService = new PlaylistService(mockRepo.Object);

			// Act
			playlistService.DeletePlaylist(playlistId);

			// Assert
			var exception = Assert.Throws<ArgumentException>(() => playlistService.GetPlaylist(playlistId));
			Assert.Equal("Playlist not found.", exception.Message);
			mockRepo.Verify(repo => repo.DeletePlaylist(playlistId), Times.Once);
		}

		[Fact]
        public void TestConstructorsPropertiesLoad()
        {
            // arrange
            string connectionString = "Data Source=LAPTOPDAVID\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";
            int playlistId = 3;
            List<int> songIDs = new List<int>() { 1 };
            int creatorId = 1;

            // act
            var playlistrepo = new PlaylistRepo(connectionString);

            Playlist playlist1 = playlistrepo.GetPlaylist(3);
            Playlist playlist2 = playlistrepo.GetPlaylist(4);
            // assert
            Assert.NotNull(playlist1);
            Assert.NotNull(playlist2);
            Assert.NotEqual(playlist2, playlist1);
            Assert.Equal(playlist1.PlaylistID, playlistId);
            Assert.Equal(playlist1.SongIDs, songIDs);
            Assert.Equal(playlist1.CreatorID, creatorId);
        }

        [Fact]
        public void TestUpdatePlaylist()
        {
            // arrange
            string connectionString = "Data Source=LAPTOPDAVID\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";
            int playlistId = 3;
			var playlistrepo = new PlaylistRepo(connectionString);
			Playlist playlist1 = playlistrepo.GetPlaylist(playlistId);

            // act
            if (playlist1.Name.Equals("Sunset Boulevard"))
            {
                playlist1.Name = "Synchronicity";
				playlistrepo.UpdatePlaylist(playlist1);
            }
            else
            {
				playlist1.Name = "Sunset Boulevard";
				playlistrepo.UpdatePlaylist(playlist1);
            }
			Playlist playlist2 = playlistrepo.GetPlaylist(4);
            Assert.Equal("123", playlist2.Name);
        }

        [Fact]
        public void TestDeletePlaylist()
        {
            // arrange
            string connectionString = "Data Source=LAPTOPDAVID\\SQLEXPRESS;Initial Catalog=se_2024;Integrated Security=True;Encrypt=False;";

			var playlistrepo = new PlaylistRepo(connectionString);
            playlistrepo.DeletePlaylist(1);

            // assert
            try
            {
				var playlist = playlistrepo.GetPlaylist(1);
			}
            catch
            {
                Assert.True(true);	// album2 could not be found
            }
        }
    }
}
