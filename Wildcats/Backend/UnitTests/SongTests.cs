using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISS_Wildcats.Backend.Models;
using Xunit;

namespace ISS_Wildcats.Backend.UnitTests
{
    public class SongTests
    {
        [Fact]
        public void TestConstructor()
        {
            // arrange
            string title1 = "Golden Hour";
            string songUrl1 = "http://example.com/song1.mp3";

            string title2 = "Twilight Zone";
            string songUrl2 = "http://example.com/song2.mp3";

            string title3 = "DayBreak";
            string songUrl3 = "http://example.com/song3.mp3";

            string title4 = "Event Horizon";
            string songUrl4 = "http://example.com/song4.mp3";

            // act
            var song1 = new Song(title1, songUrl1, 0, 0);
            var song2 = new Song(title2, songUrl2, 0, 0);
            var song3 = new Song(title3, songUrl3, 0, 0);
            var song4 = new Song(title4, songUrl4, 0, 0);

            // assert
            Assert.Equal(title1, song1.Title);
            Assert.Equal(songUrl1, song1.SongUrl);

            Assert.Equal(title2, song2.Title);
            Assert.Equal(songUrl2, song2.SongUrl);

            Assert.Equal(title3, song3.Title);
            Assert.Equal(songUrl3, song3.SongUrl);

            Assert.Equal(title4, song4.Title);
            Assert.Equal(songUrl4, song4.SongUrl);

            Assert.NotEqual(song1, song2);
            Assert.NotEqual(song1, song3);
            Assert.NotEqual(song2, song4);
        }

        [Fact]
        public void TestTitle()
        {
            // arrange
            string title2 = "Twilight Zone";
            string songUrl2 = "http://example.com/song2.mp3";

            // act
            var song2 = new Song(title2, songUrl2, 0, 0);

            // assert
            Assert.Equal(title2, song2.Title);
        }

        [Fact]
        public void TestLength()
        {
            // arrange
            string title3 = "DayBreak";
            string songUrl3 = "http://example.com/song3.mp3";
            int assertLength = 180;

            // act
            var song3 = new Song(title3, songUrl3, 180, 0);

            // assert
            Assert.Equal(assertLength, song3.Length);
        }

        [Fact]
        public void TestSongUrl()
        {
            // arrange
            string title4 = "Event Horizon";
            string songUrl4 = "http://example.com/song4.mp3";

            // act
            var song4 = new Song(title4, songUrl4, 0, 0);

            // assert
            Assert.Equal(songUrl4, song4.SongUrl);
        }

        [Fact]
        public void TestAlbumId()
        {
            // arrange
            string title1 = "Golden Hour";
            string songUrl1 = "http://example.com/song1.mp3";

            // act
            var song1 = new Song(title1, songUrl1, 0, 1);

            // Assert
            Assert.Equal(1, song1.AlbumId);
        }
    }
}
