using SE_project;

namespace SE_project_test
{
    [TestClass]
    public class UnitTest1
    {
        Song song = new Song("title", "songUrl");
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("title", song.Title);
        }
    }
}