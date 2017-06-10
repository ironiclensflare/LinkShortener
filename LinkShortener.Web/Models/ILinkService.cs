namespace LinkShortener.Web.Models
{
    public interface ILinkService
    {
        Link GetLinkById(string id);
    }
}