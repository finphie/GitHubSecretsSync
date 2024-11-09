using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GitHubSecretsSync;

/// <summary>
/// C#コードと外部ライブラリ間でデータをやり取りするためのメソッドを提供します。
/// </summary>
static partial class Interop
{
    [LibraryImport("libsodium", EntryPoint = "crypto_box_seal")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CryptoBoxSeal(Span<byte> ciphertext, ReadOnlySpan<byte> message, ulong messageLength, ReadOnlySpan<byte> recipientPk);
}
