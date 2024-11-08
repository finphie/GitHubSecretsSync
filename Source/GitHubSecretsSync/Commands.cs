using System.Security.Cryptography;
using System.Text;
using FToolkit.Net.GitHub.Client;
using FToolkit.Net.GitHub.Client.Actions.Secrets;

namespace GitHubSecretsSync;

/// <summary>
/// コマンドを提供します。
/// </summary>
static class Commands
{
    /// <summary>
    /// Synchronizes GitHub Actions Secrets to the specified repository.
    /// </summary>
    /// <param name="repository">-r, "owner/repo" format repository name.</param>
    /// <param name="secrets">-s, List of GitHub Actions Secrets to be synchronized. Specify separated by commas, spaces, or newlines.</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    public static async Task ActionsAsync(string repository, string secrets)
    {
        ArgumentException.ThrowIfNullOrEmpty(repository);
        ArgumentNullException.ThrowIfNull(secrets);

        if (repository.Split('/') is not [{ Length: > 0 } repositoryOwner, { Length: > 0 } repositoryName])
        {
            throw new ArgumentException("Invalid repository format. Expected format is owner/repo.");
        }

        Console.WriteLine($"Synchronizing GitHub Actions Secrets to {repository}.");

        var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        ArgumentException.ThrowIfNullOrEmpty(token);

        var client = GitHubClient.Create(token);

        Console.WriteLine($"Getting the public key.");

        var publicKey = await client.Actions.Secrets.GetPublicKeyAsync(repositoryOwner, repositoryName).ConfigureAwait(false);
        var publicKeyBytes = Convert.FromBase64String(publicKey.Key);

        foreach (var secretName in secrets.SplitArray())
        {
            Console.WriteLine($"Synchronizing the secret '{secretName}'.");

            var secretValue = Environment.GetEnvironmentVariable(secretName);
            ArgumentException.ThrowIfNullOrEmpty(secretValue);

            var secretValueBytes = Encoding.UTF8.GetBytes(secretValue);
            var secret = new Secret
            {
                EncryptedValue = CreateEncryptedValue(secretValueBytes, publicKeyBytes),
                KeyId = publicKey.KeyId
            };
            await client.Actions.Secrets.CreateOrUpdateAsync(repositoryOwner, repositoryName, secretName, secret).ConfigureAwait(false);
        }
    }

    static string CreateEncryptedValue(byte[] message, byte[] recipientPublicKey)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(recipientPublicKey);

        if (recipientPublicKey.Length != 32)
        {
            throw new ArgumentException($"{nameof(recipientPublicKey)} must be 32 bytes in length.");
        }

        Span<byte> buffer = stackalloc byte[message.Length + 48];

        return Interop.CryptoBoxSeal(buffer, message, (ulong)message.Length, recipientPublicKey) == 0
            ? Convert.ToBase64String(buffer)
            : throw new CryptographicException("Failed to create SealedBox.");
    }
}
