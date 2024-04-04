namespace Ebersoft.CloudProviders.CacheProvider;

public interface ICacheProvider
{
    public Task Set(string key, string value);

    public Task<string> Get(string key);
}