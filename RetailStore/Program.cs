using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace RetailStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddCommandLine(args)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Startup>();
        }

    }

    public class Student
    {
        public static StudentBuilder Builder { get; } = new StudentBuilder();
        public string Id { get; }

        public Student(string id)
        {
            Id = id;
        }

        public string Name { get; set; }
        public string Roll { get; set; }
        public string ETC { get; set; }

    }

    public class StudentBuilder
    {
        private string _name;
        private string _roll;

        public StudentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public StudentBuilder WithRollNumber(string roll)
        {
            _roll = roll;
            return this;
        }

        public Student Build()
        {
            return new Student($"{_roll}-{_name}");
        }
    }
}
