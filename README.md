# GitHubSecretsSync

[![Build(.NET)](https://github.com/finphie/GitHubSecretsSync/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/GitHubSecretsSync/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/GitHubSecretsSync?color=0078d4&label=NuGet)](https://www.nuget.org/packages/GitHubSecretsSync/)
[![Azure Artifacts]()](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSecretsSync?preferRelease=true)

GitHub Actionsのシークレットを同期するアプリケーションです。

## 説明

GitHubSecretsSyncは、GitHub Actionsのシークレット設定を行うアプリケーションです。

- [GitHubアクション](https://github.com/marketplace/actions/github-secrets-sync)
- [NuGet](https://www.nuget.org/packages/GitHubSecretsSync)
- [Azure Artifacts](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/GitHubSecretsSync?preferRelease=true)
- [バイナリ](https://github.com/finphie/GitHubSecretsSync/releases/latest)
- [Dockerイメージ](https://github.com/finphie/GitHubSecretsSync/pkgs/container/git-hub-secrets-sync)

## 使い方

### GitHubアクション

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
          actions-secrets: |
            API_KEY_1
            API_KEY_2
        env:
          GITHUB_TOKEN: {{ secrets.TOKEN }}
```

### .NETツール

```shell
GitHubSecretsSync actions \
    --repository GitHubSecretsSync \
    --secrets API_KEY_1,API_KEY_2
```

## 引数

|引数|必須|デフォルト|説明|
|-|-|-|-|
|repository|**true**|-|「オーナー名/リポジトリ名」形式のリポジトリ名。|
|secrets|**true**|-|同期するGitHub Actionsのシークレットリスト。カンマやスペース、改行区切りで指定。|

## 環境変数

|引数|必須|デフォルト|説明|
|-|-|-|-|
|GITHUB_TOKEN|**true**|-|Secretsに書き込み許可が付与されたトークン。|

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)
- [libsodium](https://github.com/jedisct1/libsodium)

### アナライザー

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)
