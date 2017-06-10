using System.Net;
using System.Web.Mvc;
using LinkShortener.Web.Controllers;
using LinkShortener.Web.Models;
using Moq;
using NUnit.Framework;

namespace LinkShortener.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            var fakeLinkService = CreateMockLinkService();
            _controller = new HomeController(fakeLinkService);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Index_NullOrEmptyId_ShouldReturn404(string id)
        {
            var result = _controller.Index(id) as HttpStatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
            Assert.AreEqual("Link is invalid", result.StatusDescription);
        }

        [TestCase("aaaa", ExpectedResult = "https://www.google.com")]
        [TestCase("bbbb", ExpectedResult = "https://www.twitch.tv")]
        public string Index_ValidId_ShouldReturnRedirect(string id)
        {
            var result = _controller.Index(id) as RedirectResult;

            Assert.NotNull(result);
            Assert.AreEqual(true, result.Permanent);
            return result.Url;
        }

        [TestCase("cccc")]
        [TestCase("dddd")]
        public void Index_InvalidId_ShouldReturn404(string id)
        {
            var result = _controller.Index(id) as HttpStatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
            Assert.AreEqual("Link is invalid", result.StatusDescription);
        }

        private ILinkService CreateMockLinkService()
        {
            var fakeLinkService = new Mock<ILinkService>();
            fakeLinkService.Setup(s => s.GetLinkById(It.Is<string>(a => a == "aaaa"))).Returns(new Link { Url = "https://www.google.com" });
            fakeLinkService.Setup(s => s.GetLinkById(It.Is<string>(a => a == "bbbb"))).Returns(new Link { Url = "https://www.twitch.tv" });
            return fakeLinkService.Object;
        }
    }
}