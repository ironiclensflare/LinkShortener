using System.Web.Mvc;
using LinkShortener.Web.Models;

namespace LinkShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILinkService _links;

        public HomeController(ILinkService links)
        {
            _links = links;
        }

        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return InvalidLink();
            var link = _links.GetLinkById(id);
            if (link == null) return InvalidLink();
            return RedirectPermanent(link.Url);
        }

        private HttpNotFoundResult InvalidLink()
        {
            return HttpNotFound("Link is invalid");
        }
    }
}
