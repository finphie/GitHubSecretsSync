# GitHubSecretsSync

[![Build(.NET)](https://github.com/finphie/GitHubSecretsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSecretsSync/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/GitHubSecretsSync?color=0078d4&label=NuGet)](https://www.nuget.org/packages/GitHubSecretsSync/)
[![Azure Artifacts]()](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSecretsSync?preferRelease=true)

This is an application to synchronize GitHub Actions secrets.

## Description

GitHubSecretsSync is an application for configuring GitHub Actions secrets.

- [Action](https://github.com/marketplace/actions/github-secrets-sync)
- [NuGet](https://www.nuget.org/packages/GitHubSecretsSync)
- [Azure Artifacts](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSecretsSync?preferRelease=true)
- [Binary](https://github.com/finphie/GitHubSecretsSync/releases/latest)
- [Docker](https://github.com/finphie/GitHubSecretsSync/pkgs/container/git-hub-secrets-sync)

## Usage

### Action

```yaml
on:
  workflow_dispatch:

jobs:
  sync-github-secrets:
    runs-on: ubuntu-latest

    steps:
      - name: GitHub Secrets Sync
        uses: finphie/GitHubSecretsSync@v0.1.0
        with:
          repository: GitHubSecretsSync
          secrets: |
            API_KEY_1
            API_KEY_2
        env:
          GITHUB_TOKEN: {{ secrets.TOKEN }}
```

### .NET tool

```shell
GitHubSecretsSync actions \
    --repository GitHubSecretsSync \
    --secrets API_KEY_1,API_KEY_2
```

## Arguments

|Argument|Required|Default|Description|
|-|-|-|-|
|repository|**true**|-|"owner/repo" format repository name.|
|secrets|**true**|-|List of GitHub Actions Secrets to be synchronized. Specify separated by commas, spaces, or newlines.|

## Environment Variables

|Argument|Required|Default|Description|
|-|-|-|-|
|GITHUB_TOKEN|**true**|-|Token with write permission to Secrets.|

## Author

finphie

## License

MIT

## Credits

This project uses the following libraries, etc.

### Libraries

- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)
- [libsodium](https://github.com/jedisct1/libsodium)

### Analyzers

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
