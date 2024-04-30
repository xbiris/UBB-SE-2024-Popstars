using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE_project;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SE_project_test
{
    [TestClass]
    public class SongTest
    {

        [TestMethod]
        public void TestGettersAndSetters()
        {
            // Arrange
            Song song = new Song("title", "songUrl");

            // Act
            song.Id = 1;
            song.Title = "newTitle";
            song.Length = 300;
            song.SongUrl = "newSongUrl";
            song.AlbumId = 2;

            // Assert
            Assert.AreEqual(1, song.Id);
            Assert.AreEqual("newTitle", song.Title);
            Assert.AreEqual(300, song.Length);
            Assert.AreEqual("newSongUrl", song.SongUrl);
            Assert.AreEqual(2, song.AlbumId);
        }

        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            string title = "title";
            string songUrl = "songUrl";

            // Act
            Song song = new Song(title, songUrl);

            // Assert
            Assert.AreEqual(title, song.Title);
            Assert.AreEqual(songUrl, song.SongUrl);
        }

        [TestMethod]
        public void TestProperties()
        {
            // Arrange
            Song song = new Song("title", "songUrl");

            // Act
            song.Id = 1;
            song.Length = 300;
            song.AlbumId = 2;

            // Assert
            Assert.AreEqual(1, song.Id);
            Assert.AreEqual(300, song.Length);
            Assert.AreEqual(2, song.AlbumId);
        }

       

        [TestMethod]
        public void TestConstructorWithValidArguments()
        {
            // Act
            Song song = new Song("title", "songUrl");

            // Assert
            Assert.AreEqual("title", song.Title);
            Assert.AreEqual("songUrl", song.SongUrl);
        }
    

    [TestMethod]
        public void TestEdgeCases()
        {
            // Arrange
            string longTitle = new string('a', 1000);
            string longSongUrl = new string('b', 1000);

            // Act
            Song song = new Song(longTitle, longSongUrl);

            // Assert
            Assert.AreEqual(longTitle, song.Title);
            Assert.AreEqual(longSongUrl, song.SongUrl);
        }

        [TestMethod]
        public void TestBoundaryValues()
        {
            // Arrange
            Song song = new Song("title", "songUrl");

            // Act
            song.Id = int.MaxValue;
            song.Length = int.MaxValue;

            // Assert
            Assert.AreEqual(int.MaxValue, song.Id);
            Assert.AreEqual(int.MaxValue, song.Length);
        }


        [TestMethod]
        public void TestMutation()
        {
            // Arrange
            Song song = new Song("title", "songUrl");

            // Mutate Title
            song.Title = "newTitle";

            // Assert
            Assert.AreEqual("newTitle", song.Title);
        }

        [TestMethod]
        public void TestConcurrency()
        {
            // Arrange
            Song song = new Song("title", "songUrl");

            // Act
            Parallel.Invoke(
                () => song.Id = 1,
                () => song.Length = 300,
                () => song.AlbumId = 2
            );

            // Assert
            Assert.AreEqual(1, song.Id);
            Assert.AreEqual(300, song.Length);
            Assert.AreEqual(2, song.AlbumId);
        }

        [TestMethod]
        public void TestSerializationDeserialization()
        {
            // Arrange
            Song originalSong = new Song("title", "songUrl");
            originalSong.Id = 1;
            originalSong.Length = 300;
            originalSong.AlbumId = 2;

            // Act
            // Simulate serialization
            string serializedData = $"{originalSong.Id},{originalSong.Title},{originalSong.Length},{originalSong.SongUrl},{originalSong.AlbumId}";

            // Simulate deserialization
            string[] parts = serializedData.Split(',');
            Song deserializedSong = new Song(parts[1], parts[3]);
            deserializedSong.Id = int.Parse(parts[0]);
            deserializedSong.Length = int.Parse(parts[2]);
            deserializedSong.AlbumId = int.Parse(parts[4]);

            // Assert
            Assert.AreEqual(originalSong.Id, deserializedSong.Id);
            Assert.AreEqual(originalSong.Length, deserializedSong.Length);
            Assert.AreEqual(originalSong.AlbumId, deserializedSong.AlbumId);
            Assert.AreEqual(originalSong.Title, deserializedSong.Title);
            Assert.AreEqual(originalSong.SongUrl, deserializedSong.SongUrl);
        }

    }
}
