using Microsoft.Extensions.Configuration;

namespace PYP_Task_One.Aplication;

public static class Configuration
{
    
    static public string ConnectionString
    {
        
        get
        {
            ConfigurationManager c = new();
            c.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PYP_Task_One.WebApi"));
            c.AddJsonFile("appsettings.json");
            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory()));
            return c.GetConnectionString("Default");
        }
    }

    static public Dictionary<string, string> EmailConfiguration
    {
        get
        {
            ConfigurationManager c = new();
            c.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PYP_Task_One.WebApi"));
            c.AddJsonFile("appsettings.json");

            var config = new Dictionary<string, string>()
            {
             {"ApiKey", $"{c.GetSection("SendGrid:ApiKey").Value}"},
             {"From",$"{c.GetSection("SendGrid:From").Value}"},
            };
            return config;
        }
    }
}
