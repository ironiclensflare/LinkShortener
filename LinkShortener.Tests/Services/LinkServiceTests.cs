using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinkShortener.Web.Models;
using Moq;
using NUnit.Framework;

namespace LinkShortener.Tests.Services
{
    [TestFixture]
    public class LinkServiceTests
    {
        private LinkService _service;

        [SetUp]
        public void Setup()
        {
            var mockContext = MockContext();
            _service = new LinkService(mockContext);
        }
        
        [TestCase(null)]
        [TestCase("")]
        public void GetLinkById_NullOrEmptyId_ShouldReturnNull(string id)
        {
            var result = _service.GetLinkById(id);

            Assert.Null(result);
        }

        [TestCase("aaaa", ExpectedResult = "https://www.google.com")]
        [TestCase("bbbb", ExpectedResult = "https://www.twitch.tv")]
        public string GetLinkById_ValidId_ShouldReturnLink(string id)
        {
            var result = _service.GetLinkById(id);

            Assert.NotNull(result);
            return result.Url;
        }

        [TestCase("cccc")]
        [TestCase("dddd")]
        public void GetLinkById_InvalidId_ShouldReturnNull(string id)
        {
            var result = _service.GetLinkById(id);

            Assert.Null(result);
        }

        private static LinkShortenerContext MockContext()
        {
            var mockData = new List<Link>
            {
                new Link {Id = "aaaa", Url = "https://www.google.com"},
                new Link {Id = "bbbb", Url = "https://www.twitch.tv"}
            }.AsQueryable();
            var mockDbSet = new Mock<DbSet<Link>>();
            mockDbSet.As<IQueryable<Link>>().Setup(m => m.Provider).Returns(mockData.Provider);
            mockDbSet.As<IQueryable<Link>>().Setup(m => m.Expression).Returns(mockData.Expression);
            mockDbSet.As<IQueryable<Link>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            mockDbSet.As<IQueryable<Link>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator);
            var mockContext = new Mock<LinkShortenerContext>();
            mockContext.Setup(m => m.Links).Returns(mockDbSet.Object);
            return mockContext.Object;
        }
    }
}
