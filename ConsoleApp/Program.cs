using System;
using System.Reflection;
using Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(cfg => cfg.AddConsole())
                .Configure<LoggerFilterOptions>(cfg => cfg.MinLevel = LogLevel.Trace)
                .Scan(x => x.FromAssemblies(
                    Assembly.Load("Core")))
                .BuildServiceProvider();

            var simpleRegexParser = serviceProvider.GetRequiredService<SimpleRegexParser>();
            var regex = "([\\wa-zA-Z])+";
            var result = simpleRegexParser.Parse(regex);
            
            Console.WriteLine(result);
        }
    }
}