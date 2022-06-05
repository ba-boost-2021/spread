namespace Spread.Common;

public class PagedList<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int PageCount => (int)Math.Ceiling((TotalCount == 0 ? TotalCount + 1 :  TotalCount) / (double)PageSize);
    public int PageSize { get; set; }
    public int ItemCount => Items.Count;
}
