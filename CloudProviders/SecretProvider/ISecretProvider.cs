namespace Ebersoft.CloudProviders.SecretProvider;

public interface ISecretProvider
{
    public Task<string> GetSecretAsync(string secretName);
}