// Goal of this application is to update the database
// That means handle migrations AND seed data
// TODO: Research how to fucking migrate the database programmatically

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MagicDbContext;

IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("./appsettings.json", false, true);
IConfiguration config = builder.Build();

string? connString = config.GetConnectionString("magic");

if(!string.IsNullOrEmpty(connString))
{
    Seeder seeder = new Seeder(connString);
    seeder.Seed();
    Console.WriteLine("Update has finished");
}

