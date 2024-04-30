using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE_project;

namespace SE_project_test
{
    [TestClass]
    public class CreatorTest
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
            Assert.AreEqual(username, creator.username);
            Assert.AreEqual(fullname, creator.fullname);
            Assert.AreEqual(email, creator.email);
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
            creator.id = 100;

            // Assert
            Assert.AreEqual(100, creator.id);
        }

        [TestMethod]
        public void TestNullArgumentsInConstructor()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Creator(null, "Test User", "test@example.com", "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg"));
            Assert.ThrowsException<ArgumentNullException>(() => new Creator("testUsername", null, "test@example.com", "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg"));
            Assert.ThrowsException<ArgumentNullException>(() => new Creator("testUsername", "Test User", null, "Test Country", "01/01/2000", "https://example.com", "Test description", "path/to/pic.jpg"));
            // Repeat for other arguments if needed
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
}
