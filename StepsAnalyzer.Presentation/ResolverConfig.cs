using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StepsAnalyzer.Presentation.Services;
using StepsAnalyzer.Presentation.ViewModels;
using StepsAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDeserializer;
using UserXmlSerializer;

namespace StepsAnalyzer.Presentation
{
    public class ResolverConfig
    {
        public IConfiguration ConfigurationRoot { get; } =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

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
                _ => throw new ArgumentException("Incorrect appsettings.json"),
            };
        }
    }
}
