using System.Linq;

namespace LinkShortener.Web.Models
{
    public class LinkService : ILinkService
    {
        private readonly LinkShortenerContext _context;

        public LinkService(LinkShortenerContext context)
        {
            _context = context;
        }

        public Link GetLinkById(string id)
        {
            return _context.Links.SingleOrDefault(l => l.Id == id);
        }
    }
}