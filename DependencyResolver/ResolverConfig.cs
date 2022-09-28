using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StepsAnalyzer.Interfaces;
using StepsAnalyzer.ViewModels;
using UserDeserializer;
using UserXmlSerializer;

namespace DependencyResolver
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
                    .AddTransient<UsersViewModel>()
                    .BuildServiceProvider(),
                _ => throw new ArgumentException("Incorrect appsettings.json"),
            };
        }
    }
}