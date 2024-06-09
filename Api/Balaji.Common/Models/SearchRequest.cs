namespace Balaji.Common.Models
{
    public class Criterion
    {
        public string? Field { get; set; } = string.Empty;
        public string? Operator { get; set; } = string.Empty;
        public string? Value { get; set; } = string.Empty;
    }

    public class Sort
    {
        public string? Field { get; set; } = string.Empty;
        public string? Order { get; set; } = string.Empty;
    }

    public class SearchRequest
    {
        public string? Intent { get; set; } = string.Empty;

        public List<Criterion> Criterion { get; set; }

        public List<string> Fields { get; set; }

        public List<Sort> Sort { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
