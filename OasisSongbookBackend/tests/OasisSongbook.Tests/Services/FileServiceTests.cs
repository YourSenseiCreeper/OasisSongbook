using OasisSongbook.Business.Services;
using Shouldly;

namespace OasisSongbook.Tests.Services
{
    public class FileServiceTests
    {
        [Test]
        [TestCase("T<es>?t&owy !p@l#ik* ś(p):i^ewnika%", "Test&owy !p@l#ik ś(p)i^ewnika%")]
        [TestCase("CON", "nie-tym-razem")]
        [TestCase("AUX", "nie-tym-razem")]
        [TestCase("NUL", "nie-tym-razem")]
        [TestCase("COM5", "nie-tym-razem")]
        [TestCase("LPT2", "nie-tym-razem")]
        public void SterilizeFileName_Success(string rawFilename, string expected)
        {
            var service = new FileService();
            var sterilized = service.SterilizeFileName(rawFilename);
            sterilized.ShouldBe(expected);
        }
    }
}