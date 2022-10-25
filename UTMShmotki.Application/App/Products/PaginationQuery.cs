namespace UTMShmotki.Application.App.Products
{
    public class PaginationQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search{ get; set; } = "";
        public string Sort { get; set; } = "";
    }
}