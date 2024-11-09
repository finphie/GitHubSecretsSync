namespace GitHubSecretsSync;

/// <summary>
/// 文字列の拡張メソッドを提供します。
/// </summary>
static class StringExtensions
{
    static readonly char[] Separator = [',', ' ', '\n', '\r'];

    /// <summary>
    /// 区切り文字に基づいて、文字列を分割します。
    /// </summary>
    /// <param name="source">分割する文字列</param>
    /// <returns>区切り文字によって分割された文字列の配列を返します。</returns>
    public static string[] SplitArray(this string source)
    {
        var span = source.AsSpan()
            .TrimStart('[')
            .TrimEnd(']')
            .ToString();

        return span.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
    }
}
