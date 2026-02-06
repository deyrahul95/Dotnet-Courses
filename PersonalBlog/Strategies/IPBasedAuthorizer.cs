using PersonalBlog.Interfaces;

namespace PersonalBlog.Strategies;

public class IPBasedAuthorizer(IHttpContextAccessor accessor, IConfiguration configuration) : IAuthorizer
{
    public bool IsAuthorize()
    {
        var ipv4 = accessor.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();
        var validIp = configuration.GetSection("Security").GetValue<string>("ValidIP");

        if (string.IsNullOrEmpty(ipv4))
        {
            return false;
        }

        return ipv4.Equals(validIp);
    }
}
