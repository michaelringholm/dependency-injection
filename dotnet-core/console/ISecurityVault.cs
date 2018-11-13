namespace samples.dependencyInjection
{
    public interface ISecurityVault {
        string GetKey(string keyName);
        string GetSecret(string secretName);
    }
}