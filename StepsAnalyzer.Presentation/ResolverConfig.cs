using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StepsAnalyzer.Presentation.Services;
using StepsAnalyzer.Presentation.ViewModels;
using StepsAnalyzer.Interfaces;
using System;
using System.IO;
using System.Linq;
using UserDeserializer;
using UserXmlSerializer;
using UserJsonSerializer;

namespace StepsAnalyzer.Presentation
{
    public class ResolverConfig
    {
        private const string file = "appsettings.json";
        public IConfiguration ConfigurationRoot { get; }

        public ResolverConfig()
        {
            this.ConfigurationRoot = new ConfigurationBuilder()
                .SetBasePath(GetAppSettingsPath())
                .AddJsonFile(file)
                .Build();
        }

        public IServiceProvider CreateServiceProvider()
        {
            return this.ConfigurationRoot["serializationType"] switch
            {
                "XML" => new ServiceCollection()
                    .AddTransient<IUserSerializer, UserXMLSerializer>()
                    .AddTransient<IUserDeserializer>(d => new StandardUserDeserializer(this.ConfigurationRoot["deserializationPath"]))
                    .AddTransient<IDialogService, DialogService>()
                    .AddTransient<UsersViewModel>()
                    .BuildServiceProvider(),
                "JSON" => new ServiceCollection()
                    .AddTransient<IUserSerializer, UserJSONSerializer>()
                    .AddTransient<IUserDeserializer>(d => new StandardUserDeserializer(this.ConfigurationRoot["deserializationPath"]))
                    .AddTransient<IDialogService, DialogService>()
                    .AddTransient<UsersViewModel>()
                    .BuildServiceProvider(),
                _ => throw new ArgumentException("Incorrect appsettings.json"),
            };
        }

        private string GetAppSettingsPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string? projectDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName;
            if (Directory.GetFiles(currentDirectory).Any(f => Path.GetFileName(f) == file))
            {
                return currentDirectory;
            }
            else if (projectDirectory is not null && Directory.GetFiles(projectDirectory).Any(f => Path.GetFileName(f) == file))
            {
                return projectDirectory;
            }

            throw new ArgumentException("There is no appsettings.json");
        }
    }
}
