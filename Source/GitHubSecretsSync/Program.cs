using ConsoleAppFramework;
using GitHubSecretsSync;

var app = ConsoleApp.Create();

app.Add("actions", Commands.ActionsAsync);
app.Run(args);
