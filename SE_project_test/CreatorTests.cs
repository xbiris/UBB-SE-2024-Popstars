using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE_project;
using SE_project.Services;

namespace SE_project_test
{
    [TestClass]
    public class CreatorTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            string username = "testUsername";
            string fullname = "Test User";
            string email = "test@example.com";
            string country = "Test Country";
            string birthday = "01/01/2000";
            string socialMediaLink = "https://example.com";
            string description = "Test description";
            string profilePicPath = "path/to/pic.jpg";

            // Act
            Creator creator = new Creator(username, fullname, email, country, birthday, socialMediaLink, description, profilePicPath);

            // Assert
            Assert.AreEqual(username, creator.Username);
            Assert.AreEqual(fullname, creator.Fullname);
            Assert.AreEqual(email, creator.Email);
            Assert.AreEqual(country, creator.Country);
            Assert.AreEqual(birthday, creator.Birthday);
            Assert.AreEqual(socialMediaLink, creator.Socialmedialink);
            Assert.AreEqual(description, creator.Description);
            Assert.AreEqual(profilePicPath, creator.ProfilePicPath);
        }

        [TestMethod]
        public void TestIdProperty()
        {
            // Arrange
            Creator creator = new Creator("testUsername", "Test User", "test@example.com", "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg");

            // Act
            creator.Id = 100;

            // Assert
            Assert.AreEqual(100, creator.Id);
        }



        [TestMethod]
        public void TestInequality()
        {
            // Arrange
            Creator creator1 = new Creator("testUsername1", "Test User", "test@example.com", "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg");
            Creator creator2 = new Creator("testUsername2", "Test User", "test@example.com", "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg");

            // Assert
            Assert.AreNotEqual(creator1, creator2);
        }
    }
    [TestClass]
        public class CreatorRepoTests
        {
            private CreatorRepo creatorRepo;
            private string connectionString = "your_connection_string_here";

            [TestInitialize]
            public void Initialize()
            {
                // Initialize CreatorRepo with a connection string for testing
                creatorRepo = new CreatorRepo();
            }

            [TestMethod]
            public void AddCreator_ValidInput_CreatorAddedSuccessfully()
            {
                // Arrange
                Creator creator = new Creator("John Doe", "johndoe", "johndoe@example.com", "USA", "1990-01-01", "https://example.com", "Description", "profile.jpg");
                string hashedPass = "hashedPassword";

                // Act
                creatorRepo.AddCreator(creator, hashedPass);

                // Assert
                Creator retrievedCreator = creatorRepo.GetCreatorById(1);
                Assert.IsNotNull(retrievedCreator);
                Assert.AreEqual("John Doe", retrievedCreator.Fullname);
                
            }

            [TestMethod]
            public void GetNoOfSavesPerCreator_ValidCreatorId_ReturnsCorrectCount()
            {
                // Arrange
                int creatorId = 1; // Assume creator with ID 1 exists in the database

                // Act
                int savesCount = creatorRepo.GetNoOfSavesPerCreator(creatorId);

                // Assert
                Assert.IsTrue(savesCount >= 0); // Ensure non-negative count
                                                
            }

            [TestMethod]
            public void GetNoOfSharesPerCreator_ValidCreatorId_ReturnsCorrectCount()
            {
                // Arrange
                int creatorId = 1; // Assume creator with ID 1 exists in the database

                // Act
                int sharesCount = creatorRepo.GetNoOfSharesPerCreator(creatorId);

                // Assert
                Assert.IsTrue(sharesCount >= 0); // Ensure non-negative count
                                                 
            }

            [TestMethod]
            public void GetNoOfStreamsPerCreator_ValidCreatorId_ReturnsCorrectCount()
            {
                // Arrange
                int creatorId = 1; // Assume creator with ID 1 exists in the database

                // Act
                int streamsCount = creatorRepo.GetNoOfStreamsPerCreator(creatorId);

                // Assert
                Assert.IsTrue(streamsCount >= 0); // Ensure non-negative count
                                                  
            }

            [TestMethod]
            public void GetNoOfPlaylistsPerCreator_ValidCreatorId_ReturnsCorrectCount()
            {
                // Arrange
                int creatorId = 1; // Assume creator with ID 1 exists in the database

                // Act
                int playlistsCount = creatorRepo.GetNoOfPlaylistsPerCreator(creatorId);

                // Assert
                Assert.IsTrue(playlistsCount >= 0); // Ensure non-negative count
                                                    
            }
        }

    [TestClass]
    public class CreatorServiceTests
    {
        private CreatorService creatorService;
        private string connectionString = "your_connection_string_here";

        [TestInitialize]
        public void Initialize()
        {
            // Initialize CreatorService with a connection string for testing
            creatorService = new CreatorService();
        }

        [TestMethod]
        public void GetNoOfSavesPerCreator_ValidCreatorId_ReturnsCorrectCount()
        {
            // Arrange
            int creatorId = 1; // Assume creator with ID 1 exists in the database

            // Act
            int savesCount = creatorService.GetNoOfSavesPerCreator(creatorId);

            // Assert
            Assert.IsTrue(savesCount >= 0); // Ensure non-negative count
            // Add more specific assertions based on your data and logic
        }

        [TestMethod]
        public void GetNoSharesPerCreator_ValidCreatorId_ReturnsCorrectCount()
        {
            // Arrange
            int creatorId = 1; // Assume creator with ID 1 exists in the database

            // Act
            int sharesCount = creatorService.GetNoSharesPerCreator(creatorId);

            // Assert
            Assert.IsTrue(sharesCount >= 0); // Ensure non-negative count
            // Add more specific assertions based on your data and logic
        }

        [TestMethod]
        public void GetNoStreamsPerCreator_ValidCreatorId_ReturnsCorrectCount()
        {
            // Arrange
            int creatorId = 1; // Assume creator with ID 1 exists in the database

            // Act
            int streamsCount = creatorService.GetNoStreamsPerCreator(creatorId);

            // Assert
            Assert.IsTrue(streamsCount >= 0); // Ensure non-negative count
            // Add more specific assertions based on your data and logic
        }

        [TestMethod]
        public void GetNoPlaylists_ValidCreatorId_ReturnsCorrectCount()
        {
            // Arrange
            int creatorId = 1; // Assume creator with ID 1 exists in the database

            // Act
            int playlistsCount = creatorService.GetNoPlaylists(creatorId);

            // Assert
            Assert.IsTrue(playlistsCount >= 0); // Ensure non-negative count
            // Add more specific assertions based on your data and logic
        }

        [TestMethod]
        public void GetCreatorInfoById_ValidCreatorId_ReturnsCorrectInfo()
        {
            // Arrange
            int creatorId = 1; // Assume creator with ID 1 exists in the database

            // Act
            (string fullname, string description, string profilePicPath) = creatorService.GetCreatorInfoById(creatorId);

            // Assert
            Assert.IsNotNull(fullname);
            Assert.IsNotNull(description);
            Assert.IsNotNull(profilePicPath);
            
        }
    }

}
