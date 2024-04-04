using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Ebersoft.CloudProviders.SecretProvider;

public class KeyVaultSecretProvider : ISecretProvider
{
    private readonly SecretClient _secretClient;
    
    public KeyVaultSecretProvider(string keyVaultUrl)
    {
        var keyVaultUri = new Uri(keyVaultUrl);
        var defaultCredential = new DefaultAzureCredential();
        this._secretClient = new SecretClient(keyVaultUri, defaultCredential);
    }
    
    public async Task<string> GetSecretAsync(string secretName)
    {
        var secret = await this._secretClient.GetSecretAsync(secretName);
        return secret.Value.ToString();
    }
}