using System.Net;
using System.Web.Mvc;
using LinkShortener.Web.Controllers;
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
            _controller = new HomeController();
        }

        [Test]
        public void Index_NullId_ShouldReturn404()
        {
            var result = _controller.Index(null) as HttpStatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
            Assert.AreEqual("Link is invalid", result.StatusDescription);
        }

        [Test]
        public void Index_EmptyId_ShouldReturn404()
        {
            var result = _controller.Index("") as HttpStatusCodeResult;

            Assert.NotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, (HttpStatusCode)result.StatusCode);
            Assert.AreEqual("Link is invalid", result.StatusDescription);
        }
    }
}
