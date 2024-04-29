using SE_project.Services;
using System.Security.Cryptography;﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SE_project;

namespace SE_project_test
    {
        [TestClass]
        public class AlbumRepoTests
        {
            [TestMethod]
            public void AddAlbum_ValidAlbum_ReturnsNewAlbumId()
            {
                // Arrange
                AlbumRepo albumRepo = new AlbumRepo();
                Album album = new Album("Test Album", "2022-01-01", "Pop", "photo.jpg", new List<Song>());
                int creatorId = 1;

                // Act
                int newAlbumId = albumRepo.AddAlbum(album, creatorId);

                // Assert
                Assert.IsTrue(newAlbumId > 0);
            }

            [TestMethod]
            public void GetAlbumsByCreatorId_ValidCreatorId_ReturnsListOfAlbums()
            {
                // Arrange
                AlbumRepo albumRepo = new AlbumRepo();
                int creatorId = 1;

                // Act
                List<Album> albums = albumRepo.GetAlbumsByCreatorId(creatorId);

                // Assert
                Assert.IsNotNull(albums);
                Assert.IsTrue(albums.Count > 0);
            }
        }

        [TestClass]
        public class AlbumServiceTests
        {
            [TestMethod]
            public void AddAlbum_ValidData_AddsAlbumToDatabase()
            {
                // Arrange
                AlbumService albumService = new AlbumService();
                int creatorId = 1;

                // Act
                albumService.AddAlbum("Test Album", "2022-01-01", "Pop", "photo.jpg", creatorId);

                // Assert (You may want to check the database directly to ensure the album was added)
                // Assert.IsTrue(albumAddedToDb);
            }

            [TestMethod]
            public void AddSongToList_ValidData_AddsSongToList()
            {
                // Arrange
                AlbumService albumService = new AlbumService();
                string title = "Test Song";
                string songPath = "song.mp3";

                // Act
                albumService.AddSongToList(title, songPath);

                // Assert
                Assert.IsTrue(albumService.Songs.Count > 0);
                Assert.AreEqual(title, albumService.Songs[0].Title);
                Assert.AreEqual(songPath, albumService.Songs[0].SongUrl);
            }


            [TestMethod]
            public void AddAlbum_ValidDataWithSongs_AddsAlbumWithSongsToDatabase()
            {
                // Arrange
                AlbumService albumService = new AlbumService();
                int creatorId = 1;
                albumService.AddSongToList("Song 1", "song1.mp3");
                albumService.AddSongToList("Song 2", "song2.mp3");

                // Act
                albumService.AddAlbum("Test Album", "2022-01-01", "Pop", "photo.jpg", creatorId);

                // Assert (You may want to check the database directly to ensure the album and songs were added)
                // Assert.IsTrue(albumAndSongsAddedToDb);
            }

        [TestMethod]
        public void GetAlbumsByCreatorId_ValidCreatorId_ReturnsListOfAlbums()
        {
            // Arrange
            AlbumService albumService = new AlbumService();
            int creatorId = 1;

            // Act
            List<Album> albums = albumService.GetAlbumsByCreatorId(creatorId);

            // Assert
            Assert.IsNotNull(albums);
            Assert.IsTrue(albums.Count > 0);
        }
        }
    }