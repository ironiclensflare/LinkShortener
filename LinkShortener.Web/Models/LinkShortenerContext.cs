using System.Data.Entity;

namespace LinkShortener.Web.Models
{
    public class LinkShortenerContext : DbContext
    {
        public virtual DbSet<Link> Links { get; set; }
    }
}