namespace Spread.Common;

public interface IClaims
{
    bool IsAuthenticated { get; set; }
    public CurrentUser CurrentUser { get; set; }
}
