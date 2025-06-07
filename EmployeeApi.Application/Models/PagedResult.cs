namespace EmployeeApi.Application.Models
{
    public class PagedResult<T>
    {
        public List<T> data { get; set; } = new();
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
